using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Framework;
using System.Web;
using Wysnan.EIMOnline.Business.Framework;
using Wysnan.EIMOnline.Common.Enum;

namespace Wysnan.EIMOnline.Business
{
    public class PersonnelAttendanceModel : GenericBusinessModel<PersonnelAttendance>, IPersonnelAttendanceModel
    {
        SystemEntity systemEntity = HttpContext.Current.Session[ConstEntity.Session_SystemEntity] as SystemEntity;

        public override IQueryable<PersonnelAttendance> List()
        {
            return base.List();
        }

        public override Result Add(PersonnelAttendance entity)
        {
            try
            {
                var perAttendanceModel = GlobalEntity.Instance.ApplicationContext.GetObject("PersonnelAttendanceModel") as IPersonnelAttendanceModel;

                var judgeAttendance = perAttendanceModel.List().Where(t => t.SecurityUserID == systemEntity.CurrentSecurityUser.ID).OrderByDescending(c => c.BeginWorkTime).FirstOrDefault();
                if (judgeAttendance != null)
                {
                    if (judgeAttendance.BeginWorkTime.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        return new Result() { Message = "已经签到过，不能再次签到。" };
                    }

                }
                entity.SecurityUserID = systemEntity.CurrentSecurityUser.ID;
                entity.BeginWorkTime = DateTime.Now.ToLocalTime();
                entity.EndWorkTime = DateTime.Now.ToLocalTime();
                entity.IsPunchCard = false;
                var dtNow = DateTime.Now;
                var dtData = Convert.ToDateTime(BusinessHelp.Lookup_GetLookup(EnumAttendanceBase.WorkStartTime).Name);
                var success = base.Add(entity);
                if (dtNow < dtData)
                {
                    success.Message = "今天迟到!";
                }

                return success;
            }
            catch (Exception ex)
            {
                return new Result() { Message = ex.Message };
            }
        }

        public Result Edit()
        {
            try
            {
                var perAttendanceModel = GlobalEntity.Instance.ApplicationContext.GetObject("PersonnelAttendanceModel") as IPersonnelAttendanceModel;
                var lookupModel = GlobalEntity.Instance.ApplicationContext.GetObject("LookupModel") as ILookupModel;

                var judgeAttendance = perAttendanceModel.List().Where(t => t.SecurityUserID == systemEntity.CurrentSecurityUser.ID).OrderByDescending(c => c.BeginWorkTime).FirstOrDefault();
                if (judgeAttendance!=null)
                {
                    judgeAttendance.EndWorkTime = DateTime.Now.ToLocalTime();
                    judgeAttendance.IsPunchCard = true;
                    var success = perAttendanceModel.Update(judgeAttendance);

                    var dtNow = DateTime.Now;
                    var dtData = Convert.ToDateTime(BusinessHelp.Lookup_GetLookup(EnumAttendanceBase.WorkEndTime).Name);
                    if (dtNow < dtData)
                    {
                        success.Message = "今天早退！";
                    }
                    return success; 
                }
                else
                {
                    return new Result() { Message = "今天还未签到。" };
                }
            }
            catch (Exception ex)
            {
                return new Result() { Message = ex.Message };
            }
        }

        public IQueryable<PersonnelAttendance> ListCombined()
        {
            throw new NotImplementedException();
        }
    }
}
