using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace GrasshopperAsync
{
    public class GrasshopperAsyncInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "GrasshopperAsync";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("3f901ed3-ffd3-4b87-9b8e-f4192250c41e");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
