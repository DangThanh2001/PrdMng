﻿namespace ManagerCustomer
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
            dtView = new DataGridView();
            label1 = new Label();
            tbSearch = new TextBox();
            btnSearch = new Button();
            fromDate = new DateTimePicker();
            toDate = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            cbDate = new CheckBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            lbCount = new Label();
            btnReload = new Button();
            ((System.ComponentModel.ISupportInitialize)dtView).BeginInit();
            SuspendLayout();
            // 
            // dtView
            // 
            dtView.AllowUserToAddRows = false;
            dtView.AllowUserToDeleteRows = false;
            dtView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(dtView, "dtView");
            dtView.MultiSelect = false;
            dtView.Name = "dtView";
            dtView.ReadOnly = true;
            dtView.RowTemplate.Height = 29;
            dtView.CellClick += dtView_CellClick;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // tbSearch
            // 
            resources.ApplyResources(tbSearch, "tbSearch");
            tbSearch.Name = "tbSearch";
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // btnSearch
            // 
            resources.ApplyResources(btnSearch, "btnSearch");
            btnSearch.Name = "btnSearch";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // fromDate
            // 
            resources.ApplyResources(fromDate, "fromDate");
            fromDate.Name = "fromDate";
            // 
            // toDate
            // 
            resources.ApplyResources(toDate, "toDate");
            toDate.Name = "toDate";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // cbDate
            // 
            resources.ApplyResources(cbDate, "cbDate");
            cbDate.Name = "cbDate";
            cbDate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            resources.ApplyResources(btnAdd, "btnAdd");
            btnAdd.Name = "btnAdd";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            resources.ApplyResources(btnUpdate, "btnUpdate");
            btnUpdate.Name = "btnUpdate";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            resources.ApplyResources(btnDelete, "btnDelete");
            btnDelete.Name = "btnDelete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // lbCount
            // 
            resources.ApplyResources(lbCount, "lbCount");
            lbCount.Name = "lbCount";
            // 
            // btnReload
            // 
            resources.ApplyResources(btnReload, "btnReload");
            btnReload.Name = "btnReload";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnReload);
            Controls.Add(lbCount);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(cbDate);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(toDate);
            Controls.Add(fromDate);
            Controls.Add(btnSearch);
            Controls.Add(tbSearch);
            Controls.Add(label1);
            Controls.Add(dtView);
            Name = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dtView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtView;
        private Label label1;
        private TextBox tbSearch;
        private Button btnSearch;
        private DateTimePicker fromDate;
        private DateTimePicker toDate;
        private Label label2;
        private Label label3;
        private CheckBox cbDate;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Label lbCount;
        private Button btnReload;
    }
}