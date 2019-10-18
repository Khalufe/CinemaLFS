using CinemaLFS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CinemaLFS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionesPage1 : ContentPage
    {
        private Pelicula pelicula;

        public FuncionesPage1(Pelicula pelicula)
        {
            InitializeComponent();

            this.pelicula = pelicula;
            BindingContext = pelicula;
        }

        private async void Funcion_Selec(object sender, SelectedItemChangedEventArgs e)
        {
            string cantidad = Cantidad.Text;
            if (string.IsNullOrEmpty(cantidad))
            {
                await DisplayAlert("Campo vacio", "Ingresa la cantidad de boletas","");
                return;
            }

            int cant = Convert.ToInt32(cantidad);
            var funcion = (Funcion)e.SelectedItem;

           await  Navigation.PushAsync(new ResumenPage1(pelicula, funcion, cant));


        }

       
    }
}