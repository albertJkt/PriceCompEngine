namespace PriceCompEngn
{
    partial class ShoppingForm
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
            this.checkIki = new System.Windows.Forms.CheckBox();
            this.checkMaxima = new System.Windows.Forms.CheckBox();
            this.checkNorfa = new System.Windows.Forms.CheckBox();
            this.checkLidl = new System.Windows.Forms.CheckBox();
            this.checkRimi = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkIki
            // 
            this.checkIki.AutoSize = true;
            this.checkIki.Location = new System.Drawing.Point(18, 404);
            this.checkIki.Name = "checkIki";
            this.checkIki.Size = new System.Drawing.Size(37, 17);
            this.checkIki.TabIndex = 0;
            this.checkIki.Text = "Iki";
            this.checkIki.UseVisualStyleBackColor = true;
            // 
            // checkMaxima
            // 
            this.checkMaxima.AutoSize = true;
            this.checkMaxima.Location = new System.Drawing.Point(61, 404);
            this.checkMaxima.Name = "checkMaxima";
            this.checkMaxima.Size = new System.Drawing.Size(62, 17);
            this.checkMaxima.TabIndex = 1;
            this.checkMaxima.Text = "Maxima";
            this.checkMaxima.UseVisualStyleBackColor = true;
            // 
            // checkNorfa
            // 
            this.checkNorfa.AutoSize = true;
            this.checkNorfa.Location = new System.Drawing.Point(129, 404);
            this.checkNorfa.Name = "checkNorfa";
            this.checkNorfa.Size = new System.Drawing.Size(52, 17);
            this.checkNorfa.TabIndex = 2;
            this.checkNorfa.Text = "Norfa";
            this.checkNorfa.UseVisualStyleBackColor = true;
            // 
            // checkLidl
            // 
            this.checkLidl.AutoSize = true;
            this.checkLidl.Location = new System.Drawing.Point(239, 404);
            this.checkLidl.Name = "checkLidl";
            this.checkLidl.Size = new System.Drawing.Size(42, 17);
            this.checkLidl.TabIndex = 3;
            this.checkLidl.Text = "Lidl";
            this.checkLidl.UseVisualStyleBackColor = true;
            // 
            // checkRimi
            // 
            this.checkRimi.AutoSize = true;
            this.checkRimi.Location = new System.Drawing.Point(187, 404);
            this.checkRimi.Name = "checkRimi";
            this.checkRimi.Size = new System.Drawing.Size(46, 17);
            this.checkRimi.TabIndex = 4;
            this.checkRimi.Text = "Rimi";
            this.checkRimi.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Paieška pagal pavadinimą";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 451);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 20);
            this.textBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ieškoti";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Prekių paieška pagal tipą:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(17, 502);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(288, 20);
            this.textBox2.TabIndex = 10;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(15, 36);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(310, 245);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nr";
            this.columnHeader1.Width = 23;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pavadinimas";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tipas";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Parduotuvė";
            this.columnHeader4.Width = 68;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "€";
            this.columnHeader5.Width = 55;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(331, 37);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(155, 211);
            this.listView2.TabIndex = 13;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Pavadinimas";
            this.columnHeader6.Width = 102;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "€";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(331, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Sudaryti prekių krepšelį";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ShoppingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 536);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkRimi);
            this.Controls.Add(this.checkLidl);
            this.Controls.Add(this.checkNorfa);
            this.Controls.Add(this.checkMaxima);
            this.Controls.Add(this.checkIki);
            this.Name = "ShoppingForm";
            this.Text = "ShoppingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkIki;
        private System.Windows.Forms.CheckBox checkMaxima;
        private System.Windows.Forms.CheckBox checkNorfa;
        private System.Windows.Forms.CheckBox checkLidl;
        private System.Windows.Forms.CheckBox checkRimi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button button2;
    }
}