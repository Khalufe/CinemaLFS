using CinemaLFS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CinemaLFS.Resources;

namespace CinemaLFS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarteleraPage1 : ContentPage
    {
                   

        public CarteleraPage1()
        {
            InitializeComponent();
            CargarPeliculas();
        }

        private async void CargarPeliculas()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://misapis.azurewebsites.net");

            var request = await client.GetAsync("/api/Cartelera");
            if (request.IsSuccessStatusCode)
            {
                var responseJson = await request.Content.ReadAsStringAsync();
                var listado = JsonConvert.DeserializeObject<List<Pelicula>>(responseJson);
                listPeliculas.ItemsSource = listado;
            }
            else
                await DisplayAlert(AppResources.Se_presento_un_problema,AppResources.Intentalo_de_nuevo,"");
        }

       
        private void Pelicula_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var pelicula = (Pelicula)e.SelectedItem;
            Navigation.PushAsync(new FuncionesPage1(pelicula));
        }
    }     
}