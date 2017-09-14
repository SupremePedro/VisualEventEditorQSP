using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualEventEditor
{
    public partial class LocEditForm : Form
    {
       // string theValue;
        private string locName;
        private string shtLocDescription;

        public string ShtLocDescription
        {
            get { return shtLocDescription; }
            set { shtLocDescription = value; }
        }

        public string LocName
        {
            get { return locName; }
            set { locName = value; }
        }
        
        public LocEditForm()
        {
            InitializeComponent();
            txtLocName.Text = locName;
            txtShtLocDescription.Text = shtLocDescription;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            cmd.StandardInput.WriteLine(@"e:");
            cmd.StandardInput.WriteLine(@"cd E:\dev\GameConventor");
            cmd.StandardInput.WriteLine(@".\txt2gam.exe game.txt game.gam");
            cmd.WaitForExit();
            
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            LocName = txtLocName.Text;
            ShtLocDescription = txtShtLocDescription.Text;
        }

    }
}
