﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


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

        private void Main_Form_Load(object sender, EventArgs e)
        {
            hideSubMenu();




        }

        #region Form Hovers
        private void pnAmazonLogo_MouseHover(object sender, EventArgs e)
        {
            pnAmazonLogo.BackColor = HeaderHoverColor;
        }

        private void pnBestBuyLogo_MouseHover(object sender, EventArgs e)
        {
            pnBestBuyLogo.BackColor = HeaderHoverColor;
        }

        private void pnAmazonLogo_MouseLeave(object sender, EventArgs e)
        {
            pnAmazonLogo.BackColor = HeaderDefaultColor;
        }


        private void pnBestBuyLogo_MouseLeave(object sender, EventArgs e)
        {
            pnBestBuyLogo.BackColor = HeaderDefaultColor;
        }
        #endregion

        #region Other Actions/Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnBestBuyLogo_MouseClick(object sender, MouseEventArgs e)
        {
            showSubMenu(pnSubMenuBestBuy);
            showSubMenu(pnBestBuyDividerBottom);
        }

        private void pnAmazonLogo_MouseClick(object sender, MouseEventArgs e)
        {
            showSubMenu(pnSubPanelAmazon);
            showSubMenu(pnAmazonDividerBottom);
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
        }
        #endregion


    }
}