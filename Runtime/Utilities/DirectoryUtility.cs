/**************************************************************************
 * 
 *  Project     : MayaMystic FileManager Framework
 *  File        : DirectoryUtility.cs
 *  Author      : Harsh Patel
 *  Company     : MayaMystic
 *  Version     : 1.0.0
 * 
 *  Description :
 *  Provides utility functions for directory operations
 *  such as creating, deleting, and checking directories.
 * 
 **************************************************************************/
using System.IO;
using UnityEngine;

namespace MayaMystic.FileManager.Utilities
{
	/// <summary>
	/// Utility class for directory operations.
	/// </summary>
	public static class DirectoryUtility
	{
		#region Create Directory

		/// <summary>
		/// Creates a directory if it does not exist.
		/// </summary>
		/// <param name="directoryPath">Target directory path.</param>
		public static void CreateDirectory(string directoryPath)
		{
			if (string.IsNullOrWhiteSpace(directoryPath))
			{
				Debug.LogError("[DirectoryUtility] Directory path is null or empty.");
				return;
			}

			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}
		}

		#endregion

		#region Directory Exists

		/// <summary>
		/// Checks whether directory exists.
		/// </summary>
		/// <param name="directoryPath">Directory path.</param>
		/// <returns>True if directory exists.</returns>
		public static bool DirectoryExists(string directoryPath)
		{
			if (string.IsNullOrWhiteSpace(directoryPath))
			{
				Debug.LogError("[DirectoryUtility] Directory path is null or empty.");
				return false;
			}

			return Directory.Exists(directoryPath);
		}

		#endregion

		#region Delete Directory

		/// <summary>
		/// Deletes a directory.
		/// </summary>
		/// <param name="directoryPath">Directory path.</param>
		/// <param name="recursive">Delete recursively.</param>
		public static void DeleteDirectory(string directoryPath, bool recursive = true)
		{
			if (string.IsNullOrWhiteSpace(directoryPath))
			{
				Debug.LogError("[DirectoryUtility] Directory path is null or empty.");
				return;
			}

			if (Directory.Exists(directoryPath))
			{
				Directory.Delete(directoryPath, recursive);
			}
		}

		#endregion

		#region Clear Directory

		/// <summary>
		/// Clears all files and subdirectories inside target directory.
		/// </summary>
		/// <param name="directoryPath">Directory path.</param>
		public static void ClearDirectory(string directoryPath)
		{
			if (string.IsNullOrWhiteSpace(directoryPath))
			{
				Debug.LogError("[DirectoryUtility] Directory path is null or empty.");
				return;
			}

			if (!Directory.Exists(directoryPath))
			{
				Debug.LogWarning($"[DirectoryUtility] Directory does not exist: {directoryPath}");
				return;
			}

			DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

			// Delete files
			foreach (FileInfo file in directoryInfo.GetFiles())
			{
				file.Delete();
			}

			// Delete subdirectories
			foreach (DirectoryInfo subDirectory in directoryInfo.GetDirectories())
			{
				subDirectory.Delete(true);
			}
		}

		#endregion

		#region Get Files

		/// <summary>
		/// Returns all files from directory.
		/// </summary>
		/// <param name="directoryPath">Directory path.</param>
		/// <param name="searchPattern">Search pattern.</param>
		/// <param name="recursive">Search recursively.</param>
		/// <returns>Array of file paths.</returns>
		public static string[] GetFiles(string directoryPath, string searchPattern = "*.*", bool recursive = false)
		{
			if (string.IsNullOrWhiteSpace(directoryPath))
			{
				Debug.LogError("[DirectoryUtility] Directory path is null or empty.");
				return new string[0];
			}

			if (!Directory.Exists(directoryPath))
			{
				Debug.LogWarning($"[DirectoryUtility] Directory does not exist: {directoryPath}");
				return new string[0];
			}

			SearchOption searchOption =
				recursive
				? SearchOption.AllDirectories
				: SearchOption.TopDirectoryOnly;

			return Directory.GetFiles(directoryPath, searchPattern, searchOption);
		}

		#endregion

		#region Get Subdirectories

		/// <summary>
		/// Returns all subdirectories.
		/// </summary>
		/// <param name="directoryPath">Directory path.</param>
		/// <returns>Array of subdirectory paths.</returns>
		public static string[] GetSubDirectories(string directoryPath)
		{
			if (string.IsNullOrWhiteSpace(directoryPath))
			{
				Debug.LogError("[DirectoryUtility] Directory path is null or empty.");
				return new string[0];
			}

			if (!Directory.Exists(directoryPath))
			{
				Debug.LogWarning($"[DirectoryUtility] Directory does not exist: {directoryPath}");
				return new string[0];
			}

			return Directory.GetDirectories(directoryPath);
		}

		#endregion
	}
}