
namespace GADE6122
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.lblOutput = new System.Windows.Forms.Label();
            this.MemoPlayerInfo = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.BtnAttack = new System.Windows.Forms.Button();
            this.MemoEnemyInfo = new System.Windows.Forms.RichTextBox();
            this.CmbEnemyList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.rtbMap = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(21, 9);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(0, 15);
            this.lblOutput.TabIndex = 1;
            // 
            // MemoPlayerInfo
            // 
            this.MemoPlayerInfo.BackColor = System.Drawing.Color.IndianRed;
            this.MemoPlayerInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MemoPlayerInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MemoPlayerInfo.Location = new System.Drawing.Point(443, 12);
            this.MemoPlayerInfo.Name = "MemoPlayerInfo";
            this.MemoPlayerInfo.ReadOnly = true;
            this.MemoPlayerInfo.Size = new System.Drawing.Size(268, 172);
            this.MemoPlayerInfo.TabIndex = 2;
            this.MemoPlayerInfo.Text = "";
            this.MemoPlayerInfo.TextChanged += new System.EventHandler(this.MemoPlayerInfo_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCoral;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.BtnAttack);
            this.panel1.Controls.Add(this.MemoEnemyInfo);
            this.panel1.Controls.Add(this.CmbEnemyList);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(443, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 412);
            this.panel1.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.IndianRed;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(13, 209);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(239, 185);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // BtnAttack
            // 
            this.BtnAttack.BackColor = System.Drawing.Color.IndianRed;
            this.BtnAttack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAttack.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnAttack.Location = new System.Drawing.Point(13, 173);
            this.BtnAttack.Name = "BtnAttack";
            this.BtnAttack.Size = new System.Drawing.Size(239, 29);
            this.BtnAttack.TabIndex = 5;
            this.BtnAttack.Text = "Attack";
            this.BtnAttack.UseVisualStyleBackColor = false;
            this.BtnAttack.Click += new System.EventHandler(this.BtnAttack_Click);
            // 
            // MemoEnemyInfo
            // 
            this.MemoEnemyInfo.BackColor = System.Drawing.Color.IndianRed;
            this.MemoEnemyInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MemoEnemyInfo.Location = new System.Drawing.Point(13, 61);
            this.MemoEnemyInfo.Name = "MemoEnemyInfo";
            this.MemoEnemyInfo.ReadOnly = true;
            this.MemoEnemyInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.MemoEnemyInfo.Size = new System.Drawing.Size(239, 105);
            this.MemoEnemyInfo.TabIndex = 4;
            this.MemoEnemyInfo.Text = "";
            // 
            // CmbEnemyList
            // 
            this.CmbEnemyList.FormattingEnabled = true;
            this.CmbEnemyList.Location = new System.Drawing.Point(13, 32);
            this.CmbEnemyList.Name = "CmbEnemyList";
            this.CmbEnemyList.Size = new System.Drawing.Size(239, 23);
            this.CmbEnemyList.TabIndex = 1;
            this.CmbEnemyList.SelectedIndexChanged += new System.EventHandler(this.CmbEnemyList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Attacking";
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.IndianRed;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUp.Location = new System.Drawing.Point(243, 490);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(76, 50);
            this.btnUp.TabIndex = 4;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.IndianRed;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDown.Location = new System.Drawing.Point(243, 546);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(76, 50);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.IndianRed;
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLeft.Location = new System.Drawing.Point(161, 517);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(76, 50);
            this.btnLeft.TabIndex = 6;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.IndianRed;
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRight.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRight.FlatAppearance.BorderSize = 0;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRight.Location = new System.Drawing.Point(325, 517);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(76, 50);
            this.btnRight.TabIndex = 7;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // rtbMap
            // 
            this.rtbMap.BackColor = System.Drawing.Color.GhostWhite;
            this.rtbMap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMap.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbMap.Location = new System.Drawing.Point(21, 12);
            this.rtbMap.Name = "rtbMap";
            this.rtbMap.ReadOnly = true;
            this.rtbMap.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbMap.Size = new System.Drawing.Size(406, 440);
            this.rtbMap.TabIndex = 8;
            this.rtbMap.Text = "";
            this.rtbMap.TextChanged += new System.EventHandler(this.rtbMap_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(21, 589);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCoral;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.checkedListBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.richTextBox3);
            this.panel2.Controls.Add(this.btnBuy);
            this.panel2.Controls.Add(this.richTextBox2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(729, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 600);
            this.panel2.TabIndex = 3;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(23, 43);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(214, 128);
            this.checkedListBox1.TabIndex = 13;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(18, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Info";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.IndianRed;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.richTextBox3.Location = new System.Drawing.Point(12, 249);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(239, 321);
            this.richTextBox3.TabIndex = 10;
            this.richTextBox3.Text = resources.GetString("richTextBox3.Text");
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.IndianRed;
            this.btnBuy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBuy.Location = new System.Drawing.Point(23, 182);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(214, 29);
            this.btnBuy.TabIndex = 12;
            this.btnBuy.Text = "-- Buy --";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.IndianRed;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(12, 30);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(239, 193);
            this.richTextBox2.TabIndex = 10;
            this.richTextBox2.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Shop";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 624);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rtbMap);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MemoPlayerInfo);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "HERO GAME";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.RichTextBox MemoPlayerInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnAttack;
        private System.Windows.Forms.RichTextBox MemoEnemyInfo;
        private System.Windows.Forms.ComboBox CmbEnemyList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.RichTextBox rtbMap;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

