using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Exceptions
{
    public class EntityNotFoundException: Exception
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        { }

        public EntityNotFoundException(string name, object key)
            : base($"Đối tượng {name} có giá trị {key} không tồn tại.")
        {
        }
    }
}
