using Newtonsoft.Json;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace Customer_Details
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadgrid();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (validatebuiling() == true)
                {
                    if (btnadd.Text == "ADD")
                    {
                        APIvalue api = new APIvalue();
                        string str = api.CAllPostAPILeads(0, 0, txtname.Text, "", "", "", "", "");
                        if (str == "")
                        {
                            lblerror.Text = "Something went wrong, please contact administrator";
                        }
                        else
                        {
                            DataTable dt1 = (DataTable)JsonConvert.DeserializeObject(str, (typeof(DataTable)));
                            if (dt1.Rows.Count != 0)
                            {
                                lblerror.Text = "Entry for this Customer already exists, You cannot add";
                            }
                            else
                            {
                                string str1 = api.CAllPostAPILeads(1, 0, txtname.Text.ToUpper(), txtphone1.Text, txtmail.Text,
                                     txtdob.Text,  txtdetails.Text,txtaddress.Text);
                                if (str1 == "")
                                {
                                    lblerror.Text = "Something went wrong, please contact administrator";
                                }
                                else
                                {
                                    DataTable dt11 = (DataTable)JsonConvert.DeserializeObject(str1, (typeof(DataTable)));
                                    if (dt11.Rows.Count == 0)
                                    {
                                        lblerror.Text = "";
                                        lblsuccess.Text = "Successfully added";
                                        ModalPopupExtender1.Show();
                                        clear();
                                        loadgrid();
                                    }
                                    else
                                    {
                                        lblerror.Text = "Something went wrong, please contact administrator";
                                    }
                                    
                                }
                            }

                        }

                    }
                    if (btnadd.Text.ToUpper() == "UPDATE")
                    {
                        APIvalue api = new APIvalue();
                        string str = api.CAllPostAPILeads(3, Convert.ToInt32(lblbuildingid.Text), txtname.Text, "", "", "", "", "");
                        if (str == "")
                        {
                            lblerror.Text = "invalid entry";
                        }
                        else
                        {

                            DataTable dt1 = (DataTable)JsonConvert.DeserializeObject(str, (typeof(DataTable)));
                            if (dt1.Rows.Count == 0)
                            {
                                lblerror.Text = "Entry for this Customer doesnot exists, please check";
                            }
                            else
                            {
                                string str1 = api.CAllPostAPILeads(2, Convert.ToInt32(lblbuildingid.Text), txtname.Text, txtphone1.Text, txtmail.Text, 
                                    txtdob.Text, txtdetails.Text, txtaddress.Text);
                                if (str1 == "")
                                {
                                    lblerror.Text = "Something went wrong, please contact administrator";
                                }
                                else
                                {
                                    lblerror.Text = "";
                                    lblsuccess.Text = "Successfully updated";
                                    ModalPopupExtender1.Show();
                                    clear();
                                    loadgrid();
                                }
                            }

                        }

                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            loadgrid();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int _id = Convert.ToInt32(e.CommandArgument);

                //GridViewRow row = GridView1.Rows[rowIndex];
                //string id = row.Cells[0].Text.ToString();
               
                APIvalue api = new APIvalue();
                string str = api.CAllPostAPILeads(3, Convert.ToInt32(_id), "", "", "", "", "","");
                if (str == "")
                {

                    lblerror.Text = "Contact admin";
                }
                else
                {
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(str, (typeof(DataTable)));

                    if (dt.Rows.Count > 0)
                    {

                        txtname.Text = dt.Rows[0]["fullname"].ToString();
                        txtphone1.Text = dt.Rows[0]["phone1"].ToString();
                        txtmail.Text = dt.Rows[0]["email"].ToString();
                        txtdetails.Text = dt.Rows[0]["details"].ToString();
                        if (dt.Rows[0]["dob"].ToString() != "")
                        {
                            DateTime _pDate = Convert.ToDateTime(dt.Rows[0]["dob"]);
                            txtdob.Text = String.Format("{0:yyyy-MM-dd}", _pDate);
                        }
                        else
                        {
                            txtdob.Text = "";
                        }
                        txtaddress.Text = dt.Rows[0]["address"].ToString();
                        lblbuildingid.Text = dt.Rows[0]["id"].ToString();

                        btnadd.Text = "Update";
                        txtname.Enabled = false;

                        CollapsiblePanelExtender1.Collapsed = false;
                        CollapsiblePanelExtender1.ClientState = false.ToString().ToLower();
                    }

                }

            }

        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        #endregion
        #region Methods
        public bool validatebuiling()
        {
            try
            {

                if (txtname.Text == "")
                {

                    lblerror.Text = "Full name must be given";
                    return false;
                }
                else if (txtphone1.Text == "")
                {

                    lblerror.Text = "Phone must be given";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                lblerror.Text = ex.Message;
                return false;
            }
        }
        public void loadgrid()
        {
            try
            {
                APIvalue api = new APIvalue();
                string str = api.CAllPostAPILeads(4, 0, txtname.Text, "", "", "", "", "");
                if (str == "")
                {
                    GridView1.DataSource = null;

                    GridView1.EmptyDataText = "No Data Found";

                    GridView1.DataBind();

                }
                else
                {

                    DataTable dt1 = (DataTable)JsonConvert.DeserializeObject(str, (typeof(DataTable)));


                    if (dt1.Rows.Count == 0)
                    {
                        GridView1.DataSource = null;

                        GridView1.EmptyDataText = "No Data Found";

                        GridView1.DataBind();
                    }
                    else
                    {
                        GridView1.Columns[0].Visible = true;
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                        GridView1.Columns[0].Visible = false;
                    }
                }
            }
            catch (Exception ex) { }
        }
        public void clear()
        {
            try
            {
                txtname.Enabled = true;
                btnadd.Text = "ADD";
                txtdob.Text = "";
                txtaddress.Text = "";
                txtname.Text = "";
               
                txtmail.Text = "";
   
                txtphone1.Text = "";
                
                lblerror.Text = "";
      
                txtdetails.Text = "";
               

            }
            catch
            {

            }
        }
        #endregion
    }
}