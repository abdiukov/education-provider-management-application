using System.Windows;

namespace View
{
    /// <summary>
    /// This method responsible for navigation throughout pages
    /// If the page is not hidden a new  page is created and the user is navigated to it.
    /// If the page is hidden, the page gets unhidden and the user navigates to it
    /// </summary>
    class PageNavigation
    {
        /// <summary>
        /// Go to new page, hide current page
        /// </summary>
        public static void GoToNewPage(Window pageToNavigate, Window currentPage)
        {
            App.pagesVisitedTracker.Add(pageToNavigate);
            pageToNavigate.Show();
            currentPage.Hide();
        }

        /// <summary>
        /// Go to new page by index, hide current page. If index is 0, the page is Main Menu
        /// </summary>
        public static void GoToExistingPage(int indexOfPage, Window currentPage)
        {
            Window selectedPage = App.pagesVisitedTracker[indexOfPage];
            if (currentPage != selectedPage)
            {
                selectedPage.Visibility = Visibility.Visible;
                currentPage.Hide();
            }
        }

        /// <summary>
        /// Go to page that already exists in App.pagesVisitedTracker, hide current page
        /// </summary>
        public static void GoToExistingPage(Window pageToNavigate, Window currentPage)
        {
            pageToNavigate.Visibility = Visibility.Visible;
            currentPage.Hide();
        }

        /// <summary>
        /// Not sure whether the page exists, so to avoid duplicates, we check all pages. If it doesn't exist, we open a new one. If it does - we open it.
        /// </summary>
        public static void GoToNewOrExistingPage(Window pageToNavigate, Window currentPage)
        {
            bool pageExists = false;

            foreach (var item in App.pagesVisitedTracker)
            {
                if (pageToNavigate.Title == item.Title)
                {
                    pageExists = true;
                    pageToNavigate = item;
                }
            }

            if (pageExists)
            {
                GoToExistingPage(pageToNavigate, currentPage);
            }
            else
            {
                GoToNewPage(pageToNavigate, currentPage);
            }
        }

        /// <summary>
        /// Closes all pages except main page. Is triggered when the main page is opened.
        /// </summary>
        public static void ClearAllPagesExceptMain()
        {
            for (int i = App.pagesVisitedTracker.Count - 1; i > 0; i--)
            {
                App.pagesVisitedTracker[i].Close();
                App.pagesVisitedTracker.RemoveAt(i);
            }
        }


    }
}
