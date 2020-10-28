using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Java.Sql;

namespace examen
{
    class Venta
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public double precioTotal { get; set; }
        public string cliente { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
    }
}
