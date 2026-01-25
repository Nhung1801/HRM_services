//using HRM_BE.Data;
//using Microsoft.AspNetCore.SignalR;

//namespace HRM_BE.Api.Hubs
//{
//    public class NotifyHub
//    {
//    }
//}
//using HRM_BE.Data;
//using Microsoft.AspNetCore.SignalR;
//using Microsoft.EntityFrameworkCore;

//namespace HRM_BE.Api.Hubs
//{
//    public class RemindWorkHub : Hub
//    {
//        private readonly HrmContext _dbcontext;
//        public RemindWorkHub(HrmContext context)
//        {
//            _dbcontext = context;
//        }
//        public async Task SendNotification(string userId, string message)
//        {
//            await Clients.User(userId).SendAsync("ReceiveRemindWorkNotification", message);
//        }

//        public override async Task OnConnectedAsync()
//        {
//            var connectionId = Context.ConnectionId;

//            var employeeId = Context.User?.FindFirst("EmployeeId")?.Value;
//            if (string.IsNullOrEmpty(employeeId))
//            {
//                throw new UnauthorizedAccessException("User is not authenticated");
//            }
//            await _dbcontext.UserConnections.AddAsync(new Core.Data.UserConnection
//            {
//                EmployeeId = int.Parse(employeeId),
//                ConnectionId = connectionId
//            });
//            await _dbcontext.SaveChangesAsync();
//            await base.OnConnectedAsync();
//        }
//        public override async Task OnDisconnectedAsync(Exception? exception)
//        {
//            var connectionId = Context.ConnectionId;

//            var userConnection = await _dbcontext.UserConnections
//            .FirstOrDefaultAsync(uc => uc.ConnectionId == connectionId);

//            if (userConnection != null)
//            {
//                _dbcontext.UserConnections.Remove(userConnection);
//                await _dbcontext.SaveChangesAsync();
//            }
//            await base.OnDisconnectedAsync(exception);
//        }
//    }
//}
