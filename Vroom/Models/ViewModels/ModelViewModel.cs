using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Vroom.Models.ViewModels
{
    public class ModelViewModel
    {
        //type of model
        public Model Model { get; set; }

        //display the list of makes in the dropdown on views page
        public IEnumerable<Make> Makes { get; set; }
        
        //convert <selectlist> to <selectlistitem>
       public IEnumerable<SelectListItem> selectListItems(IEnumerable<Make>Items)
        {
            //variable of list of selectlistitem
            List<SelectListItem> MakeList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "---Select---",
                Value = "0"
            };
            MakeList.Add(sli);
            foreach  (Make make in Items)
            {
                sli = new SelectListItem
                {
                    Text = make.Name,
                    Value =make.Id.ToString()
                };
                MakeList.Add(sli);
            }
            return MakeList;
        }

    }
}



   