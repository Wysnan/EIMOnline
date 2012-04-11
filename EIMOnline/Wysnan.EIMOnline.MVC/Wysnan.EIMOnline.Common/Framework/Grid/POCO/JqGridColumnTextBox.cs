using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid.Interfaces;
using Wysnan.EIMOnline.Common.Framework.Grid.Enum;

namespace Wysnan.EIMOnline.Common.Framework.Grid.POCO
{
    public class JqGridColumnTextBox : IJqGridColumn
    {
        #region 字段

        private GridColumnAlign align = GridColumnAlign.center;

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

        public string Name { get; set; }

        #endregion
    }
}
