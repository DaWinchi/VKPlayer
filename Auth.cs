﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKPlayer
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://oauth.vk.com/authorize?client_id=6171434&scope=audio&redirect_uri=https://oauth.vk.com/blank.html&display=popup&v=5.68&response_type=token");
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            toolStripStatusLabel1.Text = "Загрузка...";
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Загружено";
            if (webBrowser1.Url.ToString().Contains('#'))
                {
                    string URL = webBrowser1.Url.ToString();
                    string l = URL.Split('#')[1];
                    if (l[0] == 'a')
                    {
                        Settings.Default.token = l.Split('&')[0].Split('=')[1];
                        Settings.Default.id = l.Split('=')[3];
                        Settings.Default.auth = true;
                        MessageBox.Show(Settings.Default.token + " " + Settings.Default.id);
                        this.Close();
                    }
                }
           
        }

      
    }
}
