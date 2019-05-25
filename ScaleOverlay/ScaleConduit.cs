using Rhino;
using Rhino.Display;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleOverlay
{
    class ScaleConduit : DisplayConduit
    {
        public static string UnitStringFromUnitSystem(UnitSystem system)
        {
            switch (system)
            {
                case UnitSystem.None:
                    return "NaN";
                case UnitSystem.Angstroms:
                    return "as";
                case UnitSystem.Nanometers:
                    return "nm";
                case UnitSystem.Microns:
                    return "μm";
                case UnitSystem.Millimeters:
                    return "mm";
                case UnitSystem.Centimeters:
                    return "cm";
                case UnitSystem.Decimeters:
                    return "dm";
                case UnitSystem.Meters:
                    return "m";
                case UnitSystem.Dekameters:
                    return "dam";
                case UnitSystem.Hectometers:
                    return "hm";
                case UnitSystem.Kilometers:
                    return "km";
                case UnitSystem.Megameters:
                    return "Mm";
                case UnitSystem.Gigameters:
                    return "Gm";
                case UnitSystem.Microinches:
                    return "μin";
                case UnitSystem.Mils:
                    return "Mils";
                case UnitSystem.Inches:
                    return "in";
                case UnitSystem.Feet:
                    return "ft";
                case UnitSystem.Yards:
                    return "yd";
                case UnitSystem.Miles:
                    return "mi";
                case UnitSystem.PrinterPoints:
                    return "pp";
                case UnitSystem.PrinterPicas:
                    return "ppic";
                case UnitSystem.NauticalMiles:
                    return "nmi";
                case UnitSystem.AstronomicalUnits:
                    return "Au";
                case UnitSystem.LightYears:
                    return "ly";
                case UnitSystem.Parsecs:
                    return "ps";
                case UnitSystem.CustomUnits:
                    return "custom";
                case UnitSystem.Unset:
                    return "unset";
                default:
                    return "None";
            }
        }

        public static System.Drawing.Point FindBestFittingScaleLine(double pixelsPerUnit, System.Drawing.Point startPoint, out int foundScale)
        {
            double minimumDeviation = 1000000;
            System.Drawing.Point foundPoint = new System.Drawing.Point();
            foundScale = 0;

            foreach (var scale in Settings.Scales)
            {
                int unitScale = Convert.ToInt32(scale * pixelsPerUnit);
                var endPoint = LineEndFromScale(unitScale, startPoint);
                double targetLengthDeviation = Math.Abs(Math.Abs(endPoint.X - startPoint.X) - Settings.LineMaxLength);
                if (targetLengthDeviation < minimumDeviation)
                {
                    minimumDeviation = targetLengthDeviation;
                    foundPoint = endPoint;
                    foundScale = scale;
                }
            }

            return foundPoint;
        }

        public static System.Drawing.Point LineEndFromScale(int scale, System.Drawing.Point startPoint)
        {
            return new System.Drawing.Point(startPoint.X - scale, startPoint.Y);
        }

        public static double GetViewportScale(RhinoViewport viewport)
        {
            if (!viewport.IsPlanView) return 0;

            viewport.GetFrustumCenter(out var frustrumCenter);
            viewport.GetWorldToScreenScale(frustrumCenter, out var pixelsPerUnit);

            return pixelsPerUnit;
        }

        protected override void DrawForeground(DrawEventArgs e)
        {
            var bounds = e.Viewport.Bounds;
            var ptCorner = new System.Drawing.Point(bounds.Right - Settings.OffsetX, bounds.Bottom - Settings.OffsetY);
            var pixelsPerUnit = GetViewportScale(e.Viewport);
            if (pixelsPerUnit != 0)
            {
                // find best end point
                var ptEnd = FindBestFittingScaleLine(pixelsPerUnit, ptCorner, out var foundScale);

                // draw corresponding line
                e.Display.Draw2dLine(ptCorner, ptEnd, Settings.LineColor, Settings.LineThickness);

                // find boundary of text to draw
                var textOrigin = new Point2d(ptEnd.X, ptEnd.Y);
                string text = $"{foundScale} {UnitStringFromUnitSystem(RhinoDoc.ActiveDoc.ModelUnitSystem)}";
                var textRect = e.Display.Measure2dText(text, textOrigin, false, 0, Settings.TextHeight, "Arial");

                // move text origin in -X by boundary
                textOrigin.X = textOrigin.X - textRect.Width - Settings.TextGap;
                textOrigin.Y = textOrigin.Y + textRect.Height;

                // draw line ends
                e.Display.Draw2dLine(ptCorner, new System.Drawing.Point(ptCorner.X, ptCorner.Y + textRect.Height), Settings.LineColor, Settings.LineThickness);
                e.Display.Draw2dLine(ptEnd, new System.Drawing.Point(ptEnd.X, ptEnd.Y + textRect.Height), Settings.LineColor, Settings.LineThickness);

                // display the text
                e.Display.Draw2dText(text, Settings.TextColor, textOrigin, false, Settings.TextHeight);
            }
        }
    }
}
