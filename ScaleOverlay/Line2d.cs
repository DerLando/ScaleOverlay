using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleOverlay
{
    /// <summary>
    /// Helper class to clean up handling of 2d lines
    /// </summary>
    public class Line2d
    {
        #region public properties

        public Point From { get; set; }
        public Point To { get; set; }

        #endregion

        #region Auto implemented properties

        public int Length => Math.Abs(From.X - To.X);

        #endregion

        public Line2d(Point from, Point to)
        {
            From = from;
            To = to;
        }

    }
}
