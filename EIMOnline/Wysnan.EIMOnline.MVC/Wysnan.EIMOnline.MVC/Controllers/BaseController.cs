﻿using System.Web.Mvc;
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

                //type = typeof(E);
                //string typeName = type.Name + "Controller";
                //Model = GlobalEntity.Instance.ApplicationContext.GetObject(typeName) as T;
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

        public ActionResult View(int id)
        {
            var entity = Model.Get(id);
            if (entity != null)
            {
                ViewBag.entity = entity;
            }
            else
            {
                throw new ArgumentException("未检索到对象");
            }

            zMetaFormLayoutModel zMetaFormLayoutModel = new Business.zMetaFormLayoutModel();
            IList<zMetaFormLayout> ViewLayout = zMetaFormLayoutModel.List().Where(t => t.EntityName == type.Name).ToList();
            if (ViewLayout != null && ViewLayout.Count > 0)
            {
                ViewBag.ViewLayout = ViewLayout;
            }
            else
            {
                throw new ArgumentException("没有找到配置表");
            }

            return PartialView("~/Views/Shared/_DetailView.cshtml");

            // 直接跳转到区域中的View页面
            // return View();
        }
    }
}
