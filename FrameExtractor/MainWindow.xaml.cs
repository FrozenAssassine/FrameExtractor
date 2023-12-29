using FFMpegCore;
using FrameExtractor.Helper;
using FrameExtractor.Models;
using Microsoft.UI.Xaml;
using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.Media.Core;
using Windows.Storage;

namespace FrameExtractor;

public sealed partial class MainWindow : Window
{
    private VideoItem CurrentVideo = null;
    private readonly FFmpegHelper ffmpegHelper = new FFmpegHelper();

    public MainWindow()
    {
        this.InitializeComponent();
    }

    private void LoadVideo(StorageFile file)
    {
        string path = file.Path;
        noVideoSelectedInfo.Visibility = Visibility.Collapsed;
        mediaPlayer.Visibility = Visibility.Visible;

        CurrentVideo = new VideoItem(path);
        mediaPlayer.Source = MediaSource.CreateFromUri(new Uri(path));
        currentExportPath.Text = path;
    }

    private async void Grid_Drop(object sender, DragEventArgs e)
    {
        if (e.DataView.Contains(StandardDataFormats.StorageItems))
        {
            var items = await e.DataView.GetStorageItemsAsync();
            if (items.Count == 0)
                return;
            
            LoadVideo(items[0] as StorageFile);
        }
    }
    private void Grid_DragOver(object sender, DragEventArgs e)
    {
        e.AcceptedOperation = DataPackageOperation.Copy;
    }
    private async void ExportFrame_Click(object sender, RoutedEventArgs e)
    {
        await ffmpegHelper.LoadFFmpeg(ffmpegDownloadPage);

        var res = FrameExporter.ExportFrame(CurrentVideo.VideoURL, CurrentVideo.ExportURL, mediaPlayer.MediaPlayer.Position); 
    }
    private async void PickExportPath_Click(object sender, RoutedEventArgs e)
    {
        var res = await FileHelper.PickExportFile();
        if (res.success)
            this.CurrentVideo.ExportURL = currentExportPath.Text = res.file.Path;
    }
    private void currentExportPath_TextChanged(object sender, Microsoft.UI.Xaml.Controls.TextChangedEventArgs e)
    {
        this.CurrentVideo.ExportURL = currentExportPath.Text;
    }
}
