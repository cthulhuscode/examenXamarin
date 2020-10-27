using System;
using System.Collections.Generic;
using System.Text;

namespace examen
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double PreciodeVenta { get; set; }
        public int Cantidad { get; set; }
        public double PreciodeCompra { get; set; }
        public string Descripcion { get; set; }
        public string Foto { get; set; }
    }
}
