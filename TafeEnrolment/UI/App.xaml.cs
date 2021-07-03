using ModelLayer;
using System.Collections.Generic;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //pagesVisitedTracker is a tracker that contains pages that the user opened.
        public static List<Window> pagesVisitedTracker = new List<Window>();

        public static readonly Logic logic = new Logic();

        //private void Application_Deactivated(object sender, System.EventArgs e)
        //{
        //    //Task.Delay(30000).ContinueWith(t => CheckIfAppIsClosed());
        //}

        //private void CheckIfAppIsClosed()
        //{
        //    foreach (var item in pagesVisitedTracker)
        //    {
        //        if (item.IsVisible == true)
        //        {
        //            return;
        //        }
        //    }
        //    Environment.Exit(0);
        //}

    }
}
