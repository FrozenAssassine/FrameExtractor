
using Windows.Media.Editing;

namespace FrameExtractor.Models
{
    internal class VideoItem
    {
        public string VideoURL { get; set; }
        public int VideoPosition { get; set; }
        public MediaClip Clip { get; set; }
        public string ExportURL { get; set; }

        public VideoItem(string videoURL, int videoPosition = 0)
        {
            this.VideoURL = videoURL;
            this.VideoPosition = videoPosition;
        }
    }
}
