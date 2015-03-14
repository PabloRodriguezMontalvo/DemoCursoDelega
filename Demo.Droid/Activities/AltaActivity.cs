
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DemoCursoDelega.ViewModel;

namespace Demo.Droid
{
	[Activity (Label = "AltaActivity")]			
	public class AltaActivity : BaseActivity<AltaViewModel>
	{
		EditText txtNom,txtEda,txtApe;
		Button btnAdd;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.AltaPersona);

			txtNom = FindViewById<EditText> (Resource.Id.txtNomAdd);
			txtEda = FindViewById<EditText> (Resource.Id.txtEdaAdd);
			txtApe = FindViewById<EditText> (Resource.Id.txtApeAdd);
			btnAdd = FindViewById<Button> (Resource.Id.btnAdd);

			btnAdd.Click += OnAdd;
			// Create your application here
		}

		private async void OnAdd(Object Sender,EventArgs e){
			viewModel.Persona.nombre = txtNom.Text;
			viewModel.Persona.apellidos = txtApe.Text;
			viewModel.Persona.edad = Convert.ToInt32 (txtEda.Text);

			await viewModel.Alta ();
		
			new AlertDialog.Builder(this)
				.SetTitle("Error")
				.SetMessage("Alta realizada")
				.SetPositiveButton("Aceptar", (IDialogInterfaceOnClickListener)null)
				.Show();
		}

	}
}

