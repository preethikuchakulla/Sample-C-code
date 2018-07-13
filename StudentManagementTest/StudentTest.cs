using BusinessObject;
using BusinessService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementTest
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void CreateStudent()
        {
            var Name = "Preethi";
            var DepartmentId = 1;

            StudentDetailBS studentDetailBS = new StudentDetailBS();
            ClsStudentResult result = studentDetailBS.ProcessSave(new BusinessObject.StudentDetailBO()
            {
                Name = Name,
                DepartmentId = DepartmentId
            });
        }

        [TestMethod]
        public void DeleteStudent()
        {
            int Id = 1;
            string Name = "Preethi";
            int DepartmentId = 1;
            string DepartmentName = "Physics";

            StudentDetailBS studentDetailBS = new StudentDetailBS();
            ClsStudentResult result = studentDetailBS.ProcessRemove(new StudentDetailBO()
            {
                Id = Id,
                Name = Name,
                DepartmentId = DepartmentId,
                DepartmentName = DepartmentName
            });
        }
    }
}
