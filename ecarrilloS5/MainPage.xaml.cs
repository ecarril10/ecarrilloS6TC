using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ecarrilloS5
{
    public partial class MainPage : ContentPage
    {
        private string Url = "http://192.168.1.2/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Estudiantes> post;


        public MainPage()
        {
            InitializeComponent();
            ObtenerDatos();

        }

        public async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Estudiantes> listaPost = JsonConvert.DeserializeObject<List<Estudiantes>>(contenido);
            post = new ObservableCollection<Estudiantes>(listaPost);
            listarEstudiantes.ItemsSource = post;

        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());

        }

        // en la funcion obtener datos y el boton clickMostrar tenemos el mismo algoritmo por uqe al ejecutar el
        // programa vamos a mostrar toda las lsita de nuestra base de datos.

        private void listarEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            //Eliminar o actualizar campos 
            //Se almacenan en una variable objeto
            var objeto = (Estudiantes)e.SelectedItem;
            //Se almancen en una variable temporal a string para luego transformar en int
            var codigoTemp = objeto.codigo.ToString();
            int codigo = Convert.ToInt32(codigoTemp);
            string nombre = objeto.nombre.ToString();
            string apellido = objeto.apellido.ToString();
            var edadTem = objeto.edad.ToString();
            int edad = Convert.ToInt32(edadTem);

            Navigation.PushAsync(new ActualizarEliminar(codigo, nombre, apellido, edad));
        }

        
    }

}
