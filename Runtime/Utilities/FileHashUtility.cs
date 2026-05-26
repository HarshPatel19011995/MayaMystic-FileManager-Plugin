/**************************************************************************
 * 
 *  Project     : MayaMystic FileManager Framework
 *  File        : FileHashUtility.cs
 *  Author      : Harsh Patel
 *  Company     : MayaMystic
 *  Version     : 1.0.0
 * 
 *  Description :
 *  Defines utility functions for generating hashes from strings, byte arrays, and files.
 * 
 **************************************************************************/
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace MayaMystic.FileManager.Utilities
{
	/// <summary>
	/// Utility class for generating hashes from strings, bytes, and files.
	/// </summary>
	public static class FileHashUtility
	{
		#region MD5 Hash

		/// <summary>
		/// Generates MD5 hash from string.
		/// </summary>
		/// <param name="input">Input string.</param>
		/// <returns>MD5 hash string.</returns>
		public static string GenerateMD5(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				Debug.LogError("[FileHashUtility] Input string is null or empty.");
				return string.Empty;
			}

			byte[] inputBytes = Encoding.UTF8.GetBytes(input);

			return GenerateMD5(inputBytes);
		}

		/// <summary>
		/// Generates MD5 hash from byte array.
		/// </summary>
		/// <param name="data">Input byte array.</param>
		/// <returns>MD5 hash string.</returns>
		public static string GenerateMD5(byte[] data)
		{
			if (data == null || data.Length == 0)
			{
				Debug.LogError("[FileHashUtility] Input byte array is null or empty.");
				return string.Empty;
			}

			using (MD5 md5 = MD5.Create())
			{
				byte[] hashBytes = md5.ComputeHash(data);

				return ConvertBytesToHex(hashBytes);
			}
		}

		#endregion

		#region SHA256 Hash

		/// <summary>
		/// Generates SHA256 hash from string.
		/// </summary>
		/// <param name="input">Input string.</param>
		/// <returns>SHA256 hash string.</returns>
		public static string GenerateSHA256(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				Debug.LogError("[FileHashUtility] Input string is null or empty.");
				return string.Empty;
			}

			byte[] inputBytes = Encoding.UTF8.GetBytes(input);

			return GenerateSHA256(inputBytes);
		}

		/// <summary>
		/// Generates SHA256 hash from byte array.
		/// </summary>
		/// <param name="data">Input byte array.</param>
		/// <returns>SHA256 hash string.</returns>
		public static string GenerateSHA256(byte[] data)
		{
			if (data == null || data.Length == 0)
			{
				Debug.LogError("[FileHashUtility] Input byte array is null or empty.");
				return string.Empty;
			}

			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] hashBytes = sha256.ComputeHash(data);

				return ConvertBytesToHex(hashBytes);
			}
		}

		#endregion

		#region File Hash

		/// <summary>
		/// Generates MD5 hash from file.
		/// </summary>
		/// <param name="filePath">Target file path.</param>
		/// <returns>MD5 hash string.</returns>
		public static string GenerateFileMD5(string filePath)
		{
			if (string.IsNullOrWhiteSpace(filePath))
			{
				Debug.LogError("[FileHashUtility] File path is null or empty.");
				return string.Empty;
			}

			if (!File.Exists(filePath))
			{
				Debug.LogError($"[FileHashUtility] File does not exist: {filePath}");
				return string.Empty;
			}

			byte[] fileBytes = File.ReadAllBytes(filePath);

			return GenerateMD5(fileBytes);
		}

		/// <summary>
		/// Generates SHA256 hash from file.
		/// </summary>
		/// <param name="filePath">Target file path.</param>
		/// <returns>SHA256 hash string.</returns>
		public static string GenerateFileSHA256(string filePath)
		{
			if (string.IsNullOrWhiteSpace(filePath))
			{
				Debug.LogError("[FileHashUtility] File path is null or empty.");
				return string.Empty;
			}

			if (!File.Exists(filePath))
			{
				Debug.LogError($"[FileHashUtility] File does not exist: {filePath}");
				return string.Empty;
			}

			byte[] fileBytes = File.ReadAllBytes(filePath);

			return GenerateSHA256(fileBytes);
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Converts byte array into hexadecimal string.
		/// </summary>
		/// <param name="bytes">Input bytes.</param>
		/// <returns>Hexadecimal string.</returns>
		private static string ConvertBytesToHex(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < bytes.Length; i++)
			{
				stringBuilder.Append(bytes[i].ToString("x2"));
			}

			return stringBuilder.ToString();
		}

		#endregion
	}
}