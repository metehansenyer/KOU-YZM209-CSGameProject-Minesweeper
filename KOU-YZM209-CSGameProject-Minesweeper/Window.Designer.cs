﻿
namespace KOU_YZM209_CSGameProject_Minesweeper
{
    partial class Window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(16F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(59, 104, 28);
            ClientSize = new Size(1225, 683);
            Font = new Font("Arial", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Window";
            Text = "Mayın Tarlası";
            ResumeLayout(false);
        }

        #endregion
    }
}