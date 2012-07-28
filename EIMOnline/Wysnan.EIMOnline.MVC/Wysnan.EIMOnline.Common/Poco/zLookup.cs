using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Wysnan.EIMOnline.Common.Enum;
namespace Wysnan.EIMOnline.Common.Poco
{
    [Table("zMetaLookup")]
    public class Lookup : IBaseEntity
    {
        public Lookup() { }

        public Lookup(string name, LookupCodeEnum code, dynamic enumCode)
        {
            this.Name = name;
            this.Code = code.ToString();

            string type = enumCode.GetType().Name;
            string value = enumCode.ToString();
            this.EnumCode = type + "." + value;
        }


        public int ID { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte? SystemStatus { get; set; }

        public byte[] TimeStamp { get; set; }

        /// <summary>
        /// Lookup Name
        /// </summary>
        [StringLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// 分组标识
        /// </summary>
        [StringLength(30)]
        public string Code { get; set; }

        /// <summary>
        /// 枚举值
        /// </summary>
        [StringLength(50)]
        public string EnumCode { get; set; }

        public virtual ICollection<SecurityUser> SecurityUsers1 { get; set; }
        public virtual ICollection<SecurityUser> SecurityUsers2 { get; set; }
        public virtual ICollection<SecurityUser> SecurityUsers3 { get; set; }
        public virtual ICollection<SecurityUser> SecurityUsers4 { get; set; }
        public virtual ICollection<SecurityUser> SecurityUsers5 { get; set; }

    }
}
