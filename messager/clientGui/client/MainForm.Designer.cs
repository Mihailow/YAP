
namespace client
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listMessages = new System.Windows.Forms.ListBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.fieldMessage = new System.Windows.Forms.TextBox();
            this.timerMessage = new System.Windows.Forms.Timer(this.components);
            this.btnAuth = new System.Windows.Forms.Button();
            this.fieldSecret = new System.Windows.Forms.TextBox();
            this.fieldUsername = new System.Windows.Forms.TextBox();
            this.btnEmoji = new System.Windows.Forms.Button();
            this.panelEmoji = new System.Windows.Forms.Panel();
            this.btnEmoji20 = new System.Windows.Forms.Button();
            this.btnEmoji29 = new System.Windows.Forms.Button();
            this.btnEmoji28 = new System.Windows.Forms.Button();
            this.btnEmoji27 = new System.Windows.Forms.Button();
            this.btnEmoji30 = new System.Windows.Forms.Button();
            this.btnEmoji19 = new System.Windows.Forms.Button();
            this.btnEmoji15 = new System.Windows.Forms.Button();
            this.btnEmoji17 = new System.Windows.Forms.Button();
            this.btnEmoji26 = new System.Windows.Forms.Button();
            this.btnEmoji16 = new System.Windows.Forms.Button();
            this.btnEmoji25 = new System.Windows.Forms.Button();
            this.btnEmoji12 = new System.Windows.Forms.Button();
            this.btnEmoji22 = new System.Windows.Forms.Button();
            this.btnEmoji13 = new System.Windows.Forms.Button();
            this.btnEmoji14 = new System.Windows.Forms.Button();
            this.btnEmoji23 = new System.Windows.Forms.Button();
            this.btnEmoji24 = new System.Windows.Forms.Button();
            this.btnEmoji18 = new System.Windows.Forms.Button();
            this.btnEmoji21 = new System.Windows.Forms.Button();
            this.btnEmoji3 = new System.Windows.Forms.Button();
            this.btnEmoji4 = new System.Windows.Forms.Button();
            this.btnEmoji5 = new System.Windows.Forms.Button();
            this.btnEmoji6 = new System.Windows.Forms.Button();
            this.btnEmoji7 = new System.Windows.Forms.Button();
            this.btnEmoji8 = new System.Windows.Forms.Button();
            this.btnEmoji9 = new System.Windows.Forms.Button();
            this.btnEmoji10 = new System.Windows.Forms.Button();
            this.btnEmoji11 = new System.Windows.Forms.Button();
            this.btnEmoji2 = new System.Windows.Forms.Button();
            this.btnEmoji1 = new System.Windows.Forms.Button();
            this.timerDelete = new System.Windows.Forms.Timer(this.components);
            this.timerOnline = new System.Windows.Forms.Timer(this.components);
            this.btnAdmin = new System.Windows.Forms.Button();
            this.panelEmoji.SuspendLayout();
            this.SuspendLayout();
            // 
            // listMessages
            // 
            this.listMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listMessages.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.listMessages.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listMessages.ForeColor = System.Drawing.Color.White;
            this.listMessages.FormattingEnabled = true;
            this.listMessages.ItemHeight = 21;
            this.listMessages.Location = new System.Drawing.Point(0, 0);
            this.listMessages.Name = "listMessages";
            this.listMessages.Size = new System.Drawing.Size(800, 361);
            this.listMessages.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSend.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Location = new System.Drawing.Point(702, 402);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 52);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // fieldMessage
            // 
            this.fieldMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldMessage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldMessage.Location = new System.Drawing.Point(117, 367);
            this.fieldMessage.Multiline = true;
            this.fieldMessage.Name = "fieldMessage";
            this.fieldMessage.Size = new System.Drawing.Size(587, 87);
            this.fieldMessage.TabIndex = 5;
            // 
            // timerMessage
            // 
            this.timerMessage.Enabled = true;
            this.timerMessage.Interval = 200;
            this.timerMessage.Tick += new System.EventHandler(this.timerMessage_Tick);
            // 
            // btnAuth
            // 
            this.btnAuth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAuth.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAuth.Location = new System.Drawing.Point(0, 387);
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.Size = new System.Drawing.Size(117, 22);
            this.btnAuth.TabIndex = 6;
            this.btnAuth.Text = "Сменить";
            this.btnAuth.UseVisualStyleBackColor = true;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // fieldSecret
            // 
            this.fieldSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fieldSecret.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.fieldSecret.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldSecret.Location = new System.Drawing.Point(0, 415);
            this.fieldSecret.Multiline = true;
            this.fieldSecret.Name = "fieldSecret";
            this.fieldSecret.Size = new System.Drawing.Size(117, 10);
            this.fieldSecret.TabIndex = 7;
            // 
            // fieldUsername
            // 
            this.fieldUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fieldUsername.AutoCompleteCustomSource.AddRange(new string[] {
            "You are not logged in"});
            this.fieldUsername.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.fieldUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fieldUsername.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldUsername.Location = new System.Drawing.Point(0, 367);
            this.fieldUsername.Margin = new System.Windows.Forms.Padding(2);
            this.fieldUsername.Name = "fieldUsername";
            this.fieldUsername.ReadOnly = true;
            this.fieldUsername.Size = new System.Drawing.Size(117, 15);
            this.fieldUsername.TabIndex = 8;
            this.fieldUsername.Text = "Логин";
            this.fieldUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnEmoji
            // 
            this.btnEmoji.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmoji.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEmoji.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEmoji.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEmoji.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji.Location = new System.Drawing.Point(702, 370);
            this.btnEmoji.Name = "btnEmoji";
            this.btnEmoji.Size = new System.Drawing.Size(98, 39);
            this.btnEmoji.TabIndex = 9;
            this.btnEmoji.Text = "Эмодзи";
            this.btnEmoji.UseVisualStyleBackColor = false;
            this.btnEmoji.Click += new System.EventHandler(this.btnEmoji_Click);
            // 
            // panelEmoji
            // 
            this.panelEmoji.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEmoji.Controls.Add(this.btnEmoji20);
            this.panelEmoji.Controls.Add(this.btnEmoji29);
            this.panelEmoji.Controls.Add(this.btnEmoji28);
            this.panelEmoji.Controls.Add(this.btnEmoji27);
            this.panelEmoji.Controls.Add(this.btnEmoji30);
            this.panelEmoji.Controls.Add(this.btnEmoji19);
            this.panelEmoji.Controls.Add(this.btnEmoji15);
            this.panelEmoji.Controls.Add(this.btnEmoji17);
            this.panelEmoji.Controls.Add(this.btnEmoji26);
            this.panelEmoji.Controls.Add(this.btnEmoji16);
            this.panelEmoji.Controls.Add(this.btnEmoji25);
            this.panelEmoji.Controls.Add(this.btnEmoji12);
            this.panelEmoji.Controls.Add(this.btnEmoji22);
            this.panelEmoji.Controls.Add(this.btnEmoji13);
            this.panelEmoji.Controls.Add(this.btnEmoji14);
            this.panelEmoji.Controls.Add(this.btnEmoji23);
            this.panelEmoji.Controls.Add(this.btnEmoji24);
            this.panelEmoji.Controls.Add(this.btnEmoji18);
            this.panelEmoji.Controls.Add(this.btnEmoji21);
            this.panelEmoji.Controls.Add(this.btnEmoji3);
            this.panelEmoji.Controls.Add(this.btnEmoji4);
            this.panelEmoji.Controls.Add(this.btnEmoji5);
            this.panelEmoji.Controls.Add(this.btnEmoji6);
            this.panelEmoji.Controls.Add(this.btnEmoji7);
            this.panelEmoji.Controls.Add(this.btnEmoji8);
            this.panelEmoji.Controls.Add(this.btnEmoji9);
            this.panelEmoji.Controls.Add(this.btnEmoji10);
            this.panelEmoji.Controls.Add(this.btnEmoji11);
            this.panelEmoji.Controls.Add(this.btnEmoji2);
            this.panelEmoji.Controls.Add(this.btnEmoji1);
            this.panelEmoji.Location = new System.Drawing.Point(694, 0);
            this.panelEmoji.Name = "panelEmoji";
            this.panelEmoji.Size = new System.Drawing.Size(106, 361);
            this.panelEmoji.TabIndex = 10;
            this.panelEmoji.Visible = false;
            // 
            // btnEmoji20
            // 
            this.btnEmoji20.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji20.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji20.Location = new System.Drawing.Point(39, 327);
            this.btnEmoji20.Name = "btnEmoji20";
            this.btnEmoji20.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji20.TabIndex = 32;
            this.btnEmoji20.Text = "🥺";
            this.btnEmoji20.UseVisualStyleBackColor = false;
            this.btnEmoji20.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji29
            // 
            this.btnEmoji29.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji29.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji29.Location = new System.Drawing.Point(76, 291);
            this.btnEmoji29.Name = "btnEmoji29";
            this.btnEmoji29.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji29.TabIndex = 31;
            this.btnEmoji29.Text = "👀";
            this.btnEmoji29.UseVisualStyleBackColor = false;
            this.btnEmoji29.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji28
            // 
            this.btnEmoji28.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji28.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji28.Location = new System.Drawing.Point(75, 255);
            this.btnEmoji28.Name = "btnEmoji28";
            this.btnEmoji28.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji28.TabIndex = 30;
            this.btnEmoji28.Text = "🙏🏻";
            this.btnEmoji28.UseVisualStyleBackColor = false;
            this.btnEmoji28.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji27
            // 
            this.btnEmoji27.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji27.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji27.Location = new System.Drawing.Point(75, 219);
            this.btnEmoji27.Name = "btnEmoji27";
            this.btnEmoji27.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji27.TabIndex = 29;
            this.btnEmoji27.Text = "✊🏻";
            this.btnEmoji27.UseVisualStyleBackColor = false;
            this.btnEmoji27.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji30
            // 
            this.btnEmoji30.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji30.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji30.Location = new System.Drawing.Point(76, 327);
            this.btnEmoji30.Name = "btnEmoji30";
            this.btnEmoji30.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji30.TabIndex = 28;
            this.btnEmoji30.Text = "👽";
            this.btnEmoji30.UseVisualStyleBackColor = false;
            this.btnEmoji30.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji19
            // 
            this.btnEmoji19.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji19.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji19.Location = new System.Drawing.Point(39, 291);
            this.btnEmoji19.Name = "btnEmoji19";
            this.btnEmoji19.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji19.TabIndex = 27;
            this.btnEmoji19.Text = "😨";
            this.btnEmoji19.UseVisualStyleBackColor = false;
            this.btnEmoji19.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji15
            // 
            this.btnEmoji15.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji15.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji15.Location = new System.Drawing.Point(39, 147);
            this.btnEmoji15.Name = "btnEmoji15";
            this.btnEmoji15.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji15.TabIndex = 26;
            this.btnEmoji15.Text = "😱";
            this.btnEmoji15.UseVisualStyleBackColor = false;
            this.btnEmoji15.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji17
            // 
            this.btnEmoji17.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji17.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji17.Location = new System.Drawing.Point(39, 219);
            this.btnEmoji17.Name = "btnEmoji17";
            this.btnEmoji17.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji17.TabIndex = 25;
            this.btnEmoji17.Text = "🥳";
            this.btnEmoji17.UseVisualStyleBackColor = false;
            this.btnEmoji17.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji26
            // 
            this.btnEmoji26.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji26.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji26.Location = new System.Drawing.Point(76, 183);
            this.btnEmoji26.Name = "btnEmoji26";
            this.btnEmoji26.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji26.TabIndex = 24;
            this.btnEmoji26.Text = "🤙🏻";
            this.btnEmoji26.UseVisualStyleBackColor = false;
            this.btnEmoji26.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji16
            // 
            this.btnEmoji16.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji16.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji16.Location = new System.Drawing.Point(39, 183);
            this.btnEmoji16.Name = "btnEmoji16";
            this.btnEmoji16.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji16.TabIndex = 23;
            this.btnEmoji16.Text = "🤠";
            this.btnEmoji16.UseVisualStyleBackColor = false;
            this.btnEmoji16.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji25
            // 
            this.btnEmoji25.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji25.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji25.Location = new System.Drawing.Point(76, 147);
            this.btnEmoji25.Name = "btnEmoji25";
            this.btnEmoji25.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji25.TabIndex = 22;
            this.btnEmoji25.Text = "👍🏻";
            this.btnEmoji25.UseVisualStyleBackColor = false;
            this.btnEmoji25.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji12
            // 
            this.btnEmoji12.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji12.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji12.Location = new System.Drawing.Point(38, 39);
            this.btnEmoji12.Name = "btnEmoji12";
            this.btnEmoji12.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji12.TabIndex = 21;
            this.btnEmoji12.Text = "😋";
            this.btnEmoji12.UseVisualStyleBackColor = false;
            this.btnEmoji12.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji22
            // 
            this.btnEmoji22.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji22.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji22.Location = new System.Drawing.Point(76, 39);
            this.btnEmoji22.Name = "btnEmoji22";
            this.btnEmoji22.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji22.TabIndex = 20;
            this.btnEmoji22.Text = "👻";
            this.btnEmoji22.UseVisualStyleBackColor = false;
            this.btnEmoji22.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji13
            // 
            this.btnEmoji13.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji13.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji13.Location = new System.Drawing.Point(38, 75);
            this.btnEmoji13.Name = "btnEmoji13";
            this.btnEmoji13.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji13.TabIndex = 19;
            this.btnEmoji13.Text = "🤪";
            this.btnEmoji13.UseVisualStyleBackColor = false;
            this.btnEmoji13.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji14
            // 
            this.btnEmoji14.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji14.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji14.Location = new System.Drawing.Point(38, 111);
            this.btnEmoji14.Name = "btnEmoji14";
            this.btnEmoji14.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji14.TabIndex = 18;
            this.btnEmoji14.Text = "🙄";
            this.btnEmoji14.UseVisualStyleBackColor = false;
            this.btnEmoji14.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji23
            // 
            this.btnEmoji23.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji23.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji23.Location = new System.Drawing.Point(76, 75);
            this.btnEmoji23.Name = "btnEmoji23";
            this.btnEmoji23.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji23.TabIndex = 17;
            this.btnEmoji23.Text = "❤";
            this.btnEmoji23.UseVisualStyleBackColor = false;
            this.btnEmoji23.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji24
            // 
            this.btnEmoji24.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji24.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji24.Location = new System.Drawing.Point(75, 111);
            this.btnEmoji24.Name = "btnEmoji24";
            this.btnEmoji24.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji24.TabIndex = 16;
            this.btnEmoji24.Text = "💪🏻";
            this.btnEmoji24.UseVisualStyleBackColor = false;
            this.btnEmoji24.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji18
            // 
            this.btnEmoji18.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji18.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji18.Location = new System.Drawing.Point(38, 255);
            this.btnEmoji18.Name = "btnEmoji18";
            this.btnEmoji18.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji18.TabIndex = 15;
            this.btnEmoji18.Text = "😬";
            this.btnEmoji18.UseVisualStyleBackColor = false;
            this.btnEmoji18.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji21
            // 
            this.btnEmoji21.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji21.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji21.Location = new System.Drawing.Point(75, 3);
            this.btnEmoji21.Name = "btnEmoji21";
            this.btnEmoji21.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji21.TabIndex = 14;
            this.btnEmoji21.Text = "💩";
            this.btnEmoji21.UseVisualStyleBackColor = false;
            this.btnEmoji21.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji3
            // 
            this.btnEmoji3.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji3.Location = new System.Drawing.Point(3, 75);
            this.btnEmoji3.Name = "btnEmoji3";
            this.btnEmoji3.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji3.TabIndex = 13;
            this.btnEmoji3.Text = "😅";
            this.btnEmoji3.UseVisualStyleBackColor = false;
            this.btnEmoji3.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji4
            // 
            this.btnEmoji4.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji4.Location = new System.Drawing.Point(3, 111);
            this.btnEmoji4.Name = "btnEmoji4";
            this.btnEmoji4.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji4.TabIndex = 12;
            this.btnEmoji4.Text = "😂";
            this.btnEmoji4.UseVisualStyleBackColor = false;
            this.btnEmoji4.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji5
            // 
            this.btnEmoji5.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji5.Location = new System.Drawing.Point(2, 147);
            this.btnEmoji5.Name = "btnEmoji5";
            this.btnEmoji5.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji5.TabIndex = 11;
            this.btnEmoji5.Text = "😉";
            this.btnEmoji5.UseVisualStyleBackColor = false;
            this.btnEmoji5.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji6
            // 
            this.btnEmoji6.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji6.Location = new System.Drawing.Point(2, 183);
            this.btnEmoji6.Name = "btnEmoji6";
            this.btnEmoji6.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji6.TabIndex = 10;
            this.btnEmoji6.Text = "😊";
            this.btnEmoji6.UseVisualStyleBackColor = false;
            this.btnEmoji6.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji7
            // 
            this.btnEmoji7.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji7.Location = new System.Drawing.Point(3, 219);
            this.btnEmoji7.Name = "btnEmoji7";
            this.btnEmoji7.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji7.TabIndex = 9;
            this.btnEmoji7.Text = "☺";
            this.btnEmoji7.UseVisualStyleBackColor = false;
            this.btnEmoji7.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji8
            // 
            this.btnEmoji8.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji8.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji8.Location = new System.Drawing.Point(3, 255);
            this.btnEmoji8.Name = "btnEmoji8";
            this.btnEmoji8.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji8.TabIndex = 8;
            this.btnEmoji8.Text = "😇";
            this.btnEmoji8.UseVisualStyleBackColor = false;
            this.btnEmoji8.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji9
            // 
            this.btnEmoji9.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji9.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji9.Location = new System.Drawing.Point(2, 291);
            this.btnEmoji9.Name = "btnEmoji9";
            this.btnEmoji9.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji9.TabIndex = 7;
            this.btnEmoji9.Text = "😘";
            this.btnEmoji9.UseVisualStyleBackColor = false;
            this.btnEmoji9.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji10
            // 
            this.btnEmoji10.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji10.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji10.Location = new System.Drawing.Point(3, 327);
            this.btnEmoji10.Name = "btnEmoji10";
            this.btnEmoji10.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji10.TabIndex = 6;
            this.btnEmoji10.Text = "😍";
            this.btnEmoji10.UseVisualStyleBackColor = false;
            this.btnEmoji10.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji11
            // 
            this.btnEmoji11.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji11.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji11.Location = new System.Drawing.Point(39, 3);
            this.btnEmoji11.Name = "btnEmoji11";
            this.btnEmoji11.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji11.TabIndex = 5;
            this.btnEmoji11.Text = "🤩";
            this.btnEmoji11.UseVisualStyleBackColor = false;
            this.btnEmoji11.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji2
            // 
            this.btnEmoji2.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji2.Location = new System.Drawing.Point(3, 39);
            this.btnEmoji2.Name = "btnEmoji2";
            this.btnEmoji2.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji2.TabIndex = 4;
            this.btnEmoji2.Text = "😃";
            this.btnEmoji2.UseVisualStyleBackColor = false;
            this.btnEmoji2.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // btnEmoji1
            // 
            this.btnEmoji1.BackColor = System.Drawing.SystemColors.Window;
            this.btnEmoji1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmoji1.Location = new System.Drawing.Point(3, 3);
            this.btnEmoji1.Name = "btnEmoji1";
            this.btnEmoji1.Size = new System.Drawing.Size(30, 30);
            this.btnEmoji1.TabIndex = 0;
            this.btnEmoji1.Text = "😀";
            this.btnEmoji1.UseVisualStyleBackColor = false;
            this.btnEmoji1.Click += new System.EventHandler(this.ChoiceEmoji);
            // 
            // timerDelete
            // 
            this.timerDelete.Enabled = true;
            this.timerDelete.Interval = 1000;
            this.timerDelete.Tick += new System.EventHandler(this.timerDelete_Tick);
            // 
            // timerOnline
            // 
            this.timerOnline.Enabled = true;
            this.timerOnline.Interval = 1000;
            this.timerOnline.Tick += new System.EventHandler(this.timerOnline_Tick);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdmin.Location = new System.Drawing.Point(0, 431);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(117, 23);
            this.btnAdmin.TabIndex = 11;
            this.btnAdmin.Text = "Администратор";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.panelEmoji);
            this.Controls.Add(this.btnEmoji);
            this.Controls.Add(this.fieldUsername);
            this.Controls.Add(this.fieldSecret);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.fieldMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.listMessages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Messager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelEmoji.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listMessages;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox fieldMessage;
        private System.Windows.Forms.Timer timerMessage;
        private System.Windows.Forms.Button btnAuth;
        private System.Windows.Forms.TextBox fieldSecret;
        private System.Windows.Forms.TextBox fieldUsername;
        private System.Windows.Forms.Button btnEmoji;
        private System.Windows.Forms.Button btnEmoji1;
        private System.Windows.Forms.Panel panelEmoji;
        private System.Windows.Forms.Button btnEmoji2;
        private System.Windows.Forms.Button btnEmoji20;
        private System.Windows.Forms.Button btnEmoji29;
        private System.Windows.Forms.Button btnEmoji28;
        private System.Windows.Forms.Button btnEmoji27;
        private System.Windows.Forms.Button btnEmoji30;
        private System.Windows.Forms.Button btnEmoji19;
        private System.Windows.Forms.Button btnEmoji15;
        private System.Windows.Forms.Button btnEmoji17;
        private System.Windows.Forms.Button btnEmoji26;
        private System.Windows.Forms.Button btnEmoji16;
        private System.Windows.Forms.Button btnEmoji25;
        private System.Windows.Forms.Button btnEmoji12;
        private System.Windows.Forms.Button btnEmoji22;
        private System.Windows.Forms.Button btnEmoji13;
        private System.Windows.Forms.Button btnEmoji14;
        private System.Windows.Forms.Button btnEmoji23;
        private System.Windows.Forms.Button btnEmoji24;
        private System.Windows.Forms.Button btnEmoji18;
        private System.Windows.Forms.Button btnEmoji21;
        private System.Windows.Forms.Button btnEmoji3;
        private System.Windows.Forms.Button btnEmoji4;
        private System.Windows.Forms.Button btnEmoji5;
        private System.Windows.Forms.Button btnEmoji6;
        private System.Windows.Forms.Button btnEmoji7;
        private System.Windows.Forms.Button btnEmoji8;
        private System.Windows.Forms.Button btnEmoji9;
        private System.Windows.Forms.Button btnEmoji10;
        private System.Windows.Forms.Button btnEmoji11;
        private System.Windows.Forms.Timer timerDelete;
        private System.Windows.Forms.Timer timerOnline;
        private System.Windows.Forms.Button btnAdmin;
    }
}

