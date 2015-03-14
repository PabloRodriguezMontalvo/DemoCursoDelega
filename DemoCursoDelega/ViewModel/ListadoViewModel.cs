using System;
using System.Collections.Generic;
using DemoCursoDelega.Modelo;
using System.Threading.Tasks;

namespace DemoCursoDelega.ViewModel
{
	public class ListadoViewModel:ViewModelBase
	{

		public List<Persona> personas;
		public Persona personaSeleccionada;

		public ListadoViewModel(){
		
			personas = new List<Persona> ();
		}

		public async Task CargarDatos(){
		
			//IsBusy = true;

			try{
				personas=await servicio.GetPersonas();

			}
			finally{
				IsBusy = false;
			}
		
		}


	}
}








