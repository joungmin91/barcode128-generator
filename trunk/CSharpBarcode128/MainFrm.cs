using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using OnBarcode.Barcode;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Database;
using System.Xml;
using System.IO;

namespace CSharpBarcode128
{
    public partial class mainFrm : Form
    {
        private MySQLDatabase m_db = null;
        private string m_server = null;
        private string m_username = null;
        private string m_password = null;
        private string m_port = null;
        private string m_dbName = null;
        private List<BarcodeItem> m_lstBarcode = null;      // IPD
        private List<BarcodeItem> m_lstBarcodeOPD = null;   // OPD
        private List<BarcodeItem> m_lstBarCodePrint = null;
        private Dictionary<string, OVST> m_map = null;
        private int m_width;
        private int m_height;
        private int m_top;
        private int m_left;
        private int m_idxPrint = 0;
        private Color m_dgvColor;
        private long m_AN = 0;
        private long m_HNOPD = 0;

        public mainFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosed +=new FormClosedEventHandler(mainFrm_FormClosed);

            // Init controls
            txtHN.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            txtVNOPD.Enabled = false;

            // Init datagrid view.
            dgView.AllowUserToAddRows = false;
            dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgView.MultiSelect = false;
            dgView.ReadOnly = true;
            dgView.ColumnCount = 1;
            dgView.Columns[0].HeaderText = "Barcode Label";
            dgView.Columns[0].Width = 250;

            dgViewOPD.AllowUserToAddRows = false;
            dgViewOPD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgViewOPD.MultiSelect = false;
            dgViewOPD.ReadOnly = true;
            dgViewOPD.SelectionChanged += new EventHandler(dgViewOPD_SelectionChanged);
            dgViewOPD.CellContentClick += new DataGridViewCellEventHandler(dgViewOPD_CellContentClick);

            m_dgvColor = dgViewOPD.BackgroundColor;

            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.HeaderText = "";
            chkCol.Width = 30;
            dgViewOPD.Columns.Insert(0, chkCol);

            DataGridViewTextBoxColumn txtCol = new DataGridViewTextBoxColumn();
            txtCol.HeaderText = "Barcode Label";
            txtCol.Width = 250;
            dgViewOPD.Columns.Insert(1, txtCol);

            DataGridViewTextBoxColumn txtCol2 = new DataGridViewTextBoxColumn();
            txtCol2.HeaderText = "Hidden";
            txtCol2.Width = 50;
            txtCol2.Visible = false;
            dgViewOPD.Columns.Insert(2, txtCol2);

            // Init list
            m_lstBarcode = new List<BarcodeItem>();
            m_lstBarcodeOPD = new List<BarcodeItem>();
            m_lstBarCodePrint = new List<BarcodeItem>();

            // Init map
            m_map = new Dictionary<string, OVST>();

            // Init controls
            cmbVSDateOPD.SelectedIndexChanged += new EventHandler(cmbVSDateOPD_SelectedIndexChanged);
            chkBlankOPD.CheckedChanged += new EventHandler(chkBlankOPD_CheckedChanged);
            chkBlankOPD.Enabled = false;

            // Load config
            LoadFromXML();

            // Load previous data before closing form.
            if (File.Exists("savedata.txt") == true)
            {
                StreamReader sr = new StreamReader("savedata.txt");
                string line = sr.ReadLine();
                if (line != null)
                {
                    txtAN.Text = line.Substring(3);    
                }
                line = sr.ReadLine();
                if (line != null)
                {
                    txtHNOPD.Text = line.Substring(3);   
                }
                if (txtAN.Text != "")
                {
                    m_AN = Convert.ToInt32(txtAN.Text);   
                }
                if (txtHNOPD.Text != "")
                {
                    m_HNOPD = Convert.ToInt32(txtHNOPD.Text);   
                }
                sr.Close();
            }

            if (tabControl.SelectedTab.Name == "tabPageIPD")
            {
                txtAN.Select();
            }
            else
            {
                txtHNOPD.Select();
            }

