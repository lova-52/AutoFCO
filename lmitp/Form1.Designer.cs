namespace AutoFCO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelside = new System.Windows.Forms.Panel();
            this.buttonBan = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonMua = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.panelside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelside
            // 
            this.panelside.BackColor = System.Drawing.Color.DimGray;
            this.panelside.Controls.Add(this.buttonBan);
            this.panelside.Controls.Add(this.pictureBox1);
            this.panelside.Controls.Add(this.buttonMua);
            this.panelside.Controls.Add(this.buttonLogin);
            this.panelside.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelside.Location = new System.Drawing.Point(0, 0);
            this.panelside.Name = "panelside";
            this.panelside.Size = new System.Drawing.Size(200, 450);
            this.panelside.TabIndex = 0;
            // 
            // buttonBan
            // 
            this.buttonBan.BackColor = System.Drawing.Color.DimGray;
            this.buttonBan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonBan.FlatAppearance.BorderSize = 0;
            this.buttonBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBan.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBan.ForeColor = System.Drawing.Color.White;
            this.buttonBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBan.Location = new System.Drawing.Point(0, 226);
            this.buttonBan.Name = "buttonBan";
            this.buttonBan.Size = new System.Drawing.Size(200, 40);
            this.buttonBan.TabIndex = 2;
            this.buttonBan.Text = "BÁN";
            this.buttonBan.UseVisualStyleBackColor = false;
            this.buttonBan.Click += new System.EventHandler(this.btnreports_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(47, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonMua
            // 
            this.buttonMua.BackColor = System.Drawing.Color.DimGray;
            this.buttonMua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMua.FlatAppearance.BorderSize = 0;
            this.buttonMua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMua.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMua.ForeColor = System.Drawing.Color.White;
            this.buttonMua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMua.Location = new System.Drawing.Point(0, 177);
            this.buttonMua.Name = "buttonMua";
            this.buttonMua.Size = new System.Drawing.Size(200, 40);
            this.buttonMua.TabIndex = 1;
            this.buttonMua.Text = "MUA";
            this.buttonMua.UseVisualStyleBackColor = false;
            this.buttonMua.Click += new System.EventHandler(this.btnemp_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.DimGray;
            this.buttonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogin.Location = new System.Drawing.Point(0, 128);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(200, 40);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "ĐĂNG NHẬP";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.btndashbaord_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(200, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(600, 450);
            this.mainpanel.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.panelside);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(700, 200);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AutoFCO - by Lova";
            this.panelside.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelside;
        private System.Windows.Forms.Button buttonBan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonMua;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Panel mainpanel;
    }
}

