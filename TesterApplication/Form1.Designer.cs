namespace TesterApplication
{
    partial class Form1
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
            this.StartNewSessionButton = new System.Windows.Forms.Button();
            this.PairButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SmartphoneMessage = new System.Windows.Forms.Label();
            this.DeviceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartNewSessionButton
            // 
            this.StartNewSessionButton.Location = new System.Drawing.Point(370, 101);
            this.StartNewSessionButton.Name = "StartNewSessionButton";
            this.StartNewSessionButton.Size = new System.Drawing.Size(123, 23);
            this.StartNewSessionButton.TabIndex = 0;
            this.StartNewSessionButton.Text = "Start New Session";
            this.StartNewSessionButton.UseVisualStyleBackColor = true;
            this.StartNewSessionButton.Click += new System.EventHandler(this.StartNewSessionButton_Click);
            // 
            // PairButton
            // 
            this.PairButton.Location = new System.Drawing.Point(53, 101);
            this.PairButton.Name = "PairButton";
            this.PairButton.Size = new System.Drawing.Size(75, 23);
            this.PairButton.TabIndex = 1;
            this.PairButton.Text = "Pair";
            this.PairButton.UseVisualStyleBackColor = true;
            this.PairButton.Click += new System.EventHandler(this.PairButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Smartphone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wearable Device";
            // 
            // SmartphoneMessage
            // 
            this.SmartphoneMessage.AutoSize = true;
            this.SmartphoneMessage.Location = new System.Drawing.Point(53, 158);
            this.SmartphoneMessage.Name = "SmartphoneMessage";
            this.SmartphoneMessage.Size = new System.Drawing.Size(35, 13);
            this.SmartphoneMessage.TabIndex = 4;
            this.SmartphoneMessage.Text = "label3";
            // 
            // DeviceLabel
            // 
            this.DeviceLabel.AutoSize = true;
            this.DeviceLabel.Location = new System.Drawing.Point(409, 149);
            this.DeviceLabel.Name = "DeviceLabel";
            this.DeviceLabel.Size = new System.Drawing.Size(35, 13);
            this.DeviceLabel.TabIndex = 5;
            this.DeviceLabel.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 261);
            this.Controls.Add(this.DeviceLabel);
            this.Controls.Add(this.SmartphoneMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PairButton);
            this.Controls.Add(this.StartNewSessionButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartNewSessionButton;
        private System.Windows.Forms.Button PairButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SmartphoneMessage;
        private System.Windows.Forms.Label DeviceLabel;
    }
}

