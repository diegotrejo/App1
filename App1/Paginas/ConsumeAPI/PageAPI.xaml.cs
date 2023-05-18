using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Paginas.ConsumeAPI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageAPI : ContentPage
	{
		public PageAPI ()
		{
			InitializeComponent ();
		}

		private string Url = "https://cloudcomputingapi2.azurewebsites.net/api/Mascotas";

		private Models.Mascota[] Mascotas { get; set; }

        private void Button_Clicked(object sender, EventArgs e)
        {
			using (var wc = new WebClient()) {

				wc.Headers.Add("Content-Type", "application/json");
				var json = wc.DownloadString(Url + "/" + txtId.Text );
				var mascota = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Mascota>(json);

				if (mascota != null)
				{
					txtId.Text = mascota.Id;
					txtNombre.Text = mascota.Nombre;
					txtRaza.Text = mascota.Raza;
					txtEspecie.Text = mascota.Especie;
					txtEdad.Text = mascota.Edad.ToString();
					txtNroChip.Text = mascota.Nro_Chip;
				}
				else
				{
                    txtNombre.Text = "";
                    txtRaza.Text = "";
                    txtEspecie.Text = "";
                    txtEdad.Text = "";
                    txtNroChip.Text = "";
                }
			}
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
			using (var wc = new WebClient())
			{ 
				wc.Headers.Add("Content-Type", "application/json");
				var datos = new Models.Mascota
				{
					Id = txtId.Text,
					Nombre = txtNombre.Text,
					Especie = txtEspecie.Text,
					Edad = int.Parse(txtEdad.Text),
					Raza = txtRaza.Text,
					Nro_Chip = txtNroChip.Text
				};
				var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
				wc.UploadString(Url, "POST", json);
				lblDatos.Text = "DATOS INSERTADOS CON EXITO !!";
			}
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
			using (var wc = new WebClient())
			{
				wc.Headers.Add("Content-Type", "application/json");
                var datos = new Models.Mascota
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    Especie = txtEspecie.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Raza = txtRaza.Text,
                    Nro_Chip = txtNroChip.Text
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
				wc.UploadString(Url + "/" +  txtId.Text, "PUT", json);
                lblDatos.Text = "DATOS ACTUALZIADOS CON EXITO !!";
            }
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
			using(var wc = new WebClient())
			{
				wc.Headers.Add("Content-Type", "application/json");
				wc.UploadString(Url + "/" + txtId.Text, "DELETE", "");
                lblDatos.Text = "DATOS BORRADOS CON EXITO !!";

                txtId.Text = "";
                txtNombre.Text = "";
                txtRaza.Text = "";
                txtEspecie.Text = "";
                txtEdad.Text = "";
                txtNroChip.Text = "";
            }
        }
    }
}