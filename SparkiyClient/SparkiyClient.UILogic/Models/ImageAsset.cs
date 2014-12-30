using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using MetroLog;

namespace SparkiyClient.UILogic.Models
{
	public class ImageAsset : AssetWithData<BitmapImage>
	{
		private static readonly ILogger Log = LogManagerFactory.DefaultLogManager.GetLogger<ImageAsset>();

		/// <summary>
		/// Gets the data asynchronously from given path.
		/// </summary>
		/// <returns></returns>
#pragma warning disable 1998
		public override async Task GetDataAsync()
		{
			this.Data = new BitmapImage(new Uri(this.Path, UriKind.Absolute));
			Log.Debug("Loaded ImageAsset \"{0}\"", this.Name);
		}
#pragma warning restore 1998
	}
}