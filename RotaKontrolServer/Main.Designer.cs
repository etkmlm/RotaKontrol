
namespace RotaKontrolServer
{
    partial class Main
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lbSockets = new System.Windows.Forms.ListBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMsgSend = new System.Windows.Forms.Button();
            this.txtMsgContent = new System.Windows.Forms.TextBox();
            this.txtMsgTitle = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHibernate = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCmdSend = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnFileCancel = new System.Windows.Forms.Button();
            this.prgFile = new System.Windows.Forms.ProgressBar();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnFileSend = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnLiveScreenStop = new System.Windows.Forms.Button();
            this.btnLiveScreenStart = new System.Windows.Forms.Button();
            this.btnLiveTextStart = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnLiveTextStop = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtLiveText = new System.Windows.Forms.RichTextBox();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(922, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 34);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lbSockets
            // 
            this.lbSockets.FormattingEnabled = true;
            this.lbSockets.ItemHeight = 16;
            this.lbSockets.Location = new System.Drawing.Point(12, 12);
            this.lbSockets.Name = "lbSockets";
            this.lbSockets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSockets.Size = new System.Drawing.Size(247, 628);
            this.lbSockets.TabIndex = 1;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(265, 12);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(20, 17);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "IP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMsgSend);
            this.groupBox1.Controls.Add(this.txtMsgContent);
            this.groupBox1.Controls.Add(this.txtMsgTitle);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(268, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 180);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mesaj Kutusu";
            // 
            // btnMsgSend
            // 
            this.btnMsgSend.Location = new System.Drawing.Point(6, 123);
            this.btnMsgSend.Name = "btnMsgSend";
            this.btnMsgSend.Size = new System.Drawing.Size(226, 41);
            this.btnMsgSend.TabIndex = 2;
            this.btnMsgSend.Text = "Gönder";
            this.btnMsgSend.UseVisualStyleBackColor = true;
            // 
            // txtMsgContent
            // 
            this.txtMsgContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMsgContent.Location = new System.Drawing.Point(6, 81);
            this.txtMsgContent.Name = "txtMsgContent";
            this.txtMsgContent.Size = new System.Drawing.Size(226, 36);
            this.txtMsgContent.TabIndex = 1;
            // 
            // txtMsgTitle
            // 
            this.txtMsgTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtMsgTitle.Location = new System.Drawing.Point(6, 39);
            this.txtMsgTitle.Name = "txtMsgTitle";
            this.txtMsgTitle.Size = new System.Drawing.Size(226, 36);
            this.txtMsgTitle.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHibernate);
            this.groupBox2.Controls.Add(this.btnLock);
            this.groupBox2.Controls.Add(this.btnLogout);
            this.groupBox2.Controls.Add(this.btnRestart);
            this.groupBox2.Controls.Add(this.btnShutdown);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(526, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 180);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Yönetim";
            // 
            // btnHibernate
            // 
            this.btnHibernate.Location = new System.Drawing.Point(209, 103);
            this.btnHibernate.Name = "btnHibernate";
            this.btnHibernate.Size = new System.Drawing.Size(176, 41);
            this.btnHibernate.TabIndex = 7;
            this.btnHibernate.Text = "Uyku";
            this.btnHibernate.UseVisualStyleBackColor = true;
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(209, 56);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(176, 41);
            this.btnLock.TabIndex = 6;
            this.btnLock.Text = "Kilitle";
            this.btnLock.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(27, 128);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(176, 41);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Oturumu Kapat";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(27, 81);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(176, 41);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Yeniden Başlat";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // btnShutdown
            // 
            this.btnShutdown.Location = new System.Drawing.Point(27, 34);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(176, 41);
            this.btnShutdown.TabIndex = 3;
            this.btnShutdown.Text = "Kapat";
            this.btnShutdown.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCmdSend);
            this.groupBox3.Controls.Add(this.txtCommand);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(268, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(689, 77);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Komut";
            // 
            // btnCmdSend
            // 
            this.btnCmdSend.Location = new System.Drawing.Point(507, 29);
            this.btnCmdSend.Name = "btnCmdSend";
            this.btnCmdSend.Size = new System.Drawing.Size(176, 36);
            this.btnCmdSend.TabIndex = 8;
            this.btnCmdSend.Text = "Gönder";
            this.btnCmdSend.UseVisualStyleBackColor = true;
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCommand.Location = new System.Drawing.Point(6, 29);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(495, 36);
            this.txtCommand.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnFileCancel);
            this.groupBox4.Controls.Add(this.prgFile);
            this.groupBox4.Controls.Add(this.btnSelectFile);
            this.groupBox4.Controls.Add(this.btnFileSend);
            this.groupBox4.Controls.Add(this.txtFile);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox4.Location = new System.Drawing.Point(268, 317);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(689, 103);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dosya Gönder";
            // 
            // btnFileCancel
            // 
            this.btnFileCancel.Location = new System.Drawing.Point(581, 29);
            this.btnFileCancel.Name = "btnFileCancel";
            this.btnFileCancel.Size = new System.Drawing.Size(72, 36);
            this.btnFileCancel.TabIndex = 11;
            this.btnFileCancel.Text = "İptal";
            this.btnFileCancel.UseVisualStyleBackColor = true;
            // 
            // prgFile
            // 
            this.prgFile.Location = new System.Drawing.Point(6, 71);
            this.prgFile.Name = "prgFile";
            this.prgFile.Size = new System.Drawing.Size(647, 23);
            this.prgFile.TabIndex = 10;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(386, 29);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(85, 36);
            this.btnSelectFile.TabIndex = 9;
            this.btnSelectFile.Text = "Seç";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            // 
            // btnFileSend
            // 
            this.btnFileSend.Location = new System.Drawing.Point(473, 29);
            this.btnFileSend.Name = "btnFileSend";
            this.btnFileSend.Size = new System.Drawing.Size(107, 36);
            this.btnFileSend.TabIndex = 8;
            this.btnFileSend.Text = "Gönder";
            this.btnFileSend.UseVisualStyleBackColor = true;
            // 
            // txtFile
            // 
            this.txtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFile.Location = new System.Drawing.Point(6, 29);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(374, 36);
            this.txtFile.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnLiveScreenStop);
            this.groupBox5.Controls.Add(this.btnLiveScreenStart);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox5.Location = new System.Drawing.Point(268, 426);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(219, 122);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Canlı Ekran";
            // 
            // btnLiveScreenStop
            // 
            this.btnLiveScreenStop.Location = new System.Drawing.Point(55, 73);
            this.btnLiveScreenStop.Name = "btnLiveScreenStop";
            this.btnLiveScreenStop.Size = new System.Drawing.Size(104, 36);
            this.btnLiveScreenStop.TabIndex = 13;
            this.btnLiveScreenStop.Text = "Durdur";
            this.btnLiveScreenStop.UseVisualStyleBackColor = true;
            // 
            // btnLiveScreenStart
            // 
            this.btnLiveScreenStart.Location = new System.Drawing.Point(55, 31);
            this.btnLiveScreenStart.Name = "btnLiveScreenStart";
            this.btnLiveScreenStart.Size = new System.Drawing.Size(104, 36);
            this.btnLiveScreenStart.TabIndex = 12;
            this.btnLiveScreenStart.Text = "Başlat";
            this.btnLiveScreenStart.UseVisualStyleBackColor = true;
            // 
            // btnLiveTextStart
            // 
            this.btnLiveTextStart.Location = new System.Drawing.Point(329, 167);
            this.btnLiveTextStart.Name = "btnLiveTextStart";
            this.btnLiveTextStart.Size = new System.Drawing.Size(129, 36);
            this.btnLiveTextStart.TabIndex = 14;
            this.btnLiveTextStart.Text = "Başlat";
            this.btnLiveTextStart.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtLiveText);
            this.groupBox6.Controls.Add(this.btnLiveTextStop);
            this.groupBox6.Controls.Add(this.btnLiveTextStart);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox6.Location = new System.Drawing.Point(493, 426);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(464, 212);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Canlı Yazı";
            // 
            // btnLiveTextStop
            // 
            this.btnLiveTextStop.Location = new System.Drawing.Point(194, 167);
            this.btnLiveTextStop.Name = "btnLiveTextStop";
            this.btnLiveTextStop.Size = new System.Drawing.Size(129, 36);
            this.btnLiveTextStop.TabIndex = 15;
            this.btnLiveTextStop.Text = "Durdur";
            this.btnLiveTextStop.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtHeight);
            this.groupBox7.Controls.Add(this.txtWidth);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox7.Location = new System.Drawing.Point(268, 554);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(219, 84);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Ekran Ayarları";
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtHeight.Location = new System.Drawing.Point(111, 39);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(102, 36);
            this.txtHeight.TabIndex = 17;
            this.txtHeight.Text = "1080";
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtWidth.Location = new System.Drawing.Point(6, 39);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(99, 36);
            this.txtWidth.TabIndex = 16;
            this.txtWidth.Text = "1920";
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // txtLiveText
            // 
            this.txtLiveText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLiveText.Location = new System.Drawing.Point(6, 26);
            this.txtLiveText.Name = "txtLiveText";
            this.txtLiveText.Size = new System.Drawing.Size(452, 135);
            this.txtLiveText.TabIndex = 16;
            this.txtLiveText.Text = "";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Location = new System.Drawing.Point(881, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 34);
            this.btnMinimize.TabIndex = 17;
            this.btnMinimize.Text = "_";
            this.btnMinimize.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 649);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lbSockets);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Kontrol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.ListBox lbSockets;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMsgTitle;
        private System.Windows.Forms.Button btnMsgSend;
        private System.Windows.Forms.TextBox txtMsgContent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnHibernate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCmdSend;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnFileSend;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.ProgressBar prgFile;
        private System.Windows.Forms.Button btnFileCancel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnLiveScreenStop;
        private System.Windows.Forms.Button btnLiveScreenStart;
        private System.Windows.Forms.Button btnLiveTextStart;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnLiveTextStop;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.RichTextBox txtLiveText;
        private System.Windows.Forms.Button btnMinimize;
    }
}