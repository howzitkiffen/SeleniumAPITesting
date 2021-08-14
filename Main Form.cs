using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using C_SeleniumLogic;


namespace SeleniumAPITesting
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
        }

        #region Program Settings
        string path = Directory.GetCurrentDirectory();

        Color HeaderHoverColor = GLOBAL.Orange;
        Color HeaderDefaultColor = GLOBAL.DarkRed;
        #endregion

        clsBestBuy WebUI = new clsBestBuy();

        BackgroundWorker bwBB3070 = new BackgroundWorker();

        private void Main_Form_Load(object sender, EventArgs e)
        {
            hideSubMenu();
            BackgroundWorkerConfiguration();
        }

        private void BackgroundWorkerConfiguration() 
        {
            bwBB3070.DoWork += BwBB3070_DoWork;
            bwBB3070.RunWorkerCompleted += BwBB3070_RunWorkerCompleted;
            bwBB3070.WorkerSupportsCancellation = true; 
        }

        private void BwBB3070_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) 
            {
                WebUI.Chrome.Quit();
                WebUI.Chrome.Dispose();
                MessageBox.Show("CardSearch Stopped."); 
            }
        }

        private void BwBB3070_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!bwBB3070.CancellationPending) { WebUI.Get3070TI(); }
            if (bwBB3070.CancellationPending) { e.Cancel = true; }
        }

        #region Form Hovers

        #endregion

        #region Other Actions/Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnBestBuyLogo_MouseClick(object sender, MouseEventArgs e)
        {
            showSubMenu(pnSubMenuBestBuy);
        }

        private void pnAmazonLogo_MouseClick(object sender, MouseEventArgs e)
        {
            showSubMenu(pnSubPanelAmazon);
        }

        private void pnNewEggLogo_MouseClick(object sender, MouseEventArgs e)
        {
            showSubMenu(pnNewEggSubMenu);
        }
        #endregion

        #region SubMenu Hide/Show
        private void showSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                hideSubMenu();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }

        private void hideSubMenu()
        {
            if (pnSubPanelAmazon.Visible == true) { pnSubPanelAmazon.Visible = false; }
            if (pnSubMenuBestBuy.Visible == true) { pnSubMenuBestBuy.Visible = false; }
            if (pnNewEggSubMenu.Visible ==true) { pnNewEggSubMenu.Visible = false; }
        }


        #endregion

        private void btnBestBuyStartStop_Click(object sender, EventArgs e)
        {
            
            if (btnBestBuyStartStop.Text == "Start")
            {
                btnBestBuyStartStop.Text = "Stop";
                try
                {
                    bwBB3070.RunWorkerAsync();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.StackTrace + '\r' + ex.Message);
                }
            }
            else 
            {
                btnBestBuyStartStop.Text = "Start";
                if (bwBB3070.IsBusy) { bwBB3070.CancelAsync(); }
            }            
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            WebUI.CloseChromeDriver();
        }

    }
}
