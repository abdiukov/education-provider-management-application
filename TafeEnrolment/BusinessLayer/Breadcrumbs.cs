using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace BusinessLayer
{
    /// <summary>
    /// The class is responsible for tracking user activity
    /// </summary>
    public class Breadcrumbs
    {

        //START OF DEFFINING THE GLOBAL VALUES THAT WILL BE USED BY THE WHOLE PROGRAM

        XmlDocument breadcrumbs_document_xml = new XmlDocument();
        XmlNode root;

        //the name of the document is retrieved from consturctor
        private string currentDocumentName;

        //END OF DEFINING THE GLOBAL VAUES THAT WILL BE USED BY THE WHILE PROGRAM

        public Breadcrumbs(string currentDocumentName)
        {
            //if it is the main window, then clear breadcrumbs
            if (currentDocumentName == "MainWindow")
            {
                File.Delete("Breadcrumbs.xml");
                root = breadcrumbs_document_xml.CreateElement("root");
                breadcrumbs_document_xml.AppendChild(root);
                breadcrumbs_document_xml.Save("Breadcrumbs.xml");
            }
            else
            {
                breadcrumbs_document_xml.Load("Breadcrumbs.xml");
                root = breadcrumbs_document_xml.FirstChild;
            }
            this.currentDocumentName = currentDocumentName;

            //adding the item to breadcrumbs
            AddItem();
        }

        //START OF "ADD AN ITEM" SECTION OF CODE

        private void AddItem()
        {
            XmlElement page_tag = breadcrumbs_document_xml.CreateElement("Page");
            root.AppendChild(page_tag);

            page_tag.SetAttribute("Location", currentDocumentName);

            breadcrumbs_document_xml.Save("Breadcrumbs.xml");
        }


        //END OF "ADD AN ITEM" SECTION OF CODE

        //START OF "REMOVE AN ITEM" SECTION OF CODE

        public static void RemoveItem(string PageLocation)
        {
            XmlDocument breadcrumbs_document_xml = new XmlDocument();
            breadcrumbs_document_xml.Load("Breadcrumbs.xml");

            XmlNode root = breadcrumbs_document_xml.FirstChild;

            foreach (XmlNode item in root.ChildNodes)
            {
                if (item.Attributes["Location"].Value == PageLocation)
                {
                    //removing the index
                    root.RemoveChild(item);

                    //saving the file
                    breadcrumbs_document_xml.Save("Breadcrumbs.xml");
                    //exiting
                    return;
                }
            }
        }

        //END OF "REMOVE AN ITEM" SECTION OF CODE


        //START OF "OUTPUT" SECTION OF CODE

        public List<BreadcrumbsData> GetListOfPagesVisited()
        {
            //output string
            List<BreadcrumbsData> output_string = new List<BreadcrumbsData>();

            //every item gets formatted in a certain way
            foreach (XmlNode output_node in root.ChildNodes)
            {
                output_string.Add(new BreadcrumbsData(output_node.Attributes["Location"].Value));
            }
            // outputting
            return output_string;
        }

        //END OF "OUTPUT" SECTION OF CODE
    }
}