using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decaf.Repo
{
    public static class CustomHtmlHelper
    {
        // Test helper
        public static IHtmlContent HelloWorldHtmlString(this IHtmlHelper htmlHelper)
        {
            return new HtmlString("<strong>:)</strong>");
        }

        // sutvarko DateTime formata
        public static string FixDateFormat(this IHtmlHelper htmlHelper, DateTime date)
        {
            return date.ToShortDateString();
        }

        public static string GetSurename(this IHtmlHelper htmlHelper, IEnumerable<Models.Dizaineri> test)
        {
            Models.Dizaineri elementas = test.ElementAt(test.Count() - 2);
            return elementas.Pavardė.ToString();
        }
    }
}
