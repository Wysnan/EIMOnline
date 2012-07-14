using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.IBLL;

namespace Wysnan.EIMOnline.Business
{
    public class EmailServiceModel : IEmailServiceModel
    {
        public Common.Framework.Result SendEmail(string title, string body, Common.Poco.EmailService emailService)
        {
            throw new NotImplementedException();
        }
    }
}
