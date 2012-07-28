using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wysnan.EIMOnline.Common.Framework.Grid.Poco
{
    public class SearchOptions
    {
        public SearchOptions()
        {
            this.Attr = new Attr();
            this.DataInit = string.Empty;
            this.SearchHidden = true;
        }

        public string DataInit { get; set; }

        public Attr Attr { get; set; }

        public string Sopt { get; set; }

        public bool SearchHidden { get; set; }


        public override string ToString()
        {//searchoptions: {dataInit:datePick,attr:{title:'选择日期'},sopt:['eq','ne','gt','ge','le','lt'],searchhidden:false}");
            string value = string.Empty;
            string dataInit = string.Empty;

            if (!string.IsNullOrEmpty(DataInit))
            {
                dataInit = "dataInit:" + DataInit + ",";
            }


            value = string.Format("{0}{1} sopt:[{2}],searchhidden:{3}{4}", "{", dataInit, Sopt, SearchHidden.ToString().ToLower(), "}");
            return value;
        }
    }

    public class Attr
    {
        public Attr()
        {
            this.Title = string.Empty;
        }

        public string Title { get; set; }

        public override string ToString()
        {
            string value = string.Empty;
            value = string.Format(" {0}title:'{1}'  {2}", "{", Title, "}");
            return value;
        }
    }
}
