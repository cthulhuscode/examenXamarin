using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;


namespace examen
{
    public class Producto
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double PreciodeVenta { get; set; }
        public int Cantidad { get; set; }
        public double PreciodeCompra { get; set; }
        public string Foto { get; set; }
    }
}
