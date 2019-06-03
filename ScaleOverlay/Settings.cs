using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleOverlay
{
    /// <summary>
    /// Settings class to store and change all relevant settings
    /// </summary>
    public static class Settings
    {
        // changeable settings
        public static int OffsetX => ScaleOverlayPlugIn.Instance.Settings.GetInteger("OffsetX", DefaultOffsetX, MinOffsetX, MaxOffsetX);
        public static int OffsetY => ScaleOverlayPlugIn.Instance.Settings.GetInteger("OffsetY", DefaultOffsetY, MinOffsetY, MaxOffsetY);
        public static int LineThickness => ScaleOverlayPlugIn.Instance.Settings.GetInteger("LineThickness", DefaultLineThickness, MinLineThickness, MaxLineThickness);
        public static int LineMaxLength => ScaleOverlayPlugIn.Instance.Settings.GetInteger("LineMaxLength", DefaultLineMaxLength, MinLineMaxLength, MaxLineMaxLength);
        public static Color LineColor => ScaleOverlayPlugIn.Instance.Settings.GetColor("LineColor", DefaultLineColor);
        public static int TextGap => ScaleOverlayPlugIn.Instance.Settings.GetInteger("TextGap", DefaultTextGap, MinTextGap, MaxTextGap);
        public static int TextHeight => ScaleOverlayPlugIn.Instance.Settings.GetInteger("TextHeight", DefaultTextHeight, MinTextHeight, MaxTextHeight);
        public static Color TextColor => ScaleOverlayPlugIn.Instance.Settings.GetColor("TextColor", DefaultTextColor);
        public static Rhino.DocObjects.Font TextFont => new Rhino.DocObjects.Font(ScaleOverlayPlugIn.Instance.Settings.GetString("TextFontFamilyFaceName", DefaultTextFont.FamilyPlusFaceName));
        public static double LineSubdividerLengthFactor => ScaleOverlayPlugIn.Instance.Settings.GetDouble("LineSubdividerLengthFactor", DefaultLineSubdividerLengthFactor);
        public static ScaleStyle Style => ScaleOverlayPlugIn.Instance.Settings.GetEnumValue<ScaleStyle>("ScaleStyle", ScaleStyle.Ruler);

        // defaults for changeable settings
        private static int DefaultOffsetX = 10;
        private static int DefaultOffsetY = 10;
        private static int DefaultLineThickness = 2;
        private static int DefaultLineMaxLength = 100;
        private static Color DefaultLineColor = Color.FromArgb(40, 40, 40);
        private static int DefaultTextGap = 10;
        private static int DefaultTextHeight = 12;
        private static Color DefaultTextColor = Color.Black;
        public static Rhino.DocObjects.Font DefaultTextFont = new Rhino.DocObjects.Font("Arial");
        private static double DefaultLineSubdividerLengthFactor = 0.5;


        // fixed settings
        public static int[] Scales = new[] { 1, 2, 5, 10, 25, 50, 100, 250, 500, 1000, 2000, 5000, 10000 };
        public static int MaxOffsetX = 100;
        public static int MinOffsetX = 0;
        public static int MaxOffsetY = 100;
        public static int MinOffsetY = 0;
        public static int MaxLineThickness = 10;
        public static int MinLineThickness = 1;
        public static int MaxLineMaxLength = 400;
        public static int MinLineMaxLength = 1;
        public static int MaxTextGap = 100;
        public static int MinTextGap = 0;
        public static int MaxTextHeight = 40;
        public static int MinTextHeight = 1;
        public static int MinSubdivisionCount = 0;
        public static int MaxSubdivisionCount = 50;
        public static double MinSubdividerFactor = 0.01;
        public static double MaxSubdividerFactor = 1.00;

    }
}
