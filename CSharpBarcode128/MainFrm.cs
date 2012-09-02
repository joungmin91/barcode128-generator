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
        const string custom_page = "CustomPage";
        //const int custom_width = 150;
        //const int custom_height = 76;

        private MySQLDatabase m_db = null;
        private string m_server = null;
        private string m_username = null;
        private string m_password = null;
        private string m_port = null;
        private string m_dbName = null;
        private List<BarcodeItem> m_lstBarcode = null;
        private string m_txtAN = null;
        private int m_width;
        private int m_height;
        private int m_top;
        private int m_left;
        private int m_idxPrint = 0;

        public mainFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Init controls
            txtHN.Enabled = false;
            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            // Init datagrid view.
            dgView.AllowUserToAddRows = false;
            dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgView.ReadOnly = true;
            dgView.ColumnCount = 1;
            dgView.Columns[0].HeaderText = "Barcode Label";
            dgView.Columns[0].Width = 250;

            // Init list
            m_lstBarcode = new List<BarcodeItem>();

            // Load config
            LoadFromXML();

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
            XmlNodeList labels = xmlDoc.SelectNodes("//label");
            if (labels != null)
            {
                m_lstBarcode.Clear();
                foreach (XmlNode item in labels)
                {
                    string value = item.Attributes["name"].Value;
                    m_lstBarcode.Add(new BarcodeItem { name=value, image=null});
                }
            }

            return true;
        }

        private System.Drawing.Bitmap GenBarcodeByiText()
        {
            // Cerate barcode image
            iTextSharpBarcode128 barcode = new iTextSharpBarcode128();
            barcode.CodeType = Barcode.CODE128;
            barcode.ChecksumText = true;
            barcode.GenerateChecksum = true;
            barcode.StartStopText = true;
            barcode.BarHeight = 25;
            barcode.Code = m_txtAN;
            barcode.CodeAbove = "HN_" + txtHN.Text + " " + txtFirstName.Text + " " + txtLastName.Text;
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
                        m_txtAN = txtAN.Text + item.name;
                        item.image = GenBarcodeByiText();
                        dgView.Rows.Add(m_txtAN);
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
            BarcodeItem item = FindItemInList(key);
            if (item != null)
            {
                pictureBox.Image = item.image;
            }
        }

        private BarcodeItem FindItemInList(string key)
        {
            foreach (BarcodeItem item in m_lstBarcode)
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

        private int ConvertMM2Inch(int mm)
        {
            double value = mm * 0.0393701;
            value = value * 100;
            return Convert.ToInt32(value);
        }
    }

    public class BarcodeItem
    {
        public string name;
        public System.Drawing.Image image;
    }
}
