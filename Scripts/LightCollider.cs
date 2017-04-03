//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// LightCollider.cs (28/03/2017)												\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Funcionalidad de la luz										\\
// Fecha Mod:		02/03/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using Pendulum.Controller;
#endregion

namespace Pendulum
{
	/// <summary>
	/// <para>Funcionalidad de la luz</para>
	/// </summary>
	[AddComponentMenu("Pendulum/Utiles/LightCollider")]
	public class LightCollider : MonoBehaviour
	{
		#region Eventos Unity
		private void OnTriggerStay(Collider other)
		{
			if (other.tag == "Player")
			{
				if (AlexandriaManager.intensidadLuz == false) AlexandriaManager.intensidadLuz = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.tag == "Player")
			{
				if (AlexandriaManager.intensidadLuz == true) AlexandriaManager.intensidadLuz = false;
			}
		}
		#endregion
	}
}
