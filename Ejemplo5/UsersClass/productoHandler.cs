using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo5.UsersClass
{
   public class productoHandler
    {

        public ObservableCollection <Producto> ProductList { get; set; }

        public productoHandler()
        {
            this.ProductList = new ObservableCollection<Producto>();
        }

        public void Addproduct(Producto producto)
        {
            ProductList.Add(producto);
        }
        public void Modifyproduct(Producto producto, int pos)
        {
            ProductList[pos] = producto;
        }
        public void Removeproduct(int pos)
        {
            ProductList.RemoveAt(pos);
        }
    }
}
