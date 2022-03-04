using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customer_Details
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (Session["user1"] != null)
                    {
                        username.Text = (string)Session["user1"];
                        username1.Text = (string)Session["user1"];

                    }



                }

            }
            catch (Exception ex)
            { }

        }
        protected void anchorlogout_ServerClick(object sender, EventArgs e)
        {
            Session.Clear();

            Session.Abandon();
            Response.Redirect("Default.aspx");

        }
    }
}