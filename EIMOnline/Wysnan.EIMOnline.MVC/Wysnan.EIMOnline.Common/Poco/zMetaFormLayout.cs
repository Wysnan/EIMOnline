using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Wysnan.EIMOnline.Common.Poco
{
    /// <summary>
    /// 页面显示辅助类
    /// </summary>
    public class zMetaFormLayout : IBaseEntity
    {
        public int ID { get; set; }
        public string EntityName { get; set; }
        public string EntityField { get; set; }
        public string ShortLabel { get; set; }
        public string LongLabel { get; set; }

        public bool IsVisible { get; set; }
        public string ReferenceEntity { get; set; }
        public int SortNum { get; set; }
        public string ReferenceEntityUrl { get; set; }
        public string Brief { get; set; }

        public byte? SystemStatus { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}
