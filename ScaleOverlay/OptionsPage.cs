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
            ScaleOverlayPlugIn.Instance.Settings.SetInteger("LineThickness", m_control.LineThickness);
            ScaleOverlayPlugIn.Instance.Settings.SetInteger("LineMaxLength",m_control.LineMaxLength);
            ScaleOverlayPlugIn.Instance.Settings.SetDouble("LineSubdividerLengthFactor", m_control.LineDividerLengthFactor);

            // Text
            ScaleOverlayPlugIn.Instance.Settings.SetInteger("TextHeight", m_control.TextHeight);
            ScaleOverlayPlugIn.Instance.Settings.SetString("TextFontFamilyFaceName", m_control.TextFont.FamilyPlusFaceName);

            // position
            ScaleOverlayPlugIn.Instance.Settings.SetInteger("OffsetX", m_control.OffsetX);
            ScaleOverlayPlugIn.Instance.Settings.SetInteger("OffsetY", m_control.OffsetY);
            ScaleOverlayPlugIn.Instance.Settings.SetInteger("TextGap", m_control.TextGap);

            // color
            ScaleOverlayPlugIn.Instance.Settings.SetColor("LineColor", m_control.LineColor);
            ScaleOverlayPlugIn.Instance.Settings.SetColor("TextColor", m_control.TextColor);

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
            ScaleOverlayPlugIn.Instance.RestoreDefaultSettings();
            m_control.LoadSettings();
        }
    }
}