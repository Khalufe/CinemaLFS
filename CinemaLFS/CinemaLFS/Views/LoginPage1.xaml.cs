using CinemaLFS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CinemaLFS.Resources;

namespace CinemaLFS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage1 : ContentPage
    {
        public LoginPage1()
        {
            InitializeComponent();
        }

        private async void Ingresar_Click(object sender, EventArgs e)
        {
            var usuario = Usuario.Text;
            var password = Password.Text;

            if (string.IsNullOrEmpty(usuario))
            {
                await DisplayAlert(AppResources.Validacion, AppResources.Ingrese_el_usuario, AppResources.Aceptar);
                Usuario.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert(AppResources.Validacion, AppResources.Ingrese_la_password, AppResources.Aceptar);
                Usuario.Focus();
                return;
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://misapis.azurewebsites.net");

            var autentucacion = new Autenticacion
            {
                Usuario = usuario,
                Password = password
        };
            string json = JsonConvert.SerializeObject(autentucacion);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync("/api/Seguridad", content);
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<Respuesta>(responseJson);

                if (respuesta.EsPermitido)
                {
                    await Navigation.PushAsync(new CarteleraPage1());
                }
                else

                    await DisplayAlert(AppResources.Lo_sentimos, respuesta.Mensaje, AppResources.Aceptar);
                }
            
            else
                await DisplayAlert(AppResources.Se_presento_un_problema, AppResources.Intentalo_de_nuevo, "");
        }
    }
    }
