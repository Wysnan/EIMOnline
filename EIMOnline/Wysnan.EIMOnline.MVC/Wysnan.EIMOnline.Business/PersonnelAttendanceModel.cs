using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.Business
{
    public class PersonnelAttendanceModel : GenericBusinessModel<PersonnelAttendance>, IPersonnelAttendanceModel
    {
        public override IQueryable<PersonnelAttendance> List()
        {
            return base.List();
        }

        public override Result Add(PersonnelAttendance t)
        {
            return Model.Add(t);
        }

        public IQueryable<PersonnelAttendance> ListCombined()
        {
            throw new NotImplementedException();
        }
    }
}
