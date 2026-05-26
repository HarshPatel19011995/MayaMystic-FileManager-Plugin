/**************************************************************************
 * 
 *  Project     : MayaMystic FileManager Framework
 *  File        : FileManagerService.cs
 *  Author      : Harsh Patel
 *  Company     : MayaMystic
 *  Version     : 1.0.0
 * 
 *  Description :
 *  Main FileManager service implementation.
 *  Provides centralized access to file operations,
 *  serialization, hashing, and file system utilities.
 * 
 **************************************************************************/

using MayaMystic.FileManager.Interfaces;
using MayaMystic.FileManager.Utilities;
using UnityEngine;

namespace MayaMystic.FileManager.Core
{
	/// <summary>
	/// Main FileManager service implementation.
	/// Provides centralized access to all file operations.
	/// </summary>
	/// <remarks>
	/// This service acts as the primary entry point for
	/// reading, writing, deleting, serializing, and hashing files.
	/// </remarks>
	public class FileManagerService : IFileManager
	{
		#region Singleton

		/// <summary>
		/// Singleton instance of the FileManager service.
		/// </summary>
		private static FileManagerService instance;

		/// <summary>
		/// Gets the global FileManager service instance.
		/// </summary>
		public static FileManagerService Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new FileManagerService();
				}

				return instance;
			}
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Prevents external instantiation of the FileManager service.
		/// </summary>
		private FileManagerService()
		{
		}

		#endregion

		#region File Exists

		/// <summary>
		/// Checks whether a file exists at the specified path.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <returns>
		/// True if the file exists; otherwise false.
		/// </returns>
		public bool FileExists(string fullPath)
		{
			return System.IO.File.Exists(fullPath);
		}

		#endregion

		#region Delete File

		/// <summary>
		/// Deletes the target file from disk.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <returns>
		/// True if the file was deleted successfully; otherwise false.
		/// </returns>
		public bool DeleteFile(string fullPath)
		{
			if (!FileExists(fullPath))
			{
				Debug.LogWarning(
					$"[FileManager] File does not exist: {fullPath}");

				return false;
			}

			try
			{
				System.IO.File.Delete(fullPath);

				return true;
			}
			catch (System.Exception exception)
			{
				Debug.LogError(
					$"[FileManager] Failed to delete file.\n" +
					$"Path: {fullPath}\n" +
					$"Exception: {exception}");

				return false;
			}
		}

		#endregion

		#region Save Text

		/// <summary>
		/// Saves text content to a file.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <param name="content">Text content to save.</param>
		public void SaveText(string fullPath, string content)
		{
			string directoryPath =
				System.IO.Path.GetDirectoryName(fullPath);

			DirectoryUtility.CreateDirectory(directoryPath);

			FileReadWriteUtility.SaveText(fullPath, content);
		}

		#endregion

		#region Load Text

		/// <summary>
		/// Loads text content from a file.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <returns>Loaded text content.</returns>
		public string LoadText(string fullPath)
		{
			return FileReadWriteUtility.LoadText(fullPath);
		}

		#endregion

		#region Save Bytes

		/// <summary>
		/// Saves binary data to a file.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <param name="data">Binary data to save.</param>
		public void SaveBytes(string fullPath, byte[] data)
		{
			string directoryPath =
				System.IO.Path.GetDirectoryName(fullPath);

			DirectoryUtility.CreateDirectory(directoryPath);

			FileReadWriteUtility.SaveBytes(fullPath, data);
		}

		#endregion

		#region Load Bytes

		/// <summary>
		/// Loads binary data from a file.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <returns>Loaded binary data.</returns>
		public byte[] LoadBytes(string fullPath)
		{
			return FileReadWriteUtility.LoadBytes(fullPath);
		}

		#endregion

		#region Save JSON

		/// <summary>
		/// Serializes and saves an object as a JSON file.
		/// </summary>
		/// <typeparam name="T">Object type.</typeparam>
		/// <param name="fullPath">Absolute file path.</param>
		/// <param name="data">Object data to serialize.</param>
		public void SaveJson<T>(string fullPath, T data)
		{
			string directoryPath =
				System.IO.Path.GetDirectoryName(fullPath);

			DirectoryUtility.CreateDirectory(directoryPath);

			FileReadWriteUtility.SaveJson(fullPath, data);
		}

		#endregion

		#region Load JSON

		/// <summary>
		/// Loads and deserializes a JSON file into an object.
		/// </summary>
		/// <typeparam name="T">Target object type.</typeparam>
		/// <param name="fullPath">Absolute file path.</param>
		/// <returns>Deserialized object instance.</returns>
		public T LoadJson<T>(string fullPath)
		{
			return FileReadWriteUtility.LoadJson<T>(fullPath);
		}

		#endregion

		#region Hash Helpers

		/// <summary>
		/// Generates an MD5 hash from the specified string.
		/// </summary>
		/// <param name="input">Input string.</param>
		/// <returns>Generated MD5 hash string.</returns>
		public string GenerateMD5(string input)
		{
			return FileHashUtility.GenerateMD5(input);
		}

		/// <summary>
		/// Generates a SHA256 hash from the specified string.
		/// </summary>
		/// <param name="input">Input string.</param>
		/// <returns>Generated SHA256 hash string.</returns>
		public string GenerateSHA256(string input)
		{
			return FileHashUtility.GenerateSHA256(input);
		}

		#endregion
	}
}