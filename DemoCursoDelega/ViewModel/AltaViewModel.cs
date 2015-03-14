using System;
using DemoCursoDelega.Modelo;
using System.Threading.Tasks;

namespace DemoCursoDelega.ViewModel
{
	public class AltaViewModel:ViewModelBase
	{

		public Persona Persona {
			get;
			set;
		}

		public async Task Alta(){
		
			try{
				await servicio.AddPersona(Persona);

			}
			catch(Exception ee){
			}
		
		}

	}
}

