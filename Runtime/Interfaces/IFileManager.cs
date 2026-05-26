/**************************************************************************
 * 
 *  Project     : MayaMystic FileManager Framework
 *  File        : IFileManager.cs
 *  Author      : Harsh Patel
 *  Company     : MayaMystic
 *  Version     : 1.0.0
 * 
 *  Description :
 *  Defines the core contract for file management operations.
 *  Provides abstraction for file reading, writing,
 *  deletion, and JSON serialization functionality.
 * 
 **************************************************************************/

using System;

namespace MayaMystic.FileManager.Interfaces
{
	/// <summary>
	/// Defines the core contract for file management operations.
	/// </summary>
	/// <remarks>
	/// Provides abstraction for file existence checks,
	/// file deletion, text handling, binary handling,
	/// and JSON serialization operations.
	/// </remarks>
	public interface IFileManager
	{
		#region File Exists

		/// <summary>
		/// Checks whether a file exists at the specified path.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <returns>
		/// True if the file exists; otherwise false.
		/// </returns>
		bool FileExists(string fullPath);

		#endregion

		#region Delete File

		/// <summary>
		/// Deletes a file from disk.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <returns>
		/// True if the file was deleted successfully; otherwise false.
		/// </returns>
		bool DeleteFile(string fullPath);

		#endregion

		#region Save Text

		/// <summary>
		/// Saves text content to a file.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <param name="content">Text content to save.</param>
		void SaveText(string fullPath, string content);

		#endregion

		#region Load Text

		/// <summary>
		/// Loads text content from a file.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <returns>Loaded text content.</returns>
		string LoadText(string fullPath);

		#endregion

		#region Save Bytes

		/// <summary>
		/// Saves binary data to a file.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <param name="data">Binary data to save.</param>
		void SaveBytes(string fullPath, byte[] data);

		#endregion

		#region Load Bytes

		/// <summary>
		/// Loads binary data from a file.
		/// </summary>
		/// <param name="fullPath">Absolute file path.</param>
		/// <returns>Loaded binary file data.</returns>
		byte[] LoadBytes(string fullPath);

		#endregion

		#region Save JSON

		/// <summary>
		/// Serializes and saves an object as a JSON file.
		/// </summary>
		/// <typeparam name="T">Object type.</typeparam>
		/// <param name="fullPath">Absolute file path.</param>
		/// <param name="data">Object data to serialize.</param>
		void SaveJson<T>(string fullPath, T data);

		#endregion

		#region Load JSON

		/// <summary>
		/// Loads and deserializes a JSON file into an object.
		/// </summary>
		/// <typeparam name="T">Target object type.</typeparam>
		/// <param name="fullPath">Absolute file path.</param>
		/// <returns>Deserialized object instance.</returns>
		T LoadJson<T>(string fullPath);

		#endregion
	}
}