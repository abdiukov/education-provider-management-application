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
            App.pagesVisitedTracker.Add(pageToNavigate);
            pageToNavigate.Show();
        }

        public static void GoToExistingPage(int indexOfPage)
        {
            App.pagesVisitedTracker[indexOfPage].Visibility = Visibility.Visible;
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

        public static void CloseAndOpenPage(Window pageToCloseAndOpen)
        {
            string pageLocation = pageToCloseAndOpen.ToString();

            //searching the page
            for (int i = App.pagesVisitedTracker.Count - 1; i > 0; i--)
            {
                if (App.pagesVisitedTracker[i].ToString() == pageLocation)
                {
                    //if page is found close it, replace it, show the new page
                    App.pagesVisitedTracker[i].Close();
                    App.pagesVisitedTracker[i] = pageToCloseAndOpen;
                    pageToCloseAndOpen.Show();
                    return;
                }
            }
        }

    }
}
