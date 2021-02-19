using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class BreadcrumbsData
    {
        public BreadcrumbsData(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;set;
        }
    }
}
