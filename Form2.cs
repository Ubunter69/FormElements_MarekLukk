using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormElements
{
    public partial class Form2 : Form
    {
        private PictureBox pictureBox;
        private CheckBox chkOpacity, chkTopMost, chkMaximized, chkBorder;
        private RadioButton rbDark, rbLight;
        private TabControl tabControl;
        private ListBox listBox;
        private string[] images = { "esimene.jpg", "teine.jpg", "kolmas.jpg" };
        private int currentImageIndex = 0;
        private Random random = new Random();

        public Form2()
        {
            InitializeComponent();
            InitializeControls();
            CreateMenu();
        }

        private void InitializeControls()
        {
            this.Size = new Size(900, 650);
            this.Text = "Vorm elementidega";

            // PictureBox
            pictureBox = new PictureBox();
            pictureBox.Size = new Size(150, 150);
            pictureBox.Location = new Point(30, 50);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = Image.FromFile(@"..\..\Images\" + images[0]);
            pictureBox.DoubleClick += PictureBox_DoubleClick;
            pictureBox.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pictureBox);

            // CheckBoxes
            chkOpacity = new CheckBox();
            chkOpacity.Text = "Vormi läbipaistvus";
            chkOpacity.Location = new Point(220, 50);
            chkOpacity.Size = new Size(150, 25);
            chkOpacity.CheckedChanged += ChkOpacity_CheckedChanged;
            this.Controls.Add(chkOpacity);

            chkTopMost = new CheckBox();
            chkTopMost.Text = "Kõige peal";
            chkTopMost.Location = new Point(220, 80);
            chkTopMost.Size = new Size(150, 25);
            chkTopMost.CheckedChanged += ChkTopMost_CheckedChanged;
            this.Controls.Add(chkTopMost);

            chkMaximized = new CheckBox();
            chkMaximized.Text = "Suurenda aken";
            chkMaximized.Location = new Point(220, 110);
            chkMaximized.Size = new Size(150, 25);
            chkMaximized.CheckedChanged += ChkMaximized_CheckedChanged;
            this.Controls.Add(chkMaximized);

            chkBorder = new CheckBox();
            chkBorder.Text = "Näita piire";
            chkBorder.Location = new Point(220, 140);
            chkBorder.Size = new Size(150, 25);
            chkBorder.Checked = true;
            chkBorder.CheckedChanged += ChkBorder_CheckedChanged;
            this.Controls.Add(chkBorder);

            // RadioButtons
            rbDark = new RadioButton();
            rbDark.Text = "Tume teema";
            rbDark.Location = new Point(400, 50);
            rbDark.Size = new Size(120, 25);
            rbDark.CheckedChanged += ThemeChanged;
            this.Controls.Add(rbDark);

            rbLight = new RadioButton();
            rbLight.Text = "Hele teema";
            rbLight.Location = new Point(400, 80);
            rbLight.Size = new Size(120, 25);
            rbLight.Checked = true;
            rbLight.CheckedChanged += ThemeChanged;
            this.Controls.Add(rbLight);

            tabControl = new TabControl();
            tabControl.Location = new Point(30, 230);
            tabControl.Size = new Size(450, 220);
            
            TabPage tab1 = new TabPage("Kaart 1");
            Label lbl1 = new Label();
            lbl1.Text = "Esimese kaardi sisu";
            lbl1.Location = new Point(10, 10);
            tab1.Controls.Add(lbl1);
            
            TabPage tab2 = new TabPage("Kaart 2");
            
            TextBox textBox = new TextBox();
            textBox.Location = new Point(10, 10);
            textBox.Size = new Size(200, 20);
            textBox.Text = "Sisesta tekst siia";
            
            Button btn2 = new Button();
            btn2.Text = "Näita teksti";
            btn2.Location = new Point(10, 40);
            btn2.Click += (s, e) => MessageBox.Show($"Sisestatud tekst: {textBox.Text}");
            
            CheckBox chkTab2 = new CheckBox();
            chkTab2.Text = "Muuda kaardi värvi";
            chkTab2.Location = new Point(10, 70);
            chkTab2.CheckedChanged += (s, e) => tab2.BackColor = chkTab2.Checked ? Color.LightBlue : Color.White;
            
            tab2.Controls.Add(textBox);
            tab2.Controls.Add(btn2);
            tab2.Controls.Add(chkTab2);
            
            TabPage addTab = new TabPage("+");
            
            tabControl.TabPages.Add(tab1);
            tabControl.TabPages.Add(tab2);
            tabControl.TabPages.Add(addTab);
            tabControl.MouseDoubleClick += TabControl_MouseDoubleClick;
            tabControl.MouseClick += TabControl_MouseClick;
            this.Controls.Add(tabControl);

            // ListBox
            listBox = new ListBox();
            listBox.Location = new Point(520, 230);
            listBox.Size = new Size(150, 150);
            listBox.Items.AddRange(new string[] { "Punane", "Roheline", "Sinine", "Kollane", "Violetne" });
            listBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            this.Controls.Add(listBox);
            
            // Pealkirjad
            Label lblPicture = new Label();
            lblPicture.Text = "Pildid (topeltklõps)";
            lblPicture.Location = new Point(30, 25);
            lblPicture.Font = new Font("Arial", 9, FontStyle.Bold);
            this.Controls.Add(lblPicture);
            
            Label lblCheckbox = new Label();
            lblCheckbox.Text = "Märkeruudud";
            lblCheckbox.Location = new Point(220, 25);
            lblCheckbox.Font = new Font("Arial", 9, FontStyle.Bold);
            this.Controls.Add(lblCheckbox);
            
            Label lblRadio = new Label();
            lblRadio.Text = "Teemad";
            lblRadio.Location = new Point(400, 25);
            lblRadio.Font = new Font("Arial", 9, FontStyle.Bold);
            this.Controls.Add(lblRadio);
            
            Label lblColors = new Label();
            lblColors.Text = "Värvid";
            lblColors.Location = new Point(520, 205);
            lblColors.Font = new Font("Arial", 9, FontStyle.Bold);
            this.Controls.Add(lblColors);
            
            Label lblTabInstructions = new Label();
            lblTabInstructions.Text = "Kaardid: topeltklõps '+' - lisa, paremklõps - kustuta";
            lblTabInstructions.Location = new Point(30, 460);
            lblTabInstructions.Size = new Size(400, 20);
            lblTabInstructions.Font = new Font("Arial", 8, FontStyle.Italic);
            lblTabInstructions.ForeColor = Color.Gray;
            this.Controls.Add(lblTabInstructions);
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
        
            if (Control.ModifierKeys == Keys.Control)
            {
                currentImageIndex = random.Next(images.Length);
            }
            else
            {
                
                currentImageIndex = (currentImageIndex + 1) % images.Length;
            }
            pictureBox.Image = Image.FromFile(@"..\..\Images\" + images[currentImageIndex]);
        }

        private void ChkOpacity_CheckedChanged(object sender, EventArgs e)
        {
            this.Opacity = chkOpacity.Checked ? 0.5 : 1.0;
        }

        private void ChkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = chkTopMost.Checked;
        }

        private void ChkMaximized_CheckedChanged(object sender, EventArgs e)
        {
            this.WindowState = chkMaximized.Checked ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void ChkBorder_CheckedChanged(object sender, EventArgs e)
        {
            this.FormBorderStyle = chkBorder.Checked ? FormBorderStyle.Sizable : FormBorderStyle.None;
        }

        private void ThemeChanged(object sender, EventArgs e)
        {
            if (rbDark.Checked)
            {
                this.BackColor = Color.DarkGray;
                this.ForeColor = Color.White;
            }
            else if (rbLight.Checked)
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
            }
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listBox.SelectedIndex)
            {
                case 0: this.BackColor = Color.LightCoral; break;
                case 1: this.BackColor = Color.LightGreen; break;
                case 2: this.BackColor = Color.LightBlue; break;
                case 3: this.BackColor = Color.LightYellow; break;
                case 4: this.BackColor = Color.Plum; break;
            }
        }

        private void TabControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (tabControl.GetTabRect(i).Contains(e.Location) && tabControl.TabPages[i].Text == "+")
                {
                    TabPage newTab = new TabPage($"Kaart {tabControl.TabPages.Count}");
                    Label newLabel = new Label();
                    newLabel.Text = $"Uus kaart {tabControl.TabPages.Count}";
                    newLabel.Location = new Point(10, 10);
                    newTab.Controls.Add(newLabel);
                    tabControl.TabPages.Insert(tabControl.TabPages.Count - 1, newTab);
                    break;
                }
            }
        }

        private void TabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabControl.TabPages.Count - 1; i++)
                {
                    if (tabControl.GetTabRect(i).Contains(e.Location))
                    {
                        if (tabControl.TabPages.Count > 3)
                        {
                            tabControl.TabPages.RemoveAt(i);
                        }
                        break;
                    }
                }
            }
        }

        private void CreateMenu()
        {
            MenuStrip menuStrip = new MenuStrip();
            
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Fail");
            fileMenu.DropDownItems.Add("Näita dialoogi", null, ShowCustomDialog);
            fileMenu.DropDownItems.Add("Välju", null, (s, e) => this.Close());
            
            ToolStripMenuItem viewMenu = new ToolStripMenuItem("Vaade");
            viewMenu.DropDownItems.Add("Lähtesta pilt", null, ResetImage);
            viewMenu.DropDownItems.Add("Tühista valik", null, ClearSelection);
            
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(viewMenu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void ShowCustomDialog(object sender, EventArgs e)
        {
            Form dialog = new Form();
            dialog.Text = "Dialoogiaken";
            dialog.Size = new Size(300, 150);
            dialog.StartPosition = FormStartPosition.CenterParent;
            
            Label label = new Label();
            label.Text = "Tere!";
            label.Location = new Point(20, 20);
            label.AutoSize = true;
            
            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Location = new Point(100, 60);
            okButton.DialogResult = DialogResult.OK;
            
            dialog.Controls.Add(label);
            dialog.Controls.Add(okButton);
            dialog.ShowDialog();
        }

        private void ResetImage(object sender, EventArgs e)
        {
            currentImageIndex = 0;
            pictureBox.Image = Image.FromFile(@"..\..\Images\" + images[0]);
        }

        private void ClearSelection(object sender, EventArgs e)
        {
      
            listBox.ClearSelected();
            
          
            chkOpacity.Checked = false;
            chkTopMost.Checked = false;
            chkMaximized.Checked = false;
            chkBorder.Checked = true;
            
          
            rbLight.Checked = true;
            
           
            currentImageIndex = 0;
            pictureBox.Image = Image.FromFile(@"..\..\Images\" + images[0]);
            
            
            foreach (TabPage tab in tabControl.TabPages)
            {
                if (tab.Text != "+")
                {
                    foreach (Control control in tab.Controls)
                    {
                        if (control is TextBox textBox)
                        {
                            textBox.Clear();
                        }
                        else if (control is CheckBox checkBox)
                        {
                            checkBox.Checked = false;
                        }
                    }
           
                    tab.BackColor = Color.White;
                }
            }
            
  
            this.BackColor = Color.White;
        }


    }
}
