using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Tag
{
    public class GetTagPagingRequest:PagingRequest
    {
        public string? KeyWord;
    }
}
