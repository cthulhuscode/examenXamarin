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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarVenta : ContentPage
    {
        public void AbrirBase()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaDb = System.IO.Path.Combine(folder, BaseDeDatos.bdName);

            // Crea la base de datos si no existe, y crea una conexión
            var db = new SQLiteConnection(rutaDb);

            //var result = db.Query<Producto>("SELECT Nombre from Producto");

            // Jalar PRODUCTOS
            db.CreateTable<Producto>();
            var results = db.Table<Producto>().ToList();

            var products = new List<string>();

            foreach(var producto in results)
            {
                if(producto != null)
                    products.Add(producto.Nombre.ToString());
            }

            pkrProductos.ItemsSource = products;

            // Jalar CLIENTES
            /*
            db.CreateTable<Cliente>();
            var results2 = db.Table<Cliente>().ToList();

            var clients = new List<string>();

            foreach (var client in results2)
            {
                if (client != null)
                    products.Add(client.Nombre.ToString());
            }

            pkrProductos.ItemsSource = clients;

            */

        }

        public AgregarVenta()
        {
            InitializeComponent();
            this.Appearing += AgregarVenta_Appearing;
        }

        private void AgregarVenta_Appearing(object sender, EventArgs e)
        {
            AbrirBase();
        }

        private void tbiGuardar_Clicked(object sender, EventArgs e)
        {

        }
    }
}