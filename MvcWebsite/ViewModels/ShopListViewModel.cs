using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebsite.ViewModels
{
    public class ShopListViewModel
    {
        public List<IngredientDto> list;

        public ShopListViewModel()
        {
            list = new List<IngredientDto>();
        }
    }
}