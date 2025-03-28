using static test.Blackjack.Deck;
using static test.Blackjack.Dealer;
using static test.Blackjack.Blackjack;
using test.Blackjack;

namespace test
{
    partial class Form1
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

        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(373, 135);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(229, 225);
            label1.Name = "player";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "player";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(392, 217);
            label2.Name = "winner";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "winner";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(529, 224);
            label3.Name = "dealer";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 3;
            label3.Text = "dealer";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
