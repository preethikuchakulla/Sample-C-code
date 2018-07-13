using BusinessObject;
using DataAccessLayour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class StudentDetailBS
    {
        StudentDetailDal deparmentDal;
        public StudentDetailBS()
        {
            deparmentDal = new StudentDetailDal();
        }

        public ClsStudentResult ProcessSave(StudentDetailBO studentDetailBO)
        {
            return deparmentDal.ProcessSave(studentDetailBO);
        }

        public ClsStudentResult ProcessRemove(StudentDetailBO studentDetailBO)
        {
            return deparmentDal.ProcessRemove(studentDetailBO);
        }

        public ClsStudentDetailResult ProcessRead()
        {
            return deparmentDal.ProcessRead();
        }

        public ClsStudentDetailResult ProcessRead(StudentDetailBO studentDetailBO)
        {
            return deparmentDal.ProcessRead(studentDetailBO);
        }
    }
}
