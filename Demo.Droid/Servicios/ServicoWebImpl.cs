using System;
using DemoCursoDelega.Servicios;
using Microsoft.WindowsAzure.MobileServices;
using DemoCursoDelega.Utilidades;
using System.Threading.Tasks;
using System.Collections.Generic;
using DemoCursoDelega.Modelo;

namespace Demo.Droid
{
	//Servico
	public class ServicoWebImpl:IServicioWeb
	{
		MobileServiceClient client; 

		public ServicoWebImpl ()
		{
			CurrentPlatform.Init ();
			client= new MobileServiceClient (Cadenas.url);
		}





		#region IServicioWeb implementation
		public async Task<List<Persona>> GetPersonas ()
		{
			var tabla = client.GetTable<Persona> ();

			var datos = await tabla.ToListAsync ();

			return datos;

		}
		public async Task<Persona> AddPersona (Persona p)
		{
			var tabla = client.GetTable<Persona> ();

			 await tabla.InsertAsync (p);

			return p;

		}
		public async Task<Persona> UpdatePersona (Persona p)
		{
			var tabla = client.GetTable<Persona> ();

			await tabla.UpdateAsync (p);

			return p;
		}
		public async Task DeletePersona (Persona p)
		{
			var tabla = client.GetTable<Persona> ();

			await tabla.DeleteAsync (p);


		}
		#endregion
	}
}

