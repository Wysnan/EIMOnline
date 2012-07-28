using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
//using System.Web.
namespace Wysnan.EIMOnline.MVC.Tool.MvcExpand
{
    public static class ControllerExpand
    {
        #region Alert

        public static ActionResult Alert(this Controller controller, string message, AlertAction alertAction = AlertAction.None, MessageType messageType = MessageType.Ok, string script = null)
        {
            string str = Alert(message, null, null, null, script, messageType, alertAction);
            ContentResult result = new ContentResult();
            result.Content = str;
            return result;
        }

        public static ActionResult Alert(this Controller controller, string message, string actionName, string controllerName = null, string areaName = null, AlertAction alertAction = AlertAction.None, MessageType messageType = MessageType.Ok, string script = null)
        {
            if (!string.IsNullOrEmpty(actionName))
            {
                if (string.IsNullOrEmpty(controllerName))
                {
                    controllerName = controller.RouteData.Values["controller"] as string;
                }
                if (string.IsNullOrEmpty(areaName))
                {
                    areaName = controller.RouteData.Values["area"] as string;
                }
            }
            string str = Alert(message, areaName, controllerName, actionName, script, messageType, alertAction);
            ContentResult result = new ContentResult();
            result.Content = str;
            return result;
        }

        private static string Alert(string message, string area, string controller, string action, string script = null, MessageType messageType = MessageType.Ok, AlertAction alertAction = AlertAction.None)
        {
            StringBuilder messageStr = new StringBuilder();
            messageStr.Append("<script>");
            messageStr.Append("$(function () {$(\"#dialog:ui-dialog\" ).dialog(\"destroy\");");
            messageStr.Append("$(\"#dialog-message\").dialog({autoOpen: true, modal: true");
            switch (messageType)
            {
                case MessageType.Ok:
                    messageStr.Append(", buttons: {Ok: function() {");
                    if (!string.IsNullOrEmpty(controller))
                    {
                        if (controller.IndexOf("Controller") > 0)
                        {
                            controller = controller.Replace("Controller", "");
                        }
                        if (string.IsNullOrEmpty(area))
                        {
                            messageStr.AppendFormat("window.location.href=\"/{0}/{1}\";", controller, action);
                        }
                        else
                        {
                            messageStr.AppendFormat("window.location.href=\"/{0}/{1}/{2}\";", area, controller, action);
                        }
                    }
                    messageStr.Append("$(this).dialog( \"close\" );}}");
                    messageStr.Append("refresh();");
                    messageStr.Append("}}");

                    break;
                case MessageType.YesOrNo:
                    messageStr.Append(",buttons:{\"Yes\": function(){");
                    messageStr.Append("$(this).dialog( \"close\");},");
                    messageStr.Append("Cancel:function(){$(this).dialog(\"close\" );}}");
                    break;
            }
            messageStr.Append("});});");
            if (!string.IsNullOrEmpty(script))
            {
                messageStr.Append(script);
            }
            switch (alertAction)
            {
                case AlertAction.CloseCurrentWindow:
                    messageStr.Append("GlobalObj.RemovePage(GlobalObj.currentPage)");
                    break;
            }
            messageStr.Append("</script>");
            messageStr.Append("<div id=\"dialog-message\" title=\"提示\" style=\"display:none\">");
            messageStr.AppendFormat("<p>{0}</p>", message);
            messageStr.Append("</div>");
            return messageStr.ToString();
        }

        #endregion

        #region Redirect

        public static ActionResult RedirectUrl(this Controller controller, string actionName, string controllerName = null, string area = null)
        {
            if (area == null)
            {
                area = controller.RouteData.Values["area"] as string;
            }
            if (controllerName == null)
            {
                controllerName = controller.RouteData.Values["controller"] as string;
            }
            string url = (area == null ? "" : "/" + area) + string.Format("/{0}/{1}", controllerName, actionName);
            string javascript = string.Format("window.location.href='{0}'", url);
            return new JavaScriptResult() { Script = javascript };
        }

        #endregion
    }

    public class Message
    {
        public Message()
        {

        }

        public Message(string message, string controller, string action, MessageType messageType)
        {
            this.Msg = message;
            this.Controller = controller;
            this.Action = action;
            this.MessageType = messageType;
        }

        public string Msg { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        private MessageType type = MessageType.Ok;
        public MessageType MessageType { get { return type; } set { type = value; } }
    }

    public enum MessageType
    {
        Ok,
        YesOrNo
    }

    public enum AlertAction
    {
        None,
        CloseCurrentWindow
    }
}
