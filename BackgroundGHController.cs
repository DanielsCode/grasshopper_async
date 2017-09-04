using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELiSE
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
            // Slider Change (still todo)


            for (int i = 0; i < 10; i++)
            {
                // Wait until the grasshopper solution in finished
                // while (Doc.SolutionState != GH_ProcessStep.PreProcess || Doc.SolutionDepth != 0) { }

                var strMessage = "Starting new solution" + Environment.NewLine;
                MessageBox.Show(strMessage);

                Doc.NewSolution(true);

                strMessage = "Started new solution" + Environment.NewLine;
                MessageBox.Show(strMessage);

                //Wait until the grasshopper solution in finished
                while (Doc.SolutionState != GH_ProcessStep.PostProcess || Doc.SolutionDepth != 0) { }

                Worker.ReportProgress(i * 10);
            }
        }
    }
}
