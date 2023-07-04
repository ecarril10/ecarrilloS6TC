using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ecarrilloS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarEliminar : ContentPage
    {
        public ActualizarEliminar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            txtCodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient client = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                client.UploadValues("http://192.168.1.2/ws_uisrael/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "PUT", parametros);
                DisplayAlert("Aviso", "Dato actualizado", "Cerrar");
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");

            }

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient client = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                client.UploadValues("http://192.168.1.2/ws_uisrael/post.php?codigo=" + txtCodigo.Text + "&nombre=" + txtNombre.Text + "&apellido=" + txtApellido.Text + "&edad=" + txtEdad.Text, "DELETE", parametros);
                DisplayAlert("Aviso", "Dato Eliminados", "Cerrar");
                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");

            }


        }
    }
}