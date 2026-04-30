import re

with open("kalkulator_windows/Form1.Designer.cs", "r", encoding="utf-8") as f:
    lines = f.readlines()

new_lines = []
for line in lines:
    # Filter out the duplicate raw instances that look exactly like:
    # "            this.btnXXX = new System.Windows.Forms.Button();"
    # EXCEPT we KEEP the ones that are inside the `// \n // btnXXX \n //` blocks!
    # Wait, the duplicate ones were injected as a massive block of just `this.btnXXX = new ...` without comments.
    
    pass

# Actually, an easier way is to just grep the file to find where the block is.

