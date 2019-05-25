using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleOverlay
{
    public static class Settings
    {
        // changeable settings
        public static int OffsetX = 10;
        public static int OffsetY = 10;
        public static int LineThickness = 2;
        public static int LineMaxLength = 100;
        public static Color LineColor = Color.FromArgb(40, 40, 40);
        public static int TextGap = 10;
        public static int TextHeight = 12;
        public static Color TextColor = Color.Black;
        public static int LineSubdivisionCount = 5;
        public static double LineSubdividerLengthFactor = 0.5;

        // defaults for changeable settings
        private static int DefaultOffsetX = 10;
        private static int DefaultOffsetY = 10;
        private static int DefaultLineThickness = 2;
        private static int DefaultLineMaxLength = 100;
        private static Color DefaultLineColor = Color.FromArgb(40, 40, 40);
        private static int DefaultTextGap = 10;
        private static int DefaultTextHeight = 12;
        private static Color DefaultTextColor = Color.Black;
        private static int DefaultLineSubdivisionCount = 5;
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

        public static void RestoreDefaults()
        {
            OffsetX = DefaultOffsetX;
            OffsetY = DefaultOffsetY;
            LineThickness = DefaultLineThickness;
            LineColor = DefaultLineColor;
            LineMaxLength = DefaultLineMaxLength;
            TextGap = DefaultTextGap;
            TextHeight = DefaultTextHeight;
            TextColor = DefaultTextColor;
        }

        //public static void SetOffsetX(int offset)
        //{
        //    if (offset <= 0 || offset > MaxOffsetX) OffsetX = DefaultOffsetX;
        //    else OffsetX = offset;
        //}

        //public static void SetOffsetY(int offset)
        //{
        //    if (offset <= 0 || offset > MaxOffsetY) OffsetY = DefaultOffsetY;
        //    else OffsetY = offset;
        //}

        //public static void SetLineThickness(int thickness)
        //{
        //    if (thickness <= 0 || thickness > MaxLineThickness) LineThickness = DefaultLineThickness;
        //    else LineThickness = thickness;
        //}

        //public static void SetLineMaxLength(int length)
        //{
        //    if (length <= 0 || length > MaxLineMaxLength) LineMaxLength = DefaultLineMaxLength;

        //}
    }
}
