using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Nombres
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnEnviar_Clicked(object sender, EventArgs e)
        {
            if (Verificar() == true) {

                var respuesta = new Models.Persona
                {
                    Nombre = TxtNombre.Text,
                    Apellido = TxtApellidos.Text,
                    Edad = TxtEdad.Text,
                    Correo = TxtCorreo.Text
                };

                TxtNombre.Text = "";
                TxtApellidos.Text = "";
                TxtCorreo.Text = "";
                TxtEdad.Text = "";

                var pagina = new Views.Resultado();
                pagina.BindingContext = respuesta;
                await Navigation.PushAsync(pagina);

            } else{

                await DisplayAlert("Aviso", "Llene todos los campos", "Aceptar");

            }

        }

        public bool Verificar() {

            bool t;

            if (String.IsNullOrEmpty(TxtApellidos.Text) || String.IsNullOrEmpty(TxtNombre.Text) || String.IsNullOrEmpty(TxtCorreo.Text) || String.IsNullOrEmpty(TxtEdad.Text)) {
                t = false;
            }else{

                t = true;
            }

            return t;
        }
    }
}
