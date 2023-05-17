namespace Tasks
{
    partial class ThreadTest
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
            this.btnError = new System.Windows.Forms.Button();
            this.btnThread20 = new System.Windows.Forms.Button();
            this.btnThread30 = new System.Windows.Forms.Button();
            this.btnThread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnError
            // 
            this.btnError.Location = new System.Drawing.Point(12, 12);
            this.btnError.Name = "btnError";
            this.btnError.Size = new System.Drawing.Size(131, 59);
            this.btnError.TabIndex = 0;
            this.btnError.Text = "Error";
            this.btnError.UseVisualStyleBackColor = true;
            this.btnError.Click += new System.EventHandler(this.btnError_Click);
            // 
            // btnThread20
            // 
            this.btnThread20.Location = new System.Drawing.Point(12, 133);
            this.btnThread20.Name = "btnThread20";
            this.btnThread20.Size = new System.Drawing.Size(131, 59);
            this.btnThread20.TabIndex = 1;
            this.btnThread20.Text = "b2";
            this.btnThread20.UseVisualStyleBackColor = true;
            this.btnThread20.Click += new System.EventHandler(this.btnThread20_Click);
            // 
            // btnThread30
            // 
            this.btnThread30.Location = new System.Drawing.Point(12, 198);
            this.btnThread30.Name = "btnThread30";
            this.btnThread30.Size = new System.Drawing.Size(131, 59);
            this.btnThread30.TabIndex = 2;
            this.btnThread30.Text = "b3";
            this.btnThread30.UseVisualStyleBackColor = true;
            this.btnThread30.Click += new System.EventHandler(this.btnThread30_Click);
            // 
            // btnThread
            // 
            this.btnThread.Location = new System.Drawing.Point(12, 272);
            this.btnThread.Name = "btnThread";
            this.btnThread.Size = new System.Drawing.Size(131, 59);
            this.btnThread.TabIndex = 3;
            this.btnThread.Text = "b4";
            this.btnThread.UseVisualStyleBackColor = true;
            this.btnThread.Click += new System.EventHandler(this.btnThread_Click);
            // 
            // ThreadTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 366);
            this.Controls.Add(this.btnThread);
            this.Controls.Add(this.btnThread30);
            this.Controls.Add(this.btnThread20);
            this.Controls.Add(this.btnError);
            this.Name = "ThreadTest";
            this.Text = "ThreadTest";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnError;
        private Button btnThread20;
        private Button btnThread30;
        private Button btnThread;
    }
}