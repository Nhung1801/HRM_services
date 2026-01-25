using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Comment
{
    public class GetCommentRequest : PagingRequest
    {
        public int WorkId { get; set; }

    }
}
