using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeziersCurve
{
    internal class Constants
    {
        public const int DETECTION_RADIUS = 10;
        public const int REFRESH_TIME_IN_MS = 10;
        public const int DOT_R = 5;
        public const int ANIMATION_RANGE = 200;
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
    }
}
