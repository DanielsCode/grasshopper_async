using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrasshopperAsync
{
    internal static class BackgroundGHController
    {
        private static BackgroundWorker Worker;


        public static void RunLoop(object sender, DoWorkEventArgs e)
        {

            //Get worker and component
            Worker = sender as BackgroundWorker;
            var component = (BackgroundComponent)e.Argument;

            if (component == null)
            {
                MessageBox.Show("Component Error");
                return;
            }

            GH_Document Doc = component.OnPingDocument();

            for (int i = 0; i < 10; i++)
            {
                if (Worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                Doc.NewSolution(true);

                //Wait until the grasshopper solution in finished
                while (Doc.SolutionState != GH_ProcessStep.PostProcess || Doc.SolutionDepth != 0) { }
                
                //Set progress
                Worker.ReportProgress((i+1) * 10);
            }
        }
    }
}
