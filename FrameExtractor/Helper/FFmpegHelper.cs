using FFMpegCore;
using Microsoft.UI.Xaml;
using System.Threading.Tasks;
using Windows.Storage;

namespace FrameExtractor.Helper
{
    internal class FFmpegHelper
    {
        private string FFmpegPath = ApplicationData.Current.LocalFolder.Path + @"\FFmpeg";

        public async Task LoadFFmpeg(FrameworkElement progressElement)
        {
            progressElement.Visibility = Visibility.Visible;
            await Xabe.FFmpeg.Downloader.FFmpegDownloader.GetLatestVersion(Xabe.FFmpeg.Downloader.FFmpegVersion.Official, FFmpegPath);
            progressElement.Visibility = Visibility.Collapsed;

            GlobalFFOptions.Configure(option => option.BinaryFolder = FFmpegPath);
        }
    }
}
