using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;

namespace Wysnan.EIMOnline.IBLL
{
    public interface IEmailServiceModel : ISystemBaseEntity
    {
        Result SendEmail(string title, string body, EmailService emailService);
    }
}
