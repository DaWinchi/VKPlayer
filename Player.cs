using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace VKPlayer
{
    public partial class Player : Form
    {
        public Player()
        {
            InitializeComponent();
        }

        private void Player_Load(object sender, EventArgs e)
        {
            new Auth().Show();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!Settings.Default.auth) Thread.Sleep(500);

            WebRequest request =
                WebRequest.Create("https://api.vk.com/method/audio.get?owner_id=" + Settings.Default.id + "&need_user=0&access_token=" + Settings.Default.token);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            responseFromServer = HttpUtility.HtmlDecode(responseFromServer);
        }
    }
}
