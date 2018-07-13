using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class DepartmentBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ClsDepartmentResult : ClsResult
    {
        public DepartmentBO departmentBO { get; set; }
    }

    public class ClsDepartmentDetailResult : ClsResult
    {
        public List<DepartmentBO> departments { get; set; }
    }
}
