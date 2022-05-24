
namespace PictureReda4er
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bOpenone = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bOpentwo = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.buttondelpict2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.повернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отразитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поВертикалиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поГоризонталиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранить1КартинкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kEKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чБToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чБ1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чБ2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.чБ3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.методToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.линейнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.медианнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гистограммаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.частотнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(988, 599);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // bOpenone
            // 
            this.bOpenone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenone.Location = new System.Drawing.Point(1071, 12);
            this.bOpenone.Name = "bOpenone";
            this.bOpenone.Size = new System.Drawing.Size(123, 23);
            this.bOpenone.TabIndex = 1;
            this.bOpenone.Text = "Открыть 1 картинку";
            this.bOpenone.UseVisualStyleBackColor = true;
            this.bOpenone.Click += new System.EventHandler(this.bOpenone_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "попиксельно сумма",
            "произведение",
            "среднее-арифметическое",
            "минимум",
            "максимум",
            "маска"});
            this.comboBox1.Location = new System.Drawing.Point(1071, 317);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(122, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1068, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Операция";
            this.label1.Visible = false;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1-RGB",
            "2-R",
            "3-G",
            "4-B",
            "5-RG",
            "6-GB",
            "7-RB"});
            this.comboBox2.Location = new System.Drawing.Point(1071, 368);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(122, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.Visible = false;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1068, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Выбор канала";
            this.label2.Visible = false;
            // 
            // bOpentwo
            // 
            this.bOpentwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpentwo.Location = new System.Drawing.Point(1071, 150);
            this.bOpentwo.Name = "bOpentwo";
            this.bOpentwo.Size = new System.Drawing.Size(123, 21);
            this.bOpentwo.TabIndex = 8;
            this.bOpentwo.Text = "Открыть 2 картинку";
            this.bOpentwo.UseVisualStyleBackColor = true;
            this.bOpentwo.Visible = false;
            this.bOpentwo.Click += new System.EventHandler(this.bOpentwo_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(1029, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(165, 103);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(1029, 150);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(165, 103);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(1073, 521);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Сбросить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Круг",
            "Квадрат",
            "Прямоугольник"});
            this.comboBox3.Location = new System.Drawing.Point(1071, 411);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(122, 21);
            this.comboBox3.TabIndex = 12;
            this.comboBox3.Visible = false;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1068, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Маска";
            this.label3.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(12, 650);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 13);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "github.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // buttondelpict2
            // 
            this.buttondelpict2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttondelpict2.Location = new System.Drawing.Point(1006, 259);
            this.buttondelpict2.Name = "buttondelpict2";
            this.buttondelpict2.Size = new System.Drawing.Size(59, 21);
            this.buttondelpict2.TabIndex = 15;
            this.buttondelpict2.Text = "Удалить";
            this.buttondelpict2.UseVisualStyleBackColor = true;
            this.buttondelpict2.Visible = false;
            this.buttondelpict2.Click += new System.EventHandler(this.buttondelpict2_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.фильтрыToolStripMenuItem,
            this.гистограммаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(12, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(410, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripMenuItem,
            this.повернутьToolStripMenuItem,
            this.отразитьToolStripMenuItem,
            this.сохранить1КартинкуToolStripMenuItem});
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "2048×1080",
            "1920x1080",
            "1600×900",
            "1366×768",
            "1280×720",
            "11520×6480"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // повернутьToolStripMenuItem
            // 
            this.повернутьToolStripMenuItem.Name = "повернутьToolStripMenuItem";
            this.повернутьToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.повернутьToolStripMenuItem.Text = "Повернуть";
            this.повернутьToolStripMenuItem.Click += new System.EventHandler(this.повернутьToolStripMenuItem_Click);
            // 
            // отразитьToolStripMenuItem
            // 
            this.отразитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поВертикалиToolStripMenuItem,
            this.поГоризонталиToolStripMenuItem});
            this.отразитьToolStripMenuItem.Name = "отразитьToolStripMenuItem";
            this.отразитьToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.отразитьToolStripMenuItem.Text = "Отразить";
            // 
            // поВертикалиToolStripMenuItem
            // 
            this.поВертикалиToolStripMenuItem.Name = "поВертикалиToolStripMenuItem";
            this.поВертикалиToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.поВертикалиToolStripMenuItem.Text = "По вертикали";
            this.поВертикалиToolStripMenuItem.Click += new System.EventHandler(this.поВертикалиToolStripMenuItem_Click);
            // 
            // поГоризонталиToolStripMenuItem
            // 
            this.поГоризонталиToolStripMenuItem.Name = "поГоризонталиToolStripMenuItem";
            this.поГоризонталиToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.поГоризонталиToolStripMenuItem.Text = "По горизонтали";
            this.поГоризонталиToolStripMenuItem.Click += new System.EventHandler(this.поГоризонталиToolStripMenuItem_Click);
            // 
            // сохранить1КартинкуToolStripMenuItem
            // 
            this.сохранить1КартинкуToolStripMenuItem.Name = "сохранить1КартинкуToolStripMenuItem";
            this.сохранить1КартинкуToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.сохранить1КартинкуToolStripMenuItem.Text = "Сохранить  картинку";
            this.сохранить1КартинкуToolStripMenuItem.Click += new System.EventHandler(this.сохранить1КартинкуToolStripMenuItem_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kEKToolStripMenuItem,
            this.чБToolStripMenuItem,
            this.фильтрацияToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // kEKToolStripMenuItem
            // 
            this.kEKToolStripMenuItem.Name = "kEKToolStripMenuItem";
            this.kEKToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kEKToolStripMenuItem.Text = "KEK";
            this.kEKToolStripMenuItem.Click += new System.EventHandler(this.kEKToolStripMenuItem_Click);
            // 
            // чБToolStripMenuItem
            // 
            this.чБToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.чБ1ToolStripMenuItem,
            this.чБ2ToolStripMenuItem,
            this.чБ3ToolStripMenuItem,
            this.методToolStripMenuItem});
            this.чБToolStripMenuItem.Name = "чБToolStripMenuItem";
            this.чБToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.чБToolStripMenuItem.Text = "ЧБ";
            // 
            // чБ1ToolStripMenuItem
            // 
            this.чБ1ToolStripMenuItem.Name = "чБ1ToolStripMenuItem";
            this.чБ1ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.чБ1ToolStripMenuItem.Text = "Метод Гаврилова";
            this.чБ1ToolStripMenuItem.Click += new System.EventHandler(this.чБ1ToolStripMenuItem_Click);
            // 
            // чБ2ToolStripMenuItem
            // 
            this.чБ2ToolStripMenuItem.Name = "чБ2ToolStripMenuItem";
            this.чБ2ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.чБ2ToolStripMenuItem.Text = "Метод Отсу";
            this.чБ2ToolStripMenuItem.Click += new System.EventHandler(this.чБ2ToolStripMenuItem_Click);
            // 
            // чБ3ToolStripMenuItem
            // 
            this.чБ3ToolStripMenuItem.Name = "чБ3ToolStripMenuItem";
            this.чБ3ToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.чБ3ToolStripMenuItem.Text = "Метод Ниблека";
            this.чБ3ToolStripMenuItem.Click += new System.EventHandler(this.чБ3ToolStripMenuItem_Click);
            // 
            // методToolStripMenuItem
            // 
            this.методToolStripMenuItem.Name = "методToolStripMenuItem";
            this.методToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.методToolStripMenuItem.Text = "Метод Сауволы";
            this.методToolStripMenuItem.Click += new System.EventHandler(this.методToolStripMenuItem_Click);
            // 
            // фильтрацияToolStripMenuItem
            // 
            this.фильтрацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.линейнаяToolStripMenuItem,
            this.медианнаяToolStripMenuItem,
            this.частотнаяToolStripMenuItem});
            this.фильтрацияToolStripMenuItem.Name = "фильтрацияToolStripMenuItem";
            this.фильтрацияToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.фильтрацияToolStripMenuItem.Text = "Фильтрация";
            this.фильтрацияToolStripMenuItem.Click += new System.EventHandler(this.фильтрацияToolStripMenuItem_Click);
            // 
            // линейнаяToolStripMenuItem
            // 
            this.линейнаяToolStripMenuItem.Name = "линейнаяToolStripMenuItem";
            this.линейнаяToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.линейнаяToolStripMenuItem.Text = "Линейная";
            this.линейнаяToolStripMenuItem.Click += new System.EventHandler(this.линейнаяToolStripMenuItem_Click);
            // 
            // медианнаяToolStripMenuItem
            // 
            this.медианнаяToolStripMenuItem.Name = "медианнаяToolStripMenuItem";
            this.медианнаяToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.медианнаяToolStripMenuItem.Text = "Медианная";
            this.медианнаяToolStripMenuItem.Click += new System.EventHandler(this.медианнаяToolStripMenuItem_Click);
            // 
            // гистограммаToolStripMenuItem
            // 
            this.гистограммаToolStripMenuItem.Enabled = false;
            this.гистограммаToolStripMenuItem.Name = "гистограммаToolStripMenuItem";
            this.гистограммаToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.гистограммаToolStripMenuItem.Text = "Гистограмма";
            this.гистограммаToolStripMenuItem.Click += new System.EventHandler(this.гистограммаToolStripMenuItem_Click);
            // 
            // частотнаяToolStripMenuItem
            // 
            this.частотнаяToolStripMenuItem.Name = "частотнаяToolStripMenuItem";
            this.частотнаяToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.частотнаяToolStripMenuItem.Text = "Частотная";
            this.частотнаяToolStripMenuItem.Click += new System.EventHandler(this.частотнаяToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 683);
            this.Controls.Add(this.buttondelpict2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.bOpentwo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bOpenone);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pictureредачер";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button bOpenone;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bOpentwo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button buttondelpict2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kEKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отразитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поВертикалиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поГоризонталиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранить1КартинкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem чБToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem чБ1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem чБ2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem чБ3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гистограммаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem методToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem линейнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem медианнаяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem частотнаяToolStripMenuItem;
    }
}