            try
            {
                // Init database
                m_db = new MySQLDatabase();
                m_db.DBServer = m_server;
                m_db.DBUser = m_username;
                m_db.DBPassword = m_password;
                m_db.DBName = m_dbName;
                m_db.Connect();
                m_db.SQLCommand = "USE " + m_dbName + ";";
                m_db.Query();
                m_db.Result.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void chkBlankOPD_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBlankOPD.Checked == true)
            {
                dgViewOPD.Enabled = false;
                dgViewOPD.ForeColor = Color.Red;
                // Display image without type label
                pictureBoxOPD.Image = GenBarcodeByiText("HN_", m_map[cmbVSDateOPD.Text].hn, m_map[cmbVSDateOPD.Text].fname, m_map[cmbVSDateOPD.Text].lname, txtVNOPD.Text);
            }
            else
            {
                dgViewOPD.Enabled = true;
                dgViewOPD.ForeColor = Color.Black;
                // Display image without type label
                string vn = txtVNOPD.Text + (string)dgViewOPD.SelectedRows[0].Cells[2].Value;
                pictureBoxOPD.Image = GenBarcodeByiText("HN_", m_map[cmbVSDateOPD.Text].hn, m_map[cmbVSDateOPD.Text].fname, m_map[cmbVSDateOPD.Text].lname, vn);
            }
        }

        void dgViewOPD_SelectionChanged(object sender, EventArgs e)
        {
            if (dgViewOPD.CurrentRow == null)
            {
                return;
            }

            string key = (string)dgViewOPD.CurrentRow.Cells[2].Value;
            BarcodeItem item = FindItemInList(key, m_lstBarcodeOPD);
            if (item != null)
            {
                pictureBoxOPD.Image = item.image;
            }
        }

        void dgViewOPD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Allow only boolean type.
            if (dgViewOPD.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.GetType() != typeof(bool))
            {
                return;
            }

