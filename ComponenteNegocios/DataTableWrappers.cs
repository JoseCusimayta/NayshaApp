using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using ComponenteNegocios;

namespace ComponenteNegocios
{
    public class DataTableWrapper : ListSelectionWrapper<DataRow>
    {
        public DataTableWrapper(DataTable dataTable, string usePropertyAsDisplayName) : base(dataTable.Rows, false, usePropertyAsDisplayName) { }
    }
}
