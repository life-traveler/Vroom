using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vroom.Extensions
{
    public static class IEnumerableExtensions
    {
        //GENERIC METHOD TO CONVERT LIST OF OBJECTS TO SELECTLISTITEM I.E. IEnumerable<Make>  TO  IEnumerable<SelectListItem>
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> Items)
        {
            //variable of list of selectlistitem
            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "---Select---",
                Value = "0"
            };
            List.Add(sli);
            foreach (var item in Items)
            {
                sli = new SelectListItem
                {
                    Text = item.GetPropertyValue("Name"),
                Value = item.GetPropertyValue("Id")               
                };
                List.Add(sli);
            }
            return List;
        }

    }
}
