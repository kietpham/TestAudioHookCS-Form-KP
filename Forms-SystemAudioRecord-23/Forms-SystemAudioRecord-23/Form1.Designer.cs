namespace Forms_SystemAudioRecord_23
{
    partial class FormRecordSpeaker
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
            this.button_Record = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.listBox_Speakers = new System.Windows.Forms.ListBox();
            this.listBox_Micro = new System.Windows.Forms.ListBox();
            this.button_StopRecordMic = new System.Windows.Forms.Button();
            this.button_RecordMic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Record
            // 
            this.button_Record.Location = new System.Drawing.Point(13, 103);
            this.button_Record.Name = "button_Record";
            this.button_Record.Size = new System.Drawing.Size(350, 41);
            this.button_Record.TabIndex = 0;
            this.button_Record.Text = "Record Output";
            this.button_Record.UseVisualStyleBackColor = true;
            this.button_Record.Click += new System.EventHandler(this.button_Record_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(13, 150);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(349, 41);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop Recording Output";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // listBox_Speakers
            // 
            this.listBox_Speakers.FormattingEnabled = true;
            this.listBox_Speakers.ItemHeight = 16;
            this.listBox_Speakers.Location = new System.Drawing.Point(13, 13);
            this.listBox_Speakers.Name = "listBox_Speakers";
            this.listBox_Speakers.Size = new System.Drawing.Size(349, 84);
            this.listBox_Speakers.TabIndex = 2;
            this.listBox_Speakers.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox_Micro
            // 
            this.listBox_Micro.FormattingEnabled = true;
            this.listBox_Micro.ItemHeight = 16;
            this.listBox_Micro.Location = new System.Drawing.Point(13, 228);
            this.listBox_Micro.Name = "listBox_Micro";
            this.listBox_Micro.Size = new System.Drawing.Size(349, 84);
            this.listBox_Micro.TabIndex = 3;
            this.listBox_Micro.SelectedIndexChanged += new System.EventHandler(this.listBox_Micro_SelectedIndexChanged);
            // 
            // button_StopRecordMic
            // 
            this.button_StopRecordMic.Location = new System.Drawing.Point(12, 365);
            this.button_StopRecordMic.Name = "button_StopRecordMic";
            this.button_StopRecordMic.Size = new System.Drawing.Size(349, 41);
            this.button_StopRecordMic.TabIndex = 5;
            this.button_StopRecordMic.Text = "Stop Recording Mic";
            this.button_StopRecordMic.UseVisualStyleBackColor = true;
            this.button_StopRecordMic.Click += new System.EventHandler(this.button_StopRecordMic_Click);
            // 
            // button_RecordMic
            // 
            this.button_RecordMic.Location = new System.Drawing.Point(12, 318);
            this.button_RecordMic.Name = "button_RecordMic";
            this.button_RecordMic.Size = new System.Drawing.Size(350, 41);
            this.button_RecordMic.TabIndex = 4;
            this.button_RecordMic.Text = "Record Mic";
            this.button_RecordMic.UseVisualStyleBackColor = true;
            this.button_RecordMic.Click += new System.EventHandler(this.button_RecordMic_Click);
            // 
            // FormRecordSpeaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 419);
            this.Controls.Add(this.button_StopRecordMic);
            this.Controls.Add(this.button_RecordMic);
            this.Controls.Add(this.listBox_Micro);
            this.Controls.Add(this.listBox_Speakers);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.button_Record);
            this.Name = "FormRecordSpeaker";
            this.Text = "RecordSpeaker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Record;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ListBox listBox_Speakers;
        private System.Windows.Forms.ListBox listBox_Micro;
        private System.Windows.Forms.Button button_StopRecordMic;
        private System.Windows.Forms.Button button_RecordMic;
    }
}

