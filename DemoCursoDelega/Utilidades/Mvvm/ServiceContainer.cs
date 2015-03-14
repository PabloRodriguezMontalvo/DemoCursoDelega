using System;
using System.Collections.Generic;


namespace DemoCursoDelega.Utilidades.Mvvm
{
	public class ServiceContainer
	{

		private static Object locker=new object();
		private static ServiceContainer instance;



		private ServiceContainer ()
		{
			Services = new Dictionary<Type, Lazy<object>> ();

		}

		private static ServiceContainer Instance{

			get{ 
				lock(locker){

					if (instance == null) {
						instance = new ServiceContainer ();
					
					}
					return instance;
				}
			}
		}

		public Dictionary<Type,Lazy<object>> Services {
			get;
			set;
		}

		public static void Register<T> (T Service){
			Instance.Services [typeof(T)] = 
				new Lazy<object> (() => Service);
		}

		public static void Register<T> () where T:new(){
		
			Instance.Services [typeof(T)] = 
				new Lazy<object> (() => new T());
		}

		public static void Register<T> (Func<object> function){
			Instance.Services [typeof(T)] = 
				new Lazy<object> (function);
		}

		public static T Resolve<T>(){
			Lazy<object> service;
			if (Instance.Services.TryGetValue (typeof(T), out service)) {

				return (T)service.Value;
				
			} else {

		throw new KeyNotFoundException 
			(String.Format ("Servicio no encontrado {0}", typeof(T)));
			
			}
		
		}

	}
}

























