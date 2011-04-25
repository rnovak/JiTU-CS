﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiTU_CS.UI.Screens.Views
{
    public partial class WelcomeView : BaseView
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        private void WelcomeView_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "Welcome " + GlobalData.currentUser.FullName;
        }
    }
}
