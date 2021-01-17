using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo5.UsersClass
{
    public class Producto : ICloneable
    {

        public String tipo { set; get; }
        public String marca { set; get; }
        public String precio { set; get; }
        public String stock { set; get; }
        public DateTime fechaAlta { set; get; }

        public Producto(string tipo,string marca,string precio,string stock,DateTime fechaAlta)
        {
            this.tipo = tipo;
            this.marca = marca;
            this.precio = precio;
            this.stock = stock;
            this.fechaAlta = DateTime.Now;
           
        }
        public Producto()
        {
            this.tipo = "";
            this.marca = "";
            this.precio = "";
            this.stock = "";
            this.fechaAlta = DateTime.Now;
        }

        public override string ToString()
        {
            return tipo;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
