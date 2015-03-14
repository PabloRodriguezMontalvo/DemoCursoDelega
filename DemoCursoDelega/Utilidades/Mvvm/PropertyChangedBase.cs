using System;
using System.ComponentModel;

namespace DemoCursoDelega.Utilidades.Mvvm
{
	public class PropertyChangedBase:INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string property){

			var m = PropertyChanged;

			if (m != null) {
				m (this, new PropertyChangedEventArgs (property));
			}

		}

	}
}

