namespace HRM_BE.Core.Models.SumaryTimeSheet
{
    /// <summary>
    /// Request dùng cho API export Excel (không phân trang).
    /// </summary>
    public class GetSummarySheetWorkWithEmployeeExportRequest
    {
        public int Id { get; set; }
        public required int OrganizationId { get; set; }
        public string? KeyWord { get; set; }
        public int? StaffPositionId { get; set; }

        /// <summary>
        /// Tên cột muốn sort (ví dụ: Id, LastName, FirstName...)
        /// </summary>
        public string? OrderBy { get; set; }

        /// <summary>
        /// Kiểu sort (Asc/Desc)
        /// </summary>
        public string? SortBy { get; set; }
    }
}

