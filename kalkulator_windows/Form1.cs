using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace kalkulator_windows
{
    public partial class Form1 : Form
    {
        private double  currentValue    = 0;
        private string  currentOperator = "";
        private bool    isNewEntry      = true;
        private double  memoryValue     = 0;
        private double  pendingValue    = 0;
        private string  pendingOp       = "";

        private System.Collections.Generic.Stack<double> parenStack   = new System.Collections.Generic.Stack<double>();
        private System.Collections.Generic.Stack<string> parenOpStack = new System.Collections.Generic.Stack<string>();
        private int parenDepth = 0;

        private bool sci2nd = false;

        private enum ProgBase { HEX, DEC, OCT, BIN }
        private ProgBase currentBase = ProgBase.DEC;
        private long     progValue   = 0;
        private string   progWordSize = "WORD";

        private bool menuOpen = false;
        private System.Windows.Forms.Timer menuTimer;
        private int  menuTargetX = -252;
        private const int MENU_SPD = 28;

        private Button _activeMenuBtn = null;

        public Form1()
        {
            InitializeComponent();
            BuildUI();
            BuildSettings();
            WireEvents();
            SetMenuActive(menuBtnStandard);
            RefreshProgDisplays();
        }

        private void WireEvents()
        {
            btnHamburger.Click += (s,e) => ToggleMenu();
            menuTimer = new System.Windows.Forms.Timer { Interval=12 };
            menuTimer.Tick += MenuTick;
            panelMenuOverlay.Click += (s,e) => CloseSlideMenu();

            menuBtnStandard.Click   += (s,e) => { SwitchMode(panelStandard,   "Standard");         SetMenuActive(menuBtnStandard); };
            menuBtnScientific.Click += (s,e) => { SwitchMode(panelScientific, "Scientific");        SetMenuActive(menuBtnScientific); };
            menuBtnProgrammer.Click += (s,e) => { SwitchMode(panelProgrammer, "Programmer");        SetMenuActive(menuBtnProgrammer); };
            menuBtnDateCalc.Click   += (s,e) => { SwitchMode(panelDateCalc,   "Date calculation");  SetMenuActive(menuBtnDateCalc); };

            menuBtnCurrency.Click    += (s,e) => OpenConv("Currency");
            menuBtnVolume.Click      += (s,e) => OpenConv("Volume");
            menuBtnLength.Click      += (s,e) => OpenConv("Length");
            menuBtnWeight.Click      += (s,e) => OpenConv("Weight and mass");
            menuBtnTemperature.Click += (s,e) => OpenConv("Temperature");
            menuBtnEnergy.Click      += (s,e) => OpenConv("Energy");
            menuBtnArea.Click        += (s,e) => OpenConv("Area");
            menuBtnSpeed.Click       += (s,e) => OpenConv("Speed");
            menuBtnTime.Click        += (s,e) => OpenConv("Time");
            menuBtnPower.Click       += (s,e) => OpenConv("Power");
            menuBtnData.Click        += (s,e) => OpenConv("Data");
            menuBtnPressure.Click    += (s,e) => OpenConv("Pressure");
            menuBtnAngle.Click       += (s,e) => OpenConv("Angle");
            menuBtnSettings.Click    += (s,e) => { SwitchMode(panelSettings, "Appearance Settings"); SetMenuActive(menuBtnSettings); };

            foreach(Control c in panelConverterMode.Controls) {
                if (c is Button btn && btn.Text == "⇅") {
                    btn.Click += (s, e) => {
                        int temp = cmbFromUnit.SelectedIndex;
                        cmbFromUnit.SelectedIndex = cmbToUnit.SelectedIndex;
                        cmbToUnit.SelectedIndex = temp;
                    };
                }
            }

            btn0.Click+=(s,e)=>NumClick("0"); btn1.Click+=(s,e)=>NumClick("1");
            btn2.Click+=(s,e)=>NumClick("2"); btn3.Click+=(s,e)=>NumClick("3");
            btn4.Click+=(s,e)=>NumClick("4"); btn5.Click+=(s,e)=>NumClick("5");
            btn6.Click+=(s,e)=>NumClick("6"); btn7.Click+=(s,e)=>NumClick("7");
            btn8.Click+=(s,e)=>NumClick("8"); btn9.Click+=(s,e)=>NumClick("9");
            btnDot.Click+=(s,e)=>NumClick(".");

            btnDivide.Click   +=(s,e)=>OpClick("÷");
            btnMultiply.Click +=(s,e)=>OpClick("×");
            btnMinus.Click    +=(s,e)=>OpClick("-");
            btnPlus.Click     +=(s,e)=>OpClick("+");
            btnEquals.Click   +=(s,e)=>CalcResult();

            btnC.Click          +=(s,e)=>ClearAll();
            btnCE.Click         +=(s,e)=>ClearEntry();
            btnBackspace.Click  +=(s,e)=>Backspace();
            btnPercent.Click    +=(s,e)=>Percent();
            btnReciprocal.Click +=(s,e)=>Reciprocal();
            btnSquare.Click     +=(s,e)=>Square();
            btnSqrt.Click       +=(s,e)=>SqrtFn();
            btnPlusMinus.Click  +=(s,e)=>PlusMinus();

            btnMC.Click    +=(s,e)=>{ memoryValue=0; };
            btnMR.Click    +=(s,e)=>{ lblDisplay.Text=Fmt(memoryValue); isNewEntry=true; };
            btnMPlus.Click +=(s,e)=>{ if(TryVal(out double v)) memoryValue+=v; };
            btnMMinus.Click+=(s,e)=>{ if(TryVal(out double v)) memoryValue-=v; };
            btnMS.Click    +=(s,e)=>{ if(TryVal(out double v)) memoryValue=v; };
            btnMView.Click +=(s,e)=>{ MessageBox.Show("Memory: "+Fmt(memoryValue),"Memory",MessageBoxButtons.OK,MessageBoxIcon.Information); };

            btn0s.Click+=(s,e)=>NumClick("0"); btn1s.Click+=(s,e)=>NumClick("1");
            btn2s.Click+=(s,e)=>NumClick("2"); btn3s.Click+=(s,e)=>NumClick("3");
            btn4s.Click+=(s,e)=>NumClick("4"); btn5s.Click+=(s,e)=>NumClick("5");
            btn6s.Click+=(s,e)=>NumClick("6"); btn7s.Click+=(s,e)=>NumClick("7");
            btn8s.Click+=(s,e)=>NumClick("8"); btn9s.Click+=(s,e)=>NumClick("9");
            btnSciDot2.Click+=(s,e)=>NumClick(".");
            btnSciPlusMinus2.Click+=(s,e)=>PlusMinus();

            btnSciCE2.Click  +=(s,e)=>ClearEntry();
            btnSciC2.Click   +=(s,e)=>ClearAll();
            btnSciBack2.Click+=(s,e)=>Backspace();
            btnSciDiv2.Click +=(s,e)=>OpClick("÷");
            btnSciMul2.Click +=(s,e)=>OpClick("×");
            btnSciMinus2.Click+=(s,e)=>OpClick("-");
            btnSciPlus2.Click+=(s,e)=>OpClick("+");
            btnSciEqual2.Click+=(s,e)=>CalcResult();

            btnSci2nd.Click   +=(s,e)=>Toggle2nd();
            btnSciPi.Click    +=(s,e)=>{ SetDisplay(Math.PI); isNewEntry=false; };
            btnSciE.Click     +=(s,e)=>{ SetDisplay(Math.E);  isNewEntry=false; };
            btnSciSq.Click    +=(s,e)=>SciFn(v=>v*v, "sqr");
            btnSciCube.Click  +=(s,e)=>SciFn(v=>v*v*v, "cube");
            btnSciRecip.Click +=(s,e)=>SciFn(v=>1.0/v, "1/");
            btnSciAbs.Click   +=(s,e)=>SciFn(Math.Abs, "|");
            btnSciExp2.Click  +=(s,e)=>SciFn(Math.Exp, "e^");
            btnSciMod.Click   +=(s,e)=>OpClick("%");
            btnSciSqrt2.Click +=(s,e)=>SciFn(Math.Sqrt, "√");
            btnSciCbrt.Click  +=(s,e)=>SciFn(v=>Math.Pow(v,1.0/3.0),"∛");
            btnSciOpenP.Click +=(s,e)=>OpenParen();
            btnSciCloseP.Click+=(s,e)=>CloseParen();
            btnSciFact.Click  +=(s,e)=>Factorial();
            btnSciXY.Click    +=(s,e)=>{ PendPow(); };
            btnSciTenX.Click  +=(s,e)=>SciFn(v=>Math.Pow(10,v),"10^");
            btnSci2X.Click    +=(s,e)=>SciFn(v=>Math.Pow(2,v),"2^");
            btnSciLog.Click   +=(s,e)=>SciFn(Math.Log10,"log");
            btnSciLogY.Click  +=(s,e)=>{ pendingOp="logY"; if(TryVal(out double b)){pendingValue=b;lblFormula.Text="log("+Fmt(b)+","; isNewEntry=true;} };
            btnSciLn.Click    +=(s,e)=>SciFn(Math.Log,"ln");

            btnHexMode.Click   +=(s,e)=>SetProgBase(ProgBase.HEX);
            btnDecMode.Click   +=(s,e)=>SetProgBase(ProgBase.DEC);
            btnOctMode.Click   +=(s,e)=>SetProgBase(ProgBase.OCT);
            btnBinMode.Click   +=(s,e)=>SetProgBase(ProgBase.BIN);

            btnWordQword.Click +=(s,e)=>SetWordSize("QWORD");
            btnWordDword.Click +=(s,e)=>SetWordSize("DWORD");
            btnWordWord.Click  +=(s,e)=>SetWordSize("WORD");
            btnWordByte.Click  +=(s,e)=>SetWordSize("BYTE");

            btnP0.Click+=(s,e)=>ProgNum("0"); btnP1.Click+=(s,e)=>ProgNum("1");
            btnP2.Click+=(s,e)=>ProgNum("2"); btnP3.Click+=(s,e)=>ProgNum("3");
            btnP4.Click+=(s,e)=>ProgNum("4"); btnP5.Click+=(s,e)=>ProgNum("5");
            btnP6.Click+=(s,e)=>ProgNum("6"); btnP7.Click+=(s,e)=>ProgNum("7");
            btnP8.Click+=(s,e)=>ProgNum("8"); btnP9.Click+=(s,e)=>ProgNum("9");
            btnPA.Click+=(s,e)=>ProgNum("A"); btnPB.Click+=(s,e)=>ProgNum("B");
            btnPC.Click+=(s,e)=>ProgNum("C"); btnPD.Click+=(s,e)=>ProgNum("D");
            btnPE.Click+=(s,e)=>ProgNum("E"); btnPF.Click+=(s,e)=>ProgNum("F");

            btnProgCE.Click  +=(s,e)=>{ progValue=0; isNewEntry=true; lblFormula.Text=""; RefreshProgDisplays(); };
            btnProgC.Click   +=(s,e)=>{ progValue=0; isNewEntry=true; currentOperator=""; currentValue=0; lblFormula.Text=""; RefreshProgDisplays(); };
            btnProgBack.Click+=(s,e)=>ProgBackspace();
            btnProgDiv.Click +=(s,e)=>ProgOp("÷");
            btnProgMul.Click +=(s,e)=>ProgOp("×");
            btnProgMinus.Click+=(s,e)=>ProgOp("-");
            btnProgPlus.Click+=(s,e)=>ProgOp("+");
            btnProgEq.Click  +=(s,e)=>ProgCalc();
            btnProgMod.Click +=(s,e)=>ProgOp("Mod");

            btnAnd.Click+=(s,e)=>ProgOp("And");
            btnOr.Click +=(s,e)=>ProgOp("Or");
            btnXor.Click+=(s,e)=>ProgOp("Xor");
            btnNot.Click+=(s,e)=>{ progValue=~progValue; MaskProg(); RefreshProgDisplays(); };
            btnLsh.Click+=(s,e)=>{ progValue<<=1; MaskProg(); RefreshProgDisplays(); };
            btnRsh.Click+=(s,e)=>{ progValue>>=1; RefreshProgDisplays(); };
            btnRol.Click+=(s,e)=>{ progValue=RotL(progValue); RefreshProgDisplays(); };
            btnRor.Click+=(s,e)=>{ progValue=RotR(progValue); RefreshProgDisplays(); };

            cmbDateOperation.SelectedIndexChanged+=(s,e)=>DateOpChanged();
            btnCalculateDiff.Click +=(s,e)=>CalcDateDiff();
            btnCalculateAdd.Click  +=(s,e)=>CalcDateAdd();

            cmbConverterType.SelectedIndexChanged+=(s,e)=>UpdateConvUnits();
            txtFromValue.TextChanged     +=(s,e)=>DoConvert();
            txtFromValue.KeyPress        +=(s,e)=>{
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
                if (e.KeyChar == '.' && txtFromValue.Text.Contains(".")) e.Handled = true;
                if(txtFromValue.Text == "0" && char.IsDigit(e.KeyChar)) {
                    if(e.KeyChar == '0') { e.Handled = true; } 
                    else { txtFromValue.Text = ""; }
                }
            };
            cmbFromUnit.SelectedIndexChanged+=(s,e)=>DoConvert();
            cmbToUnit.SelectedIndexChanged  +=(s,e)=>DoConvert();
        }

        private void ToggleMenu() { if(menuOpen) CloseSlideMenu(); else OpenSlideMenu(); }

        private void OpenSlideMenu()
        {
            menuOpen=true; menuTargetX=0;
            panelMenuOverlay.Visible=true;
            panelSlideMenu.BringToFront();
            panelMenuOverlay.BringToFront();
            panelSlideMenu.BringToFront();
            menuTimer.Start();
        }

        public void CloseSlideMenu() { menuOpen=false; menuTargetX=-252; menuTimer.Start(); }

        private void MenuTick(object sender, EventArgs e)
        {
            int cur=panelSlideMenu.Left;
            if(cur==menuTargetX) { menuTimer.Stop(); if(!menuOpen) panelMenuOverlay.Visible=false; return; }
            int step=Math.Min(MENU_SPD, Math.Abs(cur-menuTargetX));
            panelSlideMenu.Left += (cur<menuTargetX) ? step : -step;
        }

        private void SetMenuActive(Button btn)
        {
            Color bMenu = isDarkTheme ? Color.FromArgb(17, 18, 22) : Color.FromArgb(242, 247, 255);
            Color fMenu = isDarkTheme ? Color.FromArgb(230, 234, 240) : Color.FromArgb(30, 25, 80);
            Color bAct  = isDarkTheme ? Color.FromArgb(45, 60, 95) : Color.FromArgb(205, 100, 155);
            Color fAct  = isDarkTheme ? Color.White : Color.FromArgb(22, 38, 70);

            if(_activeMenuBtn!=null) { 
                _activeMenuBtn.Tag = bMenu;
                _activeMenuBtn.BackColor=bMenu; 
                _activeMenuBtn.ForeColor=fMenu; 
            }
            _activeMenuBtn=btn;
            if(btn!=null) { 
                btn.Tag = bAct;
                btn.BackColor=bAct; 
                btn.ForeColor=fAct; 
            }
        }

        private void SwitchMode(Panel target, string title)
        {
            panelStandard.Visible=panelScientific.Visible=panelProgrammer.Visible=panelDateCalc.Visible=panelConverterMode.Visible=false;
            if(panelSettings!=null) panelSettings.Visible=false;
            foreach(var p in new[]{panelStandard,panelScientific,panelProgrammer,panelDateCalc})
            { p.Location=new Point(0,168); p.Size=new Size(340,452); }

            target.Visible=true;
            lblModeTitle.Text=title;

            if(target==panelConverterMode || target==panelSettings)
            {
                displayPanel.Visible=false;
                target.Location=new Point(0,50);
                target.Size=new Size(340,570);
            }
            else
            {
                displayPanel.Visible=true;
            }
            CloseSlideMenu();
        }

        private void OpenConv(string type)
        {
            cmbConverterType.SelectedItem=type;
            UpdateConvUnits();
            lblConverterHeader.Text=type;
            SwitchMode(panelConverterMode, type);
            SetMenuActive(ConvBtn(type));
        }

        private Button ConvBtn(string t)
        {
            switch(t)
            {
                case "Currency": return menuBtnCurrency; case "Volume": return menuBtnVolume;
                case "Length": return menuBtnLength; case "Weight and mass": return menuBtnWeight;
                case "Temperature": return menuBtnTemperature; case "Energy": return menuBtnEnergy;
                case "Area": return menuBtnArea; case "Speed": return menuBtnSpeed;
                case "Time": return menuBtnTime; case "Power": return menuBtnPower;
                case "Data": return menuBtnData; case "Pressure": return menuBtnPressure;
                case "Angle": return menuBtnAngle;
                default: return null;
            }
        }

        private void NumClick(string d)
        {
            if(isNewEntry) { lblDisplay.Text=""; isNewEntry=false; }
            if(d=="." && lblDisplay.Text.Contains(".")) return;
            if((lblDisplay.Text=="0"||lblDisplay.Text=="") && d!=".") lblDisplay.Text=d;
            else lblDisplay.Text+=d;
            if(lblDisplay.Text=="") lblDisplay.Text="0";
        }

        private void OpClick(string op)
        {
            if(!TryVal(out double val)) return;
            if(!isNewEntry && currentOperator!="") { CalcIntermediate(); val=currentValue; }
            else currentValue=val;
            currentOperator=op; lblFormula.Text=Fmt(currentValue)+" "+op; isNewEntry=true;
        }

        private void CalcIntermediate()
        {
            if(!TryVal(out double v2)) return;
            currentValue=ApplyOp(currentOperator, currentValue, v2);
            lblDisplay.Text=Fmt(currentValue);
        }

        private void CalcResult()
        {
            if(pendingOp=="^")
            {
                if(!TryVal(out double exp)) return;
                double r=Math.Pow(pendingValue,exp);
                lblFormula.Text=Fmt(pendingValue)+" ^ "+Fmt(exp)+" =";
                SetDisplay(r); pendingOp=""; isNewEntry=true; return;
            }
            if(pendingOp=="logY")
            {
                if(!TryVal(out double y)) return;
                double r=Math.Log(y,pendingValue);
                lblFormula.Text="log("+Fmt(pendingValue)+","+Fmt(y)+") =";
                SetDisplay(r); pendingOp=""; isNewEntry=true; return;
            }

            if(!TryVal(out double v2)) return;

            if(currentOperator=="") {
                if (pendingOp != "") {
                    currentValue = ApplyOp(pendingOp, v2, pendingValue);
                    SetDisplay(currentValue);
                    isNewEntry = true;
                }
                return;
            }

            double result=ApplyOp(currentOperator,currentValue,v2);
            lblFormula.Text=Fmt(currentValue)+" "+currentOperator+" "+Fmt(v2)+" =";
            pendingValue=v2; pendingOp=currentOperator;
            currentValue=result; SetDisplay(result);
            currentOperator=""; isNewEntry=true;
        }

        private double ApplyOp(string op, double a, double b)
        {
            switch(op)
            {
                case "+": return a+b;
                case "-": return a-b;
                case "×": return a*b;
                case "÷": if(b==0){MsgErr("Cannot divide by zero!"); return a;} return a/b;
                case "%": if(b==0){MsgErr("Cannot mod by zero!");     return a;} return a%b;
                default: return b;
            }
        }

        private void ClearAll()  { currentValue=0; currentOperator=""; pendingOp=""; pendingValue=0; parenDepth=0; parenStack.Clear(); parenOpStack.Clear(); lblDisplay.Text="0"; lblFormula.Text=""; isNewEntry=true; }
        private void ClearEntry(){ lblDisplay.Text="0"; isNewEntry=true; }
        private void Backspace()  { if(isNewEntry)return; if(lblDisplay.Text.Length>1) lblDisplay.Text=lblDisplay.Text.Remove(lblDisplay.Text.Length-1); else{lblDisplay.Text="0";isNewEntry=true;} }
        private void Percent()    { if(TryVal(out double v)){double r=currentOperator!=""?currentValue*v/100:v/100; SetDisplay(r); isNewEntry=false;} }
        private void Reciprocal() { if(TryVal(out double v)&&v!=0){SciFn(_=>1.0/v,"1/");} }
        private void Square()     { SciFn(v=>v*v,"sqr"); }
        private void SqrtFn()     { SciFn(v=>Math.Sqrt(v),"√"); }
        private void PlusMinus()  { if(TryVal(out double v)) SetDisplay(-v); }

        private void SetDisplay(double v) { lblDisplay.Text=Fmt(v); }
        private string Fmt(double v)
        {
            if(double.IsNaN(v)) return "Result is undefined";
            if(double.IsInfinity(v)) return "Result is infinite";
            if(v==Math.Floor(v)&&Math.Abs(v)<1e15) return ((long)v).ToString();
            return v.ToString("G12").TrimEnd('0').TrimEnd('.');
        }
        private bool TryVal(out double v) => double.TryParse(lblDisplay.Text, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out v) || double.TryParse(lblDisplay.Text, out v);
        private void MsgErr(string msg) => MessageBox.Show(msg,"Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        private void SciFn(Func<double,double> fn, string name)
        {
            if(!TryVal(out double v)) return;
            try { double r=fn(v); SetDisplay(r); isNewEntry=true; }
            catch { MsgErr("Invalid input!"); }
        }

        private void Toggle2nd()
        {
            sci2nd=!sci2nd;
            Color inact=isDarkTheme ? Color.FromArgb(38, 41, 50) : Color.FromArgb(175, 200, 230);
            Color fNor=isDarkTheme ? Color.FromArgb(225, 230, 240) : Color.FromArgb(30, 40, 90);
            btnSci2nd.Tag = sci2nd ? Color.FromArgb(65, 115, 200) : inact;
            btnSci2nd.BackColor = (Color)btnSci2nd.Tag;
            btnSci2nd.ForeColor = sci2nd ? Color.White : fNor;
        }

        private void PendPow()
        {
            if(!TryVal(out double v)) return;
            pendingOp="^"; pendingValue=v;
            lblFormula.Text=Fmt(v)+" ^ "; isNewEntry=true;
        }

        private void OpenParen()
        {
            parenStack.Push(currentValue);
            parenOpStack.Push(currentOperator);
            currentValue = 0;
            currentOperator = "";
            parenDepth++;
            lblFormula.Text += "( ";
            isNewEntry = true;
        }

        private void CloseParen()
        {
            if(parenDepth<=0) return;
            CalcResult();
            parenDepth--;
            if(parenStack.Count>0)
            {
                double prevValue=parenStack.Pop();
                string prevOp=parenOpStack.Pop();
                if(prevOp != "") { 
                    currentValue=ApplyOp(prevOp,prevValue,currentValue); 
                    SetDisplay(currentValue); 
                }
            }
            lblFormula.Text += ") ";
            isNewEntry = true;
        }

        private void Factorial()
        {
            if(!TryVal(out double vd)) return;
            int v=(int)vd;
            if(v<0||v>20){MsgErr("Factorial is for 0‑20 integers."); return;}
            long r=1; for(int i=2;i<=v;i++) r*=i;
            SetDisplay(r); isNewEntry=true;
        }

        private void SetProgBase(ProgBase b)
        {
            currentBase=b;
            Color act=Color.FromArgb(65, 115, 200), inact=isDarkTheme ? Color.FromArgb(38, 41, 50) : Color.FromArgb(175, 200, 230);
            Color fNor=isDarkTheme ? Color.FromArgb(225, 230, 240) : Color.FromArgb(30, 40, 90);
            btnHexMode.Tag=b==ProgBase.HEX?act:inact; btnHexMode.BackColor=(Color)btnHexMode.Tag; btnHexMode.ForeColor=b==ProgBase.HEX?Color.White:fNor;
            btnDecMode.Tag=b==ProgBase.DEC?act:inact; btnDecMode.BackColor=(Color)btnDecMode.Tag; btnDecMode.ForeColor=b==ProgBase.DEC?Color.White:fNor;
            btnOctMode.Tag=b==ProgBase.OCT?act:inact; btnOctMode.BackColor=(Color)btnOctMode.Tag; btnOctMode.ForeColor=b==ProgBase.OCT?Color.White:fNor;
            btnBinMode.Tag=b==ProgBase.BIN?act:inact; btnBinMode.BackColor=(Color)btnBinMode.Tag; btnBinMode.ForeColor=b==ProgBase.BIN?Color.White:fNor;

            bool isHex=(b==ProgBase.HEX);
            bool isDec=(b==ProgBase.HEX||b==ProgBase.DEC);
            bool isOct=(b!=ProgBase.BIN);
            bool isBin2=(b!=ProgBase.BIN);
            btnPA.Enabled=btnPB.Enabled=btnPC.Enabled=btnPD.Enabled=btnPE.Enabled=btnPF.Enabled=isHex;
            btnP8.Enabled=btnP9.Enabled=isDec;
            btnP2.Enabled=btnP3.Enabled=btnP4.Enabled=btnP5.Enabled=btnP6.Enabled=btnP7.Enabled=isOct;
            RefreshProgDisplays(); isNewEntry=true;
        }

        private void SetWordSize(string ws)
        {
            progWordSize=ws;
            Color act=Color.FromArgb(65, 115, 200), inact=isDarkTheme ? Color.FromArgb(38, 41, 50) : Color.FromArgb(175, 200, 230);
            Color fNor=isDarkTheme ? Color.FromArgb(225, 230, 240) : Color.FromArgb(30, 40, 90);
            btnWordQword.Tag=ws=="QWORD"?act:inact; btnWordQword.BackColor=(Color)btnWordQword.Tag; btnWordQword.ForeColor=ws=="QWORD"?Color.White:fNor;
            btnWordDword.Tag=ws=="DWORD"?act:inact; btnWordDword.BackColor=(Color)btnWordDword.Tag; btnWordDword.ForeColor=ws=="DWORD"?Color.White:fNor;
            btnWordWord.Tag=ws=="WORD"?act:inact; btnWordWord.BackColor=(Color)btnWordWord.Tag; btnWordWord.ForeColor=ws=="WORD"?Color.White:fNor;
            btnWordByte.Tag=ws=="BYTE"?act:inact; btnWordByte.BackColor=(Color)btnWordByte.Tag; btnWordByte.ForeColor=ws=="BYTE"?Color.White:fNor;
            MaskProg(); RefreshProgDisplays();
        }

        private void MaskProg()
        {
            switch(progWordSize)
            {
                case "BYTE":  progValue&=0xFF; break;
                case "WORD":  progValue&=0xFFFF; break;
                case "DWORD": progValue&=0xFFFFFFFFL; break;
            }
        }

        private void ProgNum(string d)
        {
            if(isNewEntry){progValue=0; isNewEntry=false;}
            string cur=GetProgStr();
            cur+=d;
            try
            {
                switch(currentBase)
                {
                    case ProgBase.HEX: progValue=Convert.ToInt64(cur,16); break;
                    case ProgBase.DEC: progValue=long.Parse(cur); break;
                    case ProgBase.OCT: progValue=Convert.ToInt64(cur,8);  break;
                    case ProgBase.BIN: progValue=Convert.ToInt64(cur,2);  break;
                }
                MaskProg(); RefreshProgDisplays();
            }catch{}
        }

        private void ProgBackspace()
        {
            string cur=GetProgStr();
            if(cur.Length>1) cur=cur.Remove(cur.Length-1); else{progValue=0; RefreshProgDisplays(); return;}
            try
            {
                switch(currentBase)
                {
                    case ProgBase.HEX: progValue=Convert.ToInt64(cur,16); break;
                    case ProgBase.DEC: progValue=long.Parse(cur); break;
                    case ProgBase.OCT: progValue=Convert.ToInt64(cur,8);  break;
                    case ProgBase.BIN: progValue=Convert.ToInt64(cur,2);  break;
                }
            }catch{progValue=0;}
            RefreshProgDisplays();
        }

        private void ProgOp(string op)
        {
            currentValue=progValue; currentOperator=op;
            lblFormula.Text=GetProgStr()+" "+op; isNewEntry=true;
        }

        private void ProgCalc()
        {
            if(currentOperator=="") return;
            long lv = (long)currentValue;
            long rp = progValue;
            long result = 0;
            switch(currentOperator) {
                case "And": result = lv & rp; break;
                case "Or": result = lv | rp; break;
                case "Xor": result = lv ^ rp; break;
                case "Mod": case "%": result = rp == 0 ? lv : lv % rp; break;
                case "+": result = lv + rp; break;
                case "-": result = lv - rp; break;
                case "×": result = lv * rp; break;
                case "÷": result = rp == 0 ? lv : lv / rp; break;
                default: result = rp; break;
            }
            lblFormula.Text = lv.ToString() + " " + currentOperator + " " + rp.ToString() + " =";
            progValue = result; MaskProg(); currentValue = progValue; currentOperator = ""; isNewEntry = true;
            RefreshProgDisplays();
        }

        private bool TryProgCalc()
        {
            if(currentOperator!=""){ProgCalc(); return true;}
            return false;
        }

        private string GetProgStr()
        {
            switch(currentBase)
            {
                case ProgBase.HEX: return progValue.ToString("X");
                case ProgBase.DEC: return progValue.ToString();
                case ProgBase.OCT: return Convert.ToString(progValue,8);
                case ProgBase.BIN: return Convert.ToString(progValue,2);
                default: return "0";
            }
        }

        private void RefreshProgDisplays()
        {
            string hex=progValue.ToString("X");
            string dec=progValue.ToString();
            string oct=Convert.ToString(progValue,8);
            string bin=Convert.ToString(progValue,2);
            if(bin.Length>4)
            {
                string fmt=""; int rem=bin.Length%4; if(rem>0)fmt=bin.Substring(0,rem)+" "; for(int i=rem;i<bin.Length;i+=4){if(i>rem)fmt+=" "; fmt+=bin.Substring(i,4);} bin=fmt.Trim();
            }

            lblHexDisp.Text="HEX   "+hex;
            lblDecDisp.Text="DEC   "+dec;
            lblOctDisp.Text="OCT   "+oct;
            lblBinDisp.Text="BIN   "+bin;

            lblHexDisp.Font=new Font("Cambria",8.5f,currentBase==ProgBase.HEX?FontStyle.Bold:FontStyle.Regular);
            lblDecDisp.Font=new Font("Cambria",8.5f,currentBase==ProgBase.DEC?FontStyle.Bold:FontStyle.Regular);
            lblOctDisp.Font=new Font("Cambria",8.5f,currentBase==ProgBase.OCT?FontStyle.Bold:FontStyle.Regular);
            lblBinDisp.Font=new Font("Cambria",8.5f,currentBase==ProgBase.BIN?FontStyle.Bold:FontStyle.Regular);
            Color actClr = isDarkTheme ? Color.White : Color.FromArgb(20,20,70);
            Color dimClr = isDarkTheme ? Color.FromArgb(100, 110, 130) : Color.FromArgb(80,100,150);
            lblHexDisp.ForeColor=currentBase==ProgBase.HEX?actClr:dimClr;
            lblDecDisp.ForeColor=currentBase==ProgBase.DEC?actClr:dimClr;
            lblOctDisp.ForeColor=currentBase==ProgBase.OCT?actClr:dimClr;
            lblBinDisp.ForeColor=currentBase==ProgBase.BIN?actClr:dimClr;

            lblDisplay.Text=GetProgStr();
        }

        private long RotL(long v)
        {
            int bits=64; if(progWordSize=="BYTE")bits=8; if(progWordSize=="WORD")bits=16; if(progWordSize=="DWORD")bits=32;
            return (v<<1)|((v>>(bits-1))&1);
        }
        private long RotR(long v)
        {
            int bits=64; if(progWordSize=="BYTE")bits=8; if(progWordSize=="WORD")bits=16; if(progWordSize=="DWORD")bits=32;
            return ((v>>1)&(long.MaxValue>>(bits-2)))|(v&1)<<(bits-1);
        }

        private void DateOpChanged()
        {
            bool isDiff=(cmbDateOperation.SelectedIndex==0);
            panelDateDiff.Visible=isDiff;
            panelDateAdd.Visible=!isDiff;
        }

        private void CalcDateDiff()
        {
            DateTime d1=dtpStart.Value.Date, d2=dtpEnd.Value.Date;
            if(d1>d2){var tmp=d1;d1=d2;d2=tmp;}
            int totalDays=(int)(d2-d1).TotalDays;
            int years=0,months=0,days=0;
            DateTime cur=d1;
            while(cur.AddYears(1)<=d2){cur=cur.AddYears(1);years++;}
            while(cur.AddMonths(1)<=d2){cur=cur.AddMonths(1);months++;}
            days=(int)(d2-cur).TotalDays;
            int weeks=totalDays/7;

            lblResultDiff.Text=totalDays.ToString()+" days";
            var breakLbl=panelDateDiff.Controls.OfType<Label>().FirstOrDefault(l=>l.Name=="lblDateBreak");
            if(breakLbl!=null)
                breakLbl.Text= years+" year(s), "+months+" month(s), "+days+" day(s)\r\n= "+weeks+" week(s), "+totalDays+" days total";
        }

        private void CalcDateAdd()
        {
            DateTime d=dtpAddDate.Value.Date;
            int yr=(int)nudYears.Value, mo=(int)nudMonths.Value, dy=(int)nudDays.Value;
            bool add=(cmbAddSub.SelectedIndex==0);
            DateTime result = add ? d.AddYears(yr).AddMonths(mo).AddDays(dy)
                                  : d.AddYears(-yr).AddMonths(-mo).AddDays(-dy);
            lblDateAddResult.Text=result.ToString("dddd, dd MMMM yyyy");
        }

        private void SwapUnits()
        {
            if(cmbFromUnit.SelectedIndex<0||cmbToUnit.SelectedIndex<0) return;
            int fi=cmbFromUnit.SelectedIndex, ti=cmbToUnit.SelectedIndex;
            string res=lblConverterResult.Text;
            cmbFromUnit.SelectedIndex=ti;
            cmbToUnit.SelectedIndex=fi;
            txtFromValue.Text=res;
        }

        private void UpdateConvUnits()
        {
            if(cmbConverterType.SelectedItem==null) return;
            string type=cmbConverterType.SelectedItem.ToString();
            cmbFromUnit.Items.Clear(); cmbToUnit.Items.Clear();
            string[] units=GetUnits(type);
            cmbFromUnit.Items.AddRange(units); cmbToUnit.Items.AddRange(units);
            if(units.Length>0) cmbFromUnit.SelectedIndex=0;
            if(units.Length>1) cmbToUnit.SelectedIndex=1;
        }

        private string[] GetUnits(string type)
        {
            switch(type)
            {
                case "Currency":
                    return new[]{"US Dollar (USD)","Euro (EUR)","British Pound (GBP)","Japanese Yen (JPY)",
                        "Indonesian Rupiah (IDR)","Singapore Dollar (SGD)","Australian Dollar (AUD)",
                        "Canadian Dollar (CAD)","Swiss Franc (CHF)","Chinese Yuan (CNY)",
                        "South Korean Won (KRW)","Indian Rupee (INR)","Malaysian Ringgit (MYR)"};
                case "Length":
                    return new[]{"Meter","Kilometer","Decimeter","Centimeter","Millimeter","Micrometer","Nanometer","Mile","Yard","Foot","Inch","Nautical mile","Light-year"};
                case "Weight and mass":
                    return new[]{"Kilogram","Gram","Milligram","Microgram","Metric ton","Long ton","Short ton","Pound","Ounce","Carat","Stone"};
                case "Temperature":
                    return new[]{"Celsius","Fahrenheit","Kelvin"};
                case "Volume":
                    return new[]{"Liter","Milliliter","Cubic meter","Cubic centimeter","Cubic inch","Cubic foot","US Gallon","UK Gallon","US Quart","US Pint","US Cup","US Fluid ounce","US Tablespoon","US Teaspoon"};
                case "Energy":
                    return new[]{"Joule","Kilojoule","Calorie","Kilocalorie","Watt-hour","Kilowatt-hour","Electronvolt","British thermal unit","Foot-pound","Erg"};
                case "Area":
                    return new[]{"Square meter","Square kilometer","Square centimeter","Square millimeter","Square mile","Square yard","Square foot","Square inch","Hectare","Acre"};
                case "Speed":
                    return new[]{"Meter/second","Kilometer/hour","Mile/hour","Foot/second","Knot","Mach (at sea level)"};
                case "Time":
                    return new[]{"Nanosecond","Microsecond","Millisecond","Second","Minute","Hour","Day","Week","Month (30d)","Year (365d)","Decade","Century"};
                case "Power":
                    return new[]{"Watt","Kilowatt","Megawatt","Gigawatt","Horsepower (metric)","Horsepower (US)","BTU/hour","Foot-pound/minute"};
                case "Data":
                    return new[]{"Bit","Byte","Kilobyte (KB)","Megabyte (MB)","Gigabyte (GB)","Terabyte (TB)","Petabyte (PB)","Kibibyte (KiB)","Mebibyte (MiB)","Gibibyte (GiB)","Tebibyte (TiB)"};
                case "Pressure":
                    return new[]{"Pascal","Kilopascal","Megapascal","Gigapascal","Bar","Millibar","Atmosphere","Torr (mmHg)","PSI","Inch of mercury"};
                case "Angle":
                    return new[]{"Degree","Radian","Gradian","Minute of arc","Second of arc","Turn"};
                default: return new[]{"Unit 1","Unit 2"};
            }
        }

        private void DoConvert()
        {
            if(txtFromValue.Text.Length > 1 && txtFromValue.Text.StartsWith("0") && !txtFromValue.Text.StartsWith("0."))
            {
                int sel = txtFromValue.SelectionStart;
                txtFromValue.Text = txtFromValue.Text.TrimStart('0');
                if(txtFromValue.Text == "") txtFromValue.Text = "0";
                txtFromValue.SelectionStart = Math.Max(0, sel - 1);
                return;
            }

            if(!double.TryParse(txtFromValue.Text,System.Globalization.NumberStyles.Any,System.Globalization.CultureInfo.InvariantCulture,out double v))
            { double v2; if(!double.TryParse(txtFromValue.Text,out v2)){lblConverterResult.Text="Invalid"; return;} v=v2; }
            if(cmbConverterType.SelectedItem==null||cmbFromUnit.SelectedItem==null||cmbToUnit.SelectedItem==null) return;
            string type=cmbConverterType.SelectedItem.ToString();
            string from=cmbFromUnit.SelectedItem.ToString();
            string to  =cmbToUnit.SelectedItem.ToString();
            if(from==to){lblConverterResult.Text=FmtConv(v); return;}
            try { lblConverterResult.Text=FmtConv(DoConvertUnit(v,type,from,to)); }
            catch { lblConverterResult.Text="Error"; }
        }

        private string FmtConv(double v)
        {
            if(Math.Abs(v)>=1e13||(Math.Abs(v)<1e-6&&v!=0)) return v.ToString("G6");
            return v.ToString("G10").TrimEnd('0').TrimEnd('.');
        }

        private double DoConvertUnit(double v, string type, string from, string to)
        {
            switch(type)
            {
                case "Currency":        return ToUSD(v,from)/ToUSD(1,to);
                case "Length":          return FromM(ToM(v,from),to);
                case "Weight and mass": return FromKg(ToKg(v,from),to);
                case "Temperature":     return ConvTemp(v,from,to);
                case "Volume":          return FromL(ToL(v,from),to);
                case "Energy":          return FromJ(ToJ(v,from),to);
                case "Area":            return FromSqm(ToSqm(v,from),to);
                case "Speed":           return FromMps(ToMps(v,from),to);
                case "Time":            return FromSec(ToSec(v,from),to);
                case "Power":           return FromW(ToW(v,from),to);
                case "Data":            return FromBit(ToBit(v,from),to);
                case "Pressure":        return FromPa(ToPa(v,from),to);
                case "Angle":           return FromDeg(ToDeg(v,from),to);
                default: return v;
            }
        }

        private double ToM(double v,string u){switch(u){case"Meter":return v;case"Kilometer":return v*1000;case"Decimeter":return v/10;case"Centimeter":return v/100;case"Millimeter":return v/1000;case"Micrometer":return v/1e6;case"Nanometer":return v/1e9;case"Mile":return v*1609.344;case"Yard":return v*0.9144;case"Foot":return v*0.3048;case"Inch":return v*0.0254;case"Nautical mile":return v*1852;case"Light-year":return v*9.461e15;default:return v;}}
        private double FromM(double v,string u){switch(u){case"Meter":return v;case"Kilometer":return v/1000;case"Decimeter":return v*10;case"Centimeter":return v*100;case"Millimeter":return v*1000;case"Micrometer":return v*1e6;case"Nanometer":return v*1e9;case"Mile":return v/1609.344;case"Yard":return v/0.9144;case"Foot":return v/0.3048;case"Inch":return v/0.0254;case"Nautical mile":return v/1852;case"Light-year":return v/9.461e15;default:return v;}}

        private double ToKg(double v,string u){switch(u){case"Kilogram":return v;case"Gram":return v/1000;case"Milligram":return v/1e6;case"Microgram":return v/1e9;case"Metric ton":return v*1000;case"Long ton":return v*1016.047;case"Short ton":return v*907.185;case"Pound":return v*0.453592;case"Ounce":return v*0.0283495;case"Carat":return v*0.0002;case"Stone":return v*6.35029;default:return v;}}
        private double FromKg(double v,string u){switch(u){case"Kilogram":return v;case"Gram":return v*1000;case"Milligram":return v*1e6;case"Microgram":return v*1e9;case"Metric ton":return v/1000;case"Long ton":return v/1016.047;case"Short ton":return v/907.185;case"Pound":return v/0.453592;case"Ounce":return v/0.0283495;case"Carat":return v/0.0002;case"Stone":return v/6.35029;default:return v;}}

        private double ConvTemp(double v,string from,string to)
        {
            double c; switch(from){case"Celsius":c=v;break;case"Fahrenheit":c=(v-32)*5/9;break;case"Kelvin":c=v-273.15;break;default:c=v;break;}
            switch(to){case"Celsius":return c;case"Fahrenheit":return c*9/5+32;case"Kelvin":return c+273.15;default:return c;}
        }

        private double ToL(double v,string u){switch(u){case"Liter":return v;case"Milliliter":return v/1000;case"Cubic meter":return v*1000;case"Cubic centimeter":return v/1000;case"Cubic inch":return v*0.0163871;case"Cubic foot":return v*28.3168;case"US Gallon":return v*3.78541;case"UK Gallon":return v*4.54609;case"US Quart":return v*0.946353;case"US Pint":return v*0.473176;case"US Cup":return v*0.236588;case"US Fluid ounce":return v*0.0295735;case"US Tablespoon":return v*0.0147868;case"US Teaspoon":return v*0.00492892;default:return v;}}
        private double FromL(double v,string u){switch(u){case"Liter":return v;case"Milliliter":return v*1000;case"Cubic meter":return v/1000;case"Cubic centimeter":return v*1000;case"Cubic inch":return v/0.0163871;case"Cubic foot":return v/28.3168;case"US Gallon":return v/3.78541;case"UK Gallon":return v/4.54609;case"US Quart":return v/0.946353;case"US Pint":return v/0.473176;case"US Cup":return v/0.236588;case"US Fluid ounce":return v/0.0295735;case"US Tablespoon":return v/0.0147868;case"US Teaspoon":return v/0.00492892;default:return v;}}

        private double ToJ(double v,string u){switch(u){case"Joule":return v;case"Kilojoule":return v*1000;case"Calorie":return v*4.184;case"Kilocalorie":return v*4184;case"Watt-hour":return v*3600;case"Kilowatt-hour":return v*3.6e6;case"Electronvolt":return v*1.602e-19;case"British thermal unit":return v*1055.06;case"Foot-pound":return v*1.35582;case"Erg":return v*1e-7;default:return v;}}
        private double FromJ(double v,string u){switch(u){case"Joule":return v;case"Kilojoule":return v/1000;case"Calorie":return v/4.184;case"Kilocalorie":return v/4184;case"Watt-hour":return v/3600;case"Kilowatt-hour":return v/3.6e6;case"Electronvolt":return v/1.602e-19;case"British thermal unit":return v/1055.06;case"Foot-pound":return v/1.35582;case"Erg":return v/1e-7;default:return v;}}

        private double ToSqm(double v,string u){switch(u){case"Square meter":return v;case"Square kilometer":return v*1e6;case"Square centimeter":return v/1e4;case"Square millimeter":return v/1e6;case"Square mile":return v*2.59e6;case"Square yard":return v*0.836127;case"Square foot":return v*0.092903;case"Square inch":return v*0.00064516;case"Hectare":return v*1e4;case"Acre":return v*4046.86;default:return v;}}
        private double FromSqm(double v,string u){switch(u){case"Square meter":return v;case"Square kilometer":return v/1e6;case"Square centimeter":return v*1e4;case"Square millimeter":return v*1e6;case"Square mile":return v/2.59e6;case"Square yard":return v/0.836127;case"Square foot":return v/0.092903;case"Square inch":return v/0.00064516;case"Hectare":return v/1e4;case"Acre":return v/4046.86;default:return v;}}

        private double ToMps(double v,string u){switch(u){case"Meter/second":return v;case"Kilometer/hour":return v/3.6;case"Mile/hour":return v*0.44704;case"Foot/second":return v*0.3048;case"Knot":return v*0.514444;case"Mach (at sea level)":return v*340.29;default:return v;}}
        private double FromMps(double v,string u){switch(u){case"Meter/second":return v;case"Kilometer/hour":return v*3.6;case"Mile/hour":return v/0.44704;case"Foot/second":return v/0.3048;case"Knot":return v/0.514444;case"Mach (at sea level)":return v/340.29;default:return v;}}

        private double ToSec(double v,string u){switch(u){case"Nanosecond":return v/1e9;case"Microsecond":return v/1e6;case"Millisecond":return v/1000;case"Second":return v;case"Minute":return v*60;case"Hour":return v*3600;case"Day":return v*86400;case"Week":return v*604800;case"Month (30d)":return v*2592000;case"Year (365d)":return v*31536000;case"Decade":return v*315360000;case"Century":return v*3153600000;default:return v;}}
        private double FromSec(double v,string u){switch(u){case"Nanosecond":return v*1e9;case"Microsecond":return v*1e6;case"Millisecond":return v*1000;case"Second":return v;case"Minute":return v/60;case"Hour":return v/3600;case"Day":return v/86400;case"Week":return v/604800;case"Month (30d)":return v/2592000;case"Year (365d)":return v/31536000;case"Decade":return v/315360000;case"Century":return v/3153600000;default:return v;}}

        private double ToW(double v,string u){switch(u){case"Watt":return v;case"Kilowatt":return v*1000;case"Megawatt":return v*1e6;case"Gigawatt":return v*1e9;case"Horsepower (metric)":return v*735.499;case"Horsepower (US)":return v*745.7;case"BTU/hour":return v*0.293071;case"Foot-pound/minute":return v*0.0225970;default:return v;}}
        private double FromW(double v,string u){switch(u){case"Watt":return v;case"Kilowatt":return v/1000;case"Megawatt":return v/1e6;case"Gigawatt":return v/1e9;case"Horsepower (metric)":return v/735.499;case"Horsepower (US)":return v/745.7;case"BTU/hour":return v/0.293071;case"Foot-pound/minute":return v/0.0225970;default:return v;}}

        private double ToBit(double v,string u){switch(u){case"Bit":return v;case"Byte":return v*8;case"Kilobyte (KB)":return v*8000;case"Megabyte (MB)":return v*8e6;case"Gigabyte (GB)":return v*8e9;case"Terabyte (TB)":return v*8e12;case"Petabyte (PB)":return v*8e15;case"Kibibyte (KiB)":return v*8192;case"Mebibyte (MiB)":return v*8388608;case"Gibibyte (GiB)":return v*8589934592;case"Tebibyte (TiB)":return v*8796093022208;default:return v;}}
        private double FromBit(double v,string u){switch(u){case"Bit":return v;case"Byte":return v/8;case"Kilobyte (KB)":return v/8000;case"Megabyte (MB)":return v/8e6;case"Gigabyte (GB)":return v/8e9;case"Terabyte (TB)":return v/8e12;case"Petabyte (PB)":return v/8e15;case"Kibibyte (KiB)":return v/8192;case"Mebibyte (MiB)":return v/8388608;case"Gibibyte (GiB)":return v/8589934592;case"Tebibyte (TiB)":return v/8796093022208;default:return v;}}

        private double ToPa(double v,string u){switch(u){case"Pascal":return v;case"Kilopascal":return v*1000;case"Megapascal":return v*1e6;case"Gigapascal":return v*1e9;case"Bar":return v*1e5;case"Millibar":return v*100;case"Atmosphere":return v*101325;case"Torr (mmHg)":return v*133.322;case"PSI":return v*6894.76;case"Inch of mercury":return v*3386.39;default:return v;}}
        private double FromPa(double v,string u){switch(u){case"Pascal":return v;case"Kilopascal":return v/1000;case"Megapascal":return v/1e6;case"Gigapascal":return v/1e9;case"Bar":return v/1e5;case"Millibar":return v/100;case"Atmosphere":return v/101325;case"Torr (mmHg)":return v/133.322;case"PSI":return v/6894.76;case"Inch of mercury":return v/3386.39;default:return v;}}

        private double ToDeg(double v,string u){switch(u){case"Degree":return v;case"Radian":return v*(180/Math.PI);case"Gradian":return v*0.9;case"Minute of arc":return v/60;case"Second of arc":return v/3600;case"Turn":return v*360;default:return v;}}
        private double FromDeg(double v,string u){switch(u){case"Degree":return v;case"Radian":return v*(Math.PI/180);case"Gradian":return v/0.9;case"Minute of arc":return v*60;case"Second of arc":return v*3600;case"Turn":return v/360;default:return v;}}

        private double ToUSD(double v,string u){switch(u){case"US Dollar (USD)":return v;case"Euro (EUR)":return v*1.085;case"British Pound (GBP)":return v*1.27;case"Japanese Yen (JPY)":return v*0.0067;case"Indonesian Rupiah (IDR)":return v*0.000063;case"Singapore Dollar (SGD)":return v*0.745;case"Australian Dollar (AUD)":return v*0.652;case"Canadian Dollar (CAD)":return v*0.735;case"Swiss Franc (CHF)":return v*1.115;case"Chinese Yuan (CNY)":return v*0.138;case"South Korean Won (KRW)":return v*0.00074;case"Indian Rupee (INR)":return v*0.012;case"Malaysian Ringgit (MYR)":return v*0.213;default:return v;}}
        
        private Panel panelSettings;
        private RadioButton rbThemeLight, rbThemeDark;
        private bool isDarkTheme = false;

        private void BuildSettings()
        {
            panelSettings = new Panel { Location = new Point(0, 50), Size = new Size(340, 570), Visible = false, BackColor = Color.FromArgb(218, 232, 248) };
            mainPanel.Controls.Add(panelSettings);

            Label lblApp = new Label { Text = "Appearance Settings", Font = new Font("Cambria", 16f, FontStyle.Bold), ForeColor = Color.FromArgb(40, 50, 100), Location = new Point(20, 20), Size = new Size(300, 30), BackColor = Color.Transparent };
            panelSettings.Controls.Add(lblApp);

            rbThemeLight = new RadioButton { Text = "☀️ Light Theme (Default)", Font = new Font("Cambria", 12f), ForeColor = Color.FromArgb(30, 40, 80), Location = new Point(30, 70), Size = new Size(250, 30), Checked = true };
            rbThemeDark  = new RadioButton { Text = "🌙 Dark Theme (Navy Slate Gray)", Font = new Font("Cambria", 12f), ForeColor = Color.FromArgb(30, 40, 80), Location = new Point(30, 110), Size = new Size(280, 30) };

            rbThemeLight.CheckedChanged += (s, e) => { if (rbThemeLight.Checked) ApplyTheme(false); };
            rbThemeDark.CheckedChanged  += (s, e) => { if (rbThemeDark.Checked) ApplyTheme(true); };

            panelSettings.Controls.Add(rbThemeLight);
            panelSettings.Controls.Add(rbThemeDark);
        }

        private void SetBtn(Button btn, Color bg, Color fg) {
            if(btn!=null) { btn.Tag = bg; btn.BackColor = bg; btn.ForeColor = fg; }
        }

        private void ApplyTheme(bool isDark) {
            isDarkTheme = isDark;
            Color bMain  = isDark ? Color.FromArgb(31, 34, 41) : Color.FromArgb(218, 232, 248);
            Color bHead  = isDark ? Color.FromArgb(22, 24, 29) : Color.FromArgb(200, 218, 240);
            Color bMenu  = isDark ? Color.FromArgb(17, 18, 22) : Color.FromArgb(242, 247, 255);
            Color fMain  = isDark ? Color.FromArgb(225, 230, 240) : Color.FromArgb(30, 40, 90);
            Color fDim   = isDark ? Color.FromArgb(125, 135, 155) : Color.FromArgb(80, 100, 150);

            Color bNum   = isDark ? Color.FromArgb(48, 52, 62) : Color.FromArgb(230, 240, 255);
            Color fNum   = isDark ? Color.FromArgb(250, 250, 255) : Color.FromArgb(25, 30, 80);
            Color bOp    = isDark ? Color.FromArgb(58, 75, 108) : Color.FromArgb(148, 118, 205);
            Color bEq    = isDark ? Color.FromArgb(65, 115, 200) : Color.FromArgb(205, 100, 155);
            Color bFn    = isDark ? Color.FromArgb(65, 70, 85) : Color.FromArgb(205, 100, 155);
            Color bC     = isDark ? Color.FromArgb(180, 75, 85) : Color.FromArgb(180, 70, 115);
            Color fWhite = Color.White;

            Color bMem   = isDark ? Color.FromArgb(38, 41, 50) : Color.FromArgb(175, 200, 230);
            Color bSci   = isDark ? Color.FromArgb(42, 46, 56) : Color.FromArgb(188, 212, 238);

            Color bTxtBg = isDark ? Color.FromArgb(25, 28, 35) : Color.FromArgb(210, 225, 245);
            Color bTxtBgAlt = isDark ? Color.FromArgb(38, 44, 58) : Color.FromArgb(200, 218, 242);

            this.BackColor = bMain;
            mainPanel.BackColor = bMain;
            panelStandard.BackColor = bMain;
            panelScientific.BackColor = bMain;
            panelProgrammer.BackColor = bMain;
            panelDateCalc.BackColor = bMain;
            panelConverterMode.BackColor = bMain;
            if (panelSettings != null) panelSettings.BackColor = bMain;

            panelHeaderBar.BackColor = bHead;
            btnHamburger.BackColor = bHead;
            btnHamburger.ForeColor = fMain;
            lblModeTitle.ForeColor = fMain;
            lblDisplay.ForeColor = fMain;
            lblFormula.ForeColor = fDim;

            foreach(var b in new[]{btn0,btn1,btn2,btn3,btn4,btn5,btn6,btn7,btn8,btn9,btnDot,btnPlusMinus}) SetBtn(b, bNum, fNum);
            foreach(var b in new[]{btnPlus,btnMinus,btnMultiply,btnDivide}) SetBtn(b, bOp, fWhite);
            foreach(var b in new[]{btnCE,btnBackspace,btnPercent}) SetBtn(b, bFn, fWhite);
            SetBtn(btnEquals, bEq, fWhite);
            SetBtn(btnC, bC, fWhite);
            
            foreach(var b in new[]{btnMC,btnMR,btnMS,btnMPlus,btnMMinus,btnMView}) SetBtn(b, bMem, fMain);
            foreach(var b in new[]{btnReciprocal,btnSquare,btnSqrt}) SetBtn(b, bSci, fMain);

            foreach(var b in new[]{btn0s,btn1s,btn2s,btn3s,btn4s,btn5s,btn6s,btn7s,btn8s,btn9s,btnSciDot2,btnSciPlusMinus2}) SetBtn(b, bNum, fNum);
            foreach(var b in new[]{btnSciPlus2,btnSciMinus2,btnSciMul2,btnSciDiv2,btnSciMod}) SetBtn(b, bOp, fWhite);
            foreach(var b in new[]{btnSciCE2,btnSciBack2}) SetBtn(b, bFn, fWhite);
            SetBtn(btnSciEqual2, bEq, fWhite);
            SetBtn(btnSciC2, bC, fWhite);
            foreach(var b in new[]{btnSci2nd,btnSciPi,btnSciE}) SetBtn(b, bMem, fMain);
            foreach(var b in new[]{btnSciSq,btnSciCube,btnSciRecip,btnSciAbs,btnSciExp2,btnSciSqrt2,btnSciCbrt,btnSciOpenP,btnSciCloseP,btnSciFact,btnSciXY,btnSciTenX,btnSci2X,btnSciLogY,btnSciLog,btnSciLn}) SetBtn(b, bSci, fMain);

            foreach(var b in new[]{btnP0,btnP1,btnP2,btnP3,btnP4,btnP5,btnP6,btnP7,btnP8,btnP9}) SetBtn(b, bNum, fNum);
            foreach(var b in new[]{btnProgDot,btnPA,btnPB,btnPC,btnPD,btnPE,btnPF}) SetBtn(b, bSci, fMain);
            foreach(var b in new[]{btnProgPlus,btnProgMinus,btnProgMul,btnProgDiv}) SetBtn(b, bOp, fWhite);
            foreach(var b in new[]{btnProgCE,btnProgBack}) SetBtn(b, bFn, fWhite);
            SetBtn(btnProgEq, bEq, fWhite);
            SetBtn(btnProgC, bC, fWhite);
            foreach(var b in new[]{btnRol,btnRor,btnLsh,btnRsh,btnAnd,btnOr,btnXor,btnNot,btnProgMod}) SetBtn(b, bMem, fMain);

            SetProgBase(currentBase);
            SetWordSize(progWordSize);
            bool bSci2 = sci2nd; sci2nd = !sci2nd; Toggle2nd();

            if(txtFromValue!=null) { txtFromValue.BackColor=bTxtBg; txtFromValue.ForeColor=fMain; }
            if(lblConverterResult!=null) { lblConverterResult.BackColor=bTxtBgAlt; lblConverterResult.ForeColor=bOp; }
            if(cmbFromUnit!=null) { cmbFromUnit.BackColor=bTxtBg; cmbFromUnit.ForeColor=fMain; }
            if(cmbToUnit!=null) { cmbToUnit.BackColor=bTxtBg; cmbToUnit.ForeColor=fMain; }
            if(cmbConverterType!=null) { cmbConverterType.BackColor=bTxtBg; cmbConverterType.ForeColor=fMain; }
            if(lblConverterHeader!=null) { lblConverterHeader.ForeColor=bOp; }
            foreach(Control c in panelConverterMode.Controls) {
                if (c is Button btn && btn.Text == "⇅") SetBtn(btn, bEq, fWhite);
                if (c is Panel p && p.Height <= 5) p.BackColor = isDarkTheme ? bOp : Color.FromArgb(205, 100, 155); 
            }

            if(cmbDateOperation!=null) { cmbDateOperation.BackColor=bTxtBg; cmbDateOperation.ForeColor=fMain; }
            if(cmbAddSub!=null) { cmbAddSub.BackColor=bTxtBg; cmbAddSub.ForeColor=fMain; }
            if(nudYears!=null) { nudYears.BackColor=bTxtBg; nudYears.ForeColor=fMain; }
            if(nudMonths!=null) { nudMonths.BackColor=bTxtBg; nudMonths.ForeColor=fMain; }
            if(nudDays!=null) { nudDays.BackColor=bTxtBg; nudDays.ForeColor=fMain; }
            if(lblResultDiff!=null) lblResultDiff.ForeColor=bOp;
            if(lblDateAddResult!=null) lblDateAddResult.ForeColor=bOp;
            if(panelDateDiff!=null) {
                panelDateDiff.BackColor=bMain;
                foreach(Control c in panelDateDiff.Controls) {
                    if(c is Label l && l!=lblResultDiff) l.ForeColor=fDim;
                    if(c is Button btn) SetBtn(btn, bOp, fWhite);
                }
            }
            if(panelDateAdd!=null) {
                panelDateAdd.BackColor=bMain;
                foreach(Control c in panelDateAdd.Controls) {
                    if(c is Label l && l!=lblDateAddResult) l.ForeColor=fDim;
                    if(c is Button btn) SetBtn(btn, bOp, fWhite);
                }
            }

            panelSlideMenu.BackColor = bMenu;
            panelMenuScrollArea.BackColor = bMenu;
            
            Action<Control.ControlCollection> themeMenus = null;
            themeMenus = (cc) => {
                foreach(Control c in cc) {
                    if(c is Button btn && btn.FlatAppearance.BorderSize == 0) {
                        btn.Tag = bMenu;
                        btn.BackColor = bMenu;
                        btn.ForeColor = fMain;
                    }
                    if(c is Label l) l.ForeColor = fDim;
                    if(c is Panel p && p.Height <= 5) p.BackColor = bOp;
                    if(c.HasChildren) themeMenus(c.Controls);
                }
            };
            themeMenus(panelSlideMenu.Controls);
            
            foreach(Control c in panelHeaderBar.Controls) {
                if(c is Panel p && p.Height <= 5) p.BackColor = bFn;
            }
            if(lblFooter!=null) { lblFooter.BackColor = bHead; lblFooter.ForeColor = fDim; }

            SetMenuActive(_activeMenuBtn);

            if(panelSettings!=null) {
                foreach(Control c in panelSettings.Controls) {
                    if(c is Label l) l.ForeColor = fMain;
                    if(c is RadioButton rb) rb.ForeColor = fMain;
                }
            }
        }
    }
}