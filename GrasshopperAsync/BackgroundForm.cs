using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrasshopperAsync
{
    public partial class BackgroundForm : Form
    {

        private BackgroundComponent Component;
        private bool IsRunning = false;

        public BackgroundForm(BackgroundComponent component)
        {
            InitializeComponent();
            this.Component = component;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsRunning) {
            
                //Start Solutions
                backgroundWorker.RunWorkerAsync(Component);
                button.Text = "Cancel";
                IsRunning = true;
            }
            else
            {
                if (button.Text == "Cancel")
                {
                    if (backgroundWorker.IsBusy)
                    {
                        backgroundWorker.CancelAsync();
                    }
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundGHController.RunLoop(sender, e);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled) 
            {
                MessageBox.Show("Simulation canceled");
            }
            else
            {
                MessageBox.Show("Simulation finished");
            }
            button.Text = "Run Simulation";
            IsRunning = false;
            progressBar1.Value = 0;
        }
    }
}
