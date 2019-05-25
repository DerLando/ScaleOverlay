using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleOverlay
{
    public partial class OptionsUserControl : UserControl
    {
        public int LineThickness { get; set; }
        public int LineMaxLength { get; set; }
        public int TextHeight { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public int TextGap { get; set; }
        public Color LineColor { get; set; }
        public Color TextColor { get; set; }


        public void LoadSettings()
        {
            // line
            LineThickness = Settings.LineThickness;
            tB_lineThickness.Text = LineThickness.ToString();
            LineMaxLength = Settings.LineMaxLength;
            tB_LineMaxLength.Text = LineMaxLength.ToString();

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
            btn_lineColor.BackColor = LineColor;
            TextColor = Settings.TextColor;
            btn_TextColor.BackColor = TextColor;
        }

        public OptionsUserControl()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void tB_lineThickness_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tB_lineThickness.Text, out int result))
            {
                LineThickness = result;
                if (result < Settings.MinLineThickness) LineThickness = Settings.MinLineThickness;
                if (result > Settings.MaxLineThickness) LineThickness = Settings.MaxLineThickness;
                tB_lineThickness.Text = LineThickness.ToString();
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

        private void btn_lineColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = btn_lineColor.BackColor;

            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                btn_lineColor.BackColor = colorDialog.Color;
                LineColor = colorDialog.Color;
            }
        }

        private void btn_TextColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = btn_TextColor.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                btn_TextColor.BackColor = colorDialog.Color;
                TextColor = colorDialog.Color;
            }
        }

    }
}
