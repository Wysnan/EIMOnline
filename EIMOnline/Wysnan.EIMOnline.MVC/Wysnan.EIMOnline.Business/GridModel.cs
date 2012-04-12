using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework.Grid.POCO;
using Wysnan.EIMOnline.Common.Framework.Enum;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Business.Framework;

namespace Wysnan.EIMOnline.Business
{
    public sealed class GridModel
    {
        static readonly GridModel instance = new GridModel();

        public static GridModel Instance
        {
            get { return instance; }
        }

        private GridModel()
        {
            JqGrids = new Dictionary<GridEnum, JqGrid>();

            this.JqGrids[GridEnum.SecurityUser] = GetSecurityUserConfig();
        }

        public Dictionary<GridEnum, JqGrid> JqGrids { get; set; }

        private JqGrid GetSecurityUserConfig()
        {
            JqGridConfig<SecurityUser, SecurityUser> grid = new JqGridConfig<SecurityUser, SecurityUser>()
            {
                RowNum = 10,
                SortName = "ID",
                SortOrder = "desc",
            };
            var columns = new GridColumnCollection()
            {
                new JqGridColumnTextBox(){
                    Label="编号",
                    Name=grid.Path(a=>a.ID)
                },
                new JqGridColumnTextBox(){
                    Label="姓名",
                    Name=grid.Path(a=>a.UserName)
                },
                new JqGridColumnTextBox(){
                    Label="账号",
                    Name=grid.Path(a=>a.UserLoginID)
                },
                new JqGridColumnTextBox(){
                    Label="密码",
                    Name=grid.Path(a=>a.UserLoginPwd)
                }
            };
            grid.GridColumnCollection= columns;
            grid.DataBind();
            return grid;
        }
    }
}
