using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Common.Framework
{
    /// <summary>
    /// 返回结果类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Result
    {
        #region fild

        private string message;

        private bool resultStatus = true;

        private string messageCode;

        #endregion

        #region property

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                ResultStatus = false;
            }
        }

        public bool ResultStatus
        {
            get { return resultStatus; }
            private set { resultStatus = value; }
        }

        public string MessageCode
        {
            set
            {
                messageCode = value;
                SetMessageCode();
            }
        }

        public string[] Params
        {
            get;
            set;
        }

        #endregion

        #region method

        private void SetMessageCode()
        {

        }

        #endregion
    }
}
