using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELiSE
{
    public partial class BackgroundForm : Form
    {

        private BackgroundComponent Component;

        public BackgroundForm(BackgroundComponent component)
        {
            InitializeComponent();
            this.Component = component;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Start Optimization
            backgroundWorker.RunWorkerAsync(Component);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundGHController.RunLoop(sender, e);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MessageBox.Show("Juhu next Iteration:" + e.ProgressPercentage.ToString());
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
