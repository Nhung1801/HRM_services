using HRM_BE.Core.Configs;
using HRM_BE.Core.Constants;
using HRM_BE.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace HRM_BE.Api.Hubs
{
    public class RemindWorkHub:Hub
    {
        private readonly HrmContext _dbcontext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RemindWorkHub(HrmContext context, IHttpContextAccessor httpContextAccessor)
        {
            _dbcontext = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task SendNotification(string userId,string message)
        {
            await Clients.User(userId).SendAsync("ReceiveRemindWorkNotification", message);
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();

            // Lấy token từ header Authorization
            var token = httpContext?.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(token))
            {
                // Ghi log nếu không tìm thấy token
                Console.WriteLine("Token is missing from Authorization header.");
                throw new UnauthorizedAccessException("Authorization token is missing.");
            }

            // Kiểm tra xem token có hợp lệ không (Có thể thêm xác thực JWT nếu cần)
            try
            {
                // Nếu bạn muốn thêm xác thực JWT, bạn có thể sử dụng token ở đây để kiểm tra tính hợp lệ
                // (Ví dụ: sử dụng JwtSecurityTokenHandler để kiểm tra token)
            }
            catch (Exception ex)
            {
                // Ghi log khi xác thực token thất bại
                Console.WriteLine($"Error validating token: {ex.Message}");
                throw new UnauthorizedAccessException("Invalid token.");
            }

            // Lấy EmployeeId từ Query String
            var employeeId = Context.User?.FindFirst("EmployeeId")?.Value;

            if (string.IsNullOrEmpty(employeeId))
            {
                throw new UnauthorizedAccessException("User is not authenticated");
            }

            // Tiến hành lưu kết nối của người dùng vào cơ sở dữ liệu
            var connectionId = Context.ConnectionId;
            try
            {
                await _dbcontext.UserConnections.AddAsync(new Core.Data.UserConnection
                {
                    EmployeeId = int.Parse(employeeId),  // Giả sử employeeId là số nguyên
                    ConnectionId = connectionId
                });
                await _dbcontext.SaveChangesAsync();
                Console.WriteLine($"User with EmployeeId {employeeId} connected successfully.");
            }
            catch (Exception ex)
            {
                // Ghi log khi có lỗi trong quá trình lưu kết nối vào cơ sở dữ liệu
                Console.WriteLine($"Error saving connection in database: {ex.Message}");
                throw;  // Ném lại lỗi sau khi ghi log
            }

            // Gọi phương thức cơ sở để hoàn tất quá trình kết nối
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var connectionId = Context.ConnectionId;

            var userConnection = await _dbcontext.UserConnections
            .FirstOrDefaultAsync(uc => uc.ConnectionId == connectionId);

            if (userConnection != null)
            {
                _dbcontext.UserConnections.Remove(userConnection);
                await _dbcontext.SaveChangesAsync();
            }
            await base.OnDisconnectedAsync(exception); 
        }
    }
}
