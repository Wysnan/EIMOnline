using System.Collections.Generic;
using Wysnan.EIMOnline.Common.Framework.Grid;
using Wysnan.EIMOnline.Common.Poco;
using Wysnan.EIMOnline.Common.Framework.Grid.JqGridColumn;
using Wysnan.EIMOnline.Common.Framework.Enum;
using Wysnan.EIMOnline.Common.Framework.Grid.Poco;

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
                    NameAndType=grid.Path(a=>a.ID)
                },
                new JqGridColumnTextBox(){
                    Label="姓名",
                    NameAndType=grid.Path(a=>a.UserName)
                },
                new JqGridColumnTextBox(){
                    Label="账号",
                    NameAndType=grid.Path(a=>a.UserLoginID)
                },
                new JqGridColumnTextBox(){
                    Label="密码",
                    NameAndType=grid.Path(a=>a.UserLoginPwd),
                },
                new JqGridColumnTextBox(){
                    Label="创建时间",
                    NameAndType=grid.Path(a=>a.CreatedOn),
                }
            };
            grid.GridColumnCollection = columns;
            grid.DataBind();
            return grid;
        }
    }
}
