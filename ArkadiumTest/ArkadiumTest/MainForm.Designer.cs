namespace ArkadiumTest
{
    partial class MainForm
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
            this.btnGetBoxResults = new System.Windows.Forms.Button();
            this.tbxURL = new System.Windows.Forms.TextBox();
            this.dgvBoxResult = new System.Windows.Forms.DataGridView();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.tabSecond = new System.Windows.Forms.TabPage();
            this.dgvSomeTable = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxTabNumber = new System.Windows.Forms.ComboBox();
            this.btnSowTable = new System.Windows.Forms.Button();
            this.btnGetTabs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoxResult)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabSecond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSomeTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetBoxResults
            // 
            this.btnGetBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetBoxResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetBoxResults.Location = new System.Drawing.Point(6, 6);
            this.btnGetBoxResults.Name = "btnGetBoxResults";
            this.btnGetBoxResults.Size = new System.Drawing.Size(1463, 58);
            this.btnGetBoxResults.TabIndex = 0;
            this.btnGetBoxResults.Text = "Получить результаты соревнования и сохранить в файл";
            this.btnGetBoxResults.UseVisualStyleBackColor = true;
            this.btnGetBoxResults.Click += new System.EventHandler(this.btnGetBoxResults_Click);
            // 
            // tbxURL
            // 
            this.tbxURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxURL.Location = new System.Drawing.Point(147, 15);
            this.tbxURL.Name = "tbxURL";
            this.tbxURL.Size = new System.Drawing.Size(383, 21);
            this.tbxURL.TabIndex = 1;
            this.tbxURL.Text = "https://en.wikipedia.org/wiki/Boxing_at_the_1948_Summer_Olympics_%E2%80%93_Men%27" +
    "s_heavyweight";
            this.tbxURL.TextChanged += new System.EventHandler(this.tbxURL_TextChanged);
            // 
            // dgvBoxResult
            // 
            this.dgvBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBoxResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBoxResult.Location = new System.Drawing.Point(6, 70);
            this.dgvBoxResult.Name = "dgvBoxResult";
            this.dgvBoxResult.Size = new System.Drawing.Size(1465, 747);
            this.dgvBoxResult.TabIndex = 2;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabMain);
            this.tabs.Controls.Add(this.tabSecond);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1485, 849);
            this.tabs.TabIndex = 3;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.btnGetBoxResults);
            this.tabMain.Controls.Add(this.dgvBoxResult);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1477, 823);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Основное задание";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // tabSecond
            // 
            this.tabSecond.Controls.Add(this.dgvSomeTable);
            this.tabSecond.Controls.Add(this.panel1);
            this.tabSecond.Location = new System.Drawing.Point(4, 22);
            this.tabSecond.Name = "tabSecond";
            this.tabSecond.Padding = new System.Windows.Forms.Padding(3);
            this.tabSecond.Size = new System.Drawing.Size(1477, 823);
            this.tabSecond.TabIndex = 1;
            this.tabSecond.Text = "Парсер любых таблиц";
            this.tabSecond.UseVisualStyleBackColor = true;
            // 
            // dgvSomeTable
            // 
            this.dgvSomeTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSomeTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSomeTable.Location = new System.Drawing.Point(6, 93);
            this.dgvSomeTable.Name = "dgvSomeTable";
            this.dgvSomeTable.Size = new System.Drawing.Size(1465, 727);
            this.dgvSomeTable.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbxTabNumber);
            this.panel1.Controls.Add(this.btnSowTable);
            this.panel1.Controls.Add(this.btnGetTabs);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbxURL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1471, 84);
            this.panel1.TabIndex = 2;
            // 
            // cbxTabNumber
            // 
            this.cbxTabNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTabNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbxTabNumber.FormattingEnabled = true;
            this.cbxTabNumber.Location = new System.Drawing.Point(198, 54);
            this.cbxTabNumber.Name = "cbxTabNumber";
            this.cbxTabNumber.Size = new System.Drawing.Size(75, 26);
            this.cbxTabNumber.TabIndex = 4;
            // 
            // btnSowTable
            // 
            this.btnSowTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSowTable.Location = new System.Drawing.Point(8, 53);
            this.btnSowTable.Name = "btnSowTable";
            this.btnSowTable.Size = new System.Drawing.Size(184, 28);
            this.btnSowTable.TabIndex = 3;
            this.btnSowTable.Text = "Показать таблицу №";
            this.btnSowTable.UseVisualStyleBackColor = true;
            this.btnSowTable.Click += new System.EventHandler(this.btnSowTable_Click);
            // 
            // btnGetTabs
            // 
            this.btnGetTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGetTabs.Location = new System.Drawing.Point(536, 11);
            this.btnGetTabs.Name = "btnGetTabs";
            this.btnGetTabs.Size = new System.Drawing.Size(290, 28);
            this.btnGetTabs.TabIndex = 3;
            this.btnGetTabs.Text = "Получить все таблицы со страницы";
            this.btnGetTabs.UseVisualStyleBackColor = true;
            this.btnGetTabs.Click += new System.EventHandler(this.btnGetTabs_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Адрес страницы: ";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1485, 849);
            this.Controls.Add(this.tabs);
            this.Name = "MainForm";
            this.Text = "Парсер таблиц";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBoxResult)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabSecond.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSomeTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetBoxResults;
        private System.Windows.Forms.TextBox tbxURL;
        private System.Windows.Forms.DataGridView dgvBoxResult;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabSecond;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxTabNumber;
        private System.Windows.Forms.Button btnSowTable;
        private System.Windows.Forms.Button btnGetTabs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSomeTable;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

