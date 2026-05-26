/// <summary>
/// Represents supported file data types within the FileManager framework.
/// </summary>
namespace MayaMystic.FileManager.Models
{
	/// <summary>
	/// Represents supported file data types within the FileManager framework.
	/// </summary>
	public enum FileDataType
	{
		/// <summary>
		/// JSON formatted data.
		/// </summary>
		Json,

		/// <summary>
		/// Plain text data.
		/// </summary>
		Text,

		/// <summary>
		/// Raw binary data.
		/// </summary>
		Binary,

		/// <summary>
		/// Image file data.
		/// </summary>
		Image,

		/// <summary>
		/// Audio file data.
		/// </summary>
		Audio,

		/// <summary>
		/// Video file data.
		/// </summary>
		Video,

		/// <summary>
		/// Unity AssetBundle data.
		/// </summary>
		AssetBundle,

		/// <summary>
		/// Custom or user-defined file data type.
		/// </summary>
		Custom
	}
}