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
    public partial class Usermaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    loadgrid();
                    
                    chkactive.Checked = true;

                }

            }
            catch (Exception ex)
            { }
        }
        

    

        public void loadgrid()
        {
            try
            {
                APIvalue api = new APIvalue();
                string str = api.CAllPostAPIusermaster(4, 0, txtuseremail.Text, "", "", "", "", false, "");
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
        public bool validatebuiling()
        {
            try
            {

                 if (txtuseremail.Text == "")
                {

                    lblerror.Text = "Username must be given";
                    return false;
                }
                else if (txtpassword.Text == "")
                {

                    lblerror.Text = "Password must be given";
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

        protected void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                if (validatebuiling() == true)
                {
                    if (btnadd.Text == "ADD")
                    {

                        APIvalue api = new APIvalue();
                        string str = api.CAllPostAPIusermaster(0, 0, txtuseremail.Text, "", "", "", "", false, "");
                        if (str == "")
                        {


                        }
                        else
                        {
                            bool ischecked = false;
                            if (chkactive.Checked == true) ischecked = true; else ischecked = false;
                            DataTable dt1 = (DataTable)JsonConvert.DeserializeObject(str, (typeof(DataTable)));
                            if (dt1.Rows.Count != 0)
                            {
                                lblerror.Text = "Entry for this User already exists, You cannot add";
                            }
                            else
                            {
                                string str1 = api.CAllPostAPIusermaster(1, 0, txtuseremail.Text, txtname.Text.ToUpper(), txtpassword.Text, ddllevel.SelectedValue, ddllevel.SelectedItem.Text, ischecked, txtreason.Text);
                                if (str1 == "")
                                {


                                }
                                else
                                {
                                    DataTable dt11 = (DataTable)JsonConvert.DeserializeObject(str1, (typeof(DataTable)));
                                    if (dt11.Rows.Count != 0)
                                    {
                                        if (dt11.Rows[0][0].ToString() == "0")
                                        {
                                            lblerror.Text = "Something went wrong, please contact administartor";
                                        }
                                        else
                                        {
                                            lblerror.Text = "";
                                            lblsuccess.Text = "Successfully added";
                                            ModalPopupExtender1.Show();
                                            clear();
                                            loadgrid();
                                        }
                                    }
                                }
                            }


                        }





                    }
                    if (btnadd.Text.ToUpper() == "UPDATE")
                    {
                        APIvalue api = new APIvalue();
                        string str = api.CAllPostAPIusermaster(3,Convert.ToInt32( lblbuildingid.Text), txtuseremail.Text, "", "", "", "", false, "");
                        if (str == "")
                        {

                            lblerror.Text = "invalid entry";
                        }
                        else
                        {
                            bool ischecked = false;
                            if (chkactive.Checked == true) ischecked = true; else ischecked = false;
                            DataTable dt1 = (DataTable)JsonConvert.DeserializeObject(str, (typeof(DataTable)));
                            if (dt1.Rows.Count == 0)
                            {
                                lblerror.Text = "Entry for this User doesnot exists, please check";
                            }
                            else
                            {
                                string str1 = api.CAllPostAPIusermaster(2, Convert.ToInt32(lblbuildingid.Text), txtuseremail.Text, txtname.Text.ToUpper(), txtpassword.Text, ddllevel.SelectedValue, ddllevel.SelectedItem.Text, ischecked, txtreason.Text);
                                if (str1 == "")
                                {

                                    lblerror.Text = "Something went wrong, please contact administartor";
                                }
                                else
                                {
                                    DataTable dt11 = (DataTable)JsonConvert.DeserializeObject(str1, (typeof(DataTable)));
                                    if (dt11.Rows.Count != 0)
                                    {
                                        if (dt11.Rows[0][0].ToString() != "1")
                                        {
                                            lblerror.Text = "Something went wrong, please contact administartor";
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
                }
                }catch { }

                }

        protected void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            try
            {
                btnadd.Text = "ADD";
                txtuseremail.Text = "";
                txtpassword.Text = "";
                txtname.Text = "";
                txtreason.Text = "";
                txtuseremail.Enabled = true;



            }
            catch
            {

            }
        }
        protected void gv1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
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
                //Determine the RowIndex of the Row whose LinkButton was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView1.Rows[rowIndex];

                //Fetch value of Name.
                string id = row.Cells[0].Text.ToString();

                APIvalue api = new APIvalue();
                string str = api.CAllPostAPIusermaster(3, Convert.ToInt32(id), "", "", "", "", "", false, "");
                if (str == "")
                {

                    lblerror.Text = "Contact admin";
                }
                else
                {
                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(str, (typeof(DataTable)));



                    if (dt.Rows.Count > 0)
                    {

                        txtuseremail.Text = dt.Rows[0]["username"].ToString();
                        txtpassword.Text = dt.Rows[0]["password"].ToString();
                        txtname.Text = dt.Rows[0]["Name"].ToString();
                        txtreason.Text = dt.Rows[0]["reason"].ToString();

                        if (dt.Rows[0]["isactive"].ToString() != "0")
                        {
                            chkactive.Checked = true;
                        }
                        else
                        {
                            chkactive.Checked = false;
                        }
                        ddllevel.SelectedValue = dt.Rows[0]["mode"].ToString();
                        lblbuildingid.Text = dt.Rows[0]["idusermaster"].ToString();


                        btnadd.Text = "Update";
                        txtuseremail.Enabled = false;

                        CollapsiblePanelExtender1.Collapsed = false;
                        CollapsiblePanelExtender1.ClientState = false.ToString().ToLower();
                    }

                }



            }
           
        }

        
    }
}