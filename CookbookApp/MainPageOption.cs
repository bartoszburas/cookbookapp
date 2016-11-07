using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CookbookApp
{
    class MainPageOption : PageChain
    {
        public override Page GetPage()
        {
            ServiceReference.ServiceClient client = new ServiceReference.ServiceClient();

            try
            {
                client.GetRecipeList();
                return new MainPage();
            }
            catch (Exception)
            {
                return next.GetPage();
            }
        }
    }
}
