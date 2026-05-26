/**************************************************************************
 * 
 *  Project     : MayaMystic FileManager Framework
 *  File        : FileManagerSettings.cs
 *  Author      : Harsh Patel
 *  Company     : MayaMystic
 *  Version     : 1.0.0
 * 
 *  Description :
 *  Provides global access to the FileManager configuration system.
 *  Handles loading and caching of framework configuration assets.
 * 
 **************************************************************************/

using MayaMystic.FileManager.Config.Constants;
using UnityEngine;

namespace MayaMystic.FileManager.Config
{
	/// <summary>
	/// Provides global access to the FileManager configuration asset.
	/// </summary>
	/// <remarks>
	/// This class is responsible for loading and caching the
	/// <see cref="FileManagerConfig"/> instance from the Unity Resources folder.
	/// </remarks>
	public static class FileManagerSettings
	{
		#region Private Variables

		/// <summary>
		/// Cached instance of the loaded FileManager configuration.
		/// </summary>
		private static FileManagerConfig cachedConfig;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets the loaded FileManager configuration instance.
		/// </summary>
		/// <remarks>
		/// Automatically loads the configuration asset if it has not already been loaded.
		/// </remarks>
		public static FileManagerConfig Config
		{
			get
			{
				if (cachedConfig == null)
				{
					LoadConfig();
				}

				return cachedConfig;
			}
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Loads the FileManager configuration asset from the Resources folder.
		/// </summary>
		private static void LoadConfig()
		{
			cachedConfig =
				Resources.Load<FileManagerConfig>(
					FileManagerConstants.CONFIG_RESOURCE_PATH);

			if (cachedConfig == null)
			{
				Debug.LogError(
					$"{FileManagerConstants.LOG_PREFIX} Failed to load FileManagerConfig asset from Resources folder. Please ensure it exists at the correct path.");
			}
			else
			{
				Debug.Log(
					$"{FileManagerConstants.LOG_PREFIX} FileManagerConfig loaded successfully from Resources.");
			}
		}

		#endregion
	}
}