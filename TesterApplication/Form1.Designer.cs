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
            this.PhoneName = new System.Windows.Forms.Label();
            this.WearableName = new System.Windows.Forms.Label();
            this.SmartphoneMessage = new System.Windows.Forms.Label();
            this.DeviceLabel = new System.Windows.Forms.Label();
            this.TransmitTextBox = new System.Windows.Forms.TextBox();
            this.TransmitDataButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SniffedMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartNewSessionButton
            // 
            this.StartNewSessionButton.Location = new System.Drawing.Point(531, 87);
            this.StartNewSessionButton.Margin = new System.Windows.Forms.Padding(4);
            this.StartNewSessionButton.Name = "StartNewSessionButton";
            this.StartNewSessionButton.Size = new System.Drawing.Size(164, 28);
            this.StartNewSessionButton.TabIndex = 0;
            this.StartNewSessionButton.Text = "Start New Session";
            this.StartNewSessionButton.UseVisualStyleBackColor = true;
            this.StartNewSessionButton.Click += new System.EventHandler(this.StartNewSessionButton_Click);
            // 
            // PairButton
            // 
            this.PairButton.Location = new System.Drawing.Point(75, 103);
            this.PairButton.Margin = new System.Windows.Forms.Padding(4);
            this.PairButton.Name = "PairButton";
            this.PairButton.Size = new System.Drawing.Size(100, 28);
            this.PairButton.TabIndex = 1;
            this.PairButton.Text = "Discover and Pair";
            this.PairButton.UseVisualStyleBackColor = true;
            this.PairButton.Click += new System.EventHandler(this.PairButton_Click);
            // 
            // PhoneName
            // 
            this.PhoneName.AutoSize = true;
            this.PhoneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneName.Location = new System.Drawing.Point(71, 49);
            this.PhoneName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PhoneName.Name = "PhoneName";
            this.PhoneName.Size = new System.Drawing.Size(109, 20);
            this.PhoneName.TabIndex = 2;
            this.PhoneName.Text = "Smartphone";
            // 
            // WearableName
            // 
            this.WearableName.AutoSize = true;
            this.WearableName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WearableName.Location = new System.Drawing.Point(527, 49);
            this.WearableName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WearableName.Name = "WearableName";
            this.WearableName.Size = new System.Drawing.Size(152, 20);
            this.WearableName.TabIndex = 3;
            this.WearableName.Text = "Wearable Device";
            // 
            // SmartphoneMessage
            // 
            this.SmartphoneMessage.AutoSize = true;
            this.SmartphoneMessage.Location = new System.Drawing.Point(97, 165);
            this.SmartphoneMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SmartphoneMessage.Name = "SmartphoneMessage";
            this.SmartphoneMessage.Size = new System.Drawing.Size(65, 17);
            this.SmartphoneMessage.TabIndex = 4;
            this.SmartphoneMessage.Text = "Message";
            this.SmartphoneMessage.Click += new System.EventHandler(this.SmartphoneMessage_Click);
            // 
            // DeviceLabel
            // 
            this.DeviceLabel.AutoSize = true;
            this.DeviceLabel.Location = new System.Drawing.Point(571, 133);
            this.DeviceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DeviceLabel.Name = "DeviceLabel";
            this.DeviceLabel.Size = new System.Drawing.Size(65, 17);
            this.DeviceLabel.TabIndex = 5;
            this.DeviceLabel.Text = "Message";
            this.DeviceLabel.Click += new System.EventHandler(this.DeviceLabel_Click);
            // 
            // TransmitTextBox
            // 
            this.TransmitTextBox.Location = new System.Drawing.Point(531, 186);
            this.TransmitTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TransmitTextBox.Name = "TransmitTextBox";
            this.TransmitTextBox.Size = new System.Drawing.Size(132, 22);
            this.TransmitTextBox.TabIndex = 6;
            this.TransmitTextBox.TextChanged += new System.EventHandler(this.TransmitTextBox_TextChanged);
            // 
            // TransmitDataButton
            // 
            this.TransmitDataButton.Location = new System.Drawing.Point(549, 218);
            this.TransmitDataButton.Margin = new System.Windows.Forms.Padding(4);
            this.TransmitDataButton.Name = "TransmitDataButton";
            this.TransmitDataButton.Size = new System.Drawing.Size(100, 28);
            this.TransmitDataButton.TabIndex = 7;
            this.TransmitDataButton.Text = "Send Data";
            this.TransmitDataButton.UseVisualStyleBackColor = true;
            this.TransmitDataButton.Click += new System.EventHandler(this.TransmitDataButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "MITM";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sniffed Message";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // SniffedMessage
            // 
            this.SniffedMessage.AutoSize = true;
            this.SniffedMessage.Location = new System.Drawing.Point(275, 133);
            this.SniffedMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SniffedMessage.Name = "SniffedMessage";
            this.SniffedMessage.Size = new System.Drawing.Size(65, 17);
            this.SniffedMessage.TabIndex = 10;
            this.SniffedMessage.Text = "Message";
            this.SniffedMessage.Click += new System.EventHandler(this.SniffedMessage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 321);
            this.Controls.Add(this.SniffedMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TransmitDataButton);
            this.Controls.Add(this.TransmitTextBox);
            this.Controls.Add(this.DeviceLabel);
            this.Controls.Add(this.SmartphoneMessage);
            this.Controls.Add(this.WearableName);
            this.Controls.Add(this.PhoneName);
            this.Controls.Add(this.PairButton);
            this.Controls.Add(this.StartNewSessionButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartNewSessionButton;
        private System.Windows.Forms.Button PairButton;
        private System.Windows.Forms.Label PhoneName;
        private System.Windows.Forms.Label WearableName;
        private System.Windows.Forms.Label SmartphoneMessage;
        private System.Windows.Forms.Label DeviceLabel;
        private System.Windows.Forms.TextBox TransmitTextBox;
        private System.Windows.Forms.Button TransmitDataButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SniffedMessage;
    }
}

