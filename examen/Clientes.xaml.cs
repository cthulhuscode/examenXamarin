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
    public partial class Clientes : ContentPage
    {
        public void AbrirBase()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaDb = System.IO.Path.Combine(folder, BaseDeDatos.bdName);

            // Crea la base de datos si no existe, y crea una conexión
            var db = new SQLiteConnection(rutaDb);
            db.CreateTable<Cliente>();
            var todoslosclientes = db.Table<Cliente>().ToList();

            lvClientes.ItemsSource = null;
            lvClientes.ItemsSource = todoslosclientes;
        }

        public Clientes()
        {
            InitializeComponent();
            lvClientes.IsRefreshing = false;
            this.Appearing += Clientes_Appearing;
        }

        private void Clientes_Appearing(object sender, EventArgs e)
        {
            AbrirBase();
        }

        // Agregar producto
        async private void tbiAgregar_Clicked(object sender, EventArgs e)
        {
            //r AgregarProductoPage = new NavigationPage(new AgregarProducto());
            await Navigation.PushAsync(new AgregarCliente());
            AbrirBase();
        }

        // Detalle del producto
        private void lvClientes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var cliente = e.Item as Cliente;
            var detailPage = new DetalleCliente();
            detailPage.BindingContext = cliente;
            Navigation.PushAsync(detailPage);
        }
    }
}