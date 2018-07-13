using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayour
{
    public class DepartmentDal
    {
        StudentEntities studentEntities;
        ClsDepartmentResult result;

        public DepartmentDal()
        {
            studentEntities = new DataAccessLayour.StudentEntities();
            result = new ClsDepartmentResult() { Success = true };
        }

        public ClsDepartmentResult ProcessSave(DepartmentBO departmentBO)
        {
            result.departmentBO = departmentBO;
            try
            {
                studentEntities.Departments.Add(new Department()
                {
                    Name = departmentBO.Name
                });

                studentEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorDesc = ex.Message;
            }

            return result;
        }

        public ClsDepartmentResult ProcessRemove(DepartmentBO departmentBO)
        {
            result.departmentBO = departmentBO;
            try
            {
                Department department = studentEntities.Departments.Where(x => x.Id == departmentBO.Id).FirstOrDefault();

                studentEntities.Departments.Remove(department);
                studentEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorDesc = ex.Message;
            }

            return result;
        }

        public ClsDepartmentDetailResult ProcessRead()
        {
            ClsDepartmentDetailResult detailResult = new ClsDepartmentDetailResult();
            detailResult.Success = true;
            try
            {
                detailResult.departments = (from T1 in studentEntities.Departments
                                            select new DepartmentBO() { Id = T1.Id, Name = T1.Name }).ToList<DepartmentBO>();

            }
            catch (Exception ex)
            {
                detailResult.Success = false;
                detailResult.ErrorDesc = ex.Message;
            }

            return detailResult;
        }

        public ClsDepartmentDetailResult ProcessRead(DepartmentBO deparmentBO)
        {
            ClsDepartmentDetailResult detailResult = new ClsDepartmentDetailResult();
            detailResult.Success = true;
            try
            {
                detailResult.departments = (from T1 in studentEntities.Departments
                                            where T1.Id == deparmentBO.Id
                                            select new DepartmentBO() { Id = T1.Id, Name = T1.Name }).ToList<DepartmentBO>();

            }
            catch (Exception ex)
            {
                detailResult.Success = false;
                detailResult.ErrorDesc = ex.Message;
            }

            return detailResult;
        }
    }
}
