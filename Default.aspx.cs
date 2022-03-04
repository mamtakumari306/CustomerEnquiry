using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customer_Details
{
    public partial class Default : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtemail.Focus();
                }
            }
            catch ( Exception ex){}
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtemail.Text.ToLower().Trim() == "")
                {
                    lblerror.Text = "Username must be given";

                }
                else
                if (txtpassword.Text.ToLower() == "")
                {
                    lblerror.Text = "Password must be given";
                }
                else
                {
                    APIvalue api = new APIvalue();
                    string str = api.CAllPostAPILoginCredential(0, txtemail.Text,txtpassword.Text, "", "");
                    if (str == "")
                    {
                        lblerror.Text = "Invalid Credential";
                    }
                    else
                    {
                        DataTable dt1 = (DataTable)JsonConvert.DeserializeObject(str, (typeof(DataTable)));
                        if (dt1.Rows.Count == 0)
                        {
                            lblerror.Text = "Invalid Credential";
                        }
                        else
                        {
                            DataTable _dt = (DataTable)JsonConvert.DeserializeObject(str, (typeof(DataTable)));
                            if (_dt.Rows.Count != 0)
                            {
                                if (_dt.Rows[0][0].ToString() == "0")
                                {
                                    lblerror.Text = "Invalid Credential";
                                }
                                else
                                {
                                    Response.Redirect("CustomerDetails.aspx", false);
                                }
                            }
                            
                        }

                    }

                }

            }
            catch(Exception ex) { }
        }
        #endregion
    }
}