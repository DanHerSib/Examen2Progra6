using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrdenEntity
    {
        public OrdenEntity()
        {
            NombreProducto = NombreProducto ?? new ProductoEntity();
            PrecioProducto = PrecioProducto ?? new ProductoEntity();
        }
        public int? IdOrden { get; set; }
        public int? IdProducto { get; set; }
        public virtual ProductoEntity NombreProducto { get; set; }
        public virtual ProductoEntity PrecioProducto { get; set; }
        /* public string NombreProducto { get; set; }
         public float PrecioProducto { get; set; }*/
        public int? CantidadProducto { get; set; }
        public string Estado { get; set; }
    }
}
