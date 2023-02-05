using System.Windows.Forms;

namespace CGP_Assessment_Project
{
    partial class CanvasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createSquare = new System.Windows.Forms.Button();
            this.createTriangle = new System.Windows.Forms.Button();
            this.createCircle = new System.Windows.Forms.Button();
            this.Canvas = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // createSquare
            // 
            this.createSquare.Location = new System.Drawing.Point(488, 20);
            this.createSquare.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createSquare.Name = "createSquare";
            this.createSquare.Size = new System.Drawing.Size(94, 24);
            this.createSquare.TabIndex = 0;
            this.createSquare.Text = "Create Square";
            this.createSquare.UseVisualStyleBackColor = true;
            this.createSquare.Click += new System.EventHandler(this.createSquare_Click);
            // 
            // createTriangle
            // 
            this.createTriangle.Location = new System.Drawing.Point(488, 65);
            this.createTriangle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.createTriangle.Name = "createTriangle";
            this.createTriangle.Size = new System.Drawing.Size(94, 24);
            this.createTriangle.TabIndex = 0;
            this.createTriangle.Text = "Create Triangle";
            this.createTriangle.UseVisualStyleBackColor = true;
            this.createTriangle.Click += new System.EventHandler(this.CreateTriangle_Click);
            // 
            // Canvas
            // 
            this.Canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Canvas.BackColor = System.Drawing.SystemColors.Window;
            this.Canvas.Location = new System.Drawing.Point(11, 11);
            this.Canvas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(450, 345);
            this.Canvas.TabIndex = 1;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Mouse_Click);
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // createCircle
            // 
            this.createCircle.Location = new System.Drawing.Point(488, 110);
            this.createCircle.Margin = new System.Windows.Forms.Padding(2);
            this.createCircle.Name = "createCircle";
            this.createCircle.Size = new System.Drawing.Size(94, 24);
            this.createCircle.TabIndex = 0;
            this.createCircle.Text = "Create Circle";
            this.createCircle.UseVisualStyleBackColor = true;
            this.createCircle.Click += new System.EventHandler(this.create_circle_Click);
            // 
            // CanvasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.createSquare);
            this.Controls.Add(this.createTriangle);
            this.Controls.Add(this.createCircle);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CanvasForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createSquare;
        private System.Windows.Forms.Button createTriangle;
        private System.Windows.Forms.Button createCircle;
        private System.Windows.Forms.Panel Canvas;
    }
}

