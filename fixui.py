import re

with open("kalkulator_windows/Form1.Designer.cs", "r", encoding="utf-8") as f:
    text = f.read()

# Sizes:
# Memory: 52, 32
text = re.sub(r'this\.btnM(C|R|Plus|Minus|S|View)\.Size = new System\.Drawing\.Size\(\d+, \d+\);', 
              r'this.btnM\1.Size = new System.Drawing.Size(52, 32);', text)

# Text of MPlus, MMinus, MView:
text = re.sub(r'this\.btnMPlus\.Text = ".+?";', r'this.btnMPlus.Text = "M+";', text)
text = re.sub(r'this\.btnMMinus\.Text = ".+?";', r'this.btnMMinus.Text = "M-";', text)
text = re.sub(r'this\.btnMView\.Text = ".+?";', r'this.btnMView.Text = "M?";', text)

# Locations Memory
for i, name in enumerate(['btnMC','btnMR','btnMPlus','btnMMinus','btnMS','btnMView']):
    x = 7 + i * 55
    text = re.sub(rf'this\.{name}\.Location = new System\.Drawing\.Point\(\d+, \d+\);',
                  f'this.{name}.Location = new System.Drawing.Point({x}, 4);', text)

# Main buttons Size:
main_btns = [
    'btnPercent', 'btnCE', 'btnC', 'btnBackspace',
    'btnReciprocal', 'btnSquare', 'btnSqrt', 'btnDivide',
    'btn7', 'btn8', 'btn9', 'btnMultiply',
    'btn4', 'btn5', 'btn6', 'btnMinus',
    'btn1', 'btn2', 'btn3', 'btnPlus',
    'btnPlusMinus', 'btn0', 'btnDot', 'btnEquals'
]
for btn in main_btns:
    text = re.sub(rf'this\.{btn}\.Size = new System\.Drawing\.Size\(\d+, \d+\);',
                  f'this.{btn}.Size = new System.Drawing.Size(80, 62);', text)

# Main buttons Locations:
for row in range(6):
    for col in range(4):
        idx = row * 4 + col
        btn = main_btns[idx]
        x = 6 + col * 83
        y = 40 + row * 65
        text = re.sub(rf'this\.{btn}\.Location = new System\.Drawing\.Point\(\d+, \d+\);',
                      f'this.{btn}.Location = new System.Drawing.Point({x}, {y});', text)

with open("kalkulator_windows/Form1.Designer.cs", "w", encoding="utf-8") as f:
    f.write(text)

print("Updated sizes and locations")
