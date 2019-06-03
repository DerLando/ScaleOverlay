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

        public static Rhino.DocObjects.Font ToRhinoFont(this Eto.Drawing.Font etoFont)
        {
            Rhino.DocObjects.Font.FontStyle rhinoStyle = Rhino.DocObjects.Font.FontStyle.Upright;
            Rhino.DocObjects.Font.FontWeight rhinoWeight = Rhino.DocObjects.Font.FontWeight.Normal;

            if (etoFont.FontStyle == Eto.Drawing.FontStyle.Italic) rhinoStyle = Rhino.DocObjects.Font.FontStyle.Italic;
            if (etoFont.Bold) rhinoWeight = Rhino.DocObjects.Font.FontWeight.Bold;

            return new Rhino.DocObjects.Font(etoFont.FamilyName, rhinoWeight, rhinoStyle, etoFont.Underline, etoFont.Strikethrough);
        }

        public static Eto.Drawing.FontStyle ToEtoFontStyle(this Rhino.DocObjects.Font rhinoFont)
        {
            if (rhinoFont.Bold) return Eto.Drawing.FontStyle.Bold;
            if (rhinoFont.Italic) return Eto.Drawing.FontStyle.Italic;
            return Eto.Drawing.FontStyle.None;
        }

        public static Eto.Drawing.Font ToEtoFont(this Rhino.DocObjects.Font rhinoFont)
        {
            return new Eto.Drawing.Font(rhinoFont.EnglishFamilyName, Settings.TextHeight, rhinoFont.ToEtoFontStyle());
        }
    }
}
