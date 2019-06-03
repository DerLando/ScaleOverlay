using Eto.Forms;
using Eto.Drawing;
using Rhino.UI;
using System;
using System.Linq;
using System.Collections;

namespace ScaleOverlay
{
    /// <summary>
    /// Main form that gets drawn when the optionsPage for this plugin is opened
    /// </summary>
    public class EtoOptionsPageControl : Panel
    {
        #region Elements
        // line settings labels and textboxes
        private Label lbl_LineThickness = new Label() { Text = "Thickness", ToolTip = "Thickness of scale line in pixels.", VerticalAlignment = VerticalAlignment.Center };
        private TextBox tB_LineThickness = new TextBox();
        private Label lbl_LineMaxLength = new Label() { Text = "Average Length", ToolTip = "Average length of scale line before jumping to another scale in pixels.", VerticalAlignment = VerticalAlignment.Center };
        private TextBox tB_LineMaxLength = new TextBox();
        private Label lbl_LineDividerLengthFactor = new Label() { Text = "Subdivider Length Factor", ToolTip = "Length of supdividers as a factor of the length of first and last divider.", VerticalAlignment = VerticalAlignment.Center };
        private TextBox tB_LineDividerLengthFactor = new TextBox();

        // text settings labels and textboxes
        private Label lbl_TextGap = new Label() { Text = "Gap", ToolTip = "Gap between text and scale line in pixels.", VerticalAlignment = VerticalAlignment.Center };
        private TextBox tB_TextGap = new TextBox();
        private Label lbl_TextHeight = new Label() { Text = "Height", ToolTip = "Height of text in pixels", VerticalAlignment = VerticalAlignment.Center };
        private TextBox tB_TextHeight = new TextBox();

        // margin settings labels and textboxes
        private Label lbl_OffsetX = new Label() { Text = "Offset X", ToolTip = "Horizontal offset of scale line from bottom right corner of viewport in pixels.", VerticalAlignment = VerticalAlignment.Center };
        private TextBox tB_OffsetX = new TextBox();
        private Label lbl_OffsetY = new Label() { Text = "Offset Y", ToolTip = "Vertical offset of scale line from bottom right corner of viewport in pixels.", VerticalAlignment = VerticalAlignment.Center };
        private TextBox tB_OffsetY = new TextBox();

        // color settings margins and buttons
        private Label lbl_LineColor = new Label() { Text = "Line Color", ToolTip = "Color of scale line.", VerticalAlignment = VerticalAlignment.Center };
        private Button btn_LineColor = new Button() { Text = "", BackgroundColor = Settings.LineColor.ToEto() };
        private Label lbl_TextColor = new Label() { Text = "Text Color", ToolTip = "Color of text.", VerticalAlignment = VerticalAlignment.Center };
        private Button btn_TextColor = new Button() { Text = "", BackgroundColor = Settings.TextColor.ToEto() };
        #endregion

        /// <summary>
        /// Properties this from passes on when OptionsPage.OnApply is triggered
        /// <see cref="OptionsPage.OnApply"/>
        /// </summary>
        #region Properties to pass

