using Controller;
using System.Collections.Generic;
using System.Windows;

namespace View
{
    /// <summary>
    /// Contains static methods accessible by the entire application
    /// </summary>
    public partial class App : Application
    {
        //pagesVisitedTracker is a tracker that contains pages that the user opened.
        public static List<Window> pagesVisitedTracker = new List<Window>();

        //Logic.cs is the controller for this application
        public static Logic logic;

    }
}
