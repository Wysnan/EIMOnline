using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;

namespace Wysnan.EIMOnline.Common.ViewModel
{
    public class CombinedPersonnelAttendance : ICombined
    {
        public PersonnelAttendance PersonnelAttendance { get; set; }
        public SecurityUser SecurityUser { get; set; }
    }
}
