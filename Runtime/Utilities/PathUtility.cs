/**************************************************************************
 * 
 *  Project     : MayaMystic FileManager Framework
 *  File        : PathUtility.cs
 *  Author      : Harsh Patel
 *  Company     : MayaMystic
 *  Version     : 1.0.0
 * 
 *  Description :
 *  Defines utility functions for generating and managing file paths.
 *  Provides functions for combining paths, generating file paths,
 *  and ensuring directory existence.
 **************************************************************************/
using System.IO;
using UnityEngine;
using MayaMystic.FileManager.Models;
using MayaMystic.FileManager.Config.Constants;

namespace MayaMystic.FileManager.Utilities
{
	/// <summary>
	/// Utility class for generating and managing file paths.
	/// </summary>
	public static class PathUtility
	{
		#region Public Methods

		/// <summary>
		/// Returns the root path based on path type.
		/// </summary>
		/// <param name="pathType">Path type.</param>
		/// <returns>Root directory path.</returns>
		public static string GetRootPath(FilePathType pathType)
		{
			switch (pathType)
			{
				case FilePathType.PersistentData:
					return Application.persistentDataPath;

				case FilePathType.TemporaryCache:
					return Application.temporaryCachePath;

				case FilePathType.StreamingAssets:
					return Application.streamingAssetsPath;

				case FilePathType.Custom:
					return string.Empty;

				default:
					return Application.persistentDataPath;
			}
		}

		/// <summary>
		/// Combines path parts safely.
		/// </summary>
		/// <param name="pathParts">Path parts.</param>
		/// <returns>Combined path.</returns>
		public static string CombinePath(params string[] pathParts)
		{
			if (pathParts == null || pathParts.Length == 0)
			{
				Debug.LogError(
					$"{FileManagerConstants.LOG_PREFIX} Path parts are null or empty.");

				return string.Empty;
			}

			string combinedPath = pathParts[0];

			for (int i = 1; i < pathParts.Length; i++)
			{
				if (string.IsNullOrWhiteSpace(pathParts[i]))
				{
					continue;
				}

				combinedPath =
					Path.Combine(combinedPath, pathParts[i]);
			}

			return combinedPath;
		}

		/// <summary>
		/// Generates a full file path.
		/// </summary>
		/// <param name="pathType">Base path type.</param>
		/// <param name="relativeFolderPath">
		/// Relative folder path.
		/// Supports nested folders.
		/// </param>
		/// <param name="fileName">File name.</param>
		/// <param name="extension">File extension without dot.</param>
		/// <returns>Generated full file path.</returns>
		public static string GenerateFilePath(
			FilePathType pathType,
			string relativeFolderPath,
			string fileName,
			string extension)
		{
			string rootPath =
				GetRootPath(pathType);

			string directoryPath =
				CombinePath(rootPath, relativeFolderPath);

			EnsureDirectoryExists(directoryPath);

			string sanitizedFileName =
				SanitizeFileName(fileName);

			string finalFileName =
				$"{sanitizedFileName}.{extension}";

			return CombinePath(directoryPath, finalFileName);
		}

		/// <summary>
		/// Ensures the directory exists.
		/// </summary>
		/// <param name="directoryPath">Directory path.</param>
		public static void EnsureDirectoryExists(string directoryPath)
		{
			if (string.IsNullOrWhiteSpace(directoryPath))
			{
				Debug.LogError(
					$"{FileManagerConstants.LOG_PREFIX} Directory path is null or empty.");

				return;
			}

			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}
		}

		/// <summary>
		/// Sanitizes file name by removing invalid characters.
		/// </summary>
		/// <param name="fileName">Original file name.</param>
		/// <returns>Sanitized file name.</returns>
		public static string SanitizeFileName(string fileName)
		{
			if (string.IsNullOrWhiteSpace(fileName))
			{
				Debug.LogError(
					$"{FileManagerConstants.LOG_PREFIX} File name is null or empty.");

				return string.Empty;
			}

			char[] invalidChars =
				Path.GetInvalidFileNameChars();

			foreach (char invalidChar in invalidChars)
			{
				fileName =
					fileName.Replace(invalidChar.ToString(), "_");
			}

			return fileName;
		}

		#endregion
	}
}