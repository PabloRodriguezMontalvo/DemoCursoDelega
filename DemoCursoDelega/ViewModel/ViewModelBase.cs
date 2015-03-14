using System;
using DemoCursoDelega.Utilidades.Mvvm;
using DemoCursoDelega.Servicios;

namespace DemoCursoDelega.ViewModel
{
	public class ViewModelBase: PropertyChangedBase
	{
		protected readonly IServicioWeb servicio =
			ServiceContainer.Resolve<IServicioWeb> ();

		public event EventHandler IsBusyChanged;

		private bool _isBusy;
		public bool IsBusy{
			get{ 
				return _isBusy;
			}
			set{ 
				if (_isBusy != value) {
					_isBusy = value;
					OnPropertyChanged ("IsBusy");
					OnIsBusyChanged ();
				}
			}
		}

		protected virtual void OnIsBusyChanged(){
			var m=IsBusyChanged;
			if(m!=null){

				IsBusyChanged(this,EventArgs.Empty);

			}

		}
	}
}







