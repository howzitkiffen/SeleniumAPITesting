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

        private void Main_Form_Load(object sender, EventArgs e)
        {
            hideSubMenu();
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
                    WebUI.Get3070TI();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.StackTrace + '\r' + ex.Message);
                }
            }
            else 
            {
                btnBestBuyStartStop.Text = "Start";
                WebUI.Chrome.Quit();

            }            
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            WebUI.CloseChromeDriver();
        }
    }
}
