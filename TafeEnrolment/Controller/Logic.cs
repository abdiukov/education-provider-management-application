using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
namespace Controller
{
    public class Logic
    {
        private readonly Control control;
        /// <summary>
        /// The consturctor links to the Control.cs in the Model Layer
        /// </summary>
        public Logic()
        {
           this.control = new Control();
        }


    }
}
