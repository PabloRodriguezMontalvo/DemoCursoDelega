
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
using DemoCursoDelega.Modelo;
using DemoCursoDelega.Utilidades.Mvvm;

namespace Demo.Droid
{
	[Activity (Label = "ActivityPersonas",MainLauncher=true)]			
	public class ActivityPersonas : BaseActivity<ListadoViewModel>
	{
		ListView lsPersonas;
		Button btnAdd;
		Adapter adapter;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			lsPersonas = FindViewById<ListView> (Resource.Id.lsPersonas);
			adapter = new Adapter (this);
			lsPersonas.Adapter = adapter;

			btnAdd = FindViewById<Button> (Resource.Id.btnAdd);
		}

		protected async override void OnResume ()
		{
			base.OnResume ();
			try {
				await viewModel.CargarDatos ();
				adapter.NotifyDataSetInvalidated ();
			} catch (Exception ex) {
				DisplayError (ex);
			}
		}

		class Adapter:BaseAdapter<Persona>
		{
			LayoutInflater inflater;
			ListadoViewModel lViewModel=ServiceContainer.Resolve<ListadoViewModel>();
			public Adapter(Context ctx){
				
				inflater=(LayoutInflater)ctx.GetSystemService(Context.LayoutInflaterService);
			}


			#region implemented abstract members of BaseAdapter
			public override long GetItemId (int position)
			{
				return position;	
			}
			public override View GetView (int position, View convertView, ViewGroup parent)
			{
				if (convertView == null) {
					convertView = inflater.Inflate (Resource.Layout.TemplatePersonas,null);
				}
				var persona = this [position];
				var txNom = convertView.FindViewById<TextView> (Resource.Id.txtNombre);
				var txtApe = convertView.FindViewById<TextView> (Resource.Id.txtApellido);
				var txtEda = convertView.FindViewById<TextView> (Resource.Id.txtEdad);

				txNom.Text = persona.nombre;
				txtApe.Text = persona.apellidos;
				txtEda.Text = persona.edad.ToString();

				return convertView;

			}
			public override int Count {
				get {
				return	lViewModel.personas.Count;
				}
			}
			#endregion
			#region implemented abstract members of BaseAdapter
			public override Persona this [int index] {
				get {
					return lViewModel.personas [index];
				}
			}
			#endregion
		}
	}
}

