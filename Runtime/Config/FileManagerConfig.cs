/**************************************************************************
 * 
 *  Project     : MayaMystic FileManager Framework
 *  File        : FileManagerConfig.cs
 *  Author      : Harsh Patel
 *  Company     : MayaMystic
 *  Version     : 1.0.0
 * 
 *  Description :
 *  Provides global access to the FileManager configuration system.
 *  
 **************************************************************************/
using UnityEngine;

namespace MayaMystic.FileManager.Config
{
	/// <summary>
	/// Global configuration settings for the MayaMystic FileManager framework.
	/// </summary>
	/// <remarks>
	/// This configuration asset controls framework-level behavior such as
	/// JSON formatting, caching, serialization, and future FileManager settings.
	/// </remarks>
	[CreateAssetMenu(
		fileName = "FileManagerConfig",
		menuName = "MayaMystic/FileManager/FileManagerConfig",
		order = 0)]
	public class FileManagerConfig : ScriptableObject
	{
		#region JSON Settings

		[Header("JSON Settings")]

		[SerializeField]
		[Tooltip("Determines whether JSON data should be formatted with indentation for readability.")]
		private bool usePrettyPrintJson = true;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets whether JSON output should use pretty-print formatting.
		/// </summary>
		public bool UsePrettyPrintJson =>
			usePrettyPrintJson;

		#endregion
	}
}