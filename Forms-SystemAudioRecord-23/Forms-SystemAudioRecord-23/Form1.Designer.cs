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
            this.checkBox_SystemAudio_Use_Vosk = new System.Windows.Forms.CheckBox();
            this.checkBox_SystemAudio_Use_MS = new System.Windows.Forms.CheckBox();
            this.checkBox_Mic_Use_MS = new System.Windows.Forms.CheckBox();
            this.checkBox_Mic_Use_Vosk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_Record
            // 
            this.button_Record.Location = new System.Drawing.Point(368, 38);
            this.button_Record.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Record.Name = "button_Record";
            this.button_Record.Size = new System.Drawing.Size(141, 30);
            this.button_Record.TabIndex = 0;
            this.button_Record.Text = "Record Output";
            this.button_Record.UseVisualStyleBackColor = true;
            this.button_Record.Click += new System.EventHandler(this.button_Record_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(368, 66);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(141, 30);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop Recording Output";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // listBox_Speakers
            // 
            this.listBox_Speakers.Enabled = false;
            this.listBox_Speakers.FormattingEnabled = true;
            this.listBox_Speakers.ItemHeight = 16;
            this.listBox_Speakers.Items.AddRange(new object[] {
            "LisBox Speaker"});
            this.listBox_Speakers.Location = new System.Drawing.Point(13, 14);
            this.listBox_Speakers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox_Speakers.Name = "listBox_Speakers";
            this.listBox_Speakers.Size = new System.Drawing.Size(349, 84);
            this.listBox_Speakers.TabIndex = 2;
            // 
            // listBox_Micro
            // 
            this.listBox_Micro.Enabled = false;
            this.listBox_Micro.FormattingEnabled = true;
            this.listBox_Micro.ItemHeight = 16;
            this.listBox_Micro.Items.AddRange(new object[] {
            "ListBox Micro"});
            this.listBox_Micro.Location = new System.Drawing.Point(13, 362);
            this.listBox_Micro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBox_Micro.Name = "listBox_Micro";
            this.listBox_Micro.Size = new System.Drawing.Size(349, 84);
            this.listBox_Micro.TabIndex = 3;
            // 
            // button_StopRecordMic
            // 
            this.button_StopRecordMic.Location = new System.Drawing.Point(368, 416);
            this.button_StopRecordMic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_StopRecordMic.Name = "button_StopRecordMic";
            this.button_StopRecordMic.Size = new System.Drawing.Size(141, 30);
            this.button_StopRecordMic.TabIndex = 5;
            this.button_StopRecordMic.Text = "Stop Recording Mic";
            this.button_StopRecordMic.UseVisualStyleBackColor = true;
            this.button_StopRecordMic.Click += new System.EventHandler(this.button_StopRecordMic_Click);
            // 
            // button_RecordMic
            // 
            this.button_RecordMic.Location = new System.Drawing.Point(368, 388);
            this.button_RecordMic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_RecordMic.Name = "button_RecordMic";
            this.button_RecordMic.Size = new System.Drawing.Size(141, 30);
            this.button_RecordMic.TabIndex = 4;
            this.button_RecordMic.Text = "Record Mic";
            this.button_RecordMic.UseVisualStyleBackColor = true;
            this.button_RecordMic.Click += new System.EventHandler(this.button_RecordMic_Click);
            // 
            // label_VoskTranscript_System
            // 
            this.label_VoskTranscript_System.AutoSize = true;
            this.label_VoskTranscript_System.Location = new System.Drawing.Point(520, 14);
            this.label_VoskTranscript_System.Name = "label_VoskTranscript_System";
            this.label_VoskTranscript_System.Size = new System.Drawing.Size(101, 16);
            this.label_VoskTranscript_System.TabIndex = 6;
            this.label_VoskTranscript_System.Text = "Vosk Transcript";
            // 
            // label_MSTranscript_System
            // 
            this.label_MSTranscript_System.AutoSize = true;
            this.label_MSTranscript_System.Location = new System.Drawing.Point(520, 38);
            this.label_MSTranscript_System.Name = "label_MSTranscript_System";
            this.label_MSTranscript_System.Size = new System.Drawing.Size(115, 16);
            this.label_MSTranscript_System.TabIndex = 7;
            this.label_MSTranscript_System.Text = "MS/API Transcript";
            // 
            // label_MSTranscript_Mic
            // 
            this.label_MSTranscript_Mic.AutoSize = true;
            this.label_MSTranscript_Mic.Location = new System.Drawing.Point(520, 388);
            this.label_MSTranscript_Mic.Name = "label_MSTranscript_Mic";
            this.label_MSTranscript_Mic.Size = new System.Drawing.Size(115, 16);
            this.label_MSTranscript_Mic.TabIndex = 9;
            this.label_MSTranscript_Mic.Text = "MS/API Transcript";
            // 
            // label_VoskTranscript_Mic
            // 
            this.label_VoskTranscript_Mic.AutoSize = true;
            this.label_VoskTranscript_Mic.Location = new System.Drawing.Point(520, 362);
            this.label_VoskTranscript_Mic.Name = "label_VoskTranscript_Mic";
            this.label_VoskTranscript_Mic.Size = new System.Drawing.Size(101, 16);
            this.label_VoskTranscript_Mic.TabIndex = 8;
            this.label_VoskTranscript_Mic.Text = "Vosk Transcript";
            // 
            // checkBox_RecordFile_System
            // 
            this.checkBox_RecordFile_System.AutoSize = true;
            this.checkBox_RecordFile_System.Checked = true;
            this.checkBox_RecordFile_System.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RecordFile_System.Enabled = false;
            this.checkBox_RecordFile_System.Location = new System.Drawing.Point(368, 14);
            this.checkBox_RecordFile_System.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_RecordFile_System.Name = "checkBox_RecordFile_System";
            this.checkBox_RecordFile_System.Size = new System.Drawing.Size(99, 20);
            this.checkBox_RecordFile_System.TabIndex = 10;
            this.checkBox_RecordFile_System.Text = "Record File";
            this.checkBox_RecordFile_System.UseVisualStyleBackColor = true;
            // 
            // checkBox_RecordFile_Mic
            // 
            this.checkBox_RecordFile_Mic.AutoSize = true;
            this.checkBox_RecordFile_Mic.Checked = true;
            this.checkBox_RecordFile_Mic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RecordFile_Mic.Enabled = false;
            this.checkBox_RecordFile_Mic.Location = new System.Drawing.Point(368, 362);
            this.checkBox_RecordFile_Mic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_RecordFile_Mic.Name = "checkBox_RecordFile_Mic";
            this.checkBox_RecordFile_Mic.Size = new System.Drawing.Size(99, 20);
            this.checkBox_RecordFile_Mic.TabIndex = 11;
            this.checkBox_RecordFile_Mic.Text = "Record File";
            this.checkBox_RecordFile_Mic.UseVisualStyleBackColor = true;
            // 
            // richTextBox_SAudio_Vosk_Transcript
            // 
            this.richTextBox_SAudio_Vosk_Transcript.Location = new System.Drawing.Point(13, 106);
            this.richTextBox_SAudio_Vosk_Transcript.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox_SAudio_Vosk_Transcript.Name = "richTextBox_SAudio_Vosk_Transcript";
            this.richTextBox_SAudio_Vosk_Transcript.Size = new System.Drawing.Size(827, 84);
            this.richTextBox_SAudio_Vosk_Transcript.TabIndex = 12;
            this.richTextBox_SAudio_Vosk_Transcript.Text = "Vosk Transcript";
            // 
            // richTextBox_SAudio_MS_Transcript
            // 
            this.richTextBox_SAudio_MS_Transcript.Location = new System.Drawing.Point(13, 198);
            this.richTextBox_SAudio_MS_Transcript.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox_SAudio_MS_Transcript.Name = "richTextBox_SAudio_MS_Transcript";
            this.richTextBox_SAudio_MS_Transcript.Size = new System.Drawing.Size(827, 157);
            this.richTextBox_SAudio_MS_Transcript.TabIndex = 13;
            this.richTextBox_SAudio_MS_Transcript.Text = "MS/API Transcript";
            // 
            // richTextBox_MicIn_MS_Transcript
            // 
            this.richTextBox_MicIn_MS_Transcript.Location = new System.Drawing.Point(13, 545);
            this.richTextBox_MicIn_MS_Transcript.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox_MicIn_MS_Transcript.Name = "richTextBox_MicIn_MS_Transcript";
            this.richTextBox_MicIn_MS_Transcript.Size = new System.Drawing.Size(827, 120);
            this.richTextBox_MicIn_MS_Transcript.TabIndex = 15;
            this.richTextBox_MicIn_MS_Transcript.Text = "MS/API Transcript";
            // 
            // richTextBox_MicIn_Vosk_Transcript
            // 
            this.richTextBox_MicIn_Vosk_Transcript.Location = new System.Drawing.Point(13, 453);
            this.richTextBox_MicIn_Vosk_Transcript.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox_MicIn_Vosk_Transcript.Name = "richTextBox_MicIn_Vosk_Transcript";
            this.richTextBox_MicIn_Vosk_Transcript.Size = new System.Drawing.Size(827, 84);
            this.richTextBox_MicIn_Vosk_Transcript.TabIndex = 14;
            this.richTextBox_MicIn_Vosk_Transcript.Text = "Vosk Transcript";
            // 
            // checkBox_SystemAudio_Use_Vosk
            // 
            this.checkBox_SystemAudio_Use_Vosk.AutoSize = true;
            this.checkBox_SystemAudio_Use_Vosk.Enabled = false;
            this.checkBox_SystemAudio_Use_Vosk.Location = new System.Drawing.Point(643, 14);
            this.checkBox_SystemAudio_Use_Vosk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_SystemAudio_Use_Vosk.Name = "checkBox_SystemAudio_Use_Vosk";
            this.checkBox_SystemAudio_Use_Vosk.Size = new System.Drawing.Size(88, 20);
            this.checkBox_SystemAudio_Use_Vosk.TabIndex = 16;
            this.checkBox_SystemAudio_Use_Vosk.Text = "Use Vosk";
            this.checkBox_SystemAudio_Use_Vosk.UseVisualStyleBackColor = true;
            this.checkBox_SystemAudio_Use_Vosk.CheckedChanged += new System.EventHandler(this.checkBox_SystemAudio_Use_Vosk_CheckedChanged);
            // 
            // checkBox_SystemAudio_Use_MS
            // 
            this.checkBox_SystemAudio_Use_MS.AutoSize = true;
            this.checkBox_SystemAudio_Use_MS.Checked = true;
            this.checkBox_SystemAudio_Use_MS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SystemAudio_Use_MS.Enabled = false;
            this.checkBox_SystemAudio_Use_MS.Location = new System.Drawing.Point(643, 37);
            this.checkBox_SystemAudio_Use_MS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_SystemAudio_Use_MS.Name = "checkBox_SystemAudio_Use_MS";
            this.checkBox_SystemAudio_Use_MS.Size = new System.Drawing.Size(78, 20);
            this.checkBox_SystemAudio_Use_MS.TabIndex = 17;
            this.checkBox_SystemAudio_Use_MS.Text = "Use API";
            this.checkBox_SystemAudio_Use_MS.UseVisualStyleBackColor = true;
            this.checkBox_SystemAudio_Use_MS.CheckedChanged += new System.EventHandler(this.checkBox_SystemAudio_Use_MS_CheckedChanged);
            // 
            // checkBox_Mic_Use_MS
            // 
            this.checkBox_Mic_Use_MS.AutoSize = true;
            this.checkBox_Mic_Use_MS.Checked = true;
            this.checkBox_Mic_Use_MS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Mic_Use_MS.Enabled = false;
            this.checkBox_Mic_Use_MS.Location = new System.Drawing.Point(643, 386);
            this.checkBox_Mic_Use_MS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Mic_Use_MS.Name = "checkBox_Mic_Use_MS";
            this.checkBox_Mic_Use_MS.Size = new System.Drawing.Size(78, 20);
            this.checkBox_Mic_Use_MS.TabIndex = 19;
            this.checkBox_Mic_Use_MS.Text = "Use API";
            this.checkBox_Mic_Use_MS.UseVisualStyleBackColor = true;
            this.checkBox_Mic_Use_MS.CheckedChanged += new System.EventHandler(this.checkBox_Mic_Use_MS_CheckedChanged);
            // 
            // checkBox_Mic_Use_Vosk
            // 
            this.checkBox_Mic_Use_Vosk.AutoSize = true;
            this.checkBox_Mic_Use_Vosk.Enabled = false;
            this.checkBox_Mic_Use_Vosk.Location = new System.Drawing.Point(643, 361);
            this.checkBox_Mic_Use_Vosk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_Mic_Use_Vosk.Name = "checkBox_Mic_Use_Vosk";
            this.checkBox_Mic_Use_Vosk.Size = new System.Drawing.Size(88, 20);
            this.checkBox_Mic_Use_Vosk.TabIndex = 18;
            this.checkBox_Mic_Use_Vosk.Text = "Use Vosk";
            this.checkBox_Mic_Use_Vosk.UseVisualStyleBackColor = true;
            this.checkBox_Mic_Use_Vosk.CheckedChanged += new System.EventHandler(this.checkBox_Mic_Use_Vosk_CheckedChanged);
            // 
            // FormRecordSpeaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 679);
            this.Controls.Add(this.checkBox_Mic_Use_MS);
            this.Controls.Add(this.checkBox_Mic_Use_Vosk);
            this.Controls.Add(this.checkBox_SystemAudio_Use_MS);
            this.Controls.Add(this.checkBox_SystemAudio_Use_Vosk);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.CheckBox checkBox_SystemAudio_Use_Vosk;
        private System.Windows.Forms.CheckBox checkBox_SystemAudio_Use_MS;
        private System.Windows.Forms.CheckBox checkBox_Mic_Use_MS;
        private System.Windows.Forms.CheckBox checkBox_Mic_Use_Vosk;
    }
}

