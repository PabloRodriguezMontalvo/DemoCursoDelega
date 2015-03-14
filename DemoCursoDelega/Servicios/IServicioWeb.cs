using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DemoCursoDelega.Modelo;

namespace DemoCursoDelega.Servicios
{
	public interface IServicioWeb
	{
		Task<List<Persona>> GetPersonas ();
		Task<Persona> AddPersona (Persona p);
		Task<Persona> UpdatePersona (Persona p);
		Task DeletePersona (Persona p);

	}
}

