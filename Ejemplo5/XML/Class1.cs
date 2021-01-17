using Ejemplo5.UsersClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ejemplo5.XML
{
    class Class1
    {
        private static XDocument xml;
        private static Producto producto;
        private static XElement xmlCategoria;

        private static void LoadXMl() { xml = XDocument.Load("../../XML/XMLFile1.xml"); }
        private static void saveXML() 
        {
            xml.Save("../../XML/XMLFile1.xml");
        }

       

        private static void AddCategoria(Producto p /*String category*/) 
        {
            var listaCAtegorias = xml.Root.Elements("tipo").Attributes("idTipo");
            bool isNewCategory = true;
            foreach (XAttribute categoria in listaCAtegorias)
            {
                if (categoria.Value.Equals(p.stock))
                {
                    xmlCategoria = categoria.Parent;
                    isNewCategory = false;
                    break;
                }
                else
                {
                    xmlCategoria = new XElement("tipo", new XAttribute("idTipo",p.stock /*category*/));
                   
                    isNewCategory = true;
                }
            }
            if (isNewCategory) { xml.Root.Add(xmlCategoria); }
        }
        public static void addXMLProduct(Producto p)
        {
            producto = p;
            LoadXMl();
            AddCategoria();
            saveXML();
        }


    }
}
