
/// <summary>
/// Represents supported file path types within the FileManager framework.
/// </summary>

namespace MayaMystic.FileManager.Models
{
	/// <summary>
	/// Represents supported file path types within the FileManager framework.
	/// </summary>
	public enum FilePathType
	{
		/// <summary>
		/// Unity persistent data path used for application save data.
		/// </summary>
		PersistentData,

		/// <summary>
		/// Unity temporary cache path used for cached files.
		/// </summary>
		TemporaryCache,

		/// <summary>
		/// Unity StreamingAssets folder path.
		/// </summary>
		StreamingAssets,

		/// <summary>
		/// Custom user-defined file path.
		/// </summary>
		Custom
	}
}