namespace da3_intra_sommatif.Presentation
{
    partial class FuelView
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
            dataGridView1 = new DataGridView();
            btnCharger = new Button();
            btnSave = new Button();
            btnQuitter = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(7, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(776, 381);
            dataGridView1.TabIndex = 0;
            // 
            // btnCharger
            // 
            btnCharger.Location = new Point(215, 407);
            btnCharger.Name = "btnCharger";
            btnCharger.Size = new Size(180, 31);
            btnCharger.TabIndex = 1;
            btnCharger.Text = "Charger";
            btnCharger.UseVisualStyleBackColor = true;
            btnCharger.Click += btnCharger_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(422, 407);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 31);
            btnSave.TabIndex = 2;
            btnSave.Text = "Sauvegarder";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnQuitter
            // 
            btnQuitter.Location = new Point(608, 407);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(180, 31);
            btnQuitter.TabIndex = 3;
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = true;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // FuelView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnQuitter);
            Controls.Add(btnSave);
            Controls.Add(btnCharger);
            Controls.Add(dataGridView1);
            Name = "FuelView";
            Text = "FuelView";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnCharger;
        private Button btnSave;
        private Button btnQuitter;
    }
}