            // Check box
            bool chk = (bool)dgViewOPD.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (chk == true)
            {
                dgViewOPD.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
            }
            else
            {
                dgViewOPD.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
            }
        }

        void cmbVSDateOPD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_map.Count == 0)
            {
                return;
            }

            txtVNOPD.Text = m_map[cmbVSDateOPD.Text].vn;

            // Lookup 

            // Fill VN + Label in data grid view
            dgViewOPD.Rows.Clear();
            foreach (BarcodeItem item in m_lstBarcodeOPD)
            {
                string VN = txtVNOPD.Text + item.name;
                item.image = GenBarcodeByiText("HN_", m_map[cmbVSDateOPD.Text].hn, m_map[cmbVSDateOPD.Text].fname, m_map[cmbVSDateOPD.Text].lname, VN);
                dgViewOPD.Rows.Add(false, VN, item.name);
            }
        }

        private bool ReloadConfig()
        {
            // Clear data grid view.
            dgView.Rows.Clear();
            pictureBox.Image = null;
            // Load new config
            LoadFromXML();
            try
            {
                // Re-connect database
                m_db.Close();
                m_db.DBServer = m_server;
                m_db.DBUser = m_username;
                m_db.DBPassword = m_password;
                m_db.DBName = m_dbName;
                m_db.Connect();
                m_db.SQLCommand = "USE " + m_dbName + ";";
                m_db.Query();
                m_db.Result.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private bool LoadFromXML()
        {
            // Check the file is existing.
            string configFile = @"config.xml";
            if (File.Exists(configFile) == false)
            {
                return false;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFile);
            if (xmlDoc == null)
            {
                return false;
            }

            // Get server
            XmlNode srvNode = xmlDoc.SelectSingleNode("//server");
            if (srvNode != null)
            {
                XmlAttribute name = srvNode.Attributes["name"];
                XmlAttribute user = srvNode.Attributes["username"];
                XmlAttribute pass = srvNode.Attributes["password"];
                XmlAttribute port = srvNode.Attributes["port"];
                XmlAttribute db = srvNode.Attributes["database"];

                if (name != null)
                {
                    m_server = name.Value;
                }

                if (user != null)
                {
                    m_username = user.Value;
                }

                if (pass != null)
                {
                    m_password = pass.Value;
                }

                if (port != null)
                {
                    m_port = port.Value;
                }

                if (db != null)
                {
                    m_dbName = db.Value;
                }
            }

            // Get printer
            XmlNode printNode = xmlDoc.SelectSingleNode("//printer");
            if (printNode != null)
            {
                XmlAttribute width = printNode.Attributes["width"];
                XmlAttribute height = printNode.Attributes["height"];
                XmlAttribute top = printNode.Attributes["top"];
                XmlAttribute left = printNode.Attributes["left"];

                if (width != null)
                {
                    m_width = Convert.ToInt32(width.Value);
                }

                if (height != null)
                {
                    m_height = Convert.ToInt32(height.Value);
                }

                if (top != null)
                {
                    m_top = Convert.ToInt32(top.Value);
                }

                if (left != null)
                {
                    m_left = Convert.ToInt32(left.Value);
                }
            }

            // Get label
            XmlNodeList labels = xmlDoc.SelectNodes("//labels[@type='IPD']/label");
            if (labels != null)
            {
                m_lstBarcode.Clear();
                foreach (XmlNode item in labels)
                {
                    string value = item.Attributes["name"].Value;
                    m_lstBarcode.Add(new BarcodeItem { name=value, image=null});
                }
            }

            XmlNodeList labelsOPD = xmlDoc.SelectNodes("//labels[@type='OPD']/label");
            if (labels != null)
            {
                m_lstBarcodeOPD.Clear();
                foreach (XmlNode item in labelsOPD)
                {
                    string value = item.Attributes["name"].Value;
                    m_lstBarcodeOPD.Add(new BarcodeItem { name = value, image = null });
                }
            }

            // Get tab
            XmlNode tab = xmlDoc.SelectSingleNode("//tab");
            if (tab != null)
            {
                XmlAttribute defTab = tab.Attributes["default"];
                if (defTab != null)
                {
                    if (defTab.Value == "IPD")
                    {
                        tabControl.SelectedTab = tabPageIPD;
                    }
                    else
                    {
                        tabControl.SelectedTab = tabPageOPD;
                    }
                }
            }

            return true;
        }

        private System.Drawing.Bitmap GenBarcodeByiText(string key, string id, string fname, string lname, string tag)
        {
            // Cerate barcode image
            iTextSharpBarcode128 barcode = new iTextSharpBarcode128();
            barcode.CodeType = Barcode.CODE128;
            barcode.ChecksumText = true;
            barcode.GenerateChecksum = true;
            barcode.StartStopText = true;
            barcode.BarHeight = 25;
            barcode.Code = tag;
            barcode.CodeAbove = key + id + " " + fname + " " + lname;
            return barcode.GetBarcodeBMPImage();
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_db != null && m_db.IsConnect())
                {
                    // Get HN from ipt table.
                    string sHN = null;
                    m_db.SQLCommand = "SELECT * FROM ipt WHERE AN='" + txtAN.Text + "';";
                    if (m_db.Query() == false)
                    {
                        MessageBox.Show("There is no data for AN = " + txtAN.Text + ". Please check.");
                        m_db.Result.Close();

                        // Clear
                        dgView.Rows.Clear();
                        txtHN.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        pictureBox.Image = null;

                        return;
                    }

                    m_db.Result.Read();
                    sHN = (string)m_db.Result["HN"];
                    m_db.Result.Close();
                    txtHN.Text = sHN;

                    // Get firstname and lastname from patient
                    string sFistName = null;
                    string sLastName = null;
                    m_db.SQLCommand = "SELECT * FROM patient WHERE HN='" + txtHN.Text + "';";
                    if (m_db.Query() == false)
                    {
                        MessageBox.Show("There is no data for HN = " + txtHN.Text + ". Please check.");
                        m_db.Result.Close();
                        return;
                    }

                    m_db.Result.Read();
                    sFistName = (string)m_db.Result["FName"];
                    sLastName = (string)m_db.Result["LName"];
                    m_db.Result.Close();
                    txtFirstName.Text = sFistName;
                    txtLastName.Text = sLastName;

                    dgView.Rows.Clear();
                    foreach (BarcodeItem item in m_lstBarcode)
                    {
                        string AN = txtAN.Text + item.name;
                        item.image = GenBarcodeByiText("HN_", txtHN.Text, txtFirstName.Text, txtLastName.Text, AN);
                        dgView.Rows.Add(AN);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_db != null && m_db.IsConnect())
            {
                m_db.Close();
            }

            StreamWriter sw = new StreamWriter("savedata.txt");
            if (txtAN.Text != "" && (Convert.ToInt32(txtAN.Text) > m_AN))
            {
                sw.WriteLine("AN:" + txtAN.Text);
            }
            else
            {
                sw.WriteLine("AN:" + m_AN.ToString());
            }
            if (txtHNOPD.Text != "" && (Convert.ToInt32(txtHNOPD.Text) > m_HNOPD))
            {
                sw.WriteLine("HN:" + txtHNOPD.Text);
            }
            else
            {
                sw.WriteLine("HN:" + m_HNOPD.ToString());
            }
            sw.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigFrm frm = new ConfigFrm();
            frm.ShowDialog();
            if (frm.Result == true)
            {
                // Reload config.
                ReloadConfig();
            }
            frm.Close();
        }

        private void dgView_SelectionChanged(object sender, EventArgs e)
        {
            if (dgView.CurrentRow == null)
            {
                return;
            }

            string key = ((string)dgView.CurrentRow.Cells[0].Value).Substring(7, 3);
            BarcodeItem item = FindItemInList(key, m_lstBarcode);
            if (item != null)
            {
                pictureBox.Image = item.image;
            }
        }

        private BarcodeItem FindItemInList(string key, List<BarcodeItem> lstBarcode)
        {
            foreach (BarcodeItem item in lstBarcode)
            {
                if (item.name == key)
                {
                    return item;
                }
            }
            return null;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count == 0)
            {
                MessageBox.Show("There is no a barcode in data grid view.");
                return;    
            }

            PrintPreviewDialog printDlg = new PrintPreviewDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Barcode";
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDlg.Document = printDoc;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgView.Rows.Count == 0)
            {
                MessageBox.Show("There is no a barcode in data grid view.");
                return;
            }

            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Barcode";
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDlg.Document = printDoc;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (tabControl.TabPages[tabControl.SelectedIndex].Text == "IPD")
            {
                e.Graphics.DrawImage(m_lstBarcode[m_idxPrint++].image, new Point(m_left, m_top));
                // The last page?
                if (m_idxPrint == m_lstBarcode.Count)
                {
                    e.HasMorePages = false;
                    m_idxPrint = 0;
                }
                else
                {
                    e.HasMorePages = true;
                }
            }
            else
            {
                e.Graphics.DrawImage(m_lstBarCodePrint[m_idxPrint++].image, new Point(m_left, m_top));
                // The last page?
                if (m_idxPrint == m_lstBarCodePrint.Count)
                {
                    e.HasMorePages = false;
                    m_idxPrint = 0;
                }
                else
                {
                    e.HasMorePages = true;
                }
            }
        }

        private int ConvertMM2Inch(int mm)
        {
            double value = mm * 0.0393701;
            value = value * 100;
            return Convert.ToInt32(value);
        }

        private void btnGenOPD_Click(object sender, EventArgs e)
        {
            try
            {
                txtVNOPD.Text = "";
                cmbVSDateOPD.Items.Clear();
                m_map.Clear();

                if (m_db != null && m_db.IsConnect())
                {
                    // Get HN from ipt table.                    
                    m_db.SQLCommand = "SELECT * FROM ovst WHERE hn='" + txtHNOPD.Text + "' ORDER BY vstdate DESC, vsttime DESC;";
                    if (m_db.Query() == false)
                    {
                        MessageBox.Show("There is no data for hn = " + txtHNOPD.Text + ". Please check.");
                        m_db.Result.Close();

                        // Clear
                        chkBlankOPD.Enabled = false;
                        dgViewOPD.Rows.Clear();
                        cmbVSDateOPD.Text = "";
                        pictureBoxOPD.Image = null;

                        return;
                    }

                    // Fill data in combo box
                    MySQLDatabase db = new MySQLDatabase();
                    db.DBServer = m_server;
                    db.DBUser = m_username;
                    db.DBPassword = m_password;
                    db.DBName = m_dbName;
                    db.Connect();
                    db.SQLCommand = "USE " + m_dbName + ";";
                    db.Query();
                    db.Result.Close(); 

                    string vstdate = null;
                    string vsttime = null;
                    string time = null;
                    string vn = null;
                    string hn = null;
                    string fname = null;
                    string lname = null;

                    while (m_db.Result.Read())
                    {
                        // Retrieve ovst's information
                        vn = (string)m_db.Result["vn"];
                        hn = (string)m_db.Result["hn"];
                        vstdate = ((DateTime)m_db.Result["vstdate"]).ToString("dd-MM-yyyy");
                        vsttime = (m_db.Result["vsttime"]).ToString();

                        // Retrieve patient's information
                        db.SQLCommand = "SELECT * FROM patient WHERE hn='" + hn + "';";
                        db.Query();
                        db.Result.Read();
                        fname = (string)db.Result["fname"];
                        lname = (string)db.Result["lname"];
                        db.Result.Close();
                        
                        // Build timestamp
                        time = vstdate + "  " + vsttime;

                        // Add item to combo box
                        cmbVSDateOPD.Items.Add(time);

                        // Add to map
                        m_map.Add(time, new OVST { vn = vn, hn = hn, fname = fname, lname = lname });
                    }
                    cmbVSDateOPD.SelectedIndex = 0;
                    m_db.Result.Close();
                    db.Close();

                    // Disable checkbox if no item to be printed.
                    if (m_map.Count == 0)
                    {
                        chkBlankOPD.Enabled = false;
                    }
                    else
                    {
                        chkBlankOPD.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPreviewOPD_Click(object sender, EventArgs e)
        {
            if (dgViewOPD.Rows.Count == 0)
            {
                MessageBox.Show("There is no a barcode in data grid view.");
                return;
            }

            // Select only checked items
            m_lstBarCodePrint.Clear();
            if (chkBlankOPD.Checked == false)
            {
                foreach (DataGridViewRow item in dgViewOPD.Rows)
                {
                    if ((bool)item.Cells[0].Value == true)
                    {
                        BarcodeItem barcode = FindItemInList((string)item.Cells[2].Value, m_lstBarcodeOPD);
                        m_lstBarCodePrint.Add(barcode);
                    }
                }
            }
            else
            {
                System.Drawing.Image img = GenBarcodeByiText("HN_", m_map[cmbVSDateOPD.Text].hn, m_map[cmbVSDateOPD.Text].fname, m_map[cmbVSDateOPD.Text].lname, txtVNOPD.Text);
                m_lstBarCodePrint.Add(new BarcodeItem { name = "", image = img });
            }
            

            // Check at least an item to print
            if (m_lstBarCodePrint.Count == 0)
            {
                MessageBox.Show("There is no selected items.");
                return;
            }

            PrintPreviewDialog printDlg = new PrintPreviewDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Barcode";
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDlg.Document = printDoc;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }

        private void btnPrintOPD_Click(object sender, EventArgs e)
        {
            if (dgViewOPD.Rows.Count == 0)
            {
                MessageBox.Show("There is no a barcode in data grid view.");
                return;
            }

            // Select only checked items
            m_lstBarCodePrint.Clear();
            if (chkBlankOPD.Checked == false)
            {
                foreach (DataGridViewRow item in dgViewOPD.Rows)
                {
                    if ((bool)item.Cells[0].Value == true)
                    {
                        BarcodeItem barcode = FindItemInList((string)item.Cells[2].Value, m_lstBarcodeOPD);
                        m_lstBarCodePrint.Add(barcode);
                    }
                }
            }
            else
            {
                System.Drawing.Image img = GenBarcodeByiText("HN_", m_map[cmbVSDateOPD.Text].hn, m_map[cmbVSDateOPD.Text].fname, m_map[cmbVSDateOPD.Text].lname, txtVNOPD.Text);
                m_lstBarCodePrint.Add(new BarcodeItem { name = "", image = img });
            }

            // Check at least an item to print
            if (m_lstBarCodePrint.Count == 0)
            {
                MessageBox.Show("There is no selected items.");
                return;
            }

            PrintDialog printDlg = new PrintDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.DocumentName = "Barcode";
            printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage);
            printDlg.Document = printDoc;
            if (printDlg.ShowDialog() == DialogResult.OK)
                printDoc.Print();
        }
    }

    public class BarcodeItem
    {
        public string name;
        public System.Drawing.Image image;
    }

    public class OVST
    {
        public string vn;
        public string hn;
        public string fname;
        public string lname;
    }
}
