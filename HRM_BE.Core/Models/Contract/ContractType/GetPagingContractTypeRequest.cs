using HRM_BE.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Profile.ContractType
{
    public class GetPagingContractTypeRequest : PagingRequest
    {
        public string? keyWord { get; set; }
    }
}
