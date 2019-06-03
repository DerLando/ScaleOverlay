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
    /// <summary>
    /// Custom implementation of Rhino.Display.DisplayConduit to handle drawing of scale in rhinoviewports
    /// <see cref="Rhino.Display.DisplayConduit"/>
    /// </summary>
    class ScaleConduit : DisplayConduit
    {
        /// <summary>
        /// Helper to determine the right amount of subdivisions for a given integer scale
        /// </summary>
        /// <param name="scale">scale to calculate subdivisioncount for</param>
        /// <returns>subdivisioncount as int</returns>
        public static int GetSubDivisionCount(int scale)
        {
            if (scale > 1000) scale /= 10;
            if (scale > 250) scale /= 10;
            if (scale > 25) scale /= 10;
            if (scale % 10 == 0) return 10;
            if (scale % 5 == 0) return 5;
            if (scale % 2 == 0) return 2;
            return 0;
        }

        /// <summary>
        /// Subdivides a line by a given number of subdivisions
        /// </summary>
        /// <param name="line">line to subdivide</param>
        /// <param name="subDividionCount">number of subdivisions</param>
        /// <returns>multidimensional array of start and end points of subdivision lines</returns>
        public static System.Drawing.Point[] SubdivideLine(Line2d line, int subDividionCount)
        {
            // create an array for subdivision points
            System.Drawing.Point[] points = new System.Drawing.Point[subDividionCount - 1];

            // calculate length of a single subdivision step
            // there is a possiblity of a round of error here
            // e.g.: 95 / 10 = 9
            int divisionLength = line.Length / subDividionCount;
            int[] divisionStepLengths = Enumerable.Repeat(divisionLength, points.Length).ToArray();

            // clean up round error if any
            if(divisionLength * subDividionCount != line.Length)
            {
                var i = 0;
                while (divisionStepLengths.Sum() + divisionLength < line.Length)
                {
                    if (i % 2 == 0) divisionStepLengths[i] += 1;
                    else divisionStepLengths[divisionStepLengths.Length - i] += 1;

                    i += 1;
                }
            }

            // iterate over points array and fill it
            var startPoint = line.From;
            for (int i = 0; i < divisionStepLengths.Length; i++)
            {
                points[i] = new System.Drawing.Point(startPoint.X - divisionStepLengths[i], line.From.Y);
                startPoint = points[i];
            }

            return points;
        }

        public static Line2d CreateSubdividerLine(System.Drawing.Point startPoint, int lineLength)
        {
            return new Line2d(startPoint, new System.Drawing.Point(startPoint.X, startPoint.Y + lineLength));
        }

        /// <summary>
        /// Simple switch statement to return the abbreviation of a UnitSystem
        /// <see cref="Rhino.UnitSystem"/>
        /// </summary>
        /// <param name="system">UnitSystem to get abbreviation for</param>
        /// <returns></returns>
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

        /// <summary>
        /// Function to determine the best fitting line and scale for a given scalefactor in pixels per unit
        /// </summary>
        /// <param name="pixelsPerUnit">scalefactor</param>
        /// <param name="startPoint">startpoint of line</param>
        /// <param name="foundScale">scale corresponding to found line</param>
        /// <returns>end point of line</returns>
        public static Line2d FindBestFittingScaleLine(double pixelsPerUnit, System.Drawing.Point startPoint, out int foundScale)
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

            return new Line2d(startPoint, foundPoint);
        }

        public static System.Drawing.Point LineEndFromScale(int scale, System.Drawing.Point startPoint)
        {
            return new System.Drawing.Point(startPoint.X - scale, startPoint.Y);
        }

        /// <summary>
        /// Gets scale factor of a given viewport in pixels per unit
        /// </summary>
        /// <param name="viewport">viewport to calculate scale factor for</param>
        /// <returns>scale factor in pixels per unit</returns>
        public static double GetViewportScale(RhinoViewport viewport)
        {
            if (!viewport.IsPlanView) return 0;

            viewport.GetFrustumCenter(out var frustrumCenter);
            viewport.GetWorldToScreenScale(frustrumCenter, out var pixelsPerUnit);

            return pixelsPerUnit;
        }

        /// <summary>
        /// Override standard behaviour of DrawForeground to draw scale on screen
        /// <see cref="Rhino.Display.DisplayConduit.DrawForeground(DrawEventArgs)"/>
        /// </summary>
        /// <param name="e">drawEventArgs e</param>
        protected override void DrawForeground(DrawEventArgs e)
        {
            var bounds = e.Viewport.Bounds;
            var ptCorner = new System.Drawing.Point(bounds.Right - Settings.OffsetX, bounds.Bottom - Settings.OffsetY);
            var pixelsPerUnit = GetViewportScale(e.Viewport);
            if (pixelsPerUnit != 0)
            {
                // find best line
                var line = FindBestFittingScaleLine(pixelsPerUnit, ptCorner, out var foundScale);

                // draw corresponding line
                e.Display.DrawLine2d(line, Settings.LineColor, Settings.LineThickness);

                // find boundary of text to draw
                var textOrigin = new Point2d(line.To.X, line.To.Y);
                string text = $"{foundScale} {UnitStringFromUnitSystem(RhinoDoc.ActiveDoc.ModelUnitSystem)}";
                var textRect = e.Display.Measure2dText(text, textOrigin, false, 0, Settings.TextHeight, "Arial");

                // move text origin in -X by boundary
                textOrigin.X = textOrigin.X - textRect.Width - Settings.TextGap;
                textOrigin.Y = textOrigin.Y + textRect.Height;

                // draw line ends
                e.Display.Draw2dLine(ptCorner, new System.Drawing.Point(ptCorner.X, ptCorner.Y + textRect.Height), Settings.LineColor, Settings.LineThickness);
                e.Display.Draw2dLine(line.To, new System.Drawing.Point(line.To.X, line.To.Y + textRect.Height), Settings.LineColor, Settings.LineThickness);

                // draw line divisors
                int subdivisionCount = GetSubDivisionCount(foundScale);
                if(subdivisionCount != 0)
                {
                    int lineLength = Convert.ToInt32(Settings.LineSubdividerLengthFactor * textRect.Height);
                    var subdivisonPoints = SubdivideLine(line, subdivisionCount);
                    for (int i = 0; i < subdivisonPoints.Length; i++)
                    {
                        e.Display.DrawLine2d(CreateSubdividerLine(subdivisonPoints[i], lineLength), Settings.LineColor, Convert.ToInt32(Settings.LineThickness * Settings.LineSubdividerLengthFactor));
                    }

                }

                // display the text
                e.Display.Draw2dText(text, Settings.TextColor, textOrigin, false, Settings.TextHeight);
            }
        }
    }
}
