using Rhino;
using Rhino.UI;

namespace ScaleOverlay
{
    /// <summary>
    /// Options Page for this plugin, gets added to the Rhino options menu
    /// </summary>
    public class OptionsPage : OptionsDialogPage
    {
        // page control that gets drawn as content
        private EtoOptionsPageControl m_control;

        public OptionsPage()
          : base("Scale Overlay")
        {
        }

        public override object PageControl
        {
            get { return m_control ?? (m_control = new EtoOptionsPageControl()); }
        }

        /// <summary>
        /// OnApply override to handle a user clicking "OK" at the bottom of the options page
        /// </summary>
        /// <returns>true</returns>
        public override bool OnApply()
        {
            // TODO: Check nulls
            // line
            Settings.LineThickness = m_control.LineThickness;
            Settings.LineMaxLength = m_control.LineMaxLength;
            Settings.LineSubdividerLengthFactor = m_control.LineDividerLengthFactor;

            // Text
            Settings.TextHeight = m_control.TextHeight;

            // position
            Settings.OffsetX = m_control.OffsetX;
            Settings.OffsetY = m_control.OffsetY;
            Settings.TextGap = m_control.TextGap;

            // color
            Settings.LineColor = m_control.LineColor;
            Settings.TextColor = m_control.TextColor;

            // redraw
            RhinoDoc.ActiveDoc.Views.Redraw();

            return true;
        }

        public override void OnCancel()
        {
            // Do nothing
        }

        /// <summary>
        /// We want to be able to reset to default
        /// </summary>
        public override bool ShowDefaultsButton => true;

        /// <summary>
        /// OnDefaults we just call Settings.RestoreDefaults()
        /// <see cref="Settings.RestoreDefaults"/>
        /// </summary>
        public override void OnDefaults()
        {
            Settings.RestoreDefaults();
            m_control.LoadSettings();
        }
    }
}