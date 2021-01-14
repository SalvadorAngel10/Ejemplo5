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


        private static void LoadXMl() { xml = XDocument.Load("../../XML/XMLFile1.xml"); }

        public static void addXMLProduct(Producto p)
        {
            producto = p;
            LoadXMl();
        }

        private static void AddCategoria() 
        {

        }

    }
}
