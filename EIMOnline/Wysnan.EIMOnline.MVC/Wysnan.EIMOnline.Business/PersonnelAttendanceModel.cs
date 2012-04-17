using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;

namespace Wysnan.EIMOnline.Business
{
    public class PersonnelAttendanceModel : GenericBusinessModel<PersonnelAttendance>, IPersonnelAttendanceModel
    {
        public IQueryable<PersonnelAttendance> ListCombined()
        {
            //PersonnelAttendance pa = new PersonnelAttendance();
            //return Model.Add(pa);
            return null;
        }
    }
}
