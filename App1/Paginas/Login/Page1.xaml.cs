using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Paginas.Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
			// abrir una nueva pagina misma que se colaca en la cima de la pila de paginas
			var datos = new NameValueCollection();
			datos.Add("usuario", "PEPE");
			datos.Add("clave", "1234");
			datos.Add("direccion", "wueqwioeqw");
			datos.Add("telefono", "07856787678");

			var mp = new MainPage();
			mp.Datos = datos;
			mp.Usuario = "jjkl";
			mp.Clave = "12321";

			Navigation.PushAsync( mp );
        }
    }
}