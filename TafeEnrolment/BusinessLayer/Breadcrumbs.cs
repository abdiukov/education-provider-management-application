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
        XmlNode DocumentName;

        //the name of the document is retrieved from consturctor
        private string currentDocumentName;

        //END OF DEFINING THE GLOBAL VAUES THAT WILL BE USED BY THE WHILE PROGRAM

        public void Initialise()
        {
            //CHECKING WHETHER THE XML FILE EXISTS
            //IF THE XML FILE DOESNT EXIST, A NEW ONE IS CREATED
            //ALSO THE VALUE OF ROOT IS ASSIGNED

            switch (File.Exists("Breadcrumbs.xml"))
            {

                case true:
                    breadcrumbs_document_xml.Load("Breadcrumbs.xml");
                    root = breadcrumbs_document_xml.FirstChild;
                    break;
                case false:
                    root = breadcrumbs_document_xml.CreateElement("root");
                    breadcrumbs_document_xml.AppendChild(root);
                    breadcrumbs_document_xml.Save("Breadcrumbs.xml");
                    break;
            }
        }


        public Breadcrumbs(string currentDocumentName)
        {
            this.currentDocumentName = currentDocumentName;
            Initialise();
        }


        public void AddItem()
        {
            if (currentDocumentName.Length > 0)
            {
                XmlNode doc_tag = breadcrumbs_document_xml.CreateElement("doc");
                root.AppendChild(doc_tag);

                //creating the xml tags, where the textbox input will be stored
                DocumentName = breadcrumbs_document_xml.CreateElement("Name");
                DocumentName.InnerText = currentDocumentName;
                doc_tag.AppendChild(DocumentName);

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

        public override string ToString()
        {
            //output string
            string output_string = "";

            //every item gets formatted in a certain way
            foreach (XmlNode output_node in root.ChildNodes)
            {
                output_string += output_node.SelectSingleNode("Name") + "/";
            }
            //removing the last '/'
            return output_string.Substring(0, output_string.Length - 1);
        }

    }



}