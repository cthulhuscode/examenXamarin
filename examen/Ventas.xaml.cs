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
    public partial class Ventas : ContentPage
    {
        public void AbrirBase()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaDb = System.IO.Path.Combine(folder, BaseDeDatos.bdName);

            // Crea la base de datos si no existe, y crea una conexión
            var db = new SQLiteConnection(rutaDb);
            db.CreateTable<Venta>();
            var ventas = db.Table<Venta>().ToList();

            lvVentas.ItemsSource = null;
            lvVentas.ItemsSource = ventas;
        }

        public Ventas()
        {
            InitializeComponent();

            lvVentas.IsRefreshing = true;
            this.Appearing += Ventas_Appearing;
        }

        private void Ventas_Appearing(object sender, EventArgs e)
        {
            AbrirBase();
        }

        // Agregar venta
        async private void tbiAgregar_Clicked(object sender, EventArgs e)
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaDb = System.IO.Path.Combine(folder, BaseDeDatos.bdName);

            // Crea la base de datos si no existe, y crea una conexión
            var db = new SQLiteConnection(rutaDb);
            db.CreateTable<Producto>();
            var Productos = db.Table<Producto>().ToList();

            var ventaPage = new AgregarVenta();
            ventaPage.BindingContext = Productos;          

            await Navigation.PushAsync(ventaPage);
            AbrirBase();
        }

        private void lvVentas_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}