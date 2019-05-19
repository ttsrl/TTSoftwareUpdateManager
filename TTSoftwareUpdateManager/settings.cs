﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TTSoftwareUpdateManager.Properties;
using WinSCP;

namespace TTSoftwareUpdateManager
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (txt_host.Text != "" && txt_port.Text != "" && txt_username.Text != "" && txt_pass.Text != "")
            {
                Settings.Default.ftp_host = txt_host.Text;
                Settings.Default.ftp_port = txt_port.Text;
                Settings.Default.ftp_password = txt_pass.Text;
                Settings.Default.ftp_username = txt_username.Text;
                Settings.Default.ftp_folder = txt_folder.Text;
                Settings.Default.Save();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Inserire i dati richiesti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txt_host.Text != "" && txt_port.Text != "" && txt_username.Text != "" && txt_pass.Text != "" && txt_folder.Text != "")
            {
                var fixPort = 21;
                var fixHost = txt_host.Text.ToLower().Replace("ftp://", "").Replace("ftp.", "").Replace("/", "");
                int.TryParse(txt_port.Text, out fixPort);
                try
                {
                    SessionOptions sessionOptions = new SessionOptions
                    {
                        Protocol = Protocol.Ftp,
                        HostName = fixHost,
                        UserName = txt_username.Text,
                        Password = txt_pass.Text,
                        PortNumber = fixPort
                    };
                    Session session = new Session();
                    session.Open(sessionOptions);
                    if (session.Opened)
                    {
                        session.Close();
                        MessageBox.Show("Connessione stabilita!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Errore, impossibile connettersi!", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Inserire i dati richiesti.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txt_host.Text = Settings.Default.ftp_host;
            txt_port.Text = Settings.Default.ftp_port;
            txt_username.Text = Settings.Default.ftp_username;
            txt_pass.Text = Settings.Default.ftp_password;
            txt_folder.Text = Settings.Default.ftp_folder;
            
        }
    }
}
