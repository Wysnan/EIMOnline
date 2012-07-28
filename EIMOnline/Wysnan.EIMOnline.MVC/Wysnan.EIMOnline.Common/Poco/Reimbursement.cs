using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Wysnan.EIMOnline.Common.Framework.Attributes;
using Wysnan.EIMOnline.Common.Enum;

namespace Wysnan.EIMOnline.Common.Poco
{
    /// <summary>
    /// 报销类型Model
    /// </summary>
    [CodeAttribute("Code:RBM")]
    public class Reimbursement : IBaseEntity
    {
        public int ID { get; set; }
        public byte? SystemStatus { get; set; }
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        /// <summary>
        /// 报销编号
        /// </summary>
        [StringLength(10)]
        [Display(Name = "编号")]
        [Required(ErrorMessage = "{0}必填")]
        public string Code { get; set; }

        /// <summary>
        /// 报销类型
        /// </summary>
        [StringLength(10)]
        [Display(Name = "报销类型")]
        [Required(ErrorMessage = "{0}必填")]
        public int TypeCode { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        [StringLength(10)]
        [Display(Name = "申请人")]
        [Required(ErrorMessage = "{0}必填")]
        public int ApplicantID { get; set; }

        /// <summary>
        /// 审批人 
        /// </summary>
        [StringLength(10)]
        [Display(Name = "审批人")]
        [Required(ErrorMessage = "{0}必填")]
        public int ApproverID { get; set; }


        /// <summary>
        /// 审批状态
        /// </summary>
        [StringLength(10)]
        [Display(Name = "审批状态")]
        [Required(ErrorMessage = "{0}必填")]
        public int ApproveStatusID { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>
        [StringLength(5)]
        [Display(Name = "审批意见")]
        public int Notes { get; set; }

        /// <summary>
        /// 审批结果
        /// </summary>
        [StringLength(5)]
        [Display(Name = "审批结果")]
        public Nullable<int> ApproveResultID { get; set; }

        /// <summary>
        /// 财务审批意见
        /// </summary>
        [StringLength(5)]
        [Display(Name = "财务审批意见")]
        public int FinanceNotes { get; set; }

        /// <summary>
        /// 财务审批结果
        /// </summary>
        [StringLength(5)]
        [Display(Name = "财务审批结果")]
        public Nullable<int> FinanceApproveResultID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        [Display(Name = "备注")]
        public string Remark { get; set; }

        #region Reference
        
        public virtual Lookup ApproverStatus { get; set; }
        public virtual Lookup ApproverResult { get; set; }
        public virtual Lookup FinanceApproverResult { get; set; }
        public virtual ReimbursementType ReimbursementType { get; set; }
        public virtual SecurityUser SecurityUserApplicant { get; set; }
        public virtual SecurityUser SecurityUserApprover { get; set; }

        #endregion
    }
}
