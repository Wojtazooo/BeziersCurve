using System.Collections.Generic;

namespace BeziersCurve.Helpers
{
    internal class Constants
    {
        public const int DetectionRadius = 10;
        public const int RefreshTimeInMs = 20;
        public const int DotR = 5;
        public const int AnimationRange = 200;
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
    }
}
