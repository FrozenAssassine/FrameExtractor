using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace FrameExtractor.Helper
{
    internal class FileHelper
    {
        public static async Task<(StorageFile file, bool success)> PickExportFile()
        {
            var openPicker = new FileOpenPicker();

            // Initialize the file picker with the window handle (HWND).
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, App.HWND_Handle);

            // Set options for your file picker
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.FileTypeFilter.Add("*");
            openPicker.FileTypeFilter.Add(".jpg");

            var file = await openPicker.PickSingleFileAsync();
            return (file, file != null);
        }
    }
}
