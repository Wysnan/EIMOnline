using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Wysnan.EIMOnline.Common.Framework.Attributes;
using Wysnan.EIMOnline.Common.Enum;

namespace Wysnan.EIMOnline.Common.Poco
{
    [CodeAttribute("Code:USER")]
    public class SecurityUser : IBaseEntity
    {
        public int ID { get; set; }

        public byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public DateTime CreatedOn { get; set; }
       
        public int? CreatedByUserID { get; set; }

        public int? ModifiedByUserID { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual SecurityUser CreatedByUser { get; set; }

        public virtual SecurityUser ModifiedByUser { get; set; }

        /// <summary>
        /// 职工编号
        /// </summary>
        [StringLength(10)]
        [Display(Name = "职工编号")]
        [Required(ErrorMessage="{0}必填")]
        public string Code { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        [Display(Name = "中文名称")]
        [StringLength(10)]
        [RegularExpression("^[a-zA-Z0-9_\u4E00-\u9FA5]*$", ErrorMessage = "只能是汉字、数字、字母、下划线")]
        [Required(ErrorMessage="{0}必填")]
        public string UserName { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        [Display(Name = "英文名称")]
        [StringLength(15)]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "只能是数字、字母、下划线")]
        public string UserNameEn { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        [Display(Name = "账号")]
        [StringLength(15)]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "只能是数字、字母、下划线")]
        [Required(ErrorMessage="{0}必填")]
        public string UserLoginID { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [StringLength(15)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "只能是数字、字母")]
        [Required(ErrorMessage="{0}必填")]
        public string UserLoginPwd { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        [Required(ErrorMessage="{0}必填")]
        [LookupAttribute(LookupCodeEnum.EnumSex)]
        public int Sex { get; set; }

        public virtual Lookup LookupSex { get; set; }

        /// <summary>
        /// 国籍
        /// </summary>
        [Display(Name = "国际")]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z0-9\u4E00-\u9FA5]*$", ErrorMessage = "只能是汉字、数字、字母")]
        [Required(ErrorMessage="{0}必填")]
        public string Country { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        [Display(Name = "出生地")]
        [StringLength(30)]
        [Required(ErrorMessage="{0}必填")]
        public string Birthplace { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>
        [Display(Name = "出生年月")]
        [Required(ErrorMessage="{0}必填")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        [Display(Name = "证件号")]
        [StringLength(30)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "只能是数字、字母")]
        [Required(ErrorMessage="{0}必填")]
        public string CertificateNo { get; set; }

        /// <summary>
        /// 固定电话
        /// </summary>
        [Display(Name = "固定电话")]
        [StringLength(15)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "只能是数字")]
        [Required(ErrorMessage="{0}必填")]
        public string Phone { get; set; }

        /// <summary>
        /// 邮件地址
        /// </summary>
        [Display(Name = "邮件地址")]
        [StringLength(30)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "请输入正确的邮件地址。")]
        [Required(ErrorMessage="{0}必填")]
        public string Email { get; set; }

        /// <summary>
        /// 紧急联系人
        /// </summary>
        [Display(Name = "紧急联系人")]
        [StringLength(20)]
        [RegularExpression("^[a-zA-Z0-9\u4E00-\u9FA5]*$", ErrorMessage = "只能是汉字、数字、字母")]
        [Required(ErrorMessage="{0}必填")]
        public string UrgentName { get; set; }

        /// <summary>
        /// 紧急联系人电话
        /// </summary>
        [Display(Name = "紧急联系人电话")]
        [StringLength(20)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "只能是数字")]
        [Required(ErrorMessage="{0}必填")]
        public string UrgentPhone { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Display(Name = "手机")]
        [StringLength(20)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0}只能是数字")]
        [Required(ErrorMessage="{0}必填")] 
        public string Mobile { get; set; }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        [Display(Name = "婚姻状况")]
        [LookupAttribute(LookupCodeEnum.EnumMarriageStatus)]
        public int? MarriageStatusID { get; set; }

        public virtual Lookup MarriageStatus { get; set; }

        /// <summary>
        /// 家庭地址
        /// </summary>
        [Display(Name = "家庭地址")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z0-9\u4E00-\u9FA5]*$", ErrorMessage = "只能是汉字、数字、字母")]
        public string HomeAddress { get; set; }

        /// <summary>
        /// 文化程度
        /// </summary>
        [Display(Name = "文化程度")] 
        [LookupAttribute(LookupCodeEnum.EnumCultureStatus)]
        public int? CultureStatusID { get; set; }

        public virtual Lookup CultureStatus { get; set; }

        /// <summary>
        /// 毕业院校
        /// </summary>
        [Display(Name = "毕业院校")]
        [StringLength(25)]
        [RegularExpression("^[a-zA-Z0-9\u4E00-\u9FA5]*$", ErrorMessage = "只能是汉字、数字、字母")]
        public string EducationalInstitute { get; set; }

        /// <summary>
        /// 主修专业
        /// </summary>
        [Display(Name = "主修专业")]
        [StringLength(25)]
        [RegularExpression("^[a-zA-Z0-9\u4E00-\u9FA5]*$", ErrorMessage = "只能是汉字、数字、字母")] 
        public string Professional { get; set; }

        /// <summary>
        /// 毕业时间
        /// </summary>
        [Display(Name = "毕业时间")]
        public DateTime? GraduationTime { get; set; }

        /// <summary>
        /// 职工类别
        /// </summary>
        [Display(Name = "职工类别")]
        [LookupAttribute(LookupCodeEnum.EnumStaffCategory)]
        public int StaffCategoryID { get; set; }

        public virtual Lookup StaffCategory { get; set; }

        /// <summary>
        /// 简历附件
        /// </summary>
        [Display(Name = "简历附件")]
        [StringLength(400)]
        public string Resume { get; set; }

        /// <summary>
        /// 账号状态
        /// </summary>
        [Display(Name = "账号状态")] 
        [LookupAttribute(LookupCodeEnum.EnumAccountStatus)]
        public int StatusID { get; set; }

        public virtual Lookup Status { get; set; }

        /// <summary>
        /// 年假天数
        /// </summary>
        [Display(Name = "年假天数")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "只能是数字")] 
        public int VacationDays { get; set; }

        /// <summary>
        /// 剩余年假天数
        /// </summary>
        [Display(Name = "剩余年假天数")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "只能是数字")]  
        public int RemainingVacationDays { get; set; }

        public virtual ICollection<OperateLog> OperateLogs { get; set; }
        public virtual ICollection<SecurityUserRole> SecurityUserRoles { get; set; }
        public virtual ICollection<PersonnelAttendance> PersonnelAttendances { get; set; }

        public virtual ICollection<SecurityUser> SecurityUsers1 { get; set; }
        public virtual ICollection<SecurityUser> SecurityUsers2 { get; set; }

    }
}
