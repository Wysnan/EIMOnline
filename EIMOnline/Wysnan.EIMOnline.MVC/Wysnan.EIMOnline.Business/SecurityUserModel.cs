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
using Wysnan.EIMOnline.Business.Framework;
using System.Web;

namespace Wysnan.EIMOnline.Business
{
    public class SecurityUserModel : GenericBusinessModel<SecurityUser>, ISecurityUser
    {
        public SecurityUserModel()
        {
        }

        [TransactionAttribute]
        public override IQueryable<SecurityUser> List()
        {
            return base.List();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Result Login(SecurityUser user)
        {
            Result r = new Result();
            if (user == null)
            {
                r.Message = GlobalEntity.Instance.Cache_Message.GetMessge("1");
            }
            var entity = List().Where(a => a.UserLoginID.Equals(user.UserLoginID, StringComparison.CurrentCultureIgnoreCase) &&
                a.UserLoginPwd.Equals(user.UserLoginPwd, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            if (entity == null)
            {
                r.Message = GlobalEntity.Instance.Cache_Message.GetMessge("7");
            }
            r.ResultObject = entity;
            return r;
        }

        public override Result Add(SecurityUser t)
        {
            SystemEntity systemEntity = HttpContext.Current.Session[ConstEntity.Session_SystemEntity] as SystemEntity;
            if (systemEntity != null)
            {
                t.CreatedByUserID = systemEntity.CurrentSecurityUser.ID;
                t.CreatedOn = DateTime.Now;
                t.ModifiedByUserID = systemEntity.CurrentSecurityUser.ID;
                t.ModifiedOn = DateTime.Now;
            }
            return base.Add(t);
        }

        public override Result Update(SecurityUser t)
        {
            SystemEntity systemEntity = HttpContext.Current.Session[ConstEntity.Session_SystemEntity] as SystemEntity;
            if (systemEntity != null)
            {
                t.ModifiedByUserID = systemEntity.CurrentSecurityUser.ID;
                t.ModifiedOn = DateTime.Now;
            }
            return base.Update(t);
        }
    }
}
