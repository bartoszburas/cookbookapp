using System.Windows.Controls;

namespace CookbookApp
{
    abstract class PageChain
    {
        protected PageChain next;

        public abstract Page GetPage();
        public void SetNext(PageChain next)
        {
            this.next = next;
        }
    }
}