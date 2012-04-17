using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.Common.Poco
{
    public class ErrorInfo : ISystemBaseEntity
    {
        public string Title { get; set; }

        public string Domain { get; set; }

        public string DetailError { get; set; }

        public DateTime TimeOfOccurrence { get; set; }

        public string Url { get; set; }
    }
}
