using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModelCommon.ViewModel
{
    public class JQueryDataTableParamModel
    {
        /// <summary>
        /// Request sequence number sent by DataTable, same value must be returned in response
        /// </summary>       
        public string SEcho { get; set; }

        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string SSearch { get; set; }
        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string SSearchValue1 { get; set; }
        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string SSearchValue2 { get; set; }
        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string SSearchValue3 { get; set; }

        /// <summary>
        /// Text used for filtering date
        /// </summary>
        public string SDateForm { get; set; }

        /// <summary>
        /// Text used for filtering date
        /// </summary>
        public string SDateTo { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int IDisplayLength { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int IDisplayStart { get; set; }

        /// <summary>
        /// Number of columns in table
        /// </summary>
        public int IColumns { get; set; }

        /// <summary>
        /// Number of columns that are used in sorting
        /// </summary>
        public int ISortingCols { get; set; }

        /// <summary>
        /// Comma separated list of column names
        /// </summary>
        public string SColumns { get; set; }

        /// <summary>
        ///  order column
        /// </summary>
        public int ISortCol_0 { get; set; }

        /// <summary>
        /// order type
        /// </summary>
        public string SSortDir_0 { get; set; }
    }
}
