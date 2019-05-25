namespace ScaleOverlay
{
    partial class OptionsUserControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tB_lineThickness = new System.Windows.Forms.TextBox();
            this.gB_lineSettings = new System.Windows.Forms.GroupBox();
            this.lbl_lineThickness = new System.Windows.Forms.Label();
            this.gB_Position = new System.Windows.Forms.GroupBox();
            this.lbl_XOffset = new System.Windows.Forms.Label();
            this.tB_OffsetX = new System.Windows.Forms.TextBox();
            this.lbl_YOffset = new System.Windows.Forms.Label();
            this.tB_OffsetY = new System.Windows.Forms.TextBox();
            this.lbl_TextGap = new System.Windows.Forms.Label();
            this.tB_TextGap = new System.Windows.Forms.TextBox();
            this.gB_Color = new System.Windows.Forms.GroupBox();
            this.lbl_LineColor = new System.Windows.Forms.Label();
            this.btn_lineColor = new System.Windows.Forms.Button();
            this.btn_TextColor = new System.Windows.Forms.Button();
            this.lbl_TextColor = new System.Windows.Forms.Label();
            this.lbl_LineMaxLength = new System.Windows.Forms.Label();
            this.tB_LineMaxLength = new System.Windows.Forms.TextBox();
            this.gB_TextSettings = new System.Windows.Forms.GroupBox();
            this.lbl_TextHeight = new System.Windows.Forms.Label();
            this.tB_TextHeight = new System.Windows.Forms.TextBox();
            this.gB_lineSettings.SuspendLayout();
            this.gB_Position.SuspendLayout();
            this.gB_Color.SuspendLayout();
            this.gB_TextSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tB_lineThickness
            // 
            this.tB_lineThickness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_lineThickness.Location = new System.Drawing.Point(77, 19);
            this.tB_lineThickness.Name = "tB_lineThickness";
            this.tB_lineThickness.Size = new System.Drawing.Size(100, 20);
            this.tB_lineThickness.TabIndex = 0;
            this.tB_lineThickness.TextChanged += new System.EventHandler(this.tB_lineThickness_TextChanged);
            // 
            // gB_lineSettings
            // 
            this.gB_lineSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gB_lineSettings.Controls.Add(this.lbl_LineMaxLength);
            this.gB_lineSettings.Controls.Add(this.tB_LineMaxLength);
            this.gB_lineSettings.Controls.Add(this.lbl_lineThickness);
            this.gB_lineSettings.Controls.Add(this.tB_lineThickness);
            this.gB_lineSettings.Location = new System.Drawing.Point(3, 3);
            this.gB_lineSettings.Name = "gB_lineSettings";
            this.gB_lineSettings.Size = new System.Drawing.Size(200, 80);
            this.gB_lineSettings.TabIndex = 1;
            this.gB_lineSettings.TabStop = false;
            this.gB_lineSettings.Text = "Line settings";
            // 
            // lbl_lineThickness
            // 
            this.lbl_lineThickness.AutoSize = true;
            this.lbl_lineThickness.Location = new System.Drawing.Point(6, 22);
            this.lbl_lineThickness.Name = "lbl_lineThickness";
            this.lbl_lineThickness.Size = new System.Drawing.Size(56, 13);
            this.lbl_lineThickness.TabIndex = 1;
            this.lbl_lineThickness.Text = "Thickness";
            // 
            // gB_Position
            // 
            this.gB_Position.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gB_Position.Controls.Add(this.lbl_TextGap);
            this.gB_Position.Controls.Add(this.tB_TextGap);
            this.gB_Position.Controls.Add(this.lbl_YOffset);
            this.gB_Position.Controls.Add(this.tB_OffsetY);
            this.gB_Position.Controls.Add(this.lbl_XOffset);
            this.gB_Position.Controls.Add(this.tB_OffsetX);
            this.gB_Position.Location = new System.Drawing.Point(3, 148);
            this.gB_Position.Name = "gB_Position";
            this.gB_Position.Size = new System.Drawing.Size(200, 104);
            this.gB_Position.TabIndex = 2;
            this.gB_Position.TabStop = false;
            this.gB_Position.Text = "Position settings";
            // 
            // lbl_XOffset
            // 
            this.lbl_XOffset.AutoSize = true;
            this.lbl_XOffset.Location = new System.Drawing.Point(6, 22);
            this.lbl_XOffset.Name = "lbl_XOffset";
            this.lbl_XOffset.Size = new System.Drawing.Size(45, 13);
            this.lbl_XOffset.TabIndex = 1;
            this.lbl_XOffset.Text = "Offset X";
            // 
            // tB_OffsetX
            // 
            this.tB_OffsetX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_OffsetX.Location = new System.Drawing.Point(77, 19);
            this.tB_OffsetX.Name = "tB_OffsetX";
            this.tB_OffsetX.Size = new System.Drawing.Size(100, 20);
            this.tB_OffsetX.TabIndex = 0;
            this.tB_OffsetX.TextChanged += new System.EventHandler(this.tB_OffsetX_TextChanged);
            // 
            // lbl_YOffset
            // 
            this.lbl_YOffset.AutoSize = true;
            this.lbl_YOffset.Location = new System.Drawing.Point(6, 48);
            this.lbl_YOffset.Name = "lbl_YOffset";
            this.lbl_YOffset.Size = new System.Drawing.Size(45, 13);
            this.lbl_YOffset.TabIndex = 3;
            this.lbl_YOffset.Text = "Offset Y";
            // 
            // tB_OffsetY
            // 
            this.tB_OffsetY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_OffsetY.Location = new System.Drawing.Point(77, 45);
            this.tB_OffsetY.Name = "tB_OffsetY";
            this.tB_OffsetY.Size = new System.Drawing.Size(100, 20);
            this.tB_OffsetY.TabIndex = 2;
            this.tB_OffsetY.TextChanged += new System.EventHandler(this.tB_OffsetY_TextChanged);
            // 
            // lbl_TextGap
            // 
            this.lbl_TextGap.AutoSize = true;
            this.lbl_TextGap.Location = new System.Drawing.Point(6, 74);
            this.lbl_TextGap.Name = "lbl_TextGap";
            this.lbl_TextGap.Size = new System.Drawing.Size(51, 13);
            this.lbl_TextGap.TabIndex = 5;
            this.lbl_TextGap.Text = "Text Gap";
            // 
            // tB_TextGap
            // 
            this.tB_TextGap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_TextGap.Location = new System.Drawing.Point(77, 71);
            this.tB_TextGap.Name = "tB_TextGap";
            this.tB_TextGap.Size = new System.Drawing.Size(100, 20);
            this.tB_TextGap.TabIndex = 4;
            this.tB_TextGap.TextChanged += new System.EventHandler(this.tB_TextGap_TextChanged);
            // 
            // gB_Color
            // 
            this.gB_Color.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gB_Color.Controls.Add(this.btn_TextColor);
            this.gB_Color.Controls.Add(this.lbl_TextColor);
            this.gB_Color.Controls.Add(this.btn_lineColor);
            this.gB_Color.Controls.Add(this.lbl_LineColor);
            this.gB_Color.Location = new System.Drawing.Point(3, 258);
            this.gB_Color.Name = "gB_Color";
            this.gB_Color.Size = new System.Drawing.Size(200, 80);
            this.gB_Color.TabIndex = 2;
            this.gB_Color.TabStop = false;
            this.gB_Color.Text = "Color settings";
            // 
            // lbl_LineColor
            // 
            this.lbl_LineColor.AutoSize = true;
            this.lbl_LineColor.Location = new System.Drawing.Point(6, 22);
            this.lbl_LineColor.Name = "lbl_LineColor";
            this.lbl_LineColor.Size = new System.Drawing.Size(53, 13);
            this.lbl_LineColor.TabIndex = 1;
            this.lbl_LineColor.Text = "Line color";
            // 
            // btn_lineColor
            // 
            this.btn_lineColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_lineColor.Location = new System.Drawing.Point(77, 19);
            this.btn_lineColor.Name = "btn_lineColor";
            this.btn_lineColor.Size = new System.Drawing.Size(100, 21);
            this.btn_lineColor.TabIndex = 2;
            this.btn_lineColor.UseVisualStyleBackColor = true;
            this.btn_lineColor.Click += new System.EventHandler(this.btn_lineColor_Click);
            // 
            // btn_TextColor
            // 
            this.btn_TextColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_TextColor.Location = new System.Drawing.Point(77, 46);
            this.btn_TextColor.Name = "btn_TextColor";
            this.btn_TextColor.Size = new System.Drawing.Size(100, 21);
            this.btn_TextColor.TabIndex = 4;
            this.btn_TextColor.UseVisualStyleBackColor = true;
            this.btn_TextColor.Click += new System.EventHandler(this.btn_TextColor_Click);
            // 
            // lbl_TextColor
            // 
            this.lbl_TextColor.AutoSize = true;
            this.lbl_TextColor.Location = new System.Drawing.Point(6, 49);
            this.lbl_TextColor.Name = "lbl_TextColor";
            this.lbl_TextColor.Size = new System.Drawing.Size(54, 13);
            this.lbl_TextColor.TabIndex = 3;
            this.lbl_TextColor.Text = "Text color";
            // 
            // lbl_LineMaxLength
            // 
            this.lbl_LineMaxLength.AutoSize = true;
            this.lbl_LineMaxLength.Location = new System.Drawing.Point(6, 48);
            this.lbl_LineMaxLength.Name = "lbl_LineMaxLength";
            this.lbl_LineMaxLength.Size = new System.Drawing.Size(66, 13);
            this.lbl_LineMaxLength.TabIndex = 3;
            this.lbl_LineMaxLength.Text = "Max. Length";
            // 
            // tB_LineMaxLength
            // 
            this.tB_LineMaxLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_LineMaxLength.Location = new System.Drawing.Point(77, 45);
            this.tB_LineMaxLength.Name = "tB_LineMaxLength";
            this.tB_LineMaxLength.Size = new System.Drawing.Size(100, 20);
            this.tB_LineMaxLength.TabIndex = 2;
            this.tB_LineMaxLength.TextChanged += new System.EventHandler(this.tB_LineMaxLength_TextChanged);
            // 
            // gB_TextSettings
            // 
            this.gB_TextSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gB_TextSettings.Controls.Add(this.lbl_TextHeight);
            this.gB_TextSettings.Controls.Add(this.tB_TextHeight);
            this.gB_TextSettings.Location = new System.Drawing.Point(3, 89);
            this.gB_TextSettings.Name = "gB_TextSettings";
            this.gB_TextSettings.Size = new System.Drawing.Size(200, 53);
            this.gB_TextSettings.TabIndex = 4;
            this.gB_TextSettings.TabStop = false;
            this.gB_TextSettings.Text = "Text settings";
            // 
            // lbl_TextHeight
            // 
            this.lbl_TextHeight.AutoSize = true;
            this.lbl_TextHeight.Location = new System.Drawing.Point(6, 22);
            this.lbl_TextHeight.Name = "lbl_TextHeight";
            this.lbl_TextHeight.Size = new System.Drawing.Size(38, 13);
            this.lbl_TextHeight.TabIndex = 1;
            this.lbl_TextHeight.Text = "Height";
            // 
            // tB_TextHeight
            // 
            this.tB_TextHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tB_TextHeight.Location = new System.Drawing.Point(77, 19);
            this.tB_TextHeight.Name = "tB_TextHeight";
            this.tB_TextHeight.Size = new System.Drawing.Size(100, 20);
            this.tB_TextHeight.TabIndex = 0;
            this.tB_TextHeight.TextChanged += new System.EventHandler(this.tB_TextHeight_TextChanged);
            // 
            // OptionsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gB_TextSettings);
            this.Controls.Add(this.gB_Color);
            this.Controls.Add(this.gB_Position);
            this.Controls.Add(this.gB_lineSettings);
            this.Name = "OptionsUserControl";
            this.Size = new System.Drawing.Size(209, 489);
            this.gB_lineSettings.ResumeLayout(false);
            this.gB_lineSettings.PerformLayout();
            this.gB_Position.ResumeLayout(false);
            this.gB_Position.PerformLayout();
            this.gB_Color.ResumeLayout(false);
            this.gB_Color.PerformLayout();
            this.gB_TextSettings.ResumeLayout(false);
            this.gB_TextSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tB_lineThickness;
        private System.Windows.Forms.GroupBox gB_lineSettings;
        private System.Windows.Forms.Label lbl_lineThickness;
        private System.Windows.Forms.GroupBox gB_Position;
        private System.Windows.Forms.Label lbl_XOffset;
        private System.Windows.Forms.TextBox tB_OffsetX;
        private System.Windows.Forms.Label lbl_YOffset;
        private System.Windows.Forms.TextBox tB_OffsetY;
        private System.Windows.Forms.Label lbl_TextGap;
        private System.Windows.Forms.TextBox tB_TextGap;
        private System.Windows.Forms.GroupBox gB_Color;
        private System.Windows.Forms.Label lbl_LineColor;
        private System.Windows.Forms.Button btn_lineColor;
        private System.Windows.Forms.Button btn_TextColor;
        private System.Windows.Forms.Label lbl_TextColor;
        private System.Windows.Forms.Label lbl_LineMaxLength;
        private System.Windows.Forms.TextBox tB_LineMaxLength;
        private System.Windows.Forms.GroupBox gB_TextSettings;
        private System.Windows.Forms.Label lbl_TextHeight;
        private System.Windows.Forms.TextBox tB_TextHeight;
    }
}
