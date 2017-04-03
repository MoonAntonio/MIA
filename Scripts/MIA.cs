//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// MIA.cs (28/03/2017)															\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Controlador AI del enemigo									\\
// Fecha Mod:		02/03/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace Pendulum.Controller
{
	/// <summary>
	/// <para>Controlador AI del enemigo</para>
	/// </summary>
	[AddComponentMenu("Pendulum/Controller/MIA")]
	public class MIA : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Objetivo del enemigo.</para>
		/// </summary>
		public Transform target = null;                             // Objetivo del enemigo (D: Target)
		/// <summary>
		/// <para>Tiempo que tarda en actualizar su estado.</para>
		/// </summary>
		public int timeActualizar = 0;                              // Tiempo que tarda en actualizar su estado (D: 2)
		/// <summary>
		/// <para>Velocidad de Rotacion del enemigo.</para>
		/// </summary>
		public float velRotacion = 0.0f;                            // Velocidad de Rotacion del enemigo (D: 50)
		/// <summary>
		/// <para>Rango del enemigo.</para>
		/// </summary>
		public int rango = 0;                                       // Rango del enemigo (D: 10)
		/// <summary>
		/// <para>Radio de vision del enemigo.</para>
		/// </summary>
		public int radioVision = 0;                                 // Radio de vision del enemigo (D: 45)
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Esta en el rango el objetivo.</para>
		/// </summary>
		private bool isRango = false;                               // Esta en el rango el objetivo
		/// <summary>
		/// <para>Direccion del enemigo.</para>
		/// </summary>
		private Vector3 direccion = Vector3.zero;                   // Direccion del enemigo
		/// <summary>
		/// <para>Angulo de vision del enemigo.</para>
		/// </summary>
		private float angulo = 0.0f;                                // Angulo de vision del enemigo
		/// <summary>
		/// <para>Variable que recoge los frames de cada Update.</para>
		/// </summary>
		private int tempTime = 0;                                   // Variable que recoge los frames de cada Update
		#endregion

		#region Actualizador
		/// <summary>
		/// <para>Actualizador de EnemigoIA.</para>
		/// </summary>
		private void Update()// Actualizador de EnemigoIA
		{
			// Optimizador de CPU
			tempTime++;

			// Actualizar rango
			if (AlexandriaManager.intensidadLuz == true)
			{
				rango = 10;
			}
			else
			{
				rango = 3;
			}

			if (tempTime > timeActualizar)
			{
				tempTime = 0;

				// Logica del enemigo
				Logica();
			}
		}
		#endregion

		#region API
		/// <summary>
		/// <para>Obtiene la distancia hasta el objetivo.</para>
		/// </summary>
		private void GetDistancia()// Obtiene la distancia hasta el objetivo
		{
			float distancia = Vector3.Distance(target.position, this.transform.position);
			isRango = (distancia < rango);
		}

		/// <summary>
		/// <para>Obtiene la direccion hacia el objetivo.</para>
		/// </summary>
		private void GetDireccion()// Obtiene la direccion hacia el objetivo
		{
			direccion = target.position - this.transform.position;
			if (direccion == Vector3.zero)
			{
				direccion = transform.forward;
			}
		}

		/// <summary>
		/// <para>Obtiene el Angulo de vision del enemigo.</para>
		/// </summary>
		private void GetAngulo()// Obtiene el Angulo de vision del enemigo
		{
			angulo = Vector3.Angle(transform.forward, direccion);
		}

		/// <summary>
		/// <para>Obtiene la rotacion del enemigo.</para>
		/// </summary>
		private void GetRotacion()// Obtiene la rotacion del enemigo
		{
			Quaternion rot = Quaternion.LookRotation(direccion);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rot, Time.deltaTime * velRotacion);
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Logica del enemigo ( Movimiento, rotacion, distancia, angulo ).</para>
		/// </summary>
		private void Logica()// Logica del enemigo ( Movimiento, rotacion, distancia, angulo )
		{
			// Si hay objetivo
			if (target)
			{
				// Distancia
				GetDistancia();

				// Esta el objetivo a rango
				if (isRango)
				{
					// Direccion
					GetDireccion();

					// Angulo
					GetAngulo();
					if (angulo < radioVision)
					{
						// Rotacion
						GetRotacion();
					}
				}
			}
		}
		#endregion
	}
}
