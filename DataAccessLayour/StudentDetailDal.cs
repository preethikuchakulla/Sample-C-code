using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayour
{
    public class StudentDetailDal
    {
        StudentEntities studentEntities;
        ClsStudentResult result;

        public StudentDetailDal()
        {
            studentEntities = new DataAccessLayour.StudentEntities();
            result = new ClsStudentResult() { Success = true };
        }

        public ClsStudentResult ProcessSave(StudentDetailBO studentDetailBO)
        {
            result.StudentBO = studentDetailBO;
            try
            {
                studentEntities.StudentDetails.Add(new StudentDetail()
                {
                    Name = studentDetailBO.Name,
                    DepartmentId = studentDetailBO.DepartmentId
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

        public ClsStudentResult ProcessRemove(StudentDetailBO studentDetailBO)
        {
            result.StudentBO = studentDetailBO;
            try
            {
                StudentDetail Student = studentEntities.StudentDetails.Where(x => x.Id == studentDetailBO.Id).FirstOrDefault();

                studentEntities.StudentDetails.Remove(Student);
                studentEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorDesc = ex.Message;
            }

            return result;
        }

        public ClsStudentDetailResult ProcessRead()
        {
            ClsStudentDetailResult detailResult = new ClsStudentDetailResult();
            detailResult.Success = true;
            try
            {
                detailResult.Students = (from T1 in studentEntities.StudentDetails
                                         join T2 in studentEntities.Departments on T1.DepartmentId equals T2.Id
                                         select new StudentDetailBO()
                                         {
                                             Id = T1.Id,
                                             Name = T1.Name,
                                             DepartmentId = T2.Id,
                                             DepartmentName = T2.Name
                                         }).ToList<StudentDetailBO>();

            }
            catch (Exception ex)
            {
                detailResult.Success = false;
                detailResult.ErrorDesc = ex.Message;
            }

            return detailResult;
        }

        public ClsStudentDetailResult ProcessRead(StudentDetailBO studentDetailBO)
        {
            ClsStudentDetailResult detailResult = new ClsStudentDetailResult();
            detailResult.Success = true;
            try
            {
                detailResult.Students = (from T1 in studentEntities.StudentDetails
                                         join T2 in studentEntities.Departments on T1.DepartmentId equals T2.Id
                                         where T1.Id == studentDetailBO.Id
                                         select new StudentDetailBO()
                                         {
                                             Id = T1.Id,
                                             Name = T1.Name,
                                             DepartmentId = T2.Id,
                                             DepartmentName = T2.Name
                                         }).ToList<StudentDetailBO>();

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
