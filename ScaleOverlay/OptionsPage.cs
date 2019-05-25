using Rhino;
using Rhino.UI;

namespace ScaleOverlay
{
    public class OptionsPage : OptionsDialogPage
    {
        private EtoOptionsPageControl m_control;

        public OptionsPage()
          : base("Scale Overlay")
        {
        }

        public override object PageControl
        {
            get { return m_control ?? (m_control = new EtoOptionsPageControl()); }
        }

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

        public override bool ShowDefaultsButton => true;

        public override void OnDefaults()
        {
            Settings.RestoreDefaults();
            m_control.LoadSettings();
        }
    }
}