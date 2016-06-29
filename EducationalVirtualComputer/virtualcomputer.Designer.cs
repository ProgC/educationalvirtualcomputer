namespace EducationalVirtualComputer
{
    partial class virtualcomputer
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMonitorName = new System.Windows.Forms.Label();
            this.monitor = new System.Windows.Forms.PictureBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblCpuInfo = new System.Windows.Forms.Label();
            this.lblMemoryInfoName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblInstructionNumberName = new System.Windows.Forms.Label();
            this.lblInstructionNumberValue = new System.Windows.Forms.Label();
            this.cpuClock = new System.Windows.Forms.Timer(this.components);
            this.lblColorPalatteName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblColorRedName = new System.Windows.Forms.Label();
            this.lblColorGreenName = new System.Windows.Forms.Label();
            this.lblColorBlueName = new System.Windows.Forms.Label();
            this.chkCodeAnimation = new System.Windows.Forms.CheckBox();
            this.lblTimeName = new System.Windows.Forms.Label();
            this.lblCpuTime = new System.Windows.Forms.Label();
            this.lblCpuSpeedName = new System.Windows.Forms.Label();
            this.hScrollBarCpuSpeed = new System.Windows.Forms.HScrollBar();
            this.lblCpuSpeed = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxLanguageSetting = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.monitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMonitorName
            // 
            this.lblMonitorName.AutoSize = true;
            this.lblMonitorName.Location = new System.Drawing.Point(12, 36);
            this.lblMonitorName.Name = "lblMonitorName";
            this.lblMonitorName.Size = new System.Drawing.Size(41, 12);
            this.lblMonitorName.TabIndex = 0;
            this.lblMonitorName.Text = "모니터";
            // 
            // monitor
            // 
            this.monitor.BackColor = System.Drawing.Color.White;
            this.monitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.monitor.Location = new System.Drawing.Point(14, 53);
            this.monitor.Name = "monitor";
            this.monitor.Size = new System.Drawing.Size(200, 200);
            this.monitor.TabIndex = 1;
            this.monitor.TabStop = false;
            this.monitor.Paint += new System.Windows.Forms.PaintEventHandler(this.monitor_Paint);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(268, 36);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(29, 12);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "코드";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTextBox1.Location = new System.Drawing.Point(269, 51);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(341, 476);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "할당 정수1 0\n할당 정수2 0\n할당 색상 빨강\n점찍기\n할당 정수1 1\n할당 정수2 1\n점찍기\n할당 반복 10\n반복시작\n더하기 정수1 1\n더하기 " +
    "정수2 1\n점찍기\n반복끝";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(631, 51);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(113, 23);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "실행";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(632, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "한 단계씩 실행";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(632, 109);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "프로그램 종료";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // lblCpuInfo
            // 
            this.lblCpuInfo.AutoSize = true;
            this.lblCpuInfo.Location = new System.Drawing.Point(14, 270);
            this.lblCpuInfo.Name = "lblCpuInfo";
            this.lblCpuInfo.Size = new System.Drawing.Size(58, 12);
            this.lblCpuInfo.TabIndex = 7;
            this.lblCpuInfo.Text = "CPU 정보";
            // 
            // lblMemoryInfoName
            // 
            this.lblMemoryInfoName.AutoSize = true;
            this.lblMemoryInfoName.Location = new System.Drawing.Point(14, 538);
            this.lblMemoryInfoName.Name = "lblMemoryInfoName";
            this.lblMemoryInfoName.Size = new System.Drawing.Size(69, 12);
            this.lblMemoryInfoName.TabIndex = 8;
            this.lblMemoryInfoName.Text = "메모리 정보";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 565);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(728, 226);
            this.dataGridView1.TabIndex = 9;
            // 
            // lblInstructionNumberName
            // 
            this.lblInstructionNumberName.AutoSize = true;
            this.lblInstructionNumberName.Location = new System.Drawing.Point(14, 291);
            this.lblInstructionNumberName.Name = "lblInstructionNumberName";
            this.lblInstructionNumberName.Size = new System.Drawing.Size(69, 12);
            this.lblInstructionNumberName.TabIndex = 10;
            this.lblInstructionNumberName.Text = "명령어 번호";
            // 
            // lblInstructionNumberValue
            // 
            this.lblInstructionNumberValue.AutoSize = true;
            this.lblInstructionNumberValue.Location = new System.Drawing.Point(114, 291);
            this.lblInstructionNumberValue.Name = "lblInstructionNumberValue";
            this.lblInstructionNumberValue.Size = new System.Drawing.Size(23, 12);
            this.lblInstructionNumberValue.TabIndex = 11;
            this.lblInstructionNumberValue.Text = "000";
            // 
            // cpuClock
            // 
            this.cpuClock.Tick += new System.EventHandler(this.cpuClock_Tick);
            // 
            // lblColorPalatteName
            // 
            this.lblColorPalatteName.AutoSize = true;
            this.lblColorPalatteName.Location = new System.Drawing.Point(15, 394);
            this.lblColorPalatteName.Name = "lblColorPalatteName";
            this.lblColorPalatteName.Size = new System.Drawing.Size(69, 12);
            this.lblColorPalatteName.TabIndex = 12;
            this.lblColorPalatteName.Text = "색상 팔레트";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(17, 418);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 10);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Green;
            this.pictureBox2.Location = new System.Drawing.Point(17, 437);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(10, 10);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Blue;
            this.pictureBox3.Location = new System.Drawing.Point(17, 456);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(10, 10);
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // lblColorRedName
            // 
            this.lblColorRedName.AutoSize = true;
            this.lblColorRedName.Location = new System.Drawing.Point(45, 418);
            this.lblColorRedName.Name = "lblColorRedName";
            this.lblColorRedName.Size = new System.Drawing.Size(29, 12);
            this.lblColorRedName.TabIndex = 16;
            this.lblColorRedName.Text = "빨강";
            // 
            // lblColorGreenName
            // 
            this.lblColorGreenName.AutoSize = true;
            this.lblColorGreenName.Location = new System.Drawing.Point(45, 437);
            this.lblColorGreenName.Name = "lblColorGreenName";
            this.lblColorGreenName.Size = new System.Drawing.Size(29, 12);
            this.lblColorGreenName.TabIndex = 17;
            this.lblColorGreenName.Text = "초록";
            // 
            // lblColorBlueName
            // 
            this.lblColorBlueName.AutoSize = true;
            this.lblColorBlueName.Location = new System.Drawing.Point(45, 456);
            this.lblColorBlueName.Name = "lblColorBlueName";
            this.lblColorBlueName.Size = new System.Drawing.Size(29, 12);
            this.lblColorBlueName.TabIndex = 18;
            this.lblColorBlueName.Text = "파랑";
            // 
            // chkCodeAnimation
            // 
            this.chkCodeAnimation.AutoSize = true;
            this.chkCodeAnimation.Checked = true;
            this.chkCodeAnimation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCodeAnimation.Location = new System.Drawing.Point(116, 266);
            this.chkCodeAnimation.Name = "chkCodeAnimation";
            this.chkCodeAnimation.Size = new System.Drawing.Size(112, 16);
            this.chkCodeAnimation.TabIndex = 19;
            this.chkCodeAnimation.Text = "코드 애니메이션";
            this.chkCodeAnimation.UseVisualStyleBackColor = true;
            // 
            // lblTimeName
            // 
            this.lblTimeName.AutoSize = true;
            this.lblTimeName.Location = new System.Drawing.Point(14, 313);
            this.lblTimeName.Name = "lblTimeName";
            this.lblTimeName.Size = new System.Drawing.Size(29, 12);
            this.lblTimeName.TabIndex = 20;
            this.lblTimeName.Text = "시간";
            // 
            // lblCpuTime
            // 
            this.lblCpuTime.AutoSize = true;
            this.lblCpuTime.Location = new System.Drawing.Point(114, 313);
            this.lblCpuTime.Name = "lblCpuTime";
            this.lblCpuTime.Size = new System.Drawing.Size(23, 12);
            this.lblCpuTime.TabIndex = 21;
            this.lblCpuTime.Text = "000";
            // 
            // lblCpuSpeedName
            // 
            this.lblCpuSpeedName.AutoSize = true;
            this.lblCpuSpeedName.Location = new System.Drawing.Point(15, 334);
            this.lblCpuSpeedName.Name = "lblCpuSpeedName";
            this.lblCpuSpeedName.Size = new System.Drawing.Size(29, 12);
            this.lblCpuSpeedName.TabIndex = 22;
            this.lblCpuSpeedName.Text = "속도";
            // 
            // hScrollBarCpuSpeed
            // 
            this.hScrollBarCpuSpeed.LargeChange = 1;
            this.hScrollBarCpuSpeed.Location = new System.Drawing.Point(116, 359);
            this.hScrollBarCpuSpeed.Maximum = 1000;
            this.hScrollBarCpuSpeed.Minimum = 1;
            this.hScrollBarCpuSpeed.Name = "hScrollBarCpuSpeed";
            this.hScrollBarCpuSpeed.Size = new System.Drawing.Size(98, 22);
            this.hScrollBarCpuSpeed.TabIndex = 23;
            this.hScrollBarCpuSpeed.Value = 30;
            this.hScrollBarCpuSpeed.ValueChanged += new System.EventHandler(this.hScrollBarCpuSpeed_ValueChanged);
            // 
            // lblCpuSpeed
            // 
            this.lblCpuSpeed.AutoSize = true;
            this.lblCpuSpeed.Location = new System.Drawing.Point(114, 334);
            this.lblCpuSpeed.Name = "lblCpuSpeed";
            this.lblCpuSpeed.Size = new System.Drawing.Size(23, 12);
            this.lblCpuSpeed.TabIndex = 24;
            this.lblCpuSpeed.Text = "000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "Language Setting";
            // 
            // comboBoxLanguageSetting
            // 
            this.comboBoxLanguageSetting.FormattingEnabled = true;
            this.comboBoxLanguageSetting.Location = new System.Drawing.Point(122, 10);
            this.comboBoxLanguageSetting.Name = "comboBoxLanguageSetting";
            this.comboBoxLanguageSetting.Size = new System.Drawing.Size(121, 20);
            this.comboBoxLanguageSetting.TabIndex = 26;
            this.comboBoxLanguageSetting.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguageSetting_SelectedIndexChanged);
            this.comboBoxLanguageSetting.SelectedValueChanged += new System.EventHandler(this.comboBoxLanguageSetting_SelectedValueChanged);
            // 
            // virtualcomputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 799);
            this.Controls.Add(this.comboBoxLanguageSetting);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCpuSpeed);
            this.Controls.Add(this.hScrollBarCpuSpeed);
            this.Controls.Add(this.lblCpuSpeedName);
            this.Controls.Add(this.lblCpuTime);
            this.Controls.Add(this.lblTimeName);
            this.Controls.Add(this.chkCodeAnimation);
            this.Controls.Add(this.lblColorBlueName);
            this.Controls.Add(this.lblColorGreenName);
            this.Controls.Add(this.lblColorRedName);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblColorPalatteName);
            this.Controls.Add(this.lblInstructionNumberValue);
            this.Controls.Add(this.lblInstructionNumberName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblMemoryInfoName);
            this.Controls.Add(this.lblCpuInfo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.monitor);
            this.Controls.Add(this.lblMonitorName);
            this.MaximizeBox = false;
            this.Name = "virtualcomputer";
            this.Text = "Educational Virtual Computer";
            this.Load += new System.EventHandler(this.virtualcomputer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMonitorName;
        private System.Windows.Forms.PictureBox monitor;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblCpuInfo;
        private System.Windows.Forms.Label lblMemoryInfoName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblInstructionNumberName;
        private System.Windows.Forms.Label lblInstructionNumberValue;
        private System.Windows.Forms.Timer cpuClock;
        private System.Windows.Forms.Label lblColorPalatteName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblColorRedName;
        private System.Windows.Forms.Label lblColorGreenName;
        private System.Windows.Forms.Label lblColorBlueName;
        private System.Windows.Forms.CheckBox chkCodeAnimation;
        private System.Windows.Forms.Label lblTimeName;
        private System.Windows.Forms.Label lblCpuTime;
        private System.Windows.Forms.Label lblCpuSpeedName;
        private System.Windows.Forms.HScrollBar hScrollBarCpuSpeed;
        private System.Windows.Forms.Label lblCpuSpeed;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxLanguageSetting;
    }
}

