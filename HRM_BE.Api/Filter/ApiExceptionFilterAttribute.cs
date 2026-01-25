using AutoMapper;
using HRM_BE.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.RegularExpressions;

namespace HRM_BE.Api.Filter
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {

        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        /// <summary>
        ///     ctor
        /// </summary>
        public ApiExceptionFilterAttribute()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(EntityNotFoundException), HandleNotFoundException },
                { typeof(EntityAlreadyExistsException), HandleBadRequestException },
                {typeof (BadHttpRequestException), HandleBadRequestException}
            };
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Log.Error(context.Exception, "Handling exception:");

            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }
            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            ProblemDetails details = new ProblemDetails
            {

                Status = StatusCodes.Status500InternalServerError,
                Title = "Đã xảy ra lỗi khi xử lý yêu cầu của bạn.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"

            };

            if (context.Exception is DbUpdateException dbUpdateException)
            {
                // Kiểm tra nếu lỗi là do vi phạm foreign key
                if (dbUpdateException.InnerException is SqlException sqlException)
                {
                    if (sqlException.Number == 547) // Lỗi liên quan đến ràng buộc foreign key
                    {
                        // Tìm kiếm thông báo lỗi trong Message của SqlException
                        var errorMessage = sqlException.Message;

                        // Trích xuất tên bảng và tên trường từ thông báo lỗi SQL
                        var (tableName, columnName) = ExtractConflictTableAndColumn(errorMessage);

                        details.Title = "Vi phạm ràng buộc khóa ngoại.";
                        details.Detail = $"Giá trị của trường liên kết không tồn tại trong bảng tham chiếu. Lỗi liên quan đến bảng: {tableName}, trường: {columnName}";

                        details.Instance = errorMessage;


                    }
                }
            }
            // Kiểm tra nếu ngoại lệ là AutoMapperMappingException
            if (context.Exception is AutoMapperMappingException mappingException)
            {
                // Lấy thông báo lỗi chính
                var errorMessage = mappingException.Message;

                // Kiểm tra nội dung lỗi bên trong InnerException nếu có
                if (mappingException.InnerException != null)
                {
                    errorMessage += $" | Inner Exception: {mappingException.InnerException.Message}";
                }

                // Trích xuất thông tin kiểu nguồn và đích nếu có
                var sourceType = mappingException.Types?.GetType().GetProperty("SourceType")?.GetValue(mappingException.Types, null)?.ToString() ?? "Unknown Source Type";
                var destinationType = mappingException.Types?.GetType().GetProperty("DestinationType")?.GetValue(mappingException.Types, null)?.ToString() ?? "Unknown Destination Type";

                // Ghi thông tin vào chi tiết lỗi
                details.Title = "Lỗi ánh xạ dữ liệu.";
                details.Detail = $"Lỗi khi ánh xạ dữ liệu từ nguồn đến đích. | #Loại nguồn#: {sourceType}, #loại đích#: {destinationType}.";
                //details.Instance = context.Exception.StackTrace; // Bao gồm stack trace để hỗ trợ debug
            }

            // Gắn kết quả phản hồi lỗi vào context
            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;


        }
        // Phương thức trích xuất tên bảng và tên trường từ thông báo lỗi
        private (string tableName, string columnName) ExtractConflictTableAndColumn(string errorMessage)
        {
            // Ví dụ thông báo lỗi SQL Server có thể là:
            // "The DELETE statement conflicted with the REFERENCE constraint "FK_InfoJobs_JobType_JobTypeId". The conflict occurred in database "HRM", table "dbo.JobType", column 'Id'."

            // Sử dụng một biểu thức chính quy để tìm kiếm tên bảng và tên trường
            var tableNameMatch = Regex.Match(errorMessage, @"table\s""dbo.([\w\.]+)""");
            var columnNameMatch = Regex.Match(errorMessage, @"column\s'(\w+)'");

            // Trả về tên bảng và tên trường nếu tìm thấy, ngược lại trả về thông báo "Unknown"
            string tableName = tableNameMatch.Success ? tableNameMatch.Groups[1].Value : "Unknown Table";
            string columnName = columnNameMatch.Success ? columnNameMatch.Groups[1].Value : "Unknown Column";

            return (tableName, columnName);
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            ValidationProblemDetails details = new ValidationProblemDetails(context.ModelState)
            {
                Title = "Đã xảy ra một hoặc nhiều lỗi xác thực",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            //context.Result = new BadRequestObjectResult(details);
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);


            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            EntityNotFoundException exception = context.Exception as EntityNotFoundException;

            ProblemDetails details = new ProblemDetails()
            {

                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "Không tìm thấy tài nguyên được chỉ định.",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleAlreadyExistsException(ExceptionContext context)
        {
            EntityAlreadyExistsException exception = context.Exception as EntityAlreadyExistsException;

            ProblemDetails details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "Tài nguyên được chỉ định đã tồn tại.",
                Detail = exception.Message
            };

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }
        private void HandleBadRequestException(ExceptionContext context)
        {
            var exception = context.Exception;

            ProblemDetails details = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Tham số không hợp lệ ",
                Detail = exception.Message
            };

            context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