        public int LineThickness { get; set; }
        public int LineMaxLength { get; set; }
        public int TextHeight { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public int TextGap { get; set; }
        public System.Drawing.Color LineColor { get; set; }
        public System.Drawing.Color TextColor { get; set; }
        public double LineDividerLengthFactor { get; set; }

        #endregion

        /// <summary>
        /// Helper to load Settings and populate the form elements
        /// <see cref="Settings"/>
        /// </summary>
        public void LoadSettings()
        {
            // line
            LineThickness = Settings.LineThickness;
            tB_LineThickness.Text = LineThickness.ToString();
            LineMaxLength = Settings.LineMaxLength;
            tB_LineMaxLength.Text = LineMaxLength.ToString();
            LineDividerLengthFactor = Settings.LineSubdividerLengthFactor;
            tB_LineDividerLengthFactor.Text = LineDividerLengthFactor.ToString();

            // text
            TextHeight = Settings.TextHeight;
            tB_TextHeight.Text = TextHeight.ToString();

            // position
            OffsetX = Settings.OffsetX;
            tB_OffsetX.Text = OffsetX.ToString();
            OffsetY = Settings.OffsetY;
            tB_OffsetY.Text = OffsetY.ToString();
            TextGap = Settings.TextGap;
            tB_TextGap.Text = TextGap.ToString();

            // color
            LineColor = Settings.LineColor;
            btn_LineColor.BackgroundColor = LineColor.ToEto();
            TextColor = Settings.TextColor;
            btn_TextColor.BackgroundColor = TextColor.ToEto();

        }

        /// <summary>
        /// Public parameterless constructor
        /// </summary>
        public EtoOptionsPageControl()
        {
            // call this.LoadSettings() to initialize default values for the form
            LoadSettings();

            // initialize all eventhandlers for forms
            #region eventHandlers
            tB_LineThickness.TextChanged += tB_LineThickness_TextChanged;
            tB_LineMaxLength.TextChanged += tB_LineMaxLength_TextChanged;
            tB_LineDividerLengthFactor.TextChanged += tB_LineDividerLengthFactor_TextChanged;
            tB_TextGap.TextChanged += tB_TextGap_TextChanged;
            tB_TextHeight.TextChanged += tB_TextHeight_TextChanged;
            tB_OffsetX.TextChanged += tB_OffsetX_TextChanged;
            tB_OffsetY.TextChanged += tB_OffsetY_TextChanged;
            btn_LineColor.Click += btn_LineColor_Clicked;
            btn_TextColor.Click += btn_TextColor_Clicked;
            #endregion

            // create layout
            var layout = new DynamicLayout() { DefaultSpacing = new Size(5, 5), Padding = new Padding(10) };

            // create row vor line settings
            var row = layout.BeginHorizontal();

            // create empty groupBox and fill with linesettings controls
            var group = new DynamicGroup();
            group.Title = "Line Settings";
            group.AddRow(new DynamicRow(new Control[] { lbl_LineThickness, tB_LineThickness }));
            group.AddRow(new DynamicRow(new Control[] { lbl_LineMaxLength, tB_LineMaxLength }));
            group.AddRow(new DynamicRow(new Control[] { lbl_LineDividerLengthFactor, tB_LineDividerLengthFactor }));

            row.Add(group);

            // create row for text settings
            row = layout.EndBeginHorizontal();

            // create empty groupBox and fill with textsettings controls
            group = new DynamicGroup();
            group.Title = "Text Settings";
            group.AddRow(new DynamicRow(new Control[] { lbl_TextHeight, tB_TextHeight }));
            group.AddRow(new DynamicRow(new Control[] { lbl_TextGap, tB_TextGap }));

            row.Add(group);

            // create row for margin settings
            row = layout.EndBeginHorizontal();

            // create empty groupBox and fill with marginsettings controls
            group = new DynamicGroup();
            group.Title = "Margin Settings";
            group.AddRow(new DynamicRow(new Control[] { lbl_OffsetX, tB_OffsetX }));
            group.AddRow(new DynamicRow(new Control[] { lbl_OffsetY, tB_OffsetY }));

            row.Add(group);

            // create row for color settings
            row = layout.EndBeginHorizontal();

            // create empty groupBox and fill with colorsettings controls
            group = new DynamicGroup();
            group.Title = "Color Settings";
            group.AddRow(new DynamicRow(new Control[] { lbl_LineColor, btn_LineColor }));
            group.AddRow(new DynamicRow(new Control[] { lbl_TextColor, btn_TextColor }));

            row.Add(group);

            // Clean up emd of layout and add null
            layout.EndBeginHorizontal();
            layout.Add(null);
            layout.EndHorizontal();
            Content = layout;
        }

        private void tB_OffsetY_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tB_OffsetY.Text, out int result))
            {
                OffsetY = result;
                if (result < Settings.MinOffsetY) OffsetY = Settings.MinOffsetY;
                if (result > Settings.MaxOffsetY) OffsetY = Settings.MaxOffsetY;
                tB_OffsetY.Text = OffsetY.ToString();
            }
        }

        private void tB_OffsetX_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tB_OffsetX.Text, out int result))
            {
                OffsetX = result;
                if (result < Settings.MinOffsetX) OffsetX = Settings.MinOffsetX;
                if (result > Settings.MaxOffsetX) OffsetX = Settings.MaxOffsetX;
                tB_OffsetX.Text = OffsetX.ToString();
            }
        }

        private void tB_TextHeight_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tB_TextHeight.Text, out int result))
            {
                TextHeight = result;
                if (result < Settings.MinTextHeight) TextHeight = Settings.MinTextHeight;
                if (result > Settings.MaxTextHeight) TextHeight = Settings.MaxTextHeight;
                tB_TextHeight.Text = TextHeight.ToString();
            }
        }

        private void tB_TextGap_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tB_TextGap.Text, out int result))
            {
                TextGap = result;
                if (result < Settings.MinTextGap) TextGap = Settings.MinTextGap;
                if (result > Settings.MaxTextGap) TextGap = Settings.MaxTextGap;
                tB_TextGap.Text = TextGap.ToString();
            }
        }

        private void tB_LineDividerLengthFactor_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tB_LineDividerLengthFactor.Text, out var result))
            {
                LineDividerLengthFactor = result;
                if (result < Settings.MinSubdividerFactor) LineDividerLengthFactor = Settings.MinSubdividerFactor;
                if (result > Settings.MaxSubdividerFactor) LineDividerLengthFactor = Settings.MaxSubdividerFactor;
                tB_LineDividerLengthFactor.Text = LineDividerLengthFactor.ToString();
            }
        }

            private void tB_LineMaxLength_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tB_LineMaxLength.Text, out int result))
            {
                LineMaxLength = result;
                if (result < Settings.MinLineMaxLength) LineMaxLength = Settings.MinLineMaxLength;
                if (result > Settings.MaxLineMaxLength) LineMaxLength = Settings.MaxLineMaxLength;
                tB_LineMaxLength.Text = LineMaxLength.ToString();
            }
        }

        private void tB_LineThickness_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tB_LineThickness.Text, out int result))
            {
                LineThickness = result;
                if (result < Settings.MinLineThickness) LineThickness = Settings.MinLineThickness;
                if (result > Settings.MaxLineThickness) LineThickness = Settings.MaxLineThickness;
                tB_LineThickness.Text = LineThickness.ToString();
            }
        }

        private void btn_LineColor_Clicked(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog { Color = LineColor.ToEto() };
            if(dialog.ShowDialog(this) == DialogResult.Ok)
            {
                btn_LineColor.BackgroundColor = dialog.Color;
                LineColor = System.Drawing.Color.FromArgb(dialog.Color.ToArgb());
            }
        }

        private void btn_TextColor_Clicked(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog { Color = TextColor.ToEto() };
            if (dialog.ShowDialog(this) == DialogResult.Ok)
            {
                btn_TextColor.BackgroundColor = dialog.Color;
                TextColor = System.Drawing.Color.FromArgb(dialog.Color.ToArgb());
            }
        }
    }
}
