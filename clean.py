import re

with open("kalkulator_windows/Form1.Designer.cs", "r", encoding="utf-8") as f:
    text = f.read()

# Fix the button texts that were mangled by ascii encoding
text = re.sub(r'this\.btnDivide\.Text = "\?";', r'this.btnDivide.Text = "?";', text)
text = re.sub(r'this\.btnMultiply\.Text = "\?";', r'this.btnMultiply.Text = "?";', text)
text = re.sub(r'this\.btnMinus\.Text = "-";', r'this.btnMinus.Text = "?";', text)
text = re.sub(r'this\.btnBackspace\.Text = "\?";', r'this.btnBackspace.Text = "?";', text)
text = re.sub(r'this\.btnSqrt\.Text = "\?\?x";', r'this.btnSqrt.Text = "??x";', text)
text = re.sub(r'this\.btnSquare\.Text = "x\?";', r'this.btnSquare.Text = "x?";', text)

# Fix the formula label color to be bolder/darker native soft blue
text = re.sub(r'this\.lblFormula\.ForeColor = System\.Drawing\.Color\.FromArgb\(\(\(int\)\(\(\(byte\)\(100\)\)\)\), \(\(\(int\)\(\(\(byte\)\(120\)\)\)\), \(\(\(int\)\(\(\(byte\)\(160\)\)\)\)\);',
              r'this.lblFormula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));', text)

with open("kalkulator_windows/Form1.Designer.cs", "w", encoding="utf-8") as f:
    f.write(text)

print("Fixed text and colors")
