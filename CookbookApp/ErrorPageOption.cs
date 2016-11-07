using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CookbookApp
{
    class ErrorPageOption : PageChain
    {
        public override Page GetPage()
        {
            return new ErrorPage();
        }
    }
}
