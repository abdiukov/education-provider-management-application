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

        public static void GoToNewPage(Window pageToNavigate)
        {
            MainWindow.pagesVisitedTracker.Add(pageToNavigate);
            pageToNavigate.Show();
        }

        public static void GoToExistingPage(int indexOfPage)
        {
            MainWindow.pagesVisitedTracker[indexOfPage].Visibility = Visibility.Visible;
        }

        public static void GoToNewOrExistingPage(Window pageToNavigate)
        {

            if (MainWindow.pagesVisitedTracker.Contains(pageToNavigate))
            {
                pageToNavigate.Visibility = Visibility.Visible;
            }
            else
            {
                GoToNewPage(pageToNavigate);
            }
        }

        public static void ClearAllPagesExceptMain()
        {
            for (int i = 1; i < MainWindow.pagesVisitedTracker.Count; i++)
            {
                MainWindow.pagesVisitedTracker[i].Close();
                MainWindow.pagesVisitedTracker.RemoveAt(i);
            }
        }
    }
}
