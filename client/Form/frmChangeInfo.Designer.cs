
namespace SeaFight
{
    partial class frmChangeInfo
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
            this.cbEncrypt = new System.Windows.Forms.CheckBox();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.dtpBirthDay = new System.Windows.Forms.DateTimePicker();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.rdbMale = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txbNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbNewPassWord = new System.Windows.Forms.TextBox();
            this.btnShowNewPass = new System.Windows.Forms.Button();
            this.btnShowPassWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbEncrypt
            // 
            this.cbEncrypt.AutoSize = true;
            this.cbEncrypt.Location = new System.Drawing.Point(88, 107);
            this.cbEncrypt.Name = "cbEncrypt";
            this.cbEncrypt.Size = new System.Drawing.Size(141, 17);
            this.cbEncrypt.TabIndex = 81;
            this.cbEncrypt.Text = "Mã hóa thông tin của tôi";
            this.cbEncrypt.UseVisualStyleBackColor = true;
            // 
            // txbPassWord
            // 
            this.txbPassWord.Location = new System.Drawing.Point(88, 42);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.PasswordChar = '*';
            this.txbPassWord.Size = new System.Drawing.Size(149, 20);
            this.txbPassWord.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 78;
            this.label3.Text = "Mật khẩu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Tài khoản:";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(88, 146);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(183, 20);
            this.txbName.TabIndex = 75;
            // 
            // dtpBirthDay
            // 
            this.dtpBirthDay.Location = new System.Drawing.Point(88, 229);
            this.dtpBirthDay.Margin = new System.Windows.Forms.Padding(2);
            this.dtpBirthDay.Name = "dtpBirthDay";
            this.dtpBirthDay.Size = new System.Drawing.Size(186, 20);
            this.dtpBirthDay.TabIndex = 73;
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Location = new System.Drawing.Point(88, 202);
            this.rdbFemale.Margin = new System.Windows.Forms.Padding(2);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(39, 17);
            this.rdbFemale.TabIndex = 72;
            this.rdbFemale.TabStop = true;
            this.rdbFemale.Text = "Nữ";
            this.rdbFemale.UseVisualStyleBackColor = true;
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Location = new System.Drawing.Point(88, 181);
            this.rdbMale.Margin = new System.Windows.Forms.Padding(2);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(47, 17);
            this.rdbMale.TabIndex = 71;
            this.rdbMale.TabStop = true;
            this.rdbMale.Text = "Nam";
            this.rdbMale.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 181);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "Giới tính:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(154, 342);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(163, 41);
            this.btnUpdate.TabIndex = 69;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txbNote
            // 
            this.txbNote.Location = new System.Drawing.Point(88, 267);
            this.txbNote.Margin = new System.Windows.Forms.Padding(2);
            this.txbNote.Multiline = true;
            this.txbNote.Name = "txbNote";
            this.txbNote.Size = new System.Drawing.Size(338, 71);
            this.txbNote.TabIndex = 66;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 229);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "Ngày sinh:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 267);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 64;
            this.label4.Text = "Ghi chú:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 149);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Họ tên:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(84, 11);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(34, 19);
            this.lbUserName.TabIndex = 82;
            this.lbUserName.Text = "user";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 83;
            this.label8.Text = "Mật khẩu mới:";
            // 
            // txbNewPassWord
            // 
            this.txbNewPassWord.Location = new System.Drawing.Point(88, 81);
            this.txbNewPassWord.Name = "txbNewPassWord";
            this.txbNewPassWord.PasswordChar = '*';
            this.txbNewPassWord.Size = new System.Drawing.Size(149, 20);
            this.txbNewPassWord.TabIndex = 84;
            // 
            // btnShowNewPass
            // 
            this.btnShowNewPass.BackgroundImage = global::SeaFight.Properties.Resources.OpenEye;
            this.btnShowNewPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowNewPass.Location = new System.Drawing.Point(243, 80);
            this.btnShowNewPass.Name = "btnShowNewPass";
            this.btnShowNewPass.Size = new System.Drawing.Size(31, 20);
            this.btnShowNewPass.TabIndex = 85;
            this.btnShowNewPass.UseVisualStyleBackColor = true;
            this.btnShowNewPass.Click += new System.EventHandler(this.btnShowNewPass_Click);
            // 
            // btnShowPassWord
            // 
            this.btnShowPassWord.BackgroundImage = global::SeaFight.Properties.Resources.OpenEye;
            this.btnShowPassWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowPassWord.Location = new System.Drawing.Point(243, 41);
            this.btnShowPassWord.Name = "btnShowPassWord";
            this.btnShowPassWord.Size = new System.Drawing.Size(31, 20);
            this.btnShowPassWord.TabIndex = 80;
            this.btnShowPassWord.UseVisualStyleBackColor = true;
            this.btnShowPassWord.Click += new System.EventHandler(this.btnShowPassWord_Click);
            // 
            // frmChangeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 406);
            this.Controls.Add(this.btnShowNewPass);
            this.Controls.Add(this.txbNewPassWord);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.cbEncrypt);
            this.Controls.Add(this.btnShowPassWord);
            this.Controls.Add(this.txbPassWord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.dtpBirthDay);
            this.Controls.Add(this.rdbFemale);
            this.Controls.Add(this.rdbMale);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txbNote);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "frmChangeInfo";
            this.Text = "frmChangeInfo";
            this.Shown += new System.EventHandler(this.frmChangeInfo_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbEncrypt;
        private System.Windows.Forms.Button btnShowPassWord;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.DateTimePicker dtpBirthDay;
        private System.Windows.Forms.RadioButton rdbFemale;
        private System.Windows.Forms.RadioButton rdbMale;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txbNote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbNewPassWord;
        private System.Windows.Forms.Button btnShowNewPass;
    }
}