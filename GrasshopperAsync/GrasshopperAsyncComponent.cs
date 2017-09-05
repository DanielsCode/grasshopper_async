using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Grasshopper.Kernel.Attributes;
using Grasshopper.GUI.Canvas;
using Grasshopper.GUI;
using System.Windows.Forms;

namespace GrasshopperAsync
{
    
    public class BackgroundComponent : GH_Component
    {

        private BackgroundForm _optimizationWindow;


        /// <summary>
        /// Initializes a new instance of the BackgroundComponent class.
        /// </summary>
        public BackgroundComponent()
            : base("Background Async", "Background Async Test",
                      "Creates a dummy background async test",
                      "Params", "Util")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("231e24b6-8715-4de6-a36c-d58a37fbd4b3"); }
        }

        public override void CreateAttributes()
        {
            m_attributes = new AttributesA(this);
        }

        private class AttributesA : GH_ComponentAttributes
        {
            public AttributesA(IGH_Component component)
                : base(component)
            {
            }

            public override GH_ObjectResponse RespondToMouseDoubleClick(GH_Canvas sender, GH_CanvasMouseEvent e)
            {
                ((BackgroundComponent)Owner).ShowOptimizationWindow();
                return GH_ObjectResponse.Handled;
            }
        }

        public void ShowOptimizationWindow()
        {

            var owner = Grasshopper.Instances.DocumentEditor;

            if (_optimizationWindow == null || _optimizationWindow.IsDisposed)
            {
                _optimizationWindow = new BackgroundForm(this) { StartPosition = FormStartPosition.Manual };

                GH_WindowsFormUtil.CenterFormOnWindow(_optimizationWindow, owner, true);
                owner.FormShepard.RegisterForm(_optimizationWindow);

            }
            _optimizationWindow.Show(owner);
        }
    }


}
