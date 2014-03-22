using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TitleApp_ETurner.Forms
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkMainHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Title.aspx");
        }
    }
}