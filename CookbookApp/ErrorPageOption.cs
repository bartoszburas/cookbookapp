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
