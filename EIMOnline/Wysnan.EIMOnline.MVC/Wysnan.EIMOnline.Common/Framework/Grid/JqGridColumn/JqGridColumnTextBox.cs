using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid.Interfaces;
using Wysnan.EIMOnline.Common.Framework.Grid.Enum;
using System.Text.RegularExpressions;

namespace Wysnan.EIMOnline.Common.Framework.Grid.JqGridColumn
{
    public class JqGridColumnTextBox : IJqGridColumn
    {
        #region 字段

        private GridColumnAlign align = GridColumnAlign.center;
        private string nameAndType = string.Empty;

        #endregion

        #region 属性

        /// <summary>
        /// label名称
        /// </summary>
        public string Label { get; set; }

        public GridColumnAlign Align
        {
            get { return align; }
            set { align = value; }
        }

        /// <summary>
        /// 只读，不可配置
        /// </summary>
        public string Name { get; private set; }

        public string NameAndType
        {
            get { return nameAndType; }
            set
            {
                nameAndType = value;
                string pattern = @"\[((Name:)|(Type:))(\w+\.?\w+)\]";
                var matchCollection = Regex.Matches(value, pattern);

                if (matchCollection != null && matchCollection.Count == 2)
                {
                    Match matchName = matchCollection[0]; //匹配[Name:\w+]
                    Match matchType = matchCollection[1]; //匹配[Type:\w+]

                    if (matchName.Groups.Count == 5)
                    {
                        string nameValue = matchName.Groups[4].Value;   //得到第5组的值\w+
                        if (!string.IsNullOrEmpty(nameValue))
                        {
                            this.Name = nameValue;
                        }
                    }
                    if (matchType.Groups.Count == 5)
                    {
                        string typeValue = matchType.Groups[4].Value;   //得到第5组的值\w+
                        if (!string.IsNullOrEmpty(typeValue))
                        {
                            this.Type = typeValue;
                        }
                    }
                }
                else
                {
                    throw new ApplicationException("GirdModel配置出错：" + value);
                }
            }
        }

        /// <summary>
        /// 只读，不可配置
        /// </summary>
        public string Type { get; private set; }
        #endregion

    }
}
