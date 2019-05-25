using System;
using System.Collections.Generic;
using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;

namespace ScaleOverlay
{
    public class ToggleScaleOverlay : Command
    {
        readonly static ScaleConduit scaleConduit = new ScaleConduit();

        public ToggleScaleOverlay()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static ToggleScaleOverlay Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return "ToggleScaleOverlay"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            // toggle conduit enabled
            scaleConduit.Enabled = !scaleConduit.Enabled;

            if (scaleConduit.Enabled) RhinoApp.WriteLine("Scale overlay enabled!");
            else RhinoApp.WriteLine("Scale overlay disabled!");

            doc.Views.Redraw();
            return Result.Success;
        }
    }
}
