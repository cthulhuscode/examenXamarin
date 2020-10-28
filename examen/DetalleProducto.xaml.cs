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
    public partial class DetalleProducto : ContentPage
    {
        public DetalleProducto()
        {
            InitializeComponent();
        }

        private void tbiSave_Clicked(object sender, EventArgs e)
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaDb = System.IO.Path.Combine(folder, BaseDeDatos.bdName);
            var db = new SQLiteConnection(rutaDb);

            int MiId = int.Parse(Id.Text);
            //DisplayAlert("ID", "" + MiId, "Ok");

            if (string.IsNullOrWhiteSpace(nombre.Text) ||
                string.IsNullOrWhiteSpace(foto.Text) ||
                string.IsNullOrWhiteSpace(preciodecompra.Text) ||
                string.IsNullOrWhiteSpace(preciodeventa.Text) ||
                string.IsNullOrWhiteSpace(cantidad.Text))
            {
                DisplayAlert("Error al actualizar", "Todos los campos son obligatorios", "OK");
                return;
            }

            var registro = new Producto
            {
                Id = MiId,
                Nombre = nombre.Text,
                PreciodeCompra = double.Parse(preciodecompra.Text),
                Cantidad = int.Parse(cantidad.Text),
                PreciodeVenta = double.Parse(preciodeventa.Text),
                Foto = foto.Text
            };

            db.Table<Producto>();

            db.Update(registro);
            // DisplayAlert("Anuncio", "Registro Actualizado!!", "ok");

            Application.Current.MainPage.Navigation.PopAsync();
        }

        async private void tbiDelete_Clicked(object sender, EventArgs e)
        {
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            string rutaDb = System.IO.Path.Combine(folder, BaseDeDatos.bdName);
            var db = new SQLiteConnection(rutaDb);

            int MiId = int.Parse(Id.Text);

            var respuesta = await DisplayAlert("Eliminar producto", "¿Desea eliminar el producto?", "Si", "No");

            if (respuesta == true)
            {
                db.Delete<Producto>(MiId);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}