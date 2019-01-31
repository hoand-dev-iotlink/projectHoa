using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModelCommon.ViewModel
{
    public class CommonParamDataTable
    {
        public int Page { get; set; } = 0;
        public int Limit { get; set; } = 0;
        public string Search { get; set; } = string.Empty;
        public string ColumOrder { get; set; } = string.Empty;
        public string OrderBy { get; set; } = string.Empty;
    }
}
