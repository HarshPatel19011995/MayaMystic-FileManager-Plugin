/**************************************************************************
 * 
 *  Project     : MayaMystic FileManager Framework
 *  File        : FileReadWriteUtility.cs
 *  Author      : Harsh Patel
 *  Company     : MayaMystic
 *  Version     : 1.0.0
 * 
 *  Description :
 *  Defines the core contract for file management operations.
 * 
 **************************************************************************/
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace MayaMystic.FileManager.Utilities
{
	/// <summary>
	/// Utility class for file read and write operations.
	/// </summary>
	public static class FileReadWriteUtility
	{
		#region Save Text

		/// <summary>
		/// Saves text content to file.
		/// </summary>
		/// <param name="filePath">Target file path.</param>
		/// <param name="content">Text content.</param>
		public static void SaveText(string filePath, string content)
		{
			try
			{
				File.WriteAllText(filePath, content, Encoding.UTF8);
			}
			catch (Exception exception)
			{
				Debug.LogError(
					$"[FileReadWriteUtility] Failed to save text file.\n" +
					$"Path: {filePath}\n" +
					$"Exception: {exception}");
			}
		}

		#endregion

		#region Load Text

		/// <summary>
		/// Loads text content from file.
		/// </summary>
		/// <param name="filePath">Target file path.</param>
		/// <returns>Loaded text content.</returns>
		public static string LoadText(string filePath)
		{
			try
			{
				if (!File.Exists(filePath))
				{
					Debug.LogWarning(
						$"[FileReadWriteUtility] File does not exist: {filePath}");

					return string.Empty;
				}

				return File.ReadAllText(filePath, Encoding.UTF8);
			}
			catch (Exception exception)
			{
				Debug.LogError(
					$"[FileReadWriteUtility] Failed to load text file.\n" +
					$"Path: {filePath}\n" +
					$"Exception: {exception}");

				return string.Empty;
			}
		}

		#endregion

		#region Save Bytes

		/// <summary>
		/// Saves binary data to file.
		/// </summary>
		/// <param name="filePath">Target file path.</param>
		/// <param name="data">Binary data.</param>
		public static void SaveBytes(string filePath, byte[] data)
		{
			try
			{
				File.WriteAllBytes(filePath, data);
			}
			catch (Exception exception)
			{
				Debug.LogError(
					$"[FileReadWriteUtility] Failed to save binary file.\n" +
					$"Path: {filePath}\n" +
					$"Exception: {exception}");
			}
		}

		#endregion

		#region Load Bytes

		/// <summary>
		/// Loads binary data from file.
		/// </summary>
		/// <param name="filePath">Target file path.</param>
		/// <returns>Binary file data.</returns>
		public static byte[] LoadBytes(string filePath)
		{
			try
			{
				if (!File.Exists(filePath))
				{
					Debug.LogWarning(
						$"[FileReadWriteUtility] File does not exist: {filePath}");

					return null;
				}

				return File.ReadAllBytes(filePath);
			}
			catch (Exception exception)
			{
				Debug.LogError(
					$"[FileReadWriteUtility] Failed to load binary file.\n" +
					$"Path: {filePath}\n" +
					$"Exception: {exception}");

				return null;
			}
		}

		#endregion

		#region Save JSON

		/// <summary>
		/// Saves object as JSON file.
		/// </summary>
		/// <typeparam name="T">Object type.</typeparam>
		/// <param name="filePath">Target file path.</param>
		/// <param name="data">Object data.</param>
		/// <param name="indented">Pretty print JSON.</param>
		public static void SaveJson<T>(string filePath,T data,bool indented = true)
		{
			try
			{
				Formatting formatting = indented? Formatting.Indented: Formatting.None;
				string json = JsonConvert.SerializeObject(data, formatting);
				SaveText(filePath, json);
			}
			catch (Exception exception)
			{
				Debug.LogError(
					$"[FileReadWriteUtility] Failed to save JSON file.\n" +
					$"Path: {filePath}\n" +
					$"Exception: {exception}");
			}
		}

		#endregion

		#region Load JSON

		/// <summary>
		/// Loads JSON object from file.
		/// </summary>
		/// <typeparam name="T">Object type.</typeparam>
		/// <param name="filePath">Target file path.</param>
		/// <returns>Deserialized object.</returns>
		public static T LoadJson<T>(string filePath)
		{
			try
			{
				string json = LoadText(filePath);

				if (string.IsNullOrWhiteSpace(json))
				{
					return default;
				}

				return JsonConvert.DeserializeObject<T>(json);
			}
			catch (Exception exception)
			{
				Debug.LogError(
					$"[FileReadWriteUtility] Failed to load JSON file.\n" +
					$"Path: {filePath}\n" +
					$"Exception: {exception}");

				return default;
			}
		}

		#endregion
	}
}