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
using System.Collections.Generic;
using System.Linq;
using Wysnan.EIMOnline.Tool.JqGridExtansions;
using Wysnan.EIMOnline.Common.Poco;
using System.Web.Routing;
using Wysnan.EIMOnline.Business;
using System.Web;

namespace Wysnan.EIMOnline.MVC.Controllers
{
    public class BaseController<T, E> : GeneralController
        where T : class, IBusinessLogicModel<E>
        where E : ISystemBaseEntity
    {

        #region Properties
        public T Model { get; set; }

        #endregion
        private Type type { get; set; }

        public BaseController()
        {
            try
            {
                type = typeof(E);
                string typeName = type.Name + "Model";
                Model = GlobalEntity.Instance.ApplicationContext.GetObject(typeName) as T;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SystemEntity.CurrentSecurityUser == null)
            {
                filterContext.Result = new RedirectToRouteResult("Default",
                    new RouteValueDictionary{
                        { "controller", "Index" },
                        { "action", "Login" }
                });
                return;
            }
            base.OnActionExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            //页面输出脚本，判断是否包含主框架页面，如果不包含，则跳转到首页，跳转路径如：index/index/#当前请求页面。
            //最终由总框架页面（js代码）判断是否有--#请求页面--，如果有的话，则在首页跳转请求页面。
            bool isAjax = filterContext.HttpContext.Request.IsAjaxRequest();
            if (!isAjax)
            {
                filterContext.HttpContext.Response.Output.Write("<script>var div_all = document.getElementById('div_all');if (div_all == null) {window.location.href = '/#' + window.location.href;}</script>");
            }
            //设置当前Area
            var routingValues = RouteTable.Routes.GetRouteData(new HttpContextWrapper(System.Web.HttpContext.Current)).Values;
            this.SystemEntity.CurrentArea = (string)routingValues["area"] ?? string.Empty;
        }

        #region Action

        /// <summary>
        /// JqGrid列表方法
        /// </summary>        
        [HttpGet]
        [ValidateInput(false)]
        public ActionResult List(int page, int rows, string sidx, string sord, bool search, string nd, string npage, string filters)
        {
            //cb_ID_UserName_UserLoginID_UserLoginPwd_CreatedOn
            #region 转换查询条件为Filters类
            Filters filter = null;
            if (!string.IsNullOrEmpty(filters))
            {
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(filters));
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Filters));
                filter = (Filters)ser.ReadObject(ms);
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
                            if (item.data != null)
                            {
                                var fieldtype = colModel.Find(a => a.Name == item.field).Type;
                                item.type = fieldtype;
                            }
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    //todo: wushuangqi
                    throw ex;
                }
            }
            #endregion

            #region 获取查询列

            string showFiled = Request["showFiled"];

            #endregion

            var query = Model.List().Select(showFiled);
            var query_totalRecords = Model.List().Select(showFiled);

            //添加条件
            query = filter.ConvertToIQueryable(query);
            query_totalRecords = filter.ConvertToIQueryable(query_totalRecords);

            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = query_totalRecords.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var questions = query.OrderBy(sidx + " " + sord)
              .Skip(pageIndex * pageSize)
              .Take(pageSize);

            //var d = questions.GetEnumerator();
            //while (d.MoveNext())
            //{
            //    object obj = d.Current;
            //}

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = questions
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ValidateInput(false)]
        public void SetJqGridColumn(string colModel)
        {
            if (!string.IsNullOrEmpty(colModel))
            {
                string[] colModels = colModel.Split('_');
                if (colModel != null)
                {
                    object obj = Enum.Parse(typeof(GridEnum), type.Name);
                    if (obj != null)
                    {
                        GridEnum gridEnum = (GridEnum)obj;
                        JqGrid grid = GlobalEntity.Instance.Cache_JqGrid.JqGrids[gridEnum];
                        if (grid != null)
                        {
                            var query = grid._ColModel.Where(a => colModels.Contains(a.Name));
                            if (query != null)
                            {
                                var models = query.ToList();
                                foreach (var item in models)
                                {
                                    item.Hidden = true;
                                }

                                grid.WriteCookie(gridEnum);
                            }
                        }
                    }
                }
            }
        }
        #endregion



        #region Privte Methods

        #endregion
        public E PartialView(int id)
        {
            var entity = Model.Get(id);
            if (entity == null)
            {
                throw new ArgumentException("未检索到对象");
            }

            IzMetaFormLayout zMetaFormLayoutModel = GlobalEntity.Instance.ApplicationContext.GetObject("zMetaFormLayoutModel") as IzMetaFormLayout;
            IList<zMetaFormLayout> ViewLayout = zMetaFormLayoutModel.List().Where(t => t.EntityName == type.Name).OrderBy(t => t.SortNum).ToList();
            if (ViewLayout != null && ViewLayout.Count > 0)
            {
                ViewBag.ViewLayout = ViewLayout;
            }
            else
            {
                throw new ArgumentException("没有找到配置表");
            }

            ViewBag.View = entity;
            return entity;
            //return PartialView("~/Views/Shared/_DetailView.cshtml",entity);

            // 直接跳转到区域中的View页面
            // return View();
        }
    }
}
