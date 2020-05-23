using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Bai9_QLThongTinSV.HTMLHelpers
{
    public static class CustomHelpers
    {
        public static MvcHtmlString DateTime(this HtmlHelper html, DateTime value)
        {
            TagBuilder tag = new TagBuilder("input");

            tag.MergeAttribute("type", "date");

            string day = "";

            if (value.Day < 10)
            {
                day = "0" + value.Day.ToString();
            }
            else
            {
                day = value.Day.ToString();
            }

            string month = "";

            if (value.Day < 10)
            {
                month = "0" + value.Month.ToString();
            }
            else
            {
                month = value.Month.ToString();
            }

            string year = value.Year.ToString();

            tag.MergeAttribute("value",year + "-" + month + "-" + day);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}