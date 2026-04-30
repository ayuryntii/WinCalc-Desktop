import re

def mk_btn(name, txt, x, y, w, h, font_sz, bg_rgb, fg_rgb):
    return f"""            // 
            // {name}
            // 
            this.{name} = new System.Windows.Forms.Button();
            this.{name}.BackColor = System.Drawing.Color.FromArgb({bg_rgb});
            this.{name}.Cursor = System.Windows.Forms.Cursors.Hand;
            this.{name}.FlatAppearance.BorderSize = 0;
            this.{name}.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.{name}.Font = new System.Drawing.Font("Cambria", {font_sz}F, System.Drawing.FontStyle.Bold);
            this.{name}.ForeColor = System.Drawing.Color.FromArgb({fg_rgb});
            this.{name}.Location = new System.Drawing.Point({x}, {y});
            this.{name}.Name = "{name}";
            this.{name}.Size = new System.Drawing.Size({w}, {h});
            this.{name}.Text = "{txt}";
            this.{name}.UseVisualStyleBackColor = false;
"""

with open("kalkulator_windows/Form1.Designer.cs", "r", encoding="utf-8") as f:
    text = f.read()

# We need to insert the instantiations:
b_instances = ""
for btn in "btnMC btnMR btnMPlus btnMMinus btnMS btnMView btnPercent btnCE btnC btnBackspace btnReciprocal btnSquare btnSqrt btnDivide btnMultiply btnMinus btnPlus btnEquals btn0 btn1 btn2 btn3 btn4 btn5 btn6 btn7 btn8 btn9 btnDot btnPlusMinus".split():
    b_instances += f"            this.{btn} = new System.Windows.Forms.Button();\n"

# And the controls.Add
b_add = ""
for btn in "btnMC btnMR btnMPlus btnMMinus btnMS btnMView btnPercent btnCE btnC btnBackspace btnReciprocal btnSquare btnSqrt btnDivide btnMultiply btnMinus btnPlus btnEquals btn0 btn1 btn2 btn3 btn4 btn5 btn6 btn7 btn8 btn9 btnDot btnPlusMinus".split():
    b_add += f"            this.panelStandard.Controls.Add(this.{btn});\n"

# Generate properties
props = ""
gap = 3; sx = 8; bw = 78; bh = 52
mw = 50; mh = 34; mg = 3; msx = 12

memBg = "175, 200, 230"; wh = "255, 255, 255"
clrPink = "205, 100, 155"; clrRose="180, 70, 115"
clrSciBtn = "188, 212, 238"; clrPurple="148, 118, 205"
clrNumBtn = "230, 240, 255"; clrNavi="25, 30, 80"

for i,n in enumerate(['btnMC','btnMR','btnMPlus','btnMMinus','btnMS','btnMView']):
    props += mk_btn(n, n.replace('btn',''), msx+i*(mw+mg), 4, mw, mh, 8.5, memBg, wh)
props = props.replace('"MView"','"M?"')

r1 = mh+gap+4
props += mk_btn('btnPercent', '%', sx+0*(bw+gap), r1, bw, bh, 12, clrPink, wh)
props += mk_btn('btnCE', 'CE', sx+1*(bw+gap), r1, bw, bh, 11, clrPink, wh)
props += mk_btn('btnC', 'C', sx+2*(bw+gap), r1, bw, bh, 13, clrRose, wh)
props += mk_btn('btnBackspace', '?', sx+3*(bw+gap), r1, bw, bh, 13, clrPink, wh)

r2 = r1+bh+gap
props += mk_btn('btnReciprocal', '1/x', sx+0*(bw+gap), r2, bw, bh, 10, clrSciBtn, clrNavi)
props += mk_btn('btnSquare', 'x?', sx+1*(bw+gap), r2, bw, bh, 11, clrSciBtn, clrNavi)
props += mk_btn('btnSqrt', '??x', sx+2*(bw+gap), r2, bw, bh, 10, clrSciBtn, clrNavi)
props += mk_btn('btnDivide', '?', sx+3*(bw+gap), r2, bw, bh, 16, clrPurple, wh)

r3 = r2+bh+gap
props += mk_btn('btn7', '7', sx+0*(bw+gap), r3, bw, bh, 14, clrNumBtn, clrNavi)
props += mk_btn('btn8', '8', sx+1*(bw+gap), r3, bw, bh, 14, clrNumBtn, clrNavi)
props += mk_btn('btn9', '9', sx+2*(bw+gap), r3, bw, bh, 14, clrNumBtn, clrNavi)
props += mk_btn('btnMultiply', '?', sx+3*(bw+gap), r3, bw, bh, 16, clrPurple, wh)

r4 = r3+bh+gap
props += mk_btn('btn4', '4', sx+0*(bw+gap), r4, bw, bh, 14, clrNumBtn, clrNavi)
props += mk_btn('btn5', '5', sx+1*(bw+gap), r4, bw, bh, 14, clrNumBtn, clrNavi)
props += mk_btn('btn6', '6', sx+2*(bw+gap), r4, bw, bh, 14, clrNumBtn, clrNavi)
props += mk_btn('btnMinus', '-', sx+3*(bw+gap), r4, bw, bh, 16, clrPurple, wh)

r5 = r4+bh+gap
props += mk_btn('btn1', '1', sx+0*(bw+gap), r5, bw, bh, 14, clrNumBtn, clrNavi)
props += mk_btn('btn2', '2', sx+1*(bw+gap), r5, bw, bh, 14, clrNumBtn, clrNavi)
props += mk_btn('btn3', '3', sx+2*(bw+gap), r5, bw, bh, 14, clrNumBtn, clrNavi)
props += mk_btn('btnPlus', '+', sx+3*(bw+gap), r5, bw, bh, 16, clrPurple, wh)

r6 = r5+bh+gap
props += mk_btn('btnPlusMinus', '+/-', sx+0*(bw+gap), r6, bw, bh, 10.5, clrNumBtn, clrNavi)
props += mk_btn('btn0', '0', sx+1*(bw+gap), r6, bw, bh, 14, clrNumBtn, clrNavi)
props += mk_btn('btnDot', '.', sx+2*(bw+gap), r6, bw, bh, 18, clrNumBtn, clrNavi)
props += mk_btn('btnEquals', '=', sx+3*(bw+gap), r6, bw, bh, 16, clrPink, wh)

# Insert the instances right after this.panelStandard = new System.Windows.Forms.Panel();
text = re.sub(r'(this\.panelStandard = new System\.Windows\.Forms\.Panel\(\);\n)', r'\1' + b_instances, text)

# Insert the controls.Add right before this.panelStandard.ResumeLayout
# Actually we can put them inside panelStandard initialization
text = re.sub(r'(this\.panelStandard\.TabIndex = 2;\n)', r'\1' + b_add, text)

# Insert the properties right before // panelScientific
text = re.sub(r'(            // \n            // panelScientific\n)', props + r'\n\1', text)

with open("kalkulator_windows/Form1.Designer.cs", "w", encoding="utf-8") as f:
    f.write(text)

print("Injected native buttons into InitializeComponent")
