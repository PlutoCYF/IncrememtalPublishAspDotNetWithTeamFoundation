using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IncrememtalPublish
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            publishPath = txt_publish.Text;
            physicalPath = txt_physical.Text;
            updatePath = txt_update.Text;
            int v = 0;
            if (int.TryParse(txt_version.Text, out v))
            {
                version = v;
            }
        }
        public Form1(string[] args):this()
        {
            
        }
        private string physicalPath = "", updatePath = "", publishPath = "";
        private int version = 387736;

        private void button1_Click(object sender, EventArgs e)
        {
            if (physicalPath != "" && updatePath != "" && publishPath != "" && version > 0)
            {
                ChangedFileInPublishedWeb.StartUp.Start(physicalPath, updatePath, publishPath, version);
                MessageBox.Show("完成");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (physicalPath != "" && updatePath != "" && publishPath != "" && version > 0)
            {
                ChangedFileInPublishedWeb.StartUp.StartWithoutPublish(physicalPath, updatePath, publishPath, version);
                MessageBox.Show("完成");
            }
        }

        private void txt_publish_TextChanged(object sender, EventArgs e)
        {
            publishPath = txt_publish.Text;
        }

        private void txt_physical_TextChanged(object sender, EventArgs e)
        {
            physicalPath = txt_physical.Text;
        }

        private void txt_update_TextChanged(object sender, EventArgs e)
        {
            updatePath = txt_update.Text;
        }

        private void txt_version_TextChanged(object sender, EventArgs e)
        {
            int v = 0;
            if (int.TryParse(txt_version.Text, out v))
            {
                version = v;
            }
        }

    }
}
