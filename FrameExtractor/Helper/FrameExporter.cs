using FFMpegCore;
using System;
using System.Diagnostics;

namespace FrameExtractor.Helper;

internal class FrameExporter
{
    public static bool ExportFrame(string input, string output, TimeSpan frameTime)
    {
        return FFMpeg.Snapshot(input, output, null, frameTime);
    }
}