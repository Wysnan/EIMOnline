using System.Web.Mvc;
using Spring.Context;
using Spring.Context.Support;
using System;

namespace Wysnan.EIMOnline.MVC.Controllers
{
    public class BaseController<T, E> : Controller where T : class
    {
        public T Model { get; set; }

        public BaseController()
        {
            try
            {

                IApplicationContext ctx = ContextRegistry.GetContext();

                Type type = typeof(E);
                string typeName = type.Name + "Model";
                Model = ctx.GetObject(typeName) as T;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


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
