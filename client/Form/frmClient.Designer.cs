
namespace SeaFight
{
    partial class frmClient
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
            this.pnlClient = new System.Windows.Forms.Panel();
            this.btnFindUser = new System.Windows.Forms.Button();
            this.btnUserOnline = new System.Windows.Forms.Button();
            this.btnChangeInfo = new System.Windows.Forms.Button();
            this.lbWish = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.txbRoomID = new System.Windows.Forms.TextBox();
            this.btnJoinRoom = new System.Windows.Forms.Button();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.cbEncrypt = new System.Windows.Forms.CheckBox();
            this.txbPassWord = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lbUser = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lbPassWord = new System.Windows.Forms.Label();
            this.btnShowPassWord = new System.Windows.Forms.Button();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.txbIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pnlClient.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnFindUser);
            this.pnlClient.Controls.Add(this.btnUserOnline);
            this.pnlClient.Controls.Add(this.btnChangeInfo);
            this.pnlClient.Controls.Add(this.lbWish);
            this.pnlClient.Controls.Add(this.lbUserName);
            this.pnlClient.Controls.Add(this.txbRoomID);
            this.pnlClient.Controls.Add(this.btnJoinRoom);
            this.pnlClient.Controls.Add(this.btnCreateRoom);
            this.pnlClient.Location = new System.Drawing.Point(25, 12);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(480, 219);
            this.pnlClient.TabIndex = 13;
            // 
            // btnFindUser
            // 
            this.btnFindUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindUser.Location = new System.Drawing.Point(368, 157);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(108, 34);
            this.btnFindUser.TabIndex = 8;
            this.btnFindUser.Text = "Tìm người chơi";
            this.btnFindUser.UseVisualStyleBackColor = true;
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // btnUserOnline
            // 
            this.btnUserOnline.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserOnline.Location = new System.Drawing.Point(185, 157);
            this.btnUserOnline.Name = "btnUserOnline";
            this.btnUserOnline.Size = new System.Drawing.Size(177, 34);
            this.btnUserOnline.TabIndex = 7;
            this.btnUserOnline.Text = "Những người đang online";
            this.btnUserOnline.UseVisualStyleBackColor = true;
            this.btnUserOnline.Click += new System.EventHandler(this.btnUserOnline_Click);
            // 
            // btnChangeInfo
            // 
            this.btnChangeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeInfo.Location = new System.Drawing.Point(2, 157);
            this.btnChangeInfo.Name = "btnChangeInfo";
            this.btnChangeInfo.Size = new System.Drawing.Size(177, 34);
            this.btnChangeInfo.TabIndex = 6;
            this.btnChangeInfo.Text = "Chỉnh sửa thông tin cá nhân";
            this.btnChangeInfo.UseVisualStyleBackColor = true;
            this.btnChangeInfo.Click += new System.EventHandler(this.btnChangeInfo_Click);
            // 
            // lbWish
            // 
            this.lbWish.AutoSize = true;
            this.lbWish.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWish.Location = new System.Drawing.Point(127, 48);
            this.lbWish.Name = "lbWish";
            this.lbWish.Size = new System.Drawing.Size(245, 23);
            this.lbWish.TabIndex = 5;
            this.lbWish.Text = "chúc bạn có một ngày vui vẻ";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(245, 7);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(49, 23);
            this.lbUserName.TabIndex = 4;
            this.lbUserName.Text = "User";
            // 
            // txbRoomID
            // 
            this.txbRoomID.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRoomID.Location = new System.Drawing.Point(24, 95);
            this.txbRoomID.Name = "txbRoomID";
            this.txbRoomID.Size = new System.Drawing.Size(202, 39);
            this.txbRoomID.TabIndex = 0;
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.Location = new System.Drawing.Point(232, 95);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.Size = new System.Drawing.Size(101, 39);
            this.btnJoinRoom.TabIndex = 1;
            this.btnJoinRoom.Text = "Vào Phòng";
            this.btnJoinRoom.UseVisualStyleBackColor = true;
            this.btnJoinRoom.Click += new System.EventHandler(this.btnJoinRoom_Click);
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Location = new System.Drawing.Point(339, 95);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(101, 39);
            this.btnCreateRoom.TabIndex = 2;
            this.btnCreateRoom.Text = "Tạo Phòng";
            this.btnCreateRoom.UseVisualStyleBackColor = true;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.btnConnect);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Controls.Add(this.txbIPAddress);
            this.pnlLogin.Controls.Add(this.cbEncrypt);
            this.pnlLogin.Controls.Add(this.txbPassWord);
            this.pnlLogin.Controls.Add(this.btnRegister);
            this.pnlLogin.Controls.Add(this.lbUser);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.lbPassWord);
            this.pnlLogin.Controls.Add(this.btnShowPassWord);
            this.pnlLogin.Controls.Add(this.txbUserName);
            this.pnlLogin.Location = new System.Drawing.Point(12, 19);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(507, 196);
            this.pnlLogin.TabIndex = 12;
            // 
            // cbEncrypt
            // 
            this.cbEncrypt.AutoSize = true;
            this.cbEncrypt.Location = new System.Drawing.Point(196, 122);
            this.cbEncrypt.Name = "cbEncrypt";
            this.cbEncrypt.Size = new System.Drawing.Size(141, 17);
            this.cbEncrypt.TabIndex = 10;
            this.cbEncrypt.Text = "Mã hóa thông tin của tôi";
            this.cbEncrypt.UseVisualStyleBackColor = true;
            // 
            // txbPassWord
            // 
            this.txbPassWord.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassWord.Location = new System.Drawing.Point(196, 94);
            this.txbPassWord.Name = "txbPassWord";
            this.txbPassWord.PasswordChar = '*';
            this.txbPassWord.Size = new System.Drawing.Size(215, 22);
            this.txbPassWord.TabIndex = 6;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(282, 160);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(130, 23);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(68, 63);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(122, 22);
            this.lbUser.TabIndex = 3;
            this.lbUser.Text = "Tên tài khoản:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(147, 160);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(129, 23);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lbPassWord
            // 
            this.lbPassWord.AutoSize = true;
            this.lbPassWord.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassWord.Location = new System.Drawing.Point(102, 95);
            this.lbPassWord.Name = "lbPassWord";
            this.lbPassWord.Size = new System.Drawing.Size(88, 22);
            this.lbPassWord.TabIndex = 4;
            this.lbPassWord.Text = "Mật khẩu:";
            // 
            // btnShowPassWord
            // 
            this.btnShowPassWord.BackgroundImage = global::SeaFight.Properties.Resources.OpenEye;
            this.btnShowPassWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowPassWord.Location = new System.Drawing.Point(417, 96);
            this.btnShowPassWord.Name = "btnShowPassWord";
            this.btnShowPassWord.Size = new System.Drawing.Size(30, 23);
            this.btnShowPassWord.TabIndex = 7;
            this.btnShowPassWord.UseVisualStyleBackColor = true;
            this.btnShowPassWord.Click += new System.EventHandler(this.btnShowPassWord_Click);
            // 
            // txbUserName
            // 
            this.txbUserName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.Location = new System.Drawing.Point(196, 63);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(216, 22);
            this.txbUserName.TabIndex = 5;
            // 
            // txbIPAddress
            // 
            this.txbIPAddress.Location = new System.Drawing.Point(116, 6);
            this.txbIPAddress.Name = "txbIPAddress";
            this.txbIPAddress.Size = new System.Drawing.Size(195, 20);
            this.txbIPAddress.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Địa chỉ IP máy chủ:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(317, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(130, 23);
            this.btnConnect.TabIndex = 13;
            this.btnConnect.Text = "kết nối máy chủ";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 238);
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.pnlLogin);
            this.Name = "frmClient";
            this.Text = "frmClient";
            this.Shown += new System.EventHandler(this.frmClient_Shown);
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Button btnFindUser;
        private System.Windows.Forms.Button btnUserOnline;
        private System.Windows.Forms.Button btnChangeInfo;
        private System.Windows.Forms.Label lbWish;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox txbRoomID;
        private System.Windows.Forms.Button btnJoinRoom;
        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.CheckBox cbEncrypt;
        private System.Windows.Forms.TextBox txbPassWord;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lbPassWord;
        private System.Windows.Forms.Button btnShowPassWord;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbIPAddress;
    }
}