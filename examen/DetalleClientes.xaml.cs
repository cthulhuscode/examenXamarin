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
    public partial class DetalleClientes : ContentPage
    {
        public DetalleClientes()
        {
            InitializeComponent();
        }

        private void tbiSave_Clicked(object sender, EventArgs e)
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaDb =System.IO.Path.Combine(folder, BaseDeDatos.bdName);
            var db = new SQLiteConnection(rutaDb);

            int MiID =int.Parse(Id.Text);

            var registro = new Cliente
            {
                Id = MiID,
                Nombre = nombre.Text,
                Domicilio = domicilio.Text,
                Telefono = double.Parse(telefono.Text),
                Correo = correo.Text,
                Foto=foto.Text
            };

            DisplayAlert("ID", Id.Text, "OK");

            db.Table<Cliente>();

            db.Update(registro);

            Application.Current.MainPage.Navigation.PopAsync();
        }

        async private void tbiDelete_Clicked(object sender, EventArgs e)
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaDb = System.IO.Path.Combine(folder, BaseDeDatos.bdName);
            var db = new SQLiteConnection(rutaDb);

            int MiID = int.Parse(Id.Text);

            var respuesta = await DisplayAlert("Alerta!", "¿Esta seguro de eliminar este elemento?", "Si", "No");

            if(respuesta == true)
            {
                db.Delete<Cliente>(MiID);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}