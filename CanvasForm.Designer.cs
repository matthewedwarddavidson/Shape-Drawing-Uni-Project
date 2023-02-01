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
            CanvasForm canvasForm = this;
            canvasForm.createSquare = new System.Windows.Forms.Button();
            canvasForm.createTriangle = new System.Windows.Forms.Button();
            canvasForm.Canvas = new System.Windows.Forms.Panel();
            canvasForm.SuspendLayout();
            // 
            // createSquare
            // 
            canvasForm.createSquare.Location = new System.Drawing.Point(650, 25);
            canvasForm.createSquare.Name = "createSquare";
            canvasForm.createSquare.Size = new System.Drawing.Size(125, 30);
            canvasForm.createSquare.TabIndex = 0;
            canvasForm.createSquare.Text = "Create Square";
            canvasForm.createSquare.UseVisualStyleBackColor = true;
            canvasForm.createSquare.Click += new System.EventHandler(canvasForm.createSquare_Click);
            // 
            // createTriangle
            // 
            canvasForm.createTriangle.Location = new System.Drawing.Point(650, 80);
            canvasForm.createTriangle.Name = "createTriangle";
            canvasForm.createTriangle.Size = new System.Drawing.Size(125, 30);
            canvasForm.createTriangle.TabIndex = 0;
            canvasForm.createTriangle.Text = "Create Triangle";
            canvasForm.createTriangle.UseVisualStyleBackColor = true;
            canvasForm.createTriangle.Click += new System.EventHandler(canvasForm.CreateTriangle_Click);
            // 
            // Canvas
            // 
            canvasForm.Canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            canvasForm.Canvas.BackColor = System.Drawing.SystemColors.Window;
            canvasForm.Canvas.Location = new System.Drawing.Point(15, 14);
            canvasForm.Canvas.Name = "Canvas";
            canvasForm.Canvas.Size = new System.Drawing.Size(600, 425);
            canvasForm.Canvas.TabIndex = 1;
            canvasForm.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(Canvas_Paint);
            
            canvasForm.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(canvasForm.Control_MouseDown);
            canvasForm.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(canvasForm.Control_MouseUp);
            canvasForm.Canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(canvasForm.Mouse_Click);
            // 
            // CanvasForm
            // 
            canvasForm.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            canvasForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            canvasForm.BackColor = System.Drawing.SystemColors.Menu;
            canvasForm.ClientSize = new System.Drawing.Size(800, 450);
            canvasForm.Controls.Add(canvasForm.Canvas);
            canvasForm.Controls.Add(canvasForm.createSquare);
            canvasForm.Controls.Add(canvasForm.createTriangle);
            canvasForm.Name = "CanvasForm";
            canvasForm.Text = "Form1";
            canvasForm.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createSquare;
        private System.Windows.Forms.Button createTriangle;
        private System.Windows.Forms.Panel Canvas;
    }
}

