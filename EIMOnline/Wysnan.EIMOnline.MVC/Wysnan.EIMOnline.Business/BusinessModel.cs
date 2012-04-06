using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.IDAL;

namespace Wysnan.EIMOnline.Business
{
    public class BusinessModel
    {
        public BusinessModel()
        {
            var aa = Model;
            //IApplicationContext ctx = ContextRegistry.GetContext();
            //Model = ctx.GetObject("EntityFrameworkModel") as IModel;
        }
        protected IModel Model { get; set; }
    }
}
