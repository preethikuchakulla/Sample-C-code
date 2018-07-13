using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessService;
using BusinessObject;

namespace StudentManagementTest
{
    [TestClass]
    public class DepartmentTest
    {
        [TestMethod]
        public void CreateDepartment()
        {
            var Name = "Physics";
            DepartmentBS departmentBS = new DepartmentBS();
            ClsDepartmentResult result = departmentBS.ProcessSave(new DepartmentBO()
            {
                Name = Name
            });
        }

        [TestMethod]
        public void DeleteDepartment()
        {
            int Id = 1;
            string name = "Physics";

            DepartmentBS departmentBS = new DepartmentBS();
            ClsDepartmentResult result = departmentBS.ProcessRemove(new DepartmentBO()
            {
                Id = Id,
                Name = name
            });
        }
    }
}
