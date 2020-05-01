using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTWebAPI.Models
{
    public class DataTableParams
    {
        public int start { get; set; }
        public int length { get; set; }
        public string searchValue { get; set; }
        public int totalRows { get; set; }
        public int totalRowsAfterfiltering { get; set; }
        public int draw { get; set; }

    }
}
