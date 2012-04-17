using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Injection.Transaction;
using Wysnan.EIMOnline.Common.Framework.Grid.JqGridColumn;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Common.ViewModel;
using System.Linq.Expressions;
using Wysnan.EIMOnline.Tool.Extensions;
using Wysnan.EIMOnline.Injection.Logs;

namespace Wysnan.EIMOnline.Business
{
    public class SecurityUserModel : GenericBusinessModel<SecurityUser>, ISecurityUser
    {
        public SecurityUserModel()
        {
        }

        [TransactionAttribute]
        [OperateLog]
        public override IQueryable<SecurityUser> List()
        {
            return base.List();
        }

        public override IQueryable ListJqGrid()
        {
            var query = Model.List<SecurityUser>();

            //var temp = query.Select(selector);
            var temp = query.Select("New(ID, UserName,UserLoginID,UserLoginPwd,CreatedOn)");
            //var aa = temp.GetEnumerator();

            //Type type = temp.ElementType;//获取类型
            //var id = type.GetProperty("id");//获取属性

            //////循环访问
            //while (aa.MoveNext())
            //{
            //    var current = aa.Current;

            //    var val = id.GetValue(current, null);
            //}

            return temp;
        }

        public IQueryable<CombinedSecurityUser> ListCombined()
        {
            throw new NotImplementedException();
        }
    }
}
