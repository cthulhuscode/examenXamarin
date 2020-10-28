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
    public partial class AgregarCliente : ContentPage
    {
        public AgregarCliente()
        {
            InitializeComponent();
        }

        private void addClient()
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaDb = System.IO.Path.Combine(folder, BaseDeDatos.bdName);
            // DisplayAlert("Ruta de la base de datos", rutaDb, "ok");
            // Crea la base de datos si no existe, y crea una conexión
            var db = new SQLiteConnection(rutaDb);

            // Crea la tabla si no existe
            db.CreateTable<Cliente>();

            var registro = new Cliente
            {
                Nombre = nombre.Text,
                Domicilio = domicilio.Text,
                Telefono = int.Parse(telefono.Text),
                Correo = correo.Text,
                Foto = foto.Text
            };

            db.Insert(registro);
            DisplayAlert("Registro agregado", "El registro fue agregado con exito!", "OK");
        }

        private void tbiGuardar_Clicked(object sender, EventArgs e)
        {
            addClient();
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}