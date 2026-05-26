using MayaMystic.FileManager.Core;
using MayaMystic.FileManager.Models;
using MayaMystic.FileManager.Utilities;
using MayaMystic.FileManager.Config.Constants;
using UnityEngine;

namespace MayaMystic.FileManager.Example
{
	/// <summary>
	/// Example usage for FileManager framework.
	/// </summary>
	public class FileManagerExample : MonoBehaviour
	{
		#region Unity Methods

		private void Start()
		{
			RunAllTests();
		}

		#endregion

		#region Test Runner

		/// <summary>
		/// Runs all FileManager tests.
		/// </summary>
		[ContextMenu("Run All Tests")]
		public void RunAllTests()
		{
			TestTextSaveLoad();

			TestJsonSaveLoad();

			TestBinarySaveLoad();

			TestHashGeneration();

			TestDeleteFile();
		}

		#endregion

		#region Text Test

		/// <summary>
		/// Tests text save/load.
		/// </summary>
		[ContextMenu("Test/Text Save Load")]
		public void TestTextSaveLoad()
		{
			string filePath =
				PathUtility.GenerateFilePath(
					FilePathType.PersistentData,
					"TextFiles",
					"TestText",
					FileExtensions.TEXT);

			FileManagerService.Instance.SaveText(
				filePath,
				"Hello MayaMystic FileManager!");

			string loadedText =
				FileManagerService.Instance.LoadText(filePath);

			Debug.Log(
				$"[Text Test] Loaded Text: {loadedText}");
		}

		#endregion

		#region JSON Test

		/// <summary>
		/// Tests JSON save/load.
		/// </summary>
		[ContextMenu("Test/JSON Save Load")]
		public void TestJsonSaveLoad()
		{
			string filePath =
				PathUtility.GenerateFilePath(
					FilePathType.PersistentData,
					"JsonFiles",
					"PlayerData",
					FileExtensions.JSON);

			PlayerData playerData = new PlayerData
			{
				PlayerName = "Harsh",
				PlayerLevel = 10,
				Health = 95.5f
			};

			FileManagerService.Instance.SaveJson(
				filePath,
				playerData);

			PlayerData loadedData =
				FileManagerService.Instance.LoadJson<PlayerData>(
					filePath);

			Debug.Log(
				$"[JSON Test] " +
				$"Name: {loadedData.PlayerName}, " +
				$"Level: {loadedData.PlayerLevel}, " +
				$"Health: {loadedData.Health}");
		}

		#endregion

		#region Binary Test

		/// <summary>
		/// Tests binary save/load.
		/// </summary>
		[ContextMenu("Test/Binary Save Load")]
		public void TestBinarySaveLoad()
		{
			string filePath =
				PathUtility.GenerateFilePath(
					FilePathType.PersistentData,
					"BinaryFiles",
					"TestBinary",
					FileExtensions.BINARY);

			byte[] testData =
			{
				1, 2, 3, 4, 5
			};

			FileManagerService.Instance.SaveBytes(
				filePath,
				testData);

			byte[] loadedData =
				FileManagerService.Instance.LoadBytes(filePath);

			if (loadedData != null)
			{
				Debug.Log(
					$"[Binary Test] Loaded Bytes Length: {loadedData.Length}");
			}
		}

		#endregion

		#region Hash Test

		/// <summary>
		/// Tests hash generation.
		/// </summary>
		[ContextMenu("Test/Hash Generation")]
		public void TestHashGeneration()
		{
			string input = "MayaMystic";

			string md5Hash =
				FileManagerService.Instance.GenerateMD5(input);

			string sha256Hash =
				FileManagerService.Instance.GenerateSHA256(input);

			Debug.Log(
				$"[Hash Test] MD5: {md5Hash}");

			Debug.Log(
				$"[Hash Test] SHA256: {sha256Hash}");
		}

		#endregion

		#region Delete File Test

		/// <summary>
		/// Tests file deletion.
		/// </summary>
		[ContextMenu("Test/Delete File")]
		public void TestDeleteFile()
		{
			string filePath =
				PathUtility.GenerateFilePath(
					FilePathType.PersistentData,
					"DeleteTest",
					"DeleteMe",
					FileExtensions.TEXT);

			FileManagerService.Instance.SaveText(
				filePath,
				"Temporary File");

			bool deleted =
				FileManagerService.Instance.DeleteFile(filePath);

			Debug.Log(
				$"[Delete Test] File Deleted: {deleted}");
		}

		#endregion
	}
}