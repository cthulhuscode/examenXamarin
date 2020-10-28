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
    class Cliente
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set;}
        public string Nombre { get; set;}
        public string Domicilio { get; set;}
        public double Telefono { get; set;}
        public string Correo { get; set;}
        public string Foto { get; set;}
    }
}
