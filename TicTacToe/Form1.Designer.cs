namespace TicTacToe
{
    partial class TicTacToe
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Start = new System.Windows.Forms.Button();
            this.label_Message = new System.Windows.Forms.Label();
            this.button_1 = new System.Windows.Forms.Button();
            this.button_2 = new System.Windows.Forms.Button();
            this.button_3 = new System.Windows.Forms.Button();
            this.button_4 = new System.Windows.Forms.Button();
            this.button_5 = new System.Windows.Forms.Button();
            this.button_6 = new System.Windows.Forms.Button();
            this.button_7 = new System.Windows.Forms.Button();
            this.button_8 = new System.Windows.Forms.Button();
            this.button_9 = new System.Windows.Forms.Button();
            this.AITimer = new System.Windows.Forms.Timer(this.components);
            this.labelPlayer = new System.Windows.Forms.Label();
            this.labelPC = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.button_Clear);
            this.groupBox1.Controls.Add(this.button_Start);
            this.groupBox1.Location = new System.Drawing.Point(357, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(233, 132);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки игры";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 66);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(90, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Первый - ИИ";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 30);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(145, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Первый - пользователь";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(158, 102);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(75, 23);
            this.button_Clear.TabIndex = 12;
            this.button_Clear.Text = "Очистить";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(1, 102);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 0;
            this.button_Start.Text = "Играть";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Play_Click);
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Message.Location = new System.Drawing.Point(352, 228);
            this.label_Message.MaximumSize = new System.Drawing.Size(250, 0);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(218, 29);
            this.label_Message.TabIndex = 2;
            this.label_Message.Text = "Нажмите играть";
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_1.Location = new System.Drawing.Point(23, 24);
            this.button_1.Name = "button_1";
            this.button_1.Size = new System.Drawing.Size(102, 96);
            this.button_1.TabIndex = 3;
            this.button_1.Tag = "play";
            this.button_1.UseVisualStyleBackColor = true;
            this.button_1.Click += new System.EventHandler(this.button_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_2.Location = new System.Drawing.Point(131, 24);
            this.button_2.Name = "button_2";
            this.button_2.Size = new System.Drawing.Size(102, 96);
            this.button_2.TabIndex = 4;
            this.button_2.Tag = "play";
            this.button_2.UseVisualStyleBackColor = true;
            this.button_2.Click += new System.EventHandler(this.button_Click);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_3.Location = new System.Drawing.Point(239, 24);
            this.button_3.Name = "button_3";
            this.button_3.Size = new System.Drawing.Size(102, 96);
            this.button_3.TabIndex = 5;
            this.button_3.Tag = "play";
            this.button_3.UseVisualStyleBackColor = true;
            this.button_3.Click += new System.EventHandler(this.button_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_4.Location = new System.Drawing.Point(23, 126);
            this.button_4.Name = "button_4";
            this.button_4.Size = new System.Drawing.Size(102, 96);
            this.button_4.TabIndex = 6;
            this.button_4.Tag = "play";
            this.button_4.UseVisualStyleBackColor = true;
            this.button_4.Click += new System.EventHandler(this.button_Click);
            // 
            // button_5
            // 
            this.button_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_5.Location = new System.Drawing.Point(131, 126);
            this.button_5.Name = "button_5";
            this.button_5.Size = new System.Drawing.Size(102, 96);
            this.button_5.TabIndex = 7;
            this.button_5.Tag = "play";
            this.button_5.UseVisualStyleBackColor = true;
            this.button_5.Click += new System.EventHandler(this.button_Click);
            // 
            // button_6
            // 
            this.button_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_6.Location = new System.Drawing.Point(239, 126);
            this.button_6.Name = "button_6";
            this.button_6.Size = new System.Drawing.Size(102, 96);
            this.button_6.TabIndex = 8;
            this.button_6.Tag = "play";
            this.button_6.UseVisualStyleBackColor = true;
            this.button_6.Click += new System.EventHandler(this.button_Click);
            // 
            // button_7
            // 
            this.button_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_7.Location = new System.Drawing.Point(23, 228);
            this.button_7.Name = "button_7";
            this.button_7.Size = new System.Drawing.Size(102, 96);
            this.button_7.TabIndex = 9;
            this.button_7.Tag = "play";
            this.button_7.UseVisualStyleBackColor = true;
            this.button_7.Click += new System.EventHandler(this.button_Click);
            // 
            // button_8
            // 
            this.button_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_8.Location = new System.Drawing.Point(131, 228);
            this.button_8.Name = "button_8";
            this.button_8.Size = new System.Drawing.Size(102, 96);
            this.button_8.TabIndex = 10;
            this.button_8.Tag = "play";
            this.button_8.UseVisualStyleBackColor = true;
            this.button_8.Click += new System.EventHandler(this.button_Click);
            // 
            // button_9
            // 
            this.button_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_9.Location = new System.Drawing.Point(239, 228);
            this.button_9.Name = "button_9";
            this.button_9.Size = new System.Drawing.Size(102, 96);
            this.button_9.TabIndex = 11;
            this.button_9.Tag = "play";
            this.button_9.UseVisualStyleBackColor = true;
            this.button_9.Click += new System.EventHandler(this.button_Click);
            // 
            // AITimer
            // 
            this.AITimer.Interval = 1000;
            this.AITimer.Tick += new System.EventHandler(this.pcMove);
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPlayer.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelPlayer.Location = new System.Drawing.Point(354, 169);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(159, 24);
            this.labelPlayer.TabIndex = 12;
            this.labelPlayer.Text = "Игрок выиграл - ";
            // 
            // labelPC
            // 
            this.labelPC.AutoSize = true;
            this.labelPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelPC.Location = new System.Drawing.Point(353, 198);
            this.labelPC.Name = "labelPC";
            this.labelPC.Size = new System.Drawing.Size(210, 24);
            this.labelPC.TabIndex = 13;
            this.labelPC.Text = "Компьютер выиграл - ";
            // 
            // TicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 358);
            this.Controls.Add(this.labelPC);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.button_9);
            this.Controls.Add(this.button_8);
            this.Controls.Add(this.button_7);
            this.Controls.Add(this.button_6);
            this.Controls.Add(this.button_5);
            this.Controls.Add(this.button_4);
            this.Controls.Add(this.button_3);
            this.Controls.Add(this.button_2);
            this.Controls.Add(this.button_1);
            this.Controls.Add(this.label_Message);
            this.Controls.Add(this.groupBox1);
            this.Name = "TicTacToe";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Label label_Message;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_1;
        private System.Windows.Forms.Button button_2;
        private System.Windows.Forms.Button button_3;
        private System.Windows.Forms.Button button_4;
        private System.Windows.Forms.Button button_5;
        private System.Windows.Forms.Button button_6;
        private System.Windows.Forms.Button button_7;
        private System.Windows.Forms.Button button_8;
        private System.Windows.Forms.Button button_9;
        private System.Windows.Forms.Timer AITimer;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.Label labelPC;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

