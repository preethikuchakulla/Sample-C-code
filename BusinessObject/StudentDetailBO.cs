using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class StudentDetailBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class ClsStudentResult : ClsResult
    {
        public StudentDetailBO StudentBO { get; set; }
    }

    public class ClsStudentDetailResult : ClsResult
    {
        public List<StudentDetailBO> Students { get; set; }
    }
}
