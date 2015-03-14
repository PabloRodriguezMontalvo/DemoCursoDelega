using System;
using DemoCursoDelega.Utilidades.Mvvm;
using DemoCursoDelega.ViewModel;
using DemoCursoDelega.Servicios;
using Android.Runtime;

namespace Demo.Droid
{
	[Android.App.Application(Theme="@android:style/Theme.Holo.Light")]
	public class Application:Android.App.Application
	{
		public Application(IntPtr javaReference,
			JniHandleOwnership transfer):base(javaReference,transfer){
			
		
		}

		public override void OnCreate ()
		{
			base.OnCreate ();

			ServiceContainer.Register<ListadoViewModel> ();
			ServiceContainer.Register<IServicioWeb> (()=>new ServicoWebImpl());

		}

	}
}

