using CinemaLFS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CinemaLFS.Resources;
namespace CinemaLFS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResumenPage1 : ContentPage
    {
        public ResumenPage1(Pelicula pelicula, Funcion funcion, int cantidad)
        {
            InitializeComponent();
            gridPelicula.BindingContext = pelicula;
            gridFuncion.BindingContext = funcion;
            Cantidad.Text = cantidad.ToString();
            Totalapagar.Text = (cantidad * funcion.Precio).ToString();
        }

        private async void Finalizar_Click(object sender, EventArgs e)

        {

            await DisplayAlert(AppResources.La_reserva_se_realizo_correctamente,"","");
        }
    }
}