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
    public partial class Productos : ContentPage
    {
        public void AbrirBase()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaDb = System.IO.Path.Combine(folder, "MiNegocio1.db");

            // Crea la base de datos si no existe, y crea una conexión
            var db = new SQLiteConnection(rutaDb);
            db.CreateTable<Producto>();
            var todoslosproductos = db.Table<Producto>().ToList();

            lvProductos.ItemsSource = null;
            lvProductos.ItemsSource = todoslosproductos;
        }

        public Productos()
        {
            InitializeComponent();
            
            lvProductos.IsRefreshing = false;
            this.Appearing += Productos_Appearing;
            
        }

        private void Productos_Appearing(object sender, EventArgs e)
        {
            AbrirBase();
        }

        async private void tbiAgregar_Clicked(object sender, EventArgs e)
        {
            var AgregarProductoPage = new AgregarProducto();
            await Navigation.PushAsync(AgregarProductoPage);
            AbrirBase();
        }

        private void lvProductos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var producto = e.Item as Producto;
            var detailPage = new DetalleProducto();
            detailPage.BindingContext = producto;
            Navigation.PushAsync(detailPage);
        }
    }
}