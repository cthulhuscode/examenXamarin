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
            db.CreateTable<Producto>();
            //var productos = db.Table<Producto>().Select("sdf").ToList();

            var productos = db.Query<Producto>("SELECT Nombre from Producto");

            DisplayAlert("Valores", productos[0].ToString(), "OK");

            pkrProductos.ItemsSource = null;
            pkrProductos.ItemsSource = productos;

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