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
            if (currentDocumentName.Length > 0)
            {
                XmlNode page_tag = breadcrumbs_document_xml.CreateElement("Page");
                root.AppendChild(page_tag);

                ((XmlElement)page_tag).SetAttribute("Location", currentDocumentName);

                breadcrumbs_document_xml.Save("Breadcrumbs.xml");
            }
        }


        //END OF "ADD AN ITEM" SECTION OF CODE

        //START OF "REMOVE AN ITEM" SECTION OF CODE

        public void RemoveItem(int index_to_remove)
        {
            //selecting the item that is to be removed
            root.RemoveChild(root.ChildNodes[index_to_remove]);

            //saving the file
            breadcrumbs_document_xml.Save("Breadcrumbs.xml");
        }

        //END OF "REMOVE AN ITEM" SECTION OF CODE


        //START OF "OUTPUT" SECTION OF CODE

        public override string ToString()
        {
            //output string
            string output_string = "";

            //every item gets formatted in a certain way
            foreach (XmlNode output_node in root.ChildNodes)
            {
                output_string += output_node.Attributes["Location"].Value+ "/";
            }
            //removing the last '/' and outputting
            return output_string.Substring(0, output_string.Length - 1);
        }

        //END OF "OUTPUT" SECTION OF CODE


    }



}