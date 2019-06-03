using Rhino.Display;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleOverlay
{
    public static class Extensions
    {
        public static void DrawLine2d(this DisplayPipeline pipeline, Line2d line, Color lineColor, int lineThickness)
        {
            pipeline.Draw2dLine(line.From, line.To, lineColor, lineThickness);
        }
    }
}
