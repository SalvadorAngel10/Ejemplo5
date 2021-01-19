using Ejemplo5.UsersClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static XElement xmlModelo;

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
                if (categoria.Value.Equals(p.tipo))
                {
                    xmlCategoria = categoria.Parent;
                    isNewCategory = false;
                    break;
                }
                else
                {
                    xmlCategoria = new XElement("tipo", new XAttribute("idTipo",p.tipo /*category*/));
                    xmlModelo = new XElement("modelo", new XAttribute("nombre", producto.marca));
                    isNewCategory = true;
                }
            }
            if (isNewCategory) 
            {
                xmlCategoria.Add(xmlModelo);
                xml.Root.Add(xmlCategoria); 
            }
        }
        public static void addXMLProduct(Producto p)
        {
            producto = p;
            LoadXMl();
            AddCategoria(p);
            addModelo();
            crearProducto();
            saveXML();
        }

        private static void addModelo() 
        {
            bool isNewModelo = true;
            foreach (XAttribute modelo in xmlCategoria.Elements().Attributes("nombre")) 
            {
                if (modelo.Value.Equals(producto.marca))
                {
                    xmlModelo = modelo.Parent;
                    isNewModelo = false;
                    break;
                }
                else 
                {
                    xmlModelo = new XElement("modelo", new XAttribute("nombre",producto.marca));
                    isNewModelo = true;
                }
            }
            if (isNewModelo) { xmlCategoria.Add(xmlModelo); }  
        }

        private static void crearProducto() 
        {
            XElement xmlProducto = new XElement("Producto", new XAttribute("Precio", producto.precio),
                new XAttribute("Stock",producto.stock),new XAttribute("Fecha",producto.fechaAlta));
            xmlModelo.Add(xmlProducto);
        }

        public static ObservableCollection<Producto> LoadProductos() 
        {
            ObservableCollection<Producto> productiList = new ObservableCollection<Producto>();
            LoadXMl();
            var listaProductos = xml.Root.Elements("tipo").Elements("modelo").Elements("Producto");
            foreach (XElement productoxml in listaProductos) 
            {
                producto = new Producto();
                producto.precio = productoxml.Attribute("Precio").Value;
                producto.stock = productoxml.Attribute("Stock").Value;
                DateTime.Parse(productoxml.Attribute("Fecha").Value);
                // producto.fechaAlta = productoxml.Attribute("Fecha").Value;
                producto.marca = productoxml.Parent.Attribute("nombre").Value;
                producto.tipo = productoxml.Parent.Parent.Attribute("idTipo").Value;
                productiList.Add(producto);

            }
            return productiList;
        }

           
    }

    public class ObservarProducto<T>
    {
    }
}
