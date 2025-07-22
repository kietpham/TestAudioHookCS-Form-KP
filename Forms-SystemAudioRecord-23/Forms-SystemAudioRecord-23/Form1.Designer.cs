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
            this.label_VoskTranscript_System = new System.Windows.Forms.Label();
            this.label_MSTranscript_System = new System.Windows.Forms.Label();
            this.label_MSTranscript_Mic = new System.Windows.Forms.Label();
            this.label_VoskTranscript_Mic = new System.Windows.Forms.Label();
            this.checkBox_RecordFile_System = new System.Windows.Forms.CheckBox();
            this.checkBox_RecordFile_Mic = new System.Windows.Forms.CheckBox();
            this.richTextBox_SAudio_Vosk_Transcript = new System.Windows.Forms.RichTextBox();
            this.richTextBox_SAudio_MS_Transcript = new System.Windows.Forms.RichTextBox();
            this.richTextBox_MicIn_MS_Transcript = new System.Windows.Forms.RichTextBox();
            this.richTextBox_MicIn_Vosk_Transcript = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button_Record
            // 
            this.button_Record.Location = new System.Drawing.Point(276, 31);
            this.button_Record.Margin = new System.Windows.Forms.Padding(2);
            this.button_Record.Name = "button_Record";
            this.button_Record.Size = new System.Drawing.Size(106, 24);
            this.button_Record.TabIndex = 0;
            this.button_Record.Text = "Record Output";
            this.button_Record.UseVisualStyleBackColor = true;
            this.button_Record.Click += new System.EventHandler(this.button_Record_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(276, 54);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(106, 24);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop Recording Output";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // listBox_Speakers
            // 
            this.listBox_Speakers.FormattingEnabled = true;
            this.listBox_Speakers.Location = new System.Drawing.Point(10, 11);
            this.listBox_Speakers.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_Speakers.Name = "listBox_Speakers";
            this.listBox_Speakers.Size = new System.Drawing.Size(263, 69);
            this.listBox_Speakers.TabIndex = 2;
            this.listBox_Speakers.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox_Micro
            // 
            this.listBox_Micro.FormattingEnabled = true;
            this.listBox_Micro.Location = new System.Drawing.Point(10, 225);
            this.listBox_Micro.Margin = new System.Windows.Forms.Padding(2);
            this.listBox_Micro.Name = "listBox_Micro";
            this.listBox_Micro.Size = new System.Drawing.Size(263, 69);
            this.listBox_Micro.TabIndex = 3;
            this.listBox_Micro.SelectedIndexChanged += new System.EventHandler(this.listBox_Micro_SelectedIndexChanged);
            // 
            // button_StopRecordMic
            // 
            this.button_StopRecordMic.Location = new System.Drawing.Point(276, 269);
            this.button_StopRecordMic.Margin = new System.Windows.Forms.Padding(2);
            this.button_StopRecordMic.Name = "button_StopRecordMic";
            this.button_StopRecordMic.Size = new System.Drawing.Size(106, 24);
            this.button_StopRecordMic.TabIndex = 5;
            this.button_StopRecordMic.Text = "Stop Recording Mic";
            this.button_StopRecordMic.UseVisualStyleBackColor = true;
            this.button_StopRecordMic.Click += new System.EventHandler(this.button_StopRecordMic_Click);
            // 
            // button_RecordMic
            // 
            this.button_RecordMic.Location = new System.Drawing.Point(276, 246);
            this.button_RecordMic.Margin = new System.Windows.Forms.Padding(2);
            this.button_RecordMic.Name = "button_RecordMic";
            this.button_RecordMic.Size = new System.Drawing.Size(106, 24);
            this.button_RecordMic.TabIndex = 4;
            this.button_RecordMic.Text = "Record Mic";
            this.button_RecordMic.UseVisualStyleBackColor = true;
            this.button_RecordMic.Click += new System.EventHandler(this.button_RecordMic_Click);
            // 
            // label_VoskTranscript_System
            // 
            this.label_VoskTranscript_System.AutoSize = true;
            this.label_VoskTranscript_System.Location = new System.Drawing.Point(390, 11);
            this.label_VoskTranscript_System.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_VoskTranscript_System.Name = "label_VoskTranscript_System";
            this.label_VoskTranscript_System.Size = new System.Drawing.Size(81, 13);
            this.label_VoskTranscript_System.TabIndex = 6;
            this.label_VoskTranscript_System.Text = "Vosk Transcript";
            // 
            // label_MSTranscript_System
            // 
            this.label_MSTranscript_System.AutoSize = true;
            this.label_MSTranscript_System.Location = new System.Drawing.Point(390, 31);
            this.label_MSTranscript_System.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_MSTranscript_System.Name = "label_MSTranscript_System";
            this.label_MSTranscript_System.Size = new System.Drawing.Size(73, 13);
            this.label_MSTranscript_System.TabIndex = 7;
            this.label_MSTranscript_System.Text = "MS Transcript";
            // 
            // label_MSTranscript_Mic
            // 
            this.label_MSTranscript_Mic.AutoSize = true;
            this.label_MSTranscript_Mic.Location = new System.Drawing.Point(390, 246);
            this.label_MSTranscript_Mic.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_MSTranscript_Mic.Name = "label_MSTranscript_Mic";
            this.label_MSTranscript_Mic.Size = new System.Drawing.Size(73, 13);
            this.label_MSTranscript_Mic.TabIndex = 9;
            this.label_MSTranscript_Mic.Text = "MS Transcript";
            // 
            // label_VoskTranscript_Mic
            // 
            this.label_VoskTranscript_Mic.AutoSize = true;
            this.label_VoskTranscript_Mic.Location = new System.Drawing.Point(390, 225);
            this.label_VoskTranscript_Mic.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_VoskTranscript_Mic.Name = "label_VoskTranscript_Mic";
            this.label_VoskTranscript_Mic.Size = new System.Drawing.Size(81, 13);
            this.label_VoskTranscript_Mic.TabIndex = 8;
            this.label_VoskTranscript_Mic.Text = "Vosk Transcript";
            // 
            // checkBox_RecordFile_System
            // 
            this.checkBox_RecordFile_System.AutoSize = true;
            this.checkBox_RecordFile_System.Location = new System.Drawing.Point(276, 11);
            this.checkBox_RecordFile_System.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_RecordFile_System.Name = "checkBox_RecordFile_System";
            this.checkBox_RecordFile_System.Size = new System.Drawing.Size(80, 17);
            this.checkBox_RecordFile_System.TabIndex = 10;
            this.checkBox_RecordFile_System.Text = "Record File";
            this.checkBox_RecordFile_System.UseVisualStyleBackColor = true;
            // 
            // checkBox_RecordFile_Mic
            // 
            this.checkBox_RecordFile_Mic.AutoSize = true;
            this.checkBox_RecordFile_Mic.Location = new System.Drawing.Point(276, 225);
            this.checkBox_RecordFile_Mic.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_RecordFile_Mic.Name = "checkBox_RecordFile_Mic";
            this.checkBox_RecordFile_Mic.Size = new System.Drawing.Size(80, 17);
            this.checkBox_RecordFile_Mic.TabIndex = 11;
            this.checkBox_RecordFile_Mic.Text = "Record File";
            this.checkBox_RecordFile_Mic.UseVisualStyleBackColor = true;
            // 
            // richTextBox_SAudio_Vosk_Transcript
            // 
            this.richTextBox_SAudio_Vosk_Transcript.Location = new System.Drawing.Point(10, 86);
            this.richTextBox_SAudio_Vosk_Transcript.Name = "richTextBox_SAudio_Vosk_Transcript";
            this.richTextBox_SAudio_Vosk_Transcript.Size = new System.Drawing.Size(621, 69);
            this.richTextBox_SAudio_Vosk_Transcript.TabIndex = 12;
            this.richTextBox_SAudio_Vosk_Transcript.Text = "Vosk Transcript";
            // 
            // richTextBox_SAudio_MS_Transcript
            // 
            this.richTextBox_SAudio_MS_Transcript.Location = new System.Drawing.Point(10, 161);
            this.richTextBox_SAudio_MS_Transcript.Name = "richTextBox_SAudio_MS_Transcript";
            this.richTextBox_SAudio_MS_Transcript.Size = new System.Drawing.Size(621, 46);
            this.richTextBox_SAudio_MS_Transcript.TabIndex = 13;
            this.richTextBox_SAudio_MS_Transcript.Text = "MS Transcript";
            // 
            // richTextBox_MicIn_MS_Transcript
            // 
            this.richTextBox_MicIn_MS_Transcript.Location = new System.Drawing.Point(10, 374);
            this.richTextBox_MicIn_MS_Transcript.Name = "richTextBox_MicIn_MS_Transcript";
            this.richTextBox_MicIn_MS_Transcript.Size = new System.Drawing.Size(621, 46);
            this.richTextBox_MicIn_MS_Transcript.TabIndex = 15;
            this.richTextBox_MicIn_MS_Transcript.Text = "MS Transcript";
            // 
            // richTextBox_MicIn_Vosk_Transcript
            // 
            this.richTextBox_MicIn_Vosk_Transcript.Location = new System.Drawing.Point(10, 299);
            this.richTextBox_MicIn_Vosk_Transcript.Name = "richTextBox_MicIn_Vosk_Transcript";
            this.richTextBox_MicIn_Vosk_Transcript.Size = new System.Drawing.Size(621, 69);
            this.richTextBox_MicIn_Vosk_Transcript.TabIndex = 14;
            this.richTextBox_MicIn_Vosk_Transcript.Text = "Vosk Transcript";
            // 
            // FormRecordSpeaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 431);
            this.Controls.Add(this.richTextBox_MicIn_MS_Transcript);
            this.Controls.Add(this.richTextBox_MicIn_Vosk_Transcript);
            this.Controls.Add(this.richTextBox_SAudio_MS_Transcript);
            this.Controls.Add(this.richTextBox_SAudio_Vosk_Transcript);
            this.Controls.Add(this.checkBox_RecordFile_Mic);
            this.Controls.Add(this.checkBox_RecordFile_System);
            this.Controls.Add(this.label_MSTranscript_Mic);
            this.Controls.Add(this.label_VoskTranscript_Mic);
            this.Controls.Add(this.label_MSTranscript_System);
            this.Controls.Add(this.label_VoskTranscript_System);
            this.Controls.Add(this.button_StopRecordMic);
            this.Controls.Add(this.button_RecordMic);
            this.Controls.Add(this.listBox_Micro);
            this.Controls.Add(this.listBox_Speakers);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.button_Record);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormRecordSpeaker";
            this.Text = "RecordSpeaker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Record;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ListBox listBox_Speakers;
        private System.Windows.Forms.ListBox listBox_Micro;
        private System.Windows.Forms.Button button_StopRecordMic;
        private System.Windows.Forms.Button button_RecordMic;
        private System.Windows.Forms.Label label_VoskTranscript_System;
        private System.Windows.Forms.Label label_MSTranscript_System;
        private System.Windows.Forms.Label label_MSTranscript_Mic;
        private System.Windows.Forms.Label label_VoskTranscript_Mic;
        private System.Windows.Forms.CheckBox checkBox_RecordFile_System;
        private System.Windows.Forms.CheckBox checkBox_RecordFile_Mic;
        private System.Windows.Forms.RichTextBox richTextBox_SAudio_Vosk_Transcript;
        private System.Windows.Forms.RichTextBox richTextBox_SAudio_MS_Transcript;
        private System.Windows.Forms.RichTextBox richTextBox_MicIn_MS_Transcript;
        private System.Windows.Forms.RichTextBox richTextBox_MicIn_Vosk_Transcript;
    }
}

