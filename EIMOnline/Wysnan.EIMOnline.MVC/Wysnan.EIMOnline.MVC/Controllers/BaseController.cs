using System.Web.Mvc;
using Spring.Context;
using Spring.Context.Support;
using System;
using Wysnan.EIMOnline.IBLL;
using Wysnan.EIMOnline.Common.Framework;
using Wysnan.EIMOnline.Tool.Extensions;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using Wysnan.EIMOnline.Business.Framework;
using Wysnan.EIMOnline.Common.Framework.Enum;
using Wysnan.EIMOnline.Common.Framework.Grid.Poco;
using Wysnan.EIMOnline.Common.Framework.Grid;

namespace Wysnan.EIMOnline.MVC.Controllers
{
    public class BaseController<T, E> : Controller
        where T : class, IBusinessLogicModel<E>
        where E : ISystemBaseEntity
    {
        public T Model { get; set; }

        private Type type { get; set; }

        public BaseController()
        {
            try
            {
                IApplicationContext ctx = ContextRegistry.GetContext();

                type = typeof(E);
                string typeName = type.Name + "Model";
                Model = ctx.GetObject(typeName) as T;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region Action
        /// <summary>
        /// JqGrid列表方法
        /// </summary>
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult List(int page, int rows, string sidx, string sord, bool search, string nd, string npage, string filters)
        {
         
            string where = null;
            if (!string.IsNullOrEmpty(filters))
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(filters));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Filters));
                Filters filter = (Filters)ser.ReadObject(ms);
                try
                {
                    object obj = Enum.Parse(typeof(GridEnum), type.Name);

                    if (obj != null)
                    {
                        GridEnum gridEnum = (GridEnum)obj;
                        JqGrid grid = GlobalEntity.Instance.Cache_JqGrid.JqGrids[gridEnum];
                        var colModel = grid._ColModel;
                        foreach (var item in filter.rules)
                        {
                            if (!string.IsNullOrEmpty(item.data))
                            {
                                var fieldtype = colModel.Find(a => a.Name == item.field).Type;
                                item.type = fieldtype;
                            }
                        }
                        where = filter.ConvertToString();
                    }
                }
                catch (ArgumentException ex)
                {
                    //todo: wushuangqi
                    throw ex;
                }
            }

            var query = Model.ListJqGrid();
            if (!string.IsNullOrEmpty(where))
            {
                query = query.Where(where, null);
            }

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = 21;
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var questions = query.OrderBy(sidx + " " + sord)
              .Skip(pageIndex * pageSize)
              .Take(pageSize);

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = questions
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Properties

        //protected IApplicationContext ApplicationContext
        //{
        //    get
        //    {
        //        return ApplicationContext.Current;
        //    }
        //}

        //protected bool IsAuthenticated
        //{
        //    get
        //    {
        //        return ApplicationContext.IsAuthenticated;
        //    }
        //}

        #endregion

        #region Methods

        public bool Permission()
        {
            return false;
        }

        //protected override void HandleUnknownAction(string actionName)
        //{
        //    var notFoundController = WebHelper.Mvc.GetNotFoundController(RouteData, Request);
        //    var errorController = notFoundController as ErrorController;
        //    if (errorController == null) return;
        //    var actionResult = errorController.NotFound(Request.Url.OriginalString);
        //    actionResult.ExecuteResult(ControllerContext);
        //}


        #endregion


    }
}
