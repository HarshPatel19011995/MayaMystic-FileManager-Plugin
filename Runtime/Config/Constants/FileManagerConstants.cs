namespace MayaMystic.FileManager.Config.Constants
{
	/// <summary>
	/// Global constants used by the MayaMystic FileManager framework.
	/// </summary>
	public static class FileManagerConstants
	{
		#region Resource Paths

		/// <summary>
		/// Resource path for the FileManager configuration asset.
		/// </summary>
		/// <remarks>
		/// Expected location:
		/// Assets/Resources/FileManagerConfig.asset
		/// </remarks>
		public const string CONFIG_RESOURCE_PATH =
			"FileManagerConfig";

		#endregion

		#region Default Folder Names

		/// <summary>
		/// Default folder name used for saved application data.
		/// </summary>
		public const string DEFAULT_SAVE_FOLDER =
			"SaveData";

		/// <summary>
		/// Default folder name used for cached files.
		/// </summary>
		public const string DEFAULT_CACHE_FOLDER =
			"Cache";

		/// <summary>
		/// Default folder name used for downloaded files.
		/// </summary>
		public const string DEFAULT_DOWNLOAD_FOLDER =
			"Downloads";

		#endregion

		#region Logging Prefix

		/// <summary>
		/// Log prefix used for FileManager-related debug messages.
		/// </summary>
		public const string LOG_PREFIX =
			"[MayaMystic.FileManager]";

		#endregion
	}
}