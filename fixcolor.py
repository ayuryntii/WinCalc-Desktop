import re

with open("kalkulator_windows/Form1.Designer.cs", "r", encoding="utf-8") as f:
    text = f.read()

# Change display panel backcolor
text = re.sub(r'this\.displayPanel\.BackColor = System\.Drawing\.Color\.FromArgb\(\(\(int\)\(\(\(byte\)\(55\)\)\)\), \(\(\(int\)\(\(\(byte\)\(68\)\)\)\), \(\(\(int\)\(\(\(byte\)\(105\)\)\)\)\);',
              r'this.displayPanel.BackColor = System.Drawing.Color.Transparent;', text)

# Change lblFormula forecolor
text = re.sub(r'this\.lblFormula\.ForeColor = System\.Drawing\.Color\.FromArgb\(\(\(int\)\(\(\(byte\)\(185\)\)\)\), \(\(\(int\)\(\(\(byte\)\(205\)\)\)\), \(\(\(int\)\(\(\(byte\)\(240\)\)\)\)\);',
              r'this.lblFormula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(160)))));', text)

# Change lblDisplay forecolor
text = re.sub(r'this\.lblDisplay\.ForeColor = System\.Drawing\.Color\.White;',
              r'this.lblDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(90)))));', text)


with open("kalkulator_windows/Form1.Designer.cs", "w", encoding="utf-8") as f:
    f.write(text)

print("Updated display panel colors")
