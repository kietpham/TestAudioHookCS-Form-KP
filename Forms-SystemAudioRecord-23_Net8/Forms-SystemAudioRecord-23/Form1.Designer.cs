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
            button_Record = new System.Windows.Forms.Button();
            buttonStop = new System.Windows.Forms.Button();
            listBox_Speakers = new System.Windows.Forms.ListBox();
            listBox_Micro = new System.Windows.Forms.ListBox();
            button_StopRecordMic = new System.Windows.Forms.Button();
            button_RecordMic = new System.Windows.Forms.Button();
            label_VoskTranscript_System = new System.Windows.Forms.Label();
            label_MSTranscript_System = new System.Windows.Forms.Label();
            label_MSTranscript_Mic = new System.Windows.Forms.Label();
            label_VoskTranscript_Mic = new System.Windows.Forms.Label();
            checkBox_RecordFile_System = new System.Windows.Forms.CheckBox();
            checkBox_RecordFile_Mic = new System.Windows.Forms.CheckBox();
            richTextBox_SAudio_Vosk_Transcript = new System.Windows.Forms.RichTextBox();
            richTextBox_SAudio_MS_Transcript = new System.Windows.Forms.RichTextBox();
            richTextBox_MicIn_MS_Transcript = new System.Windows.Forms.RichTextBox();
            richTextBox_MicIn_Vosk_Transcript = new System.Windows.Forms.RichTextBox();
            checkBox_SystemAudio_Use_Vosk = new System.Windows.Forms.CheckBox();
            checkBox_SystemAudio_Use_MS = new System.Windows.Forms.CheckBox();
            checkBox_Mic_Use_MS = new System.Windows.Forms.CheckBox();
            checkBox_Mic_Use_Vosk = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // button_Record
            // 
            button_Record.Location = new System.Drawing.Point(322, 32);
            button_Record.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button_Record.Name = "button_Record";
            button_Record.Size = new System.Drawing.Size(123, 26);
            button_Record.TabIndex = 0;
            button_Record.Text = "Record Output";
            button_Record.UseVisualStyleBackColor = true;
            button_Record.Click += button_Record_Click;
            // 
            // buttonStop
            // 
            buttonStop.Location = new System.Drawing.Point(322, 62);
            buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new System.Drawing.Size(123, 28);
            buttonStop.TabIndex = 1;
            buttonStop.Text = "Stop Recording Output";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // listBox_Speakers
            // 
            listBox_Speakers.Enabled = false;
            listBox_Speakers.FormattingEnabled = true;
            listBox_Speakers.ItemHeight = 15;
            listBox_Speakers.Items.AddRange(new object[] { "LisBox Speaker" });
            listBox_Speakers.Location = new System.Drawing.Point(11, 13);
            listBox_Speakers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            listBox_Speakers.Name = "listBox_Speakers";
            listBox_Speakers.Size = new System.Drawing.Size(306, 79);
            listBox_Speakers.TabIndex = 2;
            // 
            // listBox_Micro
            // 
            listBox_Micro.Enabled = false;
            listBox_Micro.FormattingEnabled = true;
            listBox_Micro.ItemHeight = 15;
            listBox_Micro.Items.AddRange(new object[] { "ListBox Micro" });
            listBox_Micro.Location = new System.Drawing.Point(11, 280);
            listBox_Micro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            listBox_Micro.Name = "listBox_Micro";
            listBox_Micro.Size = new System.Drawing.Size(306, 79);
            listBox_Micro.TabIndex = 3;
            // 
            // button_StopRecordMic
            // 
            button_StopRecordMic.Location = new System.Drawing.Point(322, 331);
            button_StopRecordMic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button_StopRecordMic.Name = "button_StopRecordMic";
            button_StopRecordMic.Size = new System.Drawing.Size(123, 28);
            button_StopRecordMic.TabIndex = 5;
            button_StopRecordMic.Text = "Stop Recording Mic";
            button_StopRecordMic.UseVisualStyleBackColor = true;
            button_StopRecordMic.Click += button_StopRecordMic_Click;
            // 
            // button_RecordMic
            // 
            button_RecordMic.Location = new System.Drawing.Point(323, 298);
            button_RecordMic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            button_RecordMic.Name = "button_RecordMic";
            button_RecordMic.Size = new System.Drawing.Size(123, 28);
            button_RecordMic.TabIndex = 4;
            button_RecordMic.Text = "Record Mic";
            button_RecordMic.UseVisualStyleBackColor = true;
            button_RecordMic.Click += button_RecordMic_Click;
            // 
            // label_VoskTranscript_System
            // 
            label_VoskTranscript_System.AutoSize = true;
            label_VoskTranscript_System.Location = new System.Drawing.Point(455, 13);
            label_VoskTranscript_System.Name = "label_VoskTranscript_System";
            label_VoskTranscript_System.Size = new System.Drawing.Size(86, 15);
            label_VoskTranscript_System.TabIndex = 6;
            label_VoskTranscript_System.Text = "Vosk Transcript";
            // 
            // label_MSTranscript_System
            // 
            label_MSTranscript_System.AutoSize = true;
            label_MSTranscript_System.Location = new System.Drawing.Point(455, 36);
            label_MSTranscript_System.Name = "label_MSTranscript_System";
            label_MSTranscript_System.Size = new System.Drawing.Size(102, 15);
            label_MSTranscript_System.TabIndex = 7;
            label_MSTranscript_System.Text = "MS/API Transcript";
            // 
            // label_MSTranscript_Mic
            // 
            label_MSTranscript_Mic.AutoSize = true;
            label_MSTranscript_Mic.Location = new System.Drawing.Point(455, 305);
            label_MSTranscript_Mic.Name = "label_MSTranscript_Mic";
            label_MSTranscript_Mic.Size = new System.Drawing.Size(102, 15);
            label_MSTranscript_Mic.TabIndex = 9;
            label_MSTranscript_Mic.Text = "MS/API Transcript";
            // 
            // label_VoskTranscript_Mic
            // 
            label_VoskTranscript_Mic.AutoSize = true;
            label_VoskTranscript_Mic.Location = new System.Drawing.Point(455, 280);
            label_VoskTranscript_Mic.Name = "label_VoskTranscript_Mic";
            label_VoskTranscript_Mic.Size = new System.Drawing.Size(86, 15);
            label_VoskTranscript_Mic.TabIndex = 8;
            label_VoskTranscript_Mic.Text = "Vosk Transcript";
            // 
            // checkBox_RecordFile_System
            // 
            checkBox_RecordFile_System.AutoSize = true;
            checkBox_RecordFile_System.Checked = true;
            checkBox_RecordFile_System.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_RecordFile_System.Enabled = false;
            checkBox_RecordFile_System.Location = new System.Drawing.Point(322, 13);
            checkBox_RecordFile_System.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            checkBox_RecordFile_System.Name = "checkBox_RecordFile_System";
            checkBox_RecordFile_System.Size = new System.Drawing.Size(84, 19);
            checkBox_RecordFile_System.TabIndex = 10;
            checkBox_RecordFile_System.Text = "Record File";
            checkBox_RecordFile_System.UseVisualStyleBackColor = true;
            // 
            // checkBox_RecordFile_Mic
            // 
            checkBox_RecordFile_Mic.AutoSize = true;
            checkBox_RecordFile_Mic.Checked = true;
            checkBox_RecordFile_Mic.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_RecordFile_Mic.Enabled = false;
            checkBox_RecordFile_Mic.Location = new System.Drawing.Point(322, 280);
            checkBox_RecordFile_Mic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            checkBox_RecordFile_Mic.Name = "checkBox_RecordFile_Mic";
            checkBox_RecordFile_Mic.Size = new System.Drawing.Size(84, 19);
            checkBox_RecordFile_Mic.TabIndex = 11;
            checkBox_RecordFile_Mic.Text = "Record File";
            checkBox_RecordFile_Mic.UseVisualStyleBackColor = true;
            // 
            // richTextBox_SAudio_Vosk_Transcript
            // 
            richTextBox_SAudio_Vosk_Transcript.Enabled = false;
            richTextBox_SAudio_Vosk_Transcript.Location = new System.Drawing.Point(11, 99);
            richTextBox_SAudio_Vosk_Transcript.Margin = new System.Windows.Forms.Padding(4);
            richTextBox_SAudio_Vosk_Transcript.Name = "richTextBox_SAudio_Vosk_Transcript";
            richTextBox_SAudio_Vosk_Transcript.Size = new System.Drawing.Size(724, 18);
            richTextBox_SAudio_Vosk_Transcript.TabIndex = 12;
            richTextBox_SAudio_Vosk_Transcript.Text = "Vosk Transcript - Obsoleted";
            // 
            // richTextBox_SAudio_MS_Transcript
            // 
            richTextBox_SAudio_MS_Transcript.Location = new System.Drawing.Point(11, 125);
            richTextBox_SAudio_MS_Transcript.Margin = new System.Windows.Forms.Padding(4);
            richTextBox_SAudio_MS_Transcript.Name = "richTextBox_SAudio_MS_Transcript";
            richTextBox_SAudio_MS_Transcript.Size = new System.Drawing.Size(724, 147);
            richTextBox_SAudio_MS_Transcript.TabIndex = 13;
            richTextBox_SAudio_MS_Transcript.Text = "MS/API Transcript";
            // 
            // richTextBox_MicIn_MS_Transcript
            // 
            richTextBox_MicIn_MS_Transcript.Location = new System.Drawing.Point(11, 392);
            richTextBox_MicIn_MS_Transcript.Margin = new System.Windows.Forms.Padding(4);
            richTextBox_MicIn_MS_Transcript.Name = "richTextBox_MicIn_MS_Transcript";
            richTextBox_MicIn_MS_Transcript.Size = new System.Drawing.Size(724, 135);
            richTextBox_MicIn_MS_Transcript.TabIndex = 15;
            richTextBox_MicIn_MS_Transcript.Text = "MS/API Transcript";
            // 
            // richTextBox_MicIn_Vosk_Transcript
            // 
            richTextBox_MicIn_Vosk_Transcript.Enabled = false;
            richTextBox_MicIn_Vosk_Transcript.Location = new System.Drawing.Point(11, 366);
            richTextBox_MicIn_Vosk_Transcript.Margin = new System.Windows.Forms.Padding(4);
            richTextBox_MicIn_Vosk_Transcript.Name = "richTextBox_MicIn_Vosk_Transcript";
            richTextBox_MicIn_Vosk_Transcript.Size = new System.Drawing.Size(724, 19);
            richTextBox_MicIn_Vosk_Transcript.TabIndex = 14;
            richTextBox_MicIn_Vosk_Transcript.Text = "Vosk Transcript  - Obsoleted";
            // 
            // checkBox_SystemAudio_Use_Vosk
            // 
            checkBox_SystemAudio_Use_Vosk.AutoSize = true;
            checkBox_SystemAudio_Use_Vosk.Enabled = false;
            checkBox_SystemAudio_Use_Vosk.Location = new System.Drawing.Point(563, 13);
            checkBox_SystemAudio_Use_Vosk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            checkBox_SystemAudio_Use_Vosk.Name = "checkBox_SystemAudio_Use_Vosk";
            checkBox_SystemAudio_Use_Vosk.Size = new System.Drawing.Size(72, 19);
            checkBox_SystemAudio_Use_Vosk.TabIndex = 16;
            checkBox_SystemAudio_Use_Vosk.Text = "Use Vosk";
            checkBox_SystemAudio_Use_Vosk.UseVisualStyleBackColor = true;
            checkBox_SystemAudio_Use_Vosk.CheckedChanged += checkBox_SystemAudio_Use_Vosk_CheckedChanged;
            // 
            // checkBox_SystemAudio_Use_MS
            // 
            checkBox_SystemAudio_Use_MS.AutoSize = true;
            checkBox_SystemAudio_Use_MS.Checked = true;
            checkBox_SystemAudio_Use_MS.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_SystemAudio_Use_MS.Enabled = false;
            checkBox_SystemAudio_Use_MS.Location = new System.Drawing.Point(563, 35);
            checkBox_SystemAudio_Use_MS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            checkBox_SystemAudio_Use_MS.Name = "checkBox_SystemAudio_Use_MS";
            checkBox_SystemAudio_Use_MS.Size = new System.Drawing.Size(66, 19);
            checkBox_SystemAudio_Use_MS.TabIndex = 17;
            checkBox_SystemAudio_Use_MS.Text = "Use API";
            checkBox_SystemAudio_Use_MS.UseVisualStyleBackColor = true;
            checkBox_SystemAudio_Use_MS.CheckedChanged += checkBox_SystemAudio_Use_MS_CheckedChanged;
            // 
            // checkBox_Mic_Use_MS
            // 
            checkBox_Mic_Use_MS.AutoSize = true;
            checkBox_Mic_Use_MS.Checked = true;
            checkBox_Mic_Use_MS.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_Mic_Use_MS.Enabled = false;
            checkBox_Mic_Use_MS.Location = new System.Drawing.Point(563, 303);
            checkBox_Mic_Use_MS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            checkBox_Mic_Use_MS.Name = "checkBox_Mic_Use_MS";
            checkBox_Mic_Use_MS.Size = new System.Drawing.Size(66, 19);
            checkBox_Mic_Use_MS.TabIndex = 19;
            checkBox_Mic_Use_MS.Text = "Use API";
            checkBox_Mic_Use_MS.UseVisualStyleBackColor = true;
            checkBox_Mic_Use_MS.CheckedChanged += checkBox_Mic_Use_MS_CheckedChanged;
            // 
            // checkBox_Mic_Use_Vosk
            // 
            checkBox_Mic_Use_Vosk.AutoSize = true;
            checkBox_Mic_Use_Vosk.Enabled = false;
            checkBox_Mic_Use_Vosk.Location = new System.Drawing.Point(563, 279);
            checkBox_Mic_Use_Vosk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            checkBox_Mic_Use_Vosk.Name = "checkBox_Mic_Use_Vosk";
            checkBox_Mic_Use_Vosk.Size = new System.Drawing.Size(72, 19);
            checkBox_Mic_Use_Vosk.TabIndex = 18;
            checkBox_Mic_Use_Vosk.Text = "Use Vosk";
            checkBox_Mic_Use_Vosk.UseVisualStyleBackColor = true;
            checkBox_Mic_Use_Vosk.CheckedChanged += checkBox_Mic_Use_Vosk_CheckedChanged;
            // 
            // FormRecordSpeaker
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(750, 543);
            Controls.Add(checkBox_Mic_Use_MS);
            Controls.Add(checkBox_Mic_Use_Vosk);
            Controls.Add(checkBox_SystemAudio_Use_MS);
            Controls.Add(checkBox_SystemAudio_Use_Vosk);
            Controls.Add(richTextBox_MicIn_MS_Transcript);
            Controls.Add(richTextBox_MicIn_Vosk_Transcript);
            Controls.Add(richTextBox_SAudio_MS_Transcript);
            Controls.Add(richTextBox_SAudio_Vosk_Transcript);
            Controls.Add(checkBox_RecordFile_Mic);
            Controls.Add(checkBox_RecordFile_System);
            Controls.Add(label_MSTranscript_Mic);
            Controls.Add(label_VoskTranscript_Mic);
            Controls.Add(label_MSTranscript_System);
            Controls.Add(label_VoskTranscript_System);
            Controls.Add(button_StopRecordMic);
            Controls.Add(button_RecordMic);
            Controls.Add(listBox_Micro);
            Controls.Add(listBox_Speakers);
            Controls.Add(buttonStop);
            Controls.Add(button_Record);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "FormRecordSpeaker";
            Text = "RecordSpeaker";
            ResumeLayout(false);
            PerformLayout();

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

