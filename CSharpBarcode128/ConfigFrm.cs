using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace CSharpBarcode128
{
    public partial class ConfigFrm : Form
    {
        public bool Result { get; set; }
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Port { get; set; }
        public List<string> ListLabel { get; set; }

        public ConfigFrm()
        {
            InitializeComponent();
        }

        private void ConfigFrm_Load(object sender, EventArgs e)
        {
            // Init vars.
            Result = false;
            ListLabel = new List<string>();

            // Init datagrid view.
            dgView.AllowUserToAddRows = false;
            dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgView.ColumnCount = 1;
            dgView.Columns[0].HeaderText = "Barcode Label";
            dgView.Columns[0].Width = 280;

            // Load XML.
            LoadFromXML();
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

                if (name != null)
                {
                    txtServer.Text = name.Value;
                }

                if (user != null)
                {
                    txtUsername.Text = user.Value;
                }

                if (pass != null)
                {
                    txtPassword.Text = pass.Value;
                }

                if (port != null)
                {
                    txtPort.Text = port.Value;
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
                    txtWidth.Text = width.Value;
                }

                if (height != null)
                {
                    txtHeight.Text = height.Value;
                }

                if (top != null)
                {
                    txtTop.Text = top.Value;
                }

                if (left != null)
                {
                    txtLeft.Text = left.Value;
                }
            }

            // Get label
            XmlNodeList labels = xmlDoc.SelectNodes("//label");
            if (labels != null)
            {
                foreach (XmlNode item in labels)
                {
                    string value = item.Attributes["name"].Value;
                    dgView.Rows.Add(value);
                }
            }

            return true;
        }

        private bool SaveToXML()
        {
            // Check data before create xml.
            if (
                txtServer.Text == "" ||
                txtUsername.Text == "" ||
                txtPassword.Text == "" ||
                txtPort.Text == ""
                )
            {
                MessageBox.Show("You must complete all field in this dialog.");
                return false;
            }

            // Create XML file
            XmlDocument xmlDoc = new XmlDocument();

            // Create config node
            XmlNode xmlNodeRoot = xmlDoc.CreateNode(XmlNodeType.Element, "config", "");

            // Create server
            XmlNode xmlNodeServer = xmlDoc.CreateNode(XmlNodeType.Element, "server", "");
            XmlAttribute xmlAttrSrvName = xmlDoc.CreateAttribute("name");
            xmlAttrSrvName.Value = txtServer.Text;
            xmlNodeServer.Attributes.Append(xmlAttrSrvName);
            XmlAttribute xmlAttrSrvUser = xmlDoc.CreateAttribute("username");
            xmlAttrSrvUser.Value = txtUsername.Text;
            xmlNodeServer.Attributes.Append(xmlAttrSrvUser);
            XmlAttribute xmlAttrSrvPass = xmlDoc.CreateAttribute("password");
            xmlAttrSrvPass.Value = txtPassword.Text;
            xmlNodeServer.Attributes.Append(xmlAttrSrvPass);
            XmlAttribute xmlAttrSrvPort = xmlDoc.CreateAttribute("port");
            xmlAttrSrvPort.Value = txtPort.Text;
            xmlNodeServer.Attributes.Append(xmlAttrSrvPort);

            // Create labels node
            XmlNode xmlNodeLabels = xmlDoc.CreateNode(XmlNodeType.Element, "labels", "");

            foreach (DataGridViewRow item in dgView.Rows)
            {
                // Create label node
                XmlNode xmlNodeLabel = xmlDoc.CreateNode(XmlNodeType.Element, "label", "");
                XmlAttribute xmlAttrName = xmlDoc.CreateAttribute("name");
                xmlAttrName.Value = (string)item.Cells[0].Value;
                xmlNodeLabel.Attributes.Append(xmlAttrName);
                xmlNodeLabels.AppendChild(xmlNodeLabel);
            }

            // Create printer node
            XmlNode xmlNodePrinter = xmlDoc.CreateNode(XmlNodeType.Element, "printer", "");
            XmlAttribute xmlAttrPrintWidth = xmlDoc.CreateAttribute("width");
            xmlAttrPrintWidth.Value = txtWidth.Text;
            xmlNodePrinter.Attributes.Append(xmlAttrPrintWidth);
            XmlAttribute xmlAttrPrintHeight = xmlDoc.CreateAttribute("height");
            xmlAttrPrintHeight.Value = txtHeight.Text;
            xmlNodePrinter.Attributes.Append(xmlAttrPrintHeight);
            XmlAttribute xmlAttrPrintTop = xmlDoc.CreateAttribute("top");
            xmlAttrPrintTop.Value = txtTop.Text;
            xmlNodePrinter.Attributes.Append(xmlAttrPrintTop);
            XmlAttribute xmlAttrPrintLeft = xmlDoc.CreateAttribute("left");
            xmlAttrPrintLeft.Value = txtLeft.Text;
            xmlNodePrinter.Attributes.Append(xmlAttrPrintLeft);
            

            // Append all nodes to root node
            xmlNodeRoot.AppendChild(xmlNodePrinter);
            xmlNodeRoot.AppendChild(xmlNodeLabels);
            xmlNodeRoot.AppendChild(xmlNodeServer);
            xmlDoc.AppendChild(xmlNodeRoot);
            xmlDoc.Save(@"config.xml");

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Result = false;
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Result = true;
            Server = txtServer.Text;
            Username = txtUsername.Text;
            Password = txtPassword.Text;
            Port = txtPort.Text;
            // Get all labels from rows
            foreach (DataGridViewRow item in dgView.Rows)
            {
                ListLabel.Add((string)item.Cells[0].Value);
            }
            SaveToXML();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLabel.Text == "")
            {
                return;
            }

            dgView.Rows.Add(txtLabel.Text);

            txtLabel.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgView.Rows.Remove(dgView.CurrentRow);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dgView.CurrentRow.Cells[0].Value = txtLabel.Text;
        }

        private void dgView_SelectionChanged(object sender, EventArgs e)
        {
            txtLabel.Text = (string)dgView.CurrentRow.Cells[0].Value;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtLeft_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
