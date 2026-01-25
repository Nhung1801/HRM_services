using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Task
{
    // Thiết lập công việc lặp
    public class SettingRepeatWork : EntityBase<int>
    {
        public int RepeatWorkId { get; set; }
        public virtual RepeatWork RepeatWork { get; set; }
        public bool IsFirstRecord { get; set; }
        public SettingRepeatType SettingRepeatType { get; set; }
        public bool IsRepeatName { get; set; }
        public bool IsRepeatDescription { get; set; }
        public bool IsRepeatSubWork { get; set; }
        public bool IsRepeatFile { get; set; }
        public bool IsRepeatTag { get; set; }
        public bool IsRepeatImportant { get; set; }
        public bool IsRepeatPersonDo { get; set; }
        public bool IsRepeatPersonRelate { get; set; }
    }
    public enum SettingRepeatType
    {
        FirstRecord,
        SecoundRecord
    }
}
