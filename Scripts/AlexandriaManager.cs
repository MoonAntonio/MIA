//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// AlexandriaManager.cs (28/03/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Manager del game											\\
// Fecha Mod:		02/03/2017													\\
// Ultima Mod:		Version inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace Pendulum.Controller
{
	/// <summary>
	/// <para>Manager del game</para>
	/// </summary>
	[AddComponentMenu("Pendulum/Controller/AlexandriaManager")]
	public class AlexandriaManager : MonoBehaviour
	{
		#region Variables Globales
		/// <summary>
		/// <para>Si la intensidad de la luz es true, los guerreros de la luz tendran mas rango.</para>
		/// </summary>
		public static bool intensidadLuz = false;											// Si la intensidad de la luz es true, los guerreros de la luz tendran mas rango
		#endregion
	}
}
