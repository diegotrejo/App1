using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(string usuario, string clave)
        {
            InitializeComponent();
            Usuario = usuario;
            Clave = clave;
        }

        public MainPage(NameValueCollection datos) {
            InitializeComponent();
            Datos = datos;
        }

        public string Usuario { get; set; } 
        public string Clave { get; set; }
        public NameValueCollection Datos { get; set; }


        private void Button_Clicked(object sender, EventArgs e)
        {
            //lblMensaje.Text = $"Hola {txtNombre.Text}";
            //lblMensaje.Text = Usuario;
            lblMensaje.Text = Datos["usuario"];
        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblMensaje.Text = $"Hola {txtNombre.Text}";
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            // cerramos la pagina actual y regresar a la página anterior de la pila
            Navigation.PopAsync();  
        }
    }
}
