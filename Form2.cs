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
        private PictureBox pic;
        private CheckBox cb1, cb2, cb3, cb4;
        private RadioButton rb1, rb2;
        private TabControl tabs;
        private ListBox list;
        private string[] images = { "esimene.jpg", "teine.jpg", "kolmas.jpg","close_box_red.png", "about.png" };
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
            pic = new PictureBox();
            pic.Size = new Size(150, 150);
            pic.Location = new Point(30, 50);
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            pic.Image = Image.FromFile(@"..\..\Images\" + images[0]);
            pic.DoubleClick += PicClick;
            pic.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pic);

            // CheckBoxes
            cb1 = new CheckBox();
            cb1.Text = "Vormi läbipaistvus";
            cb1.Location = new Point(220, 50);
            cb1.Size = new Size(150, 25);
            cb1.CheckedChanged += Cb1Click;
            this.Controls.Add(cb1);

            cb2 = new CheckBox();
            cb2.Text = "Kõige peal";
            cb2.Location = new Point(220, 80);
            cb2.Size = new Size(150, 25);
            cb2.CheckedChanged += Cb2Click;
            this.Controls.Add(cb2);

            cb3 = new CheckBox();
            cb3.Text = "Suurenda aken";
            cb3.Location = new Point(220, 110);
            cb3.Size = new Size(150, 25);
            cb3.CheckedChanged += Cb3Click;
            this.Controls.Add(cb3);

            cb4 = new CheckBox();
            cb4.Text = "Näita piire";
            cb4.Location = new Point(220, 140);
            cb4.Size = new Size(150, 25);
            cb4.Checked = true;
            cb4.CheckedChanged += Cb4Click;
            this.Controls.Add(cb4);

            // RadioButtons
            rb1 = new RadioButton();
            rb1.Text = "Tume teema";
            rb1.Location = new Point(400, 50);
            rb1.Size = new Size(120, 25);
            rb1.CheckedChanged += RbClick;
            this.Controls.Add(rb1);

            rb2 = new RadioButton();
            rb2.Text = "Hele teema";
            rb2.Location = new Point(400, 80);
            rb2.Size = new Size(120, 25);
            rb2.Checked = true;
            rb2.CheckedChanged += RbClick;
            this.Controls.Add(rb2);

            tabs = new TabControl();
            tabs.Location = new Point(30, 230);
            tabs.Size = new Size(450, 220);
            
            TabPage tab1 = new TabPage("Kaart 1");
            Label lbl1 = new Label();
            lbl1.Text = "Esimese kaardi sisu";
            lbl1.Location = new Point(10, 10);
            tab1.Controls.Add(lbl1);
            
            TabPage tab2 = new TabPage("Kaart 2");
            
            TextBox tb = new TextBox();
            tb.Location = new Point(10, 10);
            tb.Size = new Size(200, 20);
            tb.Text = "Sisesta tekst siia";
            tb.ForeColor = Color.Gray;
            tb.GotFocus += (s, e) => {
                if (tb.Text == "Sisesta tekst siia")
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };
            tb.LostFocus += (s, e) => {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.ForeColor = Color.Gray;
                    tb.Text = "Sisesta tekst siia";
                }
            };
            
            Button btn2 = new Button();
            btn2.Text = "Näita teksti";
            btn2.Location = new Point(10, 40);
            btn2.Click += (s, e) => MessageBox.Show($"Sisestatud tekst: {tb.Text}");
            
            CheckBox chkTab2 = new CheckBox();
            chkTab2.Text = "Muuda kaardi värvi";
            chkTab2.Location = new Point(10, 70);
            chkTab2.CheckedChanged += (s, e) => tab2.BackColor = chkTab2.Checked ? Color.LightBlue : Color.White;
            
            tab2.Controls.Add(tb);
            tab2.Controls.Add(btn2);
            tab2.Controls.Add(chkTab2);
            
            TabPage addTab = new TabPage("+");
            
            tabs.TabPages.Add(tab1);
            tabs.TabPages.Add(tab2);
            tabs.TabPages.Add(addTab);
            tabs.MouseDoubleClick += TabDoubleClick;
            tabs.MouseClick += TabClick;
            this.Controls.Add(tabs);

            // ListBox
            list = new ListBox();
            list.Location = new Point(520, 230);
            list.Size = new Size(150, 150);
            list.Items.AddRange(new string[] { "Punane", "Roheline", "Sinine", "Kollane", "Violetne" });
            list.SelectedIndexChanged += ListClick;
            this.Controls.Add(list);
            
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

        private void PicClick(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                currentImageIndex = random.Next(images.Length);
            }
            else
            {
                currentImageIndex = (currentImageIndex + 1) % images.Length;
            }
            pic.Image = Image.FromFile(@"..\..\Images\" + images[currentImageIndex]);
        }

        private void Cb1Click(object sender, EventArgs e)
        {
            this.Opacity = cb1.Checked ? 0.5 : 1.0;
        }

        private void Cb2Click(object sender, EventArgs e)
        {
            this.TopMost = cb2.Checked;
        }

        private void Cb3Click(object sender, EventArgs e)
        {
            this.WindowState = cb3.Checked ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void Cb4Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = cb4.Checked ? FormBorderStyle.Sizable : FormBorderStyle.None;
        }

        private void RbClick(object sender, EventArgs e)
        {
            if (rb1.Checked)
            {
                this.BackColor = Color.DarkGray;
                this.ForeColor = Color.White;
            }
            else if (rb2.Checked)
            {
                this.BackColor = Color.White;
                this.ForeColor = Color.Black;
            }
        }

        private void ListClick(object sender, EventArgs e)
        {
            switch (list.SelectedIndex)
            {
                case 0: this.BackColor = Color.LightCoral; break;
                case 1: this.BackColor = Color.LightGreen; break;
                case 2: this.BackColor = Color.LightBlue; break;
                case 3: this.BackColor = Color.LightYellow; break;
                case 4: this.BackColor = Color.Plum; break;
            }
        }

        private void TabDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabs.TabPages.Count; i++)
            {
                if (tabs.GetTabRect(i).Contains(e.Location) && tabs.TabPages[i].Text == "+")
                {
                    TabPage newTab = new TabPage($"Kaart {tabs.TabPages.Count}");
                    Label newLabel = new Label();
                    newLabel.Text = $"Uus kaart {tabs.TabPages.Count}";
                    newLabel.Location = new Point(10, 10);
                    newTab.Controls.Add(newLabel);
                    tabs.TabPages.Insert(tabs.TabPages.Count - 1, newTab);
                    break;
                }
            }
        }

        private void TabClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabs.TabPages.Count - 1; i++)
                {
                    if (tabs.GetTabRect(i).Contains(e.Location))
                    {
                        if (tabs.TabPages.Count > 3)
                        {
                            tabs.TabPages.RemoveAt(i);
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
            fileMenu.DropDownItems.Add("Näita dialoogi", null, ShowDialog);
            fileMenu.DropDownItems.Add("Välju", null, (s, e) => this.Close());
            
            ToolStripMenuItem viewMenu = new ToolStripMenuItem("Vaade");
            viewMenu.DropDownItems.Add("Lähtesta pilt", null, ResetPic);
            viewMenu.DropDownItems.Add("Tühista valik", null, ClearAll);
            
            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(viewMenu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void ShowDialog(object sender, EventArgs e)
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

        private void ResetPic(object sender, EventArgs e)
        {
            currentImageIndex = 0;
            pic.Image = Image.FromFile(@"..\..\Images\" + images[0]);
        }

        private void ClearAll(object sender, EventArgs e)
        {
            list.ClearSelected();
            
            cb1.Checked = false;
            cb2.Checked = false;
            cb3.Checked = false;
            cb4.Checked = true;
            
            rb2.Checked = true;
            
            currentImageIndex = 0;
            pic.Image = Image.FromFile(@"..\..\Images\" + images[0]);
            
            foreach (TabPage tab in tabs.TabPages)
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
