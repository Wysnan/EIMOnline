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
    [CodeAttribute("Code:RBMT")]
    public class ReimbursementType : IBaseEntity
    {
        public int ID { get; set; }
        public byte? SystemStatus { get; set; }
        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        /// <summary>
        /// 报销类型编号
        /// </summary>
        [StringLength(10)]
        [Display(Name = "编号")]
        [Required(ErrorMessage = "{0}必填")]
        public string Code { get; set; }

        /// <summary>
        /// 报销类型
        /// </summary>
        [StringLength(50)]
        [Display(Name = "报销类型")]
        [Required(ErrorMessage = "{0}必填")]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(200, ErrorMessage = "{0}信息内容不能超过200")]
        [Display(Name = "描述")]
        public string Description { get; set; }

        #region ICollection

        public ICollection<Reimbursement> Reimbursements { get; set; }

        #endregion
    }
}