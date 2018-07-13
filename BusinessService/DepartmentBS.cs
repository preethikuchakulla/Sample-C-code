using BusinessObject;
using DataAccessLayour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class DepartmentBS
    {
        DepartmentDal deparmentDal;
        public DepartmentBS()
        {
            deparmentDal = new DepartmentDal();
        }

        public ClsDepartmentResult ProcessSave(DepartmentBO departmentBO)
        {
            return deparmentDal.ProcessSave(departmentBO);
        }

        public ClsDepartmentResult ProcessRemove(DepartmentBO departmentBO)
        {
            return deparmentDal.ProcessRemove(departmentBO);
        }

        public ClsDepartmentDetailResult ProcessRead()
        {
            return deparmentDal.ProcessRead();
        }

        public ClsDepartmentDetailResult ProcessRead(DepartmentBO deparmentBO)
        {
            return deparmentDal.ProcessRead(deparmentBO);
        }
    }
}
