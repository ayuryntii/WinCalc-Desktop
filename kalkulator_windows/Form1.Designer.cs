using System.Drawing;
using System.Windows.Forms;

namespace kalkulator_windows
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // ===== SLIDE MENU =====
        private Panel panelSlideMenu;
        private Panel panelMenuScrollArea;
        private Panel panelMenuSettings;
        private Button btnHamburger;
        private Panel panelMenuOverlay;

        private Button menuBtnStandard, menuBtnScientific, menuBtnProgrammer, menuBtnDateCalc;
        private Button menuBtnCurrency, menuBtnVolume, menuBtnLength, menuBtnWeight;
        private Button menuBtnTemperature, menuBtnEnergy, menuBtnArea, menuBtnSpeed;
        private Button menuBtnTime, menuBtnPower, menuBtnData, menuBtnPressure, menuBtnAngle;
        private Button menuBtnSettings;

        // ===== MAIN =====
        private Panel mainPanel;
        private Label lblDisplay, lblFormula, lblModeTitle;
        private Panel displayPanel;
        private Panel panelHeaderBar;

        private Panel panelStandard, panelScientific, panelProgrammer, panelDateCalc, panelConverterMode;

        // Standard
        private Button btnMC, btnMR, btnMPlus, btnMMinus, btnMS, btnMView;
        private Button btnPercent, btnCE, btnC, btnBackspace;
        private Button btnReciprocal, btnSquare, btnSqrt;
        private Button btnDivide, btnMultiply, btnMinus, btnPlus, btnEquals;
        private Button btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
        private Button btnDot, btnPlusMinus;

        // Scientific
        private Button btnSci2nd, btnSciPi, btnSciE, btnSciCE2, btnSciC2, btnSciBack2;
        private Button btnSciSq, btnSciCube, btnSciRecip, btnSciAbs, btnSciExp2, btnSciMod;
        private Button btnSciSqrt2, btnSciCbrt, btnSciOpenP, btnSciCloseP, btnSciFact, btnSciDiv2;
        private Button btnSciXY, btnSciTenX, btnSci2X, btn7s, btn8s, btn9s, btnSciMul2;
        private Button btnSciLogY, btn4s, btn5s, btn6s, btnSciMinus2;
        private Button btnSciLog, btn1s, btn2s, btn3s, btnSciPlus2;
        private Button btnSciLn, btnSciPlusMinus2, btn0s, btnSciDot2, btnSciEqual2;

        // Programmer
        private Button btnHexMode, btnDecMode, btnOctMode, btnBinMode;
        private Button btnWordQword, btnWordDword, btnWordWord, btnWordByte;
        private Label lblHexDisp, lblDecDisp, lblOctDisp, lblBinDisp;
        private Button btnRol, btnRor, btnLsh, btnRsh, btnAnd, btnOr;
        private Button btnXor, btnNot, btnProgMod, btnProgCE, btnProgC, btnProgBack;
        private Button btnPA, btnPB, btnPC, btnPD, btnPE, btnPF;
        private Button btnP7, btnP8, btnP9, btnProgDiv;
        private Button btnP4, btnP5, btnP6, btnProgMul;
        private Button btnP1, btnP2, btnP3, btnProgMinus;
        private Button btnP0, btnProgDot, btnProgPlus, btnProgEq;

        // Date Calc
        private ComboBox cmbDateOperation;
        private Panel panelDateDiff, panelDateAdd;
        private DateTimePicker dtpStart, dtpEnd;
        private Button btnCalculateDiff;
        private Label lblResultDiff, lblDateAddResult;
        private DateTimePicker dtpAddDate;
        private ComboBox cmbAddSub;
        private NumericUpDown nudYears, nudMonths, nudDays;
        private Button btnCalculateAdd;

        // Converter
        private ComboBox cmbConverterType, cmbFromUnit, cmbToUnit;
        private TextBox txtFromValue;
        private Label lblConverterResult, lblConverterHeader, lblArrow;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        // ===================================================
        // TEMA WARNA: BIRU MUDA (Light Steel Blue) + HOT PINK + PURPLE
        // Nama: [Nama Mahasiswa]   NIM: 230511037
        // ===================================================

        // -- Background & Header --
        private readonly Color clrBg      = Color.FromArgb(176, 196, 222); // Light Steel Blue
        private readonly Color clrHdrBg   = Color.FromArgb(148, 172, 204); // Header lebih gelap
        private readonly Color clrDispBg  = Color.FromArgb(55, 68, 105); // Display: indigo lembut
        // -- Tombol utama (soft/pastel) --
        private readonly Color clrPink    = Color.FromArgb(205, 100, 155); // Soft rose pink (=, CE, %, ⌫)
        private readonly Color clrRose    = Color.FromArgb(180, 70, 115);  // Soft deep rose (C)
        private readonly Color clrPurple  = Color.FromArgb(148, 118, 205); // Soft lavender purple (÷ × - +)
        // -- Tombol angka & fungsi --
        private readonly Color clrNumBtn  = Color.FromArgb(230, 240, 255); // Angka: putih kebiruan
        private readonly Color clrMemBtn  = Color.FromArgb(175, 200, 230); // Memori: biru pastel
        private readonly Color clrSciBtn  = Color.FromArgb(188, 212, 238); // Fungsi sains: biru muda
        // -- Menu --
        private readonly Color clrMenuBg  = Color.FromArgb(242, 247, 255); // Menu putih lembut
        private readonly Color clrMenuHov = Color.FromArgb(218, 232, 252); // Hover biru sangat muda
        private readonly Color clrMenuAct = Color.FromArgb(205, 100, 155); // Aktif soft pink

        // ===================================================
        // InitializeComponent — minimal agar VS Designer tidak error
        // ===================================================
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panelHeaderBar = new System.Windows.Forms.Panel();
            this.btnHamburger = new System.Windows.Forms.Button();
            this.lblModeTitle = new System.Windows.Forms.Label();
            this.headerLine = new System.Windows.Forms.Panel();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.lblFormula = new System.Windows.Forms.Label();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.panelStandard = new System.Windows.Forms.Panel();
            this.btnMC = new System.Windows.Forms.Button();
            this.btnMR = new System.Windows.Forms.Button();
            this.btnMPlus = new System.Windows.Forms.Button();
            this.btnMMinus = new System.Windows.Forms.Button();
            this.btnMS = new System.Windows.Forms.Button();
            this.btnMView = new System.Windows.Forms.Button();
            this.btnPercent = new System.Windows.Forms.Button();
            this.btnCE = new System.Windows.Forms.Button();
            this.btnC = new System.Windows.Forms.Button();
            this.btnBackspace = new System.Windows.Forms.Button();
            this.btnReciprocal = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnSqrt = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnEquals = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btnPlusMinus = new System.Windows.Forms.Button();
            this.panelScientific = new System.Windows.Forms.Panel();
            this.panelProgrammer = new System.Windows.Forms.Panel();
            this.panelDateCalc = new System.Windows.Forms.Panel();
            this.panelConverterMode = new System.Windows.Forms.Panel();
            this.panelMenuOverlay = new System.Windows.Forms.Panel();
            this.panelSlideMenu = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.panelMenuScrollArea = new System.Windows.Forms.Panel();
            this.panelMenuSettings = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.panelHeaderBar.SuspendLayout();
            this.displayPanel.SuspendLayout();
            this.panelStandard.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            this.mainPanel.Controls.Add(this.panelHeaderBar);
            this.mainPanel.Controls.Add(this.displayPanel);
            this.mainPanel.Controls.Add(this.panelStandard);
            this.mainPanel.Controls.Add(this.panelScientific);
            this.mainPanel.Controls.Add(this.panelProgrammer);
            this.mainPanel.Controls.Add(this.panelDateCalc);
            this.mainPanel.Controls.Add(this.panelConverterMode);
            this.mainPanel.Controls.Add(this.panelMenuOverlay);
            this.mainPanel.Controls.Add(this.panelSlideMenu);
            this.mainPanel.Controls.Add(this.lblFooter);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(340, 640);
            this.mainPanel.TabIndex = 0;
            // 
            // panelHeaderBar
            // 
            this.panelHeaderBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(218)))), ((int)(((byte)(240)))));
            this.panelHeaderBar.Controls.Add(this.btnHamburger);
            this.panelHeaderBar.Controls.Add(this.lblModeTitle);
            this.panelHeaderBar.Controls.Add(this.headerLine);
            this.panelHeaderBar.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderBar.Name = "panelHeaderBar";
            this.panelHeaderBar.Size = new System.Drawing.Size(340, 50);
            this.panelHeaderBar.TabIndex = 0;
            // 
            // btnHamburger
            // 
            this.btnHamburger.BackColor = System.Drawing.Color.Transparent;
            this.btnHamburger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHamburger.FlatAppearance.BorderSize = 0;
            this.btnHamburger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHamburger.Font = new System.Drawing.Font("Cambria", 14F);
            this.btnHamburger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btnHamburger.Location = new System.Drawing.Point(4, 5);
            this.btnHamburger.Name = "btnHamburger";
            this.btnHamburger.Size = new System.Drawing.Size(44, 40);
            this.btnHamburger.TabIndex = 0;
            this.btnHamburger.Text = "☰";
            this.btnHamburger.UseVisualStyleBackColor = false;
            // 
            // lblModeTitle
            // 
            this.lblModeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblModeTitle.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.lblModeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(100)))));
            this.lblModeTitle.Location = new System.Drawing.Point(52, 8);
            this.lblModeTitle.Name = "lblModeTitle";
            this.lblModeTitle.Size = new System.Drawing.Size(240, 32);
            this.lblModeTitle.TabIndex = 1;
            this.lblModeTitle.Text = "Standard";
            this.lblModeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // headerLine
            // 
            this.headerLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.headerLine.Location = new System.Drawing.Point(0, 47);
            this.headerLine.Name = "headerLine";
            this.headerLine.Size = new System.Drawing.Size(340, 3);
            this.headerLine.TabIndex = 2;
            // 
            // displayPanel
            // 
            this.displayPanel.BackColor = System.Drawing.Color.Transparent;
            this.displayPanel.Controls.Add(this.lblFormula);
            this.displayPanel.Controls.Add(this.lblDisplay);
            this.displayPanel.Location = new System.Drawing.Point(0, 50);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(340, 118);
            this.displayPanel.TabIndex = 1;
            // 
            // lblFormula
            // 
            this.lblFormula.Font = new System.Drawing.Font("Cambria", 10F);
            this.lblFormula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.lblFormula.Location = new System.Drawing.Point(20, 0);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(308, 28);
            this.lblFormula.TabIndex = 0;
            this.lblFormula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDisplay
            // 
            this.lblDisplay.Font = new System.Drawing.Font("Cambria", 34F, System.Drawing.FontStyle.Bold);
            this.lblDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(90)))));
            this.lblDisplay.Location = new System.Drawing.Point(6, 42);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(328, 68);
            this.lblDisplay.TabIndex = 1;
            this.lblDisplay.Text = "0";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelStandard
            // 
            this.panelStandard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            this.panelStandard.Controls.Add(this.btnMC);
            this.panelStandard.Controls.Add(this.btnMR);
            this.panelStandard.Controls.Add(this.btnMPlus);
            this.panelStandard.Controls.Add(this.btnMMinus);
            this.panelStandard.Controls.Add(this.btnMS);
            this.panelStandard.Controls.Add(this.btnMView);
            this.panelStandard.Controls.Add(this.btnPercent);
            this.panelStandard.Controls.Add(this.btnCE);
            this.panelStandard.Controls.Add(this.btnC);
            this.panelStandard.Controls.Add(this.btnBackspace);
            this.panelStandard.Controls.Add(this.btnReciprocal);
            this.panelStandard.Controls.Add(this.btnSquare);
            this.panelStandard.Controls.Add(this.btnSqrt);
            this.panelStandard.Controls.Add(this.btnDivide);
            this.panelStandard.Controls.Add(this.btnMultiply);
            this.panelStandard.Controls.Add(this.btnMinus);
            this.panelStandard.Controls.Add(this.btnPlus);
            this.panelStandard.Controls.Add(this.btnEquals);
            this.panelStandard.Controls.Add(this.btn0);
            this.panelStandard.Controls.Add(this.btn1);
            this.panelStandard.Controls.Add(this.btn2);
            this.panelStandard.Controls.Add(this.btn3);
            this.panelStandard.Controls.Add(this.btn4);
            this.panelStandard.Controls.Add(this.btn5);
            this.panelStandard.Controls.Add(this.btn6);
            this.panelStandard.Controls.Add(this.btn7);
            this.panelStandard.Controls.Add(this.btn8);
            this.panelStandard.Controls.Add(this.btn9);
            this.panelStandard.Controls.Add(this.btnDot);
            this.panelStandard.Controls.Add(this.btnPlusMinus);
            this.panelStandard.Location = new System.Drawing.Point(0, 0);
            this.panelStandard.Name = "panelStandard";
            this.panelStandard.Size = new System.Drawing.Size(200, 100);
            this.panelStandard.TabIndex = 2;
            // 
            // btnMC
            // 
            this.btnMC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.btnMC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMC.FlatAppearance.BorderSize = 0;
            this.btnMC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMC.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMC.Location = new System.Drawing.Point(7, 4);
            this.btnMC.Name = "btnMC";
            this.btnMC.Size = new System.Drawing.Size(52, 32);
            this.btnMC.TabIndex = 0;
            this.btnMC.Text = "MC";
            this.btnMC.UseVisualStyleBackColor = false;
            // 
            // btnMR
            // 
            this.btnMR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.btnMR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMR.FlatAppearance.BorderSize = 0;
            this.btnMR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMR.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMR.Location = new System.Drawing.Point(62, 4);
            this.btnMR.Name = "btnMR";
            this.btnMR.Size = new System.Drawing.Size(52, 32);
            this.btnMR.TabIndex = 1;
            this.btnMR.Text = "MR";
            this.btnMR.UseVisualStyleBackColor = false;
            // 
            // btnMPlus
            // 
            this.btnMPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.btnMPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMPlus.FlatAppearance.BorderSize = 0;
            this.btnMPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMPlus.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMPlus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMPlus.Location = new System.Drawing.Point(117, 4);
            this.btnMPlus.Name = "btnMPlus";
            this.btnMPlus.Size = new System.Drawing.Size(52, 32);
            this.btnMPlus.TabIndex = 2;
            this.btnMPlus.Text = "M+";
            this.btnMPlus.UseVisualStyleBackColor = false;
            // 
            // btnMMinus
            // 
            this.btnMMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.btnMMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMMinus.FlatAppearance.BorderSize = 0;
            this.btnMMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMMinus.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMMinus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMMinus.Location = new System.Drawing.Point(172, 4);
            this.btnMMinus.Name = "btnMMinus";
            this.btnMMinus.Size = new System.Drawing.Size(52, 32);
            this.btnMMinus.TabIndex = 3;
            this.btnMMinus.Text = "M-";
            this.btnMMinus.UseVisualStyleBackColor = false;
            // 
            // btnMS
            // 
            this.btnMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.btnMS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMS.FlatAppearance.BorderSize = 0;
            this.btnMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMS.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMS.Location = new System.Drawing.Point(227, 4);
            this.btnMS.Name = "btnMS";
            this.btnMS.Size = new System.Drawing.Size(52, 32);
            this.btnMS.TabIndex = 4;
            this.btnMS.Text = "MS";
            this.btnMS.UseVisualStyleBackColor = false;
            // 
            // btnMView
            // 
            this.btnMView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.btnMView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMView.FlatAppearance.BorderSize = 0;
            this.btnMView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMView.Font = new System.Drawing.Font("Cambria", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnMView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMView.Location = new System.Drawing.Point(282, 4);
            this.btnMView.Name = "btnMView";
            this.btnMView.Size = new System.Drawing.Size(52, 32);
            this.btnMView.TabIndex = 5;
            this.btnMView.Text = "M▾";
            this.btnMView.UseVisualStyleBackColor = false;
            // 
            // btnPercent
            // 
            this.btnPercent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.btnPercent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPercent.FlatAppearance.BorderSize = 0;
            this.btnPercent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPercent.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold);
            this.btnPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPercent.Location = new System.Drawing.Point(6, 40);
            this.btnPercent.Name = "btnPercent";
            this.btnPercent.Size = new System.Drawing.Size(80, 62);
            this.btnPercent.TabIndex = 6;
            this.btnPercent.Text = "%";
            this.btnPercent.UseVisualStyleBackColor = false;
            // 
            // btnCE
            // 
            this.btnCE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.btnCE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCE.FlatAppearance.BorderSize = 0;
            this.btnCE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCE.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.btnCE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCE.Location = new System.Drawing.Point(89, 40);
            this.btnCE.Name = "btnCE";
            this.btnCE.Size = new System.Drawing.Size(80, 62);
            this.btnCE.TabIndex = 7;
            this.btnCE.Text = "CE";
            this.btnCE.UseVisualStyleBackColor = false;
            // 
            // btnC
            // 
            this.btnC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(70)))), ((int)(((byte)(115)))));
            this.btnC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnC.FlatAppearance.BorderSize = 0;
            this.btnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold);
            this.btnC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnC.Location = new System.Drawing.Point(172, 40);
            this.btnC.Name = "btnC";
            this.btnC.Size = new System.Drawing.Size(80, 62);
            this.btnC.TabIndex = 8;
            this.btnC.Text = "C";
            this.btnC.UseVisualStyleBackColor = false;
            // 
            // btnBackspace
            // 
            this.btnBackspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.btnBackspace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackspace.FlatAppearance.BorderSize = 0;
            this.btnBackspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackspace.Font = new System.Drawing.Font("Cambria", 13F, System.Drawing.FontStyle.Bold);
            this.btnBackspace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBackspace.Location = new System.Drawing.Point(255, 40);
            this.btnBackspace.Name = "btnBackspace";
            this.btnBackspace.Size = new System.Drawing.Size(80, 62);
            this.btnBackspace.TabIndex = 9;
            this.btnBackspace.Text = "⌫";
            this.btnBackspace.UseVisualStyleBackColor = false;
            // 
            // btnReciprocal
            // 
            this.btnReciprocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(212)))), ((int)(((byte)(238)))));
            this.btnReciprocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReciprocal.FlatAppearance.BorderSize = 0;
            this.btnReciprocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReciprocal.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.btnReciprocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btnReciprocal.Location = new System.Drawing.Point(6, 105);
            this.btnReciprocal.Name = "btnReciprocal";
            this.btnReciprocal.Size = new System.Drawing.Size(80, 62);
            this.btnReciprocal.TabIndex = 10;
            this.btnReciprocal.Text = "1/x";
            this.btnReciprocal.UseVisualStyleBackColor = false;
            // 
            // btnSquare
            // 
            this.btnSquare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(212)))), ((int)(((byte)(238)))));
            this.btnSquare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSquare.FlatAppearance.BorderSize = 0;
            this.btnSquare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSquare.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.btnSquare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btnSquare.Location = new System.Drawing.Point(89, 105);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(80, 62);
            this.btnSquare.TabIndex = 11;
            this.btnSquare.Text = "x²";
            this.btnSquare.UseVisualStyleBackColor = false;
            // 
            // btnSqrt
            // 
            this.btnSqrt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(212)))), ((int)(((byte)(238)))));
            this.btnSqrt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSqrt.FlatAppearance.BorderSize = 0;
            this.btnSqrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSqrt.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold);
            this.btnSqrt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btnSqrt.Location = new System.Drawing.Point(172, 105);
            this.btnSqrt.Name = "btnSqrt";
            this.btnSqrt.Size = new System.Drawing.Size(80, 62);
            this.btnSqrt.TabIndex = 12;
            this.btnSqrt.Text = "²√x";
            this.btnSqrt.UseVisualStyleBackColor = false;
            // 
            // btnDivide
            // 
            this.btnDivide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(118)))), ((int)(((byte)(205)))));
            this.btnDivide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDivide.FlatAppearance.BorderSize = 0;
            this.btnDivide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivide.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold);
            this.btnDivide.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDivide.Location = new System.Drawing.Point(255, 105);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(80, 62);
            this.btnDivide.TabIndex = 13;
            this.btnDivide.Text = "÷";
            this.btnDivide.UseVisualStyleBackColor = false;
            // 
            // btnMultiply
            // 
            this.btnMultiply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(118)))), ((int)(((byte)(205)))));
            this.btnMultiply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMultiply.FlatAppearance.BorderSize = 0;
            this.btnMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiply.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold);
            this.btnMultiply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMultiply.Location = new System.Drawing.Point(255, 170);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(80, 62);
            this.btnMultiply.TabIndex = 14;
            this.btnMultiply.Text = "×";
            this.btnMultiply.UseVisualStyleBackColor = false;
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(118)))), ((int)(((byte)(205)))));
            this.btnMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinus.FlatAppearance.BorderSize = 0;
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinus.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold);
            this.btnMinus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMinus.Location = new System.Drawing.Point(255, 235);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(80, 62);
            this.btnMinus.TabIndex = 15;
            this.btnMinus.Text = "−";
            this.btnMinus.UseVisualStyleBackColor = false;
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(118)))), ((int)(((byte)(205)))));
            this.btnPlus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlus.FlatAppearance.BorderSize = 0;
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold);
            this.btnPlus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPlus.Location = new System.Drawing.Point(255, 300);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(80, 62);
            this.btnPlus.TabIndex = 16;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = false;
            // 
            // btnEquals
            // 
            this.btnEquals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(100)))), ((int)(((byte)(155)))));
            this.btnEquals.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEquals.FlatAppearance.BorderSize = 0;
            this.btnEquals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEquals.Font = new System.Drawing.Font("Cambria", 16F, System.Drawing.FontStyle.Bold);
            this.btnEquals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEquals.Location = new System.Drawing.Point(255, 365);
            this.btnEquals.Name = "btnEquals";
            this.btnEquals.Size = new System.Drawing.Size(80, 62);
            this.btnEquals.TabIndex = 17;
            this.btnEquals.Text = "=";
            this.btnEquals.UseVisualStyleBackColor = false;
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btn0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn0.FlatAppearance.BorderSize = 0;
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.btn0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btn0.Location = new System.Drawing.Point(89, 365);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(80, 62);
            this.btn0.TabIndex = 18;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btn1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn1.FlatAppearance.BorderSize = 0;
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.btn1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btn1.Location = new System.Drawing.Point(6, 300);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(80, 62);
            this.btn1.TabIndex = 19;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn2.FlatAppearance.BorderSize = 0;
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.btn2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btn2.Location = new System.Drawing.Point(89, 300);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(80, 62);
            this.btn2.TabIndex = 20;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btn3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn3.FlatAppearance.BorderSize = 0;
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.btn3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btn3.Location = new System.Drawing.Point(172, 300);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(80, 62);
            this.btn3.TabIndex = 21;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btn4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn4.FlatAppearance.BorderSize = 0;
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.btn4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btn4.Location = new System.Drawing.Point(6, 235);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(80, 62);
            this.btn4.TabIndex = 22;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btn5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn5.FlatAppearance.BorderSize = 0;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.btn5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btn5.Location = new System.Drawing.Point(89, 235);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(80, 62);
            this.btn5.TabIndex = 23;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btn6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn6.FlatAppearance.BorderSize = 0;
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.btn6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btn6.Location = new System.Drawing.Point(172, 235);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(80, 62);
            this.btn6.TabIndex = 24;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btn7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn7.FlatAppearance.BorderSize = 0;
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.btn7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btn7.Location = new System.Drawing.Point(6, 170);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(80, 62);
            this.btn7.TabIndex = 25;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btn8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn8.FlatAppearance.BorderSize = 0;
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.btn8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btn8.Location = new System.Drawing.Point(89, 170);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(80, 62);
            this.btn8.TabIndex = 26;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btn9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn9.FlatAppearance.BorderSize = 0;
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Bold);
            this.btn9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btn9.Location = new System.Drawing.Point(172, 170);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(80, 62);
            this.btn9.TabIndex = 27;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            // 
            // btnDot
            // 
            this.btnDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btnDot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDot.FlatAppearance.BorderSize = 0;
            this.btnDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDot.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Bold);
            this.btnDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btnDot.Location = new System.Drawing.Point(172, 365);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(80, 62);
            this.btnDot.TabIndex = 28;
            this.btnDot.Text = ".";
            this.btnDot.UseVisualStyleBackColor = false;
            // 
            // btnPlusMinus
            // 
            this.btnPlusMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.btnPlusMinus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlusMinus.FlatAppearance.BorderSize = 0;
            this.btnPlusMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlusMinus.Font = new System.Drawing.Font("Cambria", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnPlusMinus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(30)))), ((int)(((byte)(80)))));
            this.btnPlusMinus.Location = new System.Drawing.Point(6, 365);
            this.btnPlusMinus.Name = "btnPlusMinus";
            this.btnPlusMinus.Size = new System.Drawing.Size(80, 62);
            this.btnPlusMinus.TabIndex = 29;
            this.btnPlusMinus.Text = "+/-";
            this.btnPlusMinus.UseVisualStyleBackColor = false;
            // 
            // panelScientific
            // 
            this.panelScientific.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            this.panelScientific.Location = new System.Drawing.Point(0, 0);
            this.panelScientific.Name = "panelScientific";
            this.panelScientific.Size = new System.Drawing.Size(200, 100);
            this.panelScientific.TabIndex = 3;
            this.panelScientific.Visible = false;
            // 
            // panelProgrammer
            // 
            this.panelProgrammer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            this.panelProgrammer.Location = new System.Drawing.Point(0, 0);
            this.panelProgrammer.Name = "panelProgrammer";
            this.panelProgrammer.Size = new System.Drawing.Size(200, 100);
            this.panelProgrammer.TabIndex = 4;
            this.panelProgrammer.Visible = false;
            // 
            // panelDateCalc
            // 
            this.panelDateCalc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            this.panelDateCalc.Location = new System.Drawing.Point(0, 0);
            this.panelDateCalc.Name = "panelDateCalc";
            this.panelDateCalc.Size = new System.Drawing.Size(200, 100);
            this.panelDateCalc.TabIndex = 5;
            this.panelDateCalc.Visible = false;
            // 
            // panelConverterMode
            // 
            this.panelConverterMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            this.panelConverterMode.Location = new System.Drawing.Point(0, 0);
            this.panelConverterMode.Name = "panelConverterMode";
            this.panelConverterMode.Size = new System.Drawing.Size(200, 100);
            this.panelConverterMode.TabIndex = 6;
            this.panelConverterMode.Visible = false;
            // 
            // panelMenuOverlay
            // 
            this.panelMenuOverlay.Location = new System.Drawing.Point(0, 0);
            this.panelMenuOverlay.Name = "panelMenuOverlay";
            this.panelMenuOverlay.Size = new System.Drawing.Size(200, 100);
            this.panelMenuOverlay.TabIndex = 7;
            this.panelMenuOverlay.Visible = false;
            // 
            // panelSlideMenu
            // 
            this.panelSlideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSlideMenu.Name = "panelSlideMenu";
            this.panelSlideMenu.Size = new System.Drawing.Size(200, 100);
            this.panelSlideMenu.TabIndex = 8;
            // 
            // lblFooter
            // 
            this.lblFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(172)))), ((int)(((byte)(204)))));
            this.lblFooter.Font = new System.Drawing.Font("Cambria", 7.5F, System.Drawing.FontStyle.Italic);
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(80)))), ((int)(((byte)(130)))));
            this.lblFooter.Location = new System.Drawing.Point(0, 620);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(340, 18);
            this.lblFooter.TabIndex = 9;
            this.lblFooter.Text = "© 2026  —  Aplikasi Kalkulator Windows  |  230511037";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMenuScrollArea
            // 
            this.panelMenuScrollArea.Location = new System.Drawing.Point(0, 0);
            this.panelMenuScrollArea.Name = "panelMenuScrollArea";
            this.panelMenuScrollArea.Size = new System.Drawing.Size(200, 100);
            this.panelMenuScrollArea.TabIndex = 0;
            // 
            // panelMenuSettings
            // 
            this.panelMenuSettings.Location = new System.Drawing.Point(0, 0);
            this.panelMenuSettings.Name = "panelMenuSettings";
            this.panelMenuSettings.Size = new System.Drawing.Size(200, 100);
            this.panelMenuSettings.TabIndex = 0;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(340, 640);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Cambria", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kalkulator";
            this.mainPanel.ResumeLayout(false);
            this.panelHeaderBar.ResumeLayout(false);
            this.displayPanel.ResumeLayout(false);
            this.panelStandard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        // ================================================================
        // BuildUI — dipanggil dari constructor, membangun semua tombol
        // ================================================================
        public void BuildUI()
        {
            // Posisi & ukuran dasar semua panel mode
            var panelPos  = new Point(0, 168);
            var panelSize = new Size(340, 452);

            panelStandard.Location      = panelPos; panelStandard.Size      = panelSize;
            panelScientific.Location    = panelPos; panelScientific.Size    = panelSize;
            panelProgrammer.Location    = panelPos; panelProgrammer.Size    = panelSize;
            panelDateCalc.Location      = panelPos; panelDateCalc.Size      = panelSize;
            panelConverterMode.Location = panelPos; panelConverterMode.Size = panelSize;

            panelMenuOverlay.Location = new Point(0, 0);
            panelMenuOverlay.Size     = new Size(340, 640);
            panelMenuOverlay.BackColor= Color.FromArgb(100, 20, 10, 50);

            panelSlideMenu.Location   = new Point(-252, 0);
            panelSlideMenu.Size       = new Size(252, 640);
            panelSlideMenu.BackColor  = clrMenuBg;

            BuildScientific();
            BuildProgrammer();
            BuildDateCalc();
            BuildConverter();
            BuildSlideMenu();

            panelSlideMenu.BringToFront();
            panelMenuOverlay.BringToFront();
            panelSlideMenu.BringToFront();
        }

        // ================================================================
        // HELPER: Buat tombol dengan font Cambria
        // ================================================================
        private Button Btn(string txt, Color bg, Color fg,
                           int x, int y, int w, int h,
                           float sz = 13f, FontStyle fs = FontStyle.Bold)
        {
            var b = new Button
            {
                Text      = txt,
                Font      = new Font("Cambria", sz, fs),
                BackColor = bg,
                ForeColor = fg,
                Size      = new Size(w, h),
                Location  = new Point(x, y),
                FlatStyle = FlatStyle.Flat,
                Cursor    = Cursors.Hand
            };
            b.FlatAppearance.BorderSize = 0;
            b.Tag = bg;
            b.MouseEnter += (s, e) => { b.BackColor = ControlPaint.Light((Color)b.Tag, 0.20f); };
            b.MouseLeave += (s, e) => { b.BackColor = (Color)b.Tag; };
            return b;
        }

        // ================================================================
        // SLIDE MENU
        // ================================================================
        private void BuildSlideMenu()
        {
            // Header menu
            var hdr = new Panel { Size = new Size(252, 52), Location = new Point(0, 0), BackColor = Color.FromArgb(210, 220, 240) };
            var hdrLine = new Panel { Location = new Point(0, 0), Size = new Size(252, 3), BackColor = Color.FromArgb(218, 48, 130) };
            hdr.Controls.Add(hdrLine);

            var btnClose = new Button
            {
                Text = "☰", Font = new Font("Cambria", 14f),
                Size = new Size(44, 40), Location = new Point(4, 6),
                FlatStyle = FlatStyle.Flat, BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(30, 30, 80), Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => CloseSlideMenu();
            hdr.Controls.Add(btnClose);

            var lblT = new Label
            {
                Text = "KALKULATOR",
                Font = new Font("Cambria", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 20, 90),
                Location = new Point(52, 11), Size = new Size(185, 30),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            hdr.Controls.Add(lblT);
            panelSlideMenu.Controls.Add(hdr);

            // Scroll area
            panelMenuScrollArea = new Panel
            {
                Location   = new Point(0, 52),
                Size       = new Size(252, 640 - 52 - 50),
                AutoScroll = true,
                BackColor  = clrMenuBg
            };
            panelSlideMenu.Controls.Add(panelMenuScrollArea);

            int y = 4;
            AddMenuSep(y); y += 6;
            AddMenuSectionLbl("Calculator", y); y += 28;
            menuBtnStandard   = AddMenuBtn("Standard",         y, "⊞");  y += 40;
            menuBtnScientific = AddMenuBtn("Scientific",       y, "f(x)");y += 40;
            menuBtnProgrammer = AddMenuBtn("Programmer",       y, "</>");  y += 40;
            menuBtnDateCalc   = AddMenuBtn("Date calculation", y, "📅");  y += 40;
            AddMenuSep(y); y += 8;
            AddMenuSectionLbl("Converter", y); y += 28;
            menuBtnCurrency    = AddMenuBtn("Currency",        y, "💱"); y += 40;
            menuBtnVolume      = AddMenuBtn("Volume",          y, "🧊"); y += 40;
            menuBtnLength      = AddMenuBtn("Length",          y, "📏"); y += 40;
            menuBtnWeight      = AddMenuBtn("Weight and mass", y, "⚖");  y += 40;
            menuBtnTemperature = AddMenuBtn("Temperature",     y, "🌡"); y += 40;
            menuBtnEnergy      = AddMenuBtn("Energy",          y, "⚡"); y += 40;
            menuBtnArea        = AddMenuBtn("Area",            y, "▦");  y += 40;
            menuBtnSpeed       = AddMenuBtn("Speed",           y, "🏎"); y += 40;
            menuBtnTime        = AddMenuBtn("Time",            y, "⏱"); y += 40;
            menuBtnPower       = AddMenuBtn("Power",           y, "🔋"); y += 40;
            menuBtnData        = AddMenuBtn("Data",            y, "💾"); y += 40;
            menuBtnPressure    = AddMenuBtn("Pressure",        y, "◉");  y += 40;
            menuBtnAngle       = AddMenuBtn("Angle",           y, "📐"); y += 40;
            panelMenuScrollArea.AutoScrollMinSize = new System.Drawing.Size(252, y + 4);

            // Settings pinned bottom
            panelMenuSettings = new Panel
            {
                Location  = new Point(0, 640 - 50),
                Size      = new Size(252, 50),
                BackColor = Color.FromArgb(210, 220, 240)
            };
            panelMenuSettings.Controls.Add(new Panel { Size = new Size(252, 1), Location = new Point(0, 0), BackColor = Color.FromArgb(180, 200, 230) });
            menuBtnSettings = MakeMenuButton("Settings", 1, "⚙");
            menuBtnSettings.Size = new Size(252, 48);
            panelMenuSettings.Controls.Add(menuBtnSettings);
            panelSlideMenu.Controls.Add(panelMenuSettings);
        }

        private Button AddMenuBtn(string text, int y, string icon)
        {
            var btn = MakeMenuButton(text, y, icon);
            panelMenuScrollArea.Controls.Add(btn);
            return btn;
        }

        private Button MakeMenuButton(string text, int y, string icon)
        {
            var btn = new Button
            {
                Text      = "  " + icon + "  " + text,
                Font      = new Font("Cambria", 9.5f),
                ForeColor = Color.FromArgb(30, 25, 80),
                BackColor = clrMenuBg,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size(252, 40),
                Location  = new Point(0, y),
                TextAlign = ContentAlignment.MiddleLeft,
                Cursor    = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Tag = clrMenuBg;
            btn.MouseEnter += (s, e) => { btn.BackColor = ControlPaint.Light((Color)btn.Tag, 0.15f); };
            btn.MouseLeave += (s, e) => { btn.BackColor = (Color)btn.Tag; };
            return btn;
        }

        private void AddMenuSep(int y)
        {
            panelMenuScrollArea.Controls.Add(new Panel { Size = new Size(252, 1), Location = new Point(0, y), BackColor = Color.FromArgb(190, 210, 235) });
        }

        private void AddMenuSectionLbl(string text, int y)
        {
            panelMenuScrollArea.Controls.Add(new Label
            {
                Text = text, Font = new Font("Cambria", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(80, 100, 160),
                Location = new Point(12, y), Size = new Size(228, 26),
                TextAlign = ContentAlignment.BottomLeft,
                BackColor = Color.Transparent
            });
        }

        // ================================================================        // ================================================================
        // SCIENTIFIC
        // ================================================================
        private void BuildScientific()
        {
            int sx = 5, sg = 2, sw = 51, sh = 36;
            Color cF = Color.FromArgb(20, 20, 70);

            // Baris 0: 2nd π e CE C ⌫
            btnSci2nd   = Btn("2nd",clrMemBtn,Color.White,sx+0*(sw+sg),2,sw,sh,8.5f);
            btnSciPi    = Btn("π",  clrMemBtn,Color.White,sx+1*(sw+sg),2,sw,sh,11f);
            btnSciE     = Btn("e",  clrMemBtn,Color.White,sx+2*(sw+sg),2,sw,sh,11f);
            btnSciCE2   = Btn("CE", clrPink,  Color.White,sx+3*(sw+sg),2,sw,sh,9f);
            btnSciC2    = Btn("C",  clrRose,  Color.White,sx+4*(sw+sg),2,sw,sh,11f);
            btnSciBack2 = Btn("⌫",  clrPink,  Color.White,sx+5*(sw+sg),2,sw,sh,11f);
            panelScientific.Controls.AddRange(new Control[]{ btnSci2nd,btnSciPi,btnSciE,btnSciCE2,btnSciC2,btnSciBack2 });

            int r2=sh+sg+2;
            btnSciSq   =Btn("x²",  clrSciBtn,cF,sx+0*(sw+sg),r2,sw,sh,8.5f);
            btnSciCube =Btn("x³",  clrSciBtn,cF,sx+1*(sw+sg),r2,sw,sh,8.5f);
            btnSciRecip=Btn("1/x", clrSciBtn,cF,sx+2*(sw+sg),r2,sw,sh,8f);
            btnSciAbs  =Btn("|x|", clrSciBtn,cF,sx+3*(sw+sg),r2,sw,sh,8f);
            btnSciExp2 =Btn("exp", clrSciBtn,cF,sx+4*(sw+sg),r2,sw,sh,8f);
            btnSciMod  =Btn("mod", clrSciBtn,cF,sx+5*(sw+sg),r2,sw,sh,8f);
            panelScientific.Controls.AddRange(new Control[]{ btnSciSq,btnSciCube,btnSciRecip,btnSciAbs,btnSciExp2,btnSciMod });

            int r3=r2+sh+sg;
            btnSciSqrt2 =Btn("²√x",clrSciBtn,cF,sx+0*(sw+sg),r3,sw,sh,8f);
            btnSciCbrt  =Btn("³√x",clrSciBtn,cF,sx+1*(sw+sg),r3,sw,sh,8f);
            btnSciOpenP =Btn("(",  clrSciBtn,cF,sx+2*(sw+sg),r3,sw,sh,11f);
            btnSciCloseP=Btn(")",  clrSciBtn,cF,sx+3*(sw+sg),r3,sw,sh,11f);
            btnSciFact  =Btn("n!", clrSciBtn,cF,sx+4*(sw+sg),r3,sw,sh,8.5f);
            btnSciDiv2  =Btn("÷",  clrPurple,Color.White,sx+5*(sw+sg),r3,sw,sh,13f);
            panelScientific.Controls.AddRange(new Control[]{ btnSciSqrt2,btnSciCbrt,btnSciOpenP,btnSciCloseP,btnSciFact,btnSciDiv2 });

            int r4=r3+sh+sg;
            btnSciXY  =Btn("xʸ", clrSciBtn,cF,sx+0*(sw+sg),r4,sw,sh,8.5f);
            btn7s     =Btn("7",  clrNumBtn,Color.FromArgb(25,30,80),sx+1*(sw+sg),r4,sw,sh,12f);
            btn8s     =Btn("8",  clrNumBtn,Color.FromArgb(25,30,80),sx+2*(sw+sg),r4,sw,sh,12f);
            btn9s     =Btn("9",  clrNumBtn,Color.FromArgb(25,30,80),sx+3*(sw+sg),r4,sw,sh,12f);
            btnSciTenX=Btn("10ˣ",clrSciBtn,cF,sx+4*(sw+sg),r4,sw,sh,7.5f);
            btnSciMul2=Btn("×",  clrPurple,Color.White,sx+5*(sw+sg),r4,sw,sh,13f);
            panelScientific.Controls.AddRange(new Control[]{ btnSciXY,btn7s,btn8s,btn9s,btnSciTenX,btnSciMul2 });

            int r5=r4+sh+sg;
            btnSciLogY =Btn("logᵧ",clrSciBtn,cF,sx+0*(sw+sg),r5,sw,sh,7.5f);
            btn4s      =Btn("4",   clrNumBtn,Color.FromArgb(25,30,80),sx+1*(sw+sg),r5,sw,sh,12f);
            btn5s      =Btn("5",   clrNumBtn,Color.FromArgb(25,30,80),sx+2*(sw+sg),r5,sw,sh,12f);
            btn6s      =Btn("6",   clrNumBtn,Color.FromArgb(25,30,80),sx+3*(sw+sg),r5,sw,sh,12f);
            btnSci2X   =Btn("2ˣ",  clrSciBtn,cF,sx+4*(sw+sg),r5,sw,sh,8.5f);
            btnSciMinus2=Btn("-",  clrPurple,Color.White,sx+5*(sw+sg),r5,sw,sh,14f);
            panelScientific.Controls.AddRange(new Control[]{ btnSciLogY,btn4s,btn5s,btn6s,btnSci2X,btnSciMinus2 });

            int r6=r5+sh+sg;
            btnSciLog  =Btn("log",clrSciBtn,cF,sx+0*(sw+sg),r6,sw,sh,8.5f);
            btn1s      =Btn("1",  clrNumBtn,Color.FromArgb(25,30,80),sx+1*(sw+sg),r6,sw,sh,12f);
            btn2s      =Btn("2",  clrNumBtn,Color.FromArgb(25,30,80),sx+2*(sw+sg),r6,sw,sh,12f);
            btn3s      =Btn("3",  clrNumBtn,Color.FromArgb(25,30,80),sx+3*(sw+sg),r6,sw,sh,12f);
            btnSciPlus2=Btn("+",  clrPurple,Color.White,sx+5*(sw+sg),r6,sw,sh,14f);
            panelScientific.Controls.AddRange(new Control[]{ btnSciLog,btn1s,btn2s,btn3s,btnSciPlus2 });

            int r7=r6+sh+sg;
            btnSciLn        =Btn("ln", clrSciBtn,cF,sx+0*(sw+sg),r7,sw,sh,8.5f);
            btnSciPlusMinus2=Btn("+/-",clrNumBtn,Color.FromArgb(25,30,80),sx+1*(sw+sg),r7,sw,sh,9f);
            btn0s           =Btn("0",  clrNumBtn,Color.FromArgb(25,30,80),sx+2*(sw+sg),r7,sw,sh,12f);
            btnSciDot2      =Btn(".",  clrNumBtn,Color.FromArgb(25,30,80),sx+3*(sw+sg),r7,sw,sh,16f);
            btnSciEqual2    =Btn("=",  clrPink,  Color.White,sx+5*(sw+sg),r7,sw,sh,14f);
            panelScientific.Controls.AddRange(new Control[]{ btnSciLn,btnSciPlusMinus2,btn0s,btnSciDot2,btnSciEqual2 });
        }

        // ================================================================
        // PROGRAMMER
        // ================================================================
        private void BuildProgrammer()
        {
            int sx=6, gap=2, mw=78, mh=30;

            btnHexMode=Btn("HEX",clrMemBtn, Color.White,sx+0*(mw+gap),4,mw,mh,9f);
            btnDecMode=Btn("DEC",clrPurple, Color.White,sx+1*(mw+gap),4,mw,mh,9f);
            btnOctMode=Btn("OCT",clrMemBtn, Color.White,sx+2*(mw+gap),4,mw,mh,9f);
            btnBinMode=Btn("BIN",clrMemBtn, Color.White,sx+3*(mw+gap),4,mw,mh,9f);
            panelProgrammer.Controls.AddRange(new Control[]{ btnHexMode,btnDecMode,btnOctMode,btnBinMode });

            int wy=mh+gap+4;
            btnWordQword=Btn("QWORD",clrMemBtn, Color.White,sx+0*(mw+gap),wy,mw,mh,8f);
            btnWordDword=Btn("DWORD",clrMemBtn, Color.White,sx+1*(mw+gap),wy,mw,mh,8f);
            btnWordWord =Btn("WORD", clrPurple, Color.White,sx+2*(mw+gap),wy,mw,mh,8f);
            btnWordByte =Btn("BYTE", clrMemBtn, Color.White,sx+3*(mw+gap),wy,mw,mh,8f);
            panelProgrammer.Controls.AddRange(new Control[]{ btnWordQword,btnWordDword,btnWordWord,btnWordByte });

            int dy=wy+mh+gap, dh=20, dg=1;
            lblHexDisp=new Label{Text="HEX   0",Font=new Font("Cambria",8.5f),Location=new Point(sx,dy),Size=new Size(328,dh),ForeColor=Color.FromArgb(80,100,150),BackColor=Color.Transparent};
            lblDecDisp=new Label{Text="DEC   0",Font=new Font("Cambria",8.5f,FontStyle.Bold),Location=new Point(sx,dy+dh+dg),Size=new Size(328,dh),ForeColor=Color.FromArgb(20,20,70),BackColor=Color.Transparent};
            lblOctDisp=new Label{Text="OCT   0",Font=new Font("Cambria",8.5f),Location=new Point(sx,dy+2*(dh+dg)),Size=new Size(328,dh),ForeColor=Color.FromArgb(80,100,150),BackColor=Color.Transparent};
            lblBinDisp=new Label{Text="BIN   0",Font=new Font("Cambria",8.5f),Location=new Point(sx,dy+3*(dh+dg)),Size=new Size(328,dh),ForeColor=Color.FromArgb(80,100,150),BackColor=Color.Transparent};
            panelProgrammer.Controls.AddRange(new Control[]{ lblHexDisp,lblDecDisp,lblOctDisp,lblBinDisp });

            int lr=dy+4*(dh+dg)+gap, lw=51, lh=34, lg=2;
            btnRol =Btn("RoL",clrMemBtn,Color.White,sx+0*(lw+lg),lr,lw,lh,8f);
            btnRor =Btn("RoR",clrMemBtn,Color.White,sx+1*(lw+lg),lr,lw,lh,8f);
            btnLsh =Btn("Lsh",clrMemBtn,Color.White,sx+2*(lw+lg),lr,lw,lh,8f);
            btnRsh =Btn("Rsh",clrMemBtn,Color.White,sx+3*(lw+lg),lr,lw,lh,8f);
            btnAnd =Btn("And",clrMemBtn,Color.White,sx+4*(lw+lg),lr,lw,lh,8f);
            btnOr  =Btn("Or", clrMemBtn,Color.White,sx+5*(lw+lg),lr,lw,lh,8f);
            panelProgrammer.Controls.AddRange(new Control[]{ btnRol,btnRor,btnLsh,btnRsh,btnAnd,btnOr });

            int lr2=lr+lh+lg;
            btnXor    =Btn("Xor",clrMemBtn,Color.White,sx+0*(lw+lg),lr2,lw,lh,8f);
            btnNot    =Btn("Not",clrMemBtn,Color.White,sx+1*(lw+lg),lr2,lw,lh,8f);
            btnProgMod=Btn("Mod",clrMemBtn,Color.White,sx+2*(lw+lg),lr2,lw,lh,8f);
            btnProgCE =Btn("CE", clrPink,  Color.White,sx+3*(lw+lg),lr2,lw,lh,8.5f);
            btnProgC  =Btn("C",  clrRose,  Color.White,sx+4*(lw+lg),lr2,lw,lh,9.5f);
            btnProgBack=Btn("⌫", clrPink,  Color.White,sx+5*(lw+lg),lr2,lw,lh,11f);
            panelProgrammer.Controls.AddRange(new Control[]{ btnXor,btnNot,btnProgMod,btnProgCE,btnProgC,btnProgBack });

            int nr=lr2+lh+lg, nw=51, nh=40, ng=2;
            Color hxFg=Color.FromArgb(30,20,80);
            Color hxBg=Color.FromArgb(188,206,228);
            btnPA=Btn("A",hxBg,hxFg,sx+0*(nw+ng),nr,nw,nh,12f);
            btnPB=Btn("B",hxBg,hxFg,sx+1*(nw+ng),nr,nw,nh,12f);
            btnP7=Btn("7",clrNumBtn,Color.FromArgb(25,30,80),sx+2*(nw+ng),nr,nw,nh,12f);
            btnP8=Btn("8",clrNumBtn,Color.FromArgb(25,30,80),sx+3*(nw+ng),nr,nw,nh,12f);
            btnP9=Btn("9",clrNumBtn,Color.FromArgb(25,30,80),sx+4*(nw+ng),nr,nw,nh,12f);
            btnProgDiv=Btn("÷",clrPurple,Color.White,sx+5*(nw+ng),nr,nw,nh,13f);
            panelProgrammer.Controls.AddRange(new Control[]{ btnPA,btnPB,btnP7,btnP8,btnP9,btnProgDiv });

            int nr2=nr+nh+ng;
            btnPC=Btn("C",hxBg,hxFg,sx+0*(nw+ng),nr2,nw,nh,12f);
            btnPD=Btn("D",hxBg,hxFg,sx+1*(nw+ng),nr2,nw,nh,12f);
            btnP4=Btn("4",clrNumBtn,Color.FromArgb(25,30,80),sx+2*(nw+ng),nr2,nw,nh,12f);
            btnP5=Btn("5",clrNumBtn,Color.FromArgb(25,30,80),sx+3*(nw+ng),nr2,nw,nh,12f);
            btnP6=Btn("6",clrNumBtn,Color.FromArgb(25,30,80),sx+4*(nw+ng),nr2,nw,nh,12f);
            btnProgMul=Btn("×",clrPurple,Color.White,sx+5*(nw+ng),nr2,nw,nh,13f);
            panelProgrammer.Controls.AddRange(new Control[]{ btnPC,btnPD,btnP4,btnP5,btnP6,btnProgMul });

            int nr3=nr2+nh+ng;
            btnPE=Btn("E",hxBg,hxFg,sx+0*(nw+ng),nr3,nw,nh,12f);
            btnPF=Btn("F",hxBg,hxFg,sx+1*(nw+ng),nr3,nw,nh,12f);
            btnP1=Btn("1",clrNumBtn,Color.FromArgb(25,30,80),sx+2*(nw+ng),nr3,nw,nh,12f);
            btnP2=Btn("2",clrNumBtn,Color.FromArgb(25,30,80),sx+3*(nw+ng),nr3,nw,nh,12f);
            btnP3=Btn("3",clrNumBtn,Color.FromArgb(25,30,80),sx+4*(nw+ng),nr3,nw,nh,12f);
            btnProgMinus=Btn("-",clrPurple,Color.White,sx+5*(nw+ng),nr3,nw,nh,14f);
            panelProgrammer.Controls.AddRange(new Control[]{ btnPE,btnPF,btnP1,btnP2,btnP3,btnProgMinus });

            int nr4=nr3+nh+ng;
            var ppm=Btn("+/-",clrNumBtn,Color.FromArgb(25,30,80),sx+0*(nw+ng),nr4,nw,nh,9f);
            btnP0      =Btn("0",  clrNumBtn,Color.FromArgb(25,30,80),sx+1*(nw+ng),nr4,nw,nh,12f);
            btnProgDot =Btn(".",  clrNumBtn,Color.FromArgb(25,30,80),sx+2*(nw+ng),nr4,nw,nh,16f);
            btnProgPlus=Btn("+",  clrPurple,Color.White,sx+3*(nw+ng),nr4,nw*2+ng,nh,14f);
            btnProgEq  =Btn("=",  clrPink,  Color.White,sx+5*(nw+ng),nr4,nw,nh,14f);
            panelProgrammer.Controls.AddRange(new Control[]{ ppm,btnP0,btnProgDot,btnProgPlus,btnProgEq });
        }

        // ================================================================
        // DATE CALC
        // ================================================================
        private void BuildDateCalc()
        {
            cmbDateOperation = new ComboBox
            {
                Font = new Font("Cambria", 10f),
                Location = new Point(12, 10), Size = new Size(316, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(210, 225, 245),
                ForeColor = Color.FromArgb(20, 20, 70)
            };
            cmbDateOperation.Items.AddRange(new object[]{ "Difference between dates", "Add or subtract days" });
            cmbDateOperation.SelectedIndex = 0;
            panelDateCalc.Controls.Add(cmbDateOperation);

            // --- Panel DIFF ---
            panelDateDiff = new Panel { Location=new Point(0,46), Size=new Size(340,400), BackColor=Color.FromArgb(176,196,222) };
            AddDateLbl(panelDateDiff,"From",4,12);
            dtpStart = new DateTimePicker { Location=new Point(12,24), Size=new Size(316,28), Font=new Font("Cambria",10f) };
            panelDateDiff.Controls.Add(dtpStart);
            AddDateLbl(panelDateDiff,"To",58,12);
            dtpEnd = new DateTimePicker { Location=new Point(12,78), Size=new Size(316,28), Font=new Font("Cambria",10f) };
            panelDateDiff.Controls.Add(dtpEnd);
            btnCalculateDiff = Btn("Calculate",clrPurple,Color.White,95,120,150,38,10.5f);
            panelDateDiff.Controls.Add(btnCalculateDiff);
            lblResultDiff = new Label { Text="—", Font=new Font("Cambria",16f,FontStyle.Bold), ForeColor=Color.FromArgb(180,30,100), Location=new Point(12,172), Size=new Size(316,38), TextAlign=ContentAlignment.MiddleCenter, BackColor=Color.Transparent };
            panelDateDiff.Controls.Add(lblResultDiff);
            var brk = new Label { Name="lblDateBreak", Text="", Font=new Font("Cambria",9.5f), ForeColor=Color.FromArgb(40,60,120), Location=new Point(12,215), Size=new Size(316,80), TextAlign=ContentAlignment.TopCenter, BackColor=Color.Transparent };
            panelDateDiff.Controls.Add(brk);
            panelDateCalc.Controls.Add(panelDateDiff);

            // --- Panel ADD/SUB ---
            panelDateAdd = new Panel { Location=new Point(0,46), Size=new Size(340,400), BackColor=Color.FromArgb(176,196,222), Visible=false };
            AddDateLbl(panelDateAdd,"Date",4,12);
            dtpAddDate = new DateTimePicker { Location=new Point(12,24), Size=new Size(316,28), Font=new Font("Cambria",10f) };
            panelDateAdd.Controls.Add(dtpAddDate);
            cmbAddSub = new ComboBox { Items={"Add","Subtract"}, SelectedIndex=0, Font=new Font("Cambria",10f), Location=new Point(12,62), Size=new Size(130,28), DropDownStyle=ComboBoxStyle.DropDownList, BackColor=Color.FromArgb(210,225,245), ForeColor=Color.FromArgb(20,20,70) };
            panelDateAdd.Controls.Add(cmbAddSub);
            AddDateLbl(panelDateAdd,"Years",96,12);   nudYears  = new NumericUpDown { Location=new Point(12,116),  Size=new Size(80,28), Font=new Font("Cambria",10f), Minimum=0, Maximum=999 }; panelDateAdd.Controls.Add(nudYears);
            AddDateLbl(panelDateAdd,"Months",96,100); nudMonths = new NumericUpDown { Location=new Point(100,116), Size=new Size(80,28), Font=new Font("Cambria",10f), Minimum=0, Maximum=11  }; panelDateAdd.Controls.Add(nudMonths);
            AddDateLbl(panelDateAdd,"Days",96,188);   nudDays   = new NumericUpDown { Location=new Point(188,116), Size=new Size(80,28), Font=new Font("Cambria",10f), Minimum=0, Maximum=999 }; panelDateAdd.Controls.Add(nudDays);
            btnCalculateAdd = Btn("Calculate",clrPurple,Color.White,95,158,150,38,10.5f);
            panelDateAdd.Controls.Add(btnCalculateAdd);
            lblDateAddResult = new Label { Text="—", Font=new Font("Cambria",12f,FontStyle.Bold), ForeColor=Color.FromArgb(180,30,100), Location=new Point(12,212), Size=new Size(316,40), TextAlign=ContentAlignment.MiddleCenter, BackColor=Color.Transparent };
            panelDateAdd.Controls.Add(lblDateAddResult);
            panelDateCalc.Controls.Add(panelDateAdd);
        }

        private void AddDateLbl(Panel p, string text, int y, int x)
        {
            p.Controls.Add(new Label { Text=text, Font=new Font("Cambria",8.5f,FontStyle.Bold), ForeColor=Color.FromArgb(50,70,130), Location=new Point(x,y), Size=new Size(250,20), BackColor=Color.Transparent });
        }

        // ================================================================
        // CONVERTER
        // ================================================================
        private void BuildConverter()
        {
            lblConverterHeader = new Label
            {
                Text = "Length", Font = new Font("Cambria", 14f, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 58, 188),
                Location = new Point(14, 8), Size = new Size(310, 32),
                BackColor = Color.Transparent
            };
            panelConverterMode.Controls.Add(lblConverterHeader);

            panelConverterMode.Controls.Add(new Panel { Location=new Point(14,42), Size=new Size(310,2), BackColor=Color.FromArgb(218,48,130) });

            txtFromValue = new TextBox
            {
                Font = new Font("Cambria", 22f),
                Location = new Point(14, 50), Size = new Size(312, 54),
                AutoSize = false,
                Text = "0", BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(210, 225, 245),
                ForeColor = Color.FromArgb(20, 20, 70),
                TextAlign = HorizontalAlignment.Right
            };
            panelConverterMode.Controls.Add(txtFromValue);

            cmbFromUnit = new ComboBox
            {
                Font = new Font("Cambria", 10f), Location = new Point(14, 108),
                Size = new Size(312, 30), DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(210, 225, 245), ForeColor = Color.FromArgb(20, 20, 70)
            };
            panelConverterMode.Controls.Add(cmbFromUnit);

            // Tombol swap ⇅
            var btnSwap = new Button
            {
                Text = "⇅", Font = new Font("Cambria", 16f), Size = new Size(40, 40),
                Location = new Point(150, 142), FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(218, 48, 130), ForeColor = Color.White, Cursor = Cursors.Hand
            };
            btnSwap.FlatAppearance.BorderSize = 0;
            btnSwap.Click += (s, e) => SwapUnits();
            panelConverterMode.Controls.Add(btnSwap);

            lblArrow = new Label { Text = "", Location = new Point(0, 0), Size = new Size(1, 1) };
            panelConverterMode.Controls.Add(lblArrow);

            lblConverterResult = new Label
            {
                Text = "0", Font = new Font("Cambria", 22f),
                ForeColor = Color.FromArgb(80, 50, 160),
                Location = new Point(14, 188), Size = new Size(312, 54),
                BackColor = Color.FromArgb(200, 218, 242),
                TextAlign = ContentAlignment.MiddleRight
            };
            panelConverterMode.Controls.Add(lblConverterResult);

            cmbToUnit = new ComboBox
            {
                Font = new Font("Cambria", 10f), Location = new Point(14, 246),
                Size = new Size(312, 30), DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = Color.FromArgb(210, 225, 245), ForeColor = Color.FromArgb(20, 20, 70)
            };
            panelConverterMode.Controls.Add(cmbToUnit);

            cmbConverterType = new ComboBox { Visible = false };
            cmbConverterType.Items.AddRange(new object[]{"Currency","Volume","Length","Weight and mass","Temperature","Energy","Area","Speed","Time","Power","Data","Pressure","Angle"});
            cmbConverterType.SelectedIndex = 2;
            panelConverterMode.Controls.Add(cmbConverterType);
        }

        private Panel headerLine;
        private Label lblFooter;
    }
}