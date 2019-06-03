using System.Collections.Generic;
using System.Drawing;
using Rhino.PlugIns;
using Rhino.UI;

namespace ScaleOverlay
{
    ///<summary>
    /// <para>Every RhinoCommon .rhp assembly must have one and only one PlugIn-derived
    /// class. DO NOT create instances of this class yourself. It is the
    /// responsibility of Rhino to create an instance of this class.</para>
    /// <para>To complete plug-in information, please also see all PlugInDescription
    /// attributes in AssemblyInfo.cs (you might need to click "Project" ->
    /// "Show All Files" to see it in the "Solution Explorer" window).</para>
    ///</summary>
    public class ScaleOverlayPlugIn : Rhino.PlugIns.PlugIn

    {
        public ScaleOverlayPlugIn()
        {
            Instance = this;
            Settings.SetDefault("OffsetX", 10);
            Settings.SetDefault("OffsetY", 10);
            Settings.SetDefault("LineThickness", 2);
            Settings.SetDefault("LineMaxLength", 100);
            Settings.SetDefault("LineColor", Color.FromArgb(40, 40, 40));
            Settings.SetDefault("TextGap", 10);
            Settings.SetDefault("TextHeight", 12);
            Settings.SetDefault("TextColor", Color.Black);
            Settings.SetDefault("TextFontFamilyFaceName", "Arial");
            Settings.SetDefault("LineSubdividerLengthFactor", 0.5);

        }

        ///<summary>Gets the only instance of the ScaleOverlayPlugIn plug-in.</summary>
        public static ScaleOverlayPlugIn Instance
        {
            get; private set;
        }

        // You can override methods here to change the plug-in behavior on
        // loading and shut down, add options pages to the Rhino _Option command
        // and maintain plug-in wide options in a document.

        /// <summary>
        /// override OptionsDialogPages to add out own custom OptionsPage
        /// <see cref="OptionsPage"/>
        /// </summary>
        /// <param name="pages"></param>
        protected override void OptionsDialogPages(List<OptionsDialogPage> pages)
        {
            var optionsPage = new OptionsPage();
            pages.Add(optionsPage);
        }

        public void RestoreDefaultSettings()
        {
            if(Settings.TryGetDefault("OffsetX", out int offsetX)) Settings.SetInteger("OffsetX", offsetX);
            if (Settings.TryGetDefault("OffsetY", out int offsetY)) Settings.SetInteger("OffsetY", offsetY);
            if (Settings.TryGetDefault("LineThickness", out int lineThickness)) Settings.SetInteger("LineThickness", lineThickness);
            if (Settings.TryGetDefault("LineMaxLength", out int lineMaxLength)) Settings.SetInteger("LineMaxLength", lineMaxLength);
            if (Settings.TryGetDefault("LineColor", out Color lineColor)) Settings.SetColor("LineColor", lineColor);
            if (Settings.TryGetDefault("TextGap", out int textGap)) Settings.SetInteger("TextGap", textGap);
            if (Settings.TryGetDefault("TextHeight", out int textHeight)) Settings.SetInteger("TextHeight", textHeight);
            if (Settings.TryGetDefault("TextColor", out Color textColor)) Settings.SetColor("TextColor", textColor);
            if (Settings.TryGetDefault("TextFontFamilyFaceName", out string textFontFamilyFaceName)) Settings.SetString("TextFontFamilyFaceName", textFontFamilyFaceName);
            if (Settings.TryGetDefault("LineSubdividerLengthFactor", out double lineSubdividerLengthFactor)) Settings.SetDouble("LineSubdividerLengthFactor", lineSubdividerLengthFactor);
        }
    }
}