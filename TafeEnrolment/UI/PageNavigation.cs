using System.Windows;

namespace UI
{
    /// <summary>
    /// This method responsible for navigation throughout pages
    /// If the page is not hidden a new  page is created and the user is navigated to it.
    /// If the page is hidden, the page gets unhidden and the user navigates to it
    /// </summary>
    class PageNavigation
    {

        public static void GoToNewPage(Window pageToNavigate, Window currentPage)
        {
            App.pagesVisitedTracker.Add(pageToNavigate);
            pageToNavigate.Show();
            currentPage.Hide();
        }


        public static void GoToNewPage(Window pageToNavigate)
        {
            App.pagesVisitedTracker.Add(pageToNavigate);
            pageToNavigate.Show();
        }


        public static void GoToExistingPage(int indexOfPage, Window currentPage)
        {
            Window selectedPage = App.pagesVisitedTracker[indexOfPage];
            if (currentPage != selectedPage)
            {
                selectedPage.Visibility = Visibility.Visible;
                currentPage.Hide();
            }
        }

        public static void GoToExistingPage(Window pageToNavigate)
        {
            pageToNavigate.Visibility = Visibility.Visible;
        }

        public static void GoToNewOrExistingPage(Window pageToNavigate)
        {
            if (App.pagesVisitedTracker.Contains(pageToNavigate))
            {
                GoToExistingPage(pageToNavigate);
            }
            else
            {
                GoToNewPage(pageToNavigate);
            }
        }

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
