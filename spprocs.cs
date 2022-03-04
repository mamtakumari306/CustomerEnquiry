
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Customer_Details
{
    public class spprocs
    {
        String SqlconString = ConfigurationManager.ConnectionStrings["Mydb"].ConnectionString;
        public DataTable Checkcredential(int Pid, string username, string pwd)
        {


            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(SqlconString))
            {
                using (SqlCommand cmd = new SqlCommand("p_CheckCredential", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_pid", Pid);
                    cmd.Parameters.AddWithValue("p_email", username);
                    cmd.Parameters.AddWithValue("p_pawd", pwd);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dt);

                    }
                }
            }
            return dt;

        }

        public DataTable loginusermaster(int Pid, int userid, string p_username, string p_password, string p_Name, bool p_isactive, string p_mode, string p_role, string p_reason)
        {

            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(SqlconString))
            {
                using (SqlCommand cmd = new SqlCommand("p_CheckCredential", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_pid", Pid);
                    cmd.Parameters.AddWithValue("p_idusermaster", userid);
                    cmd.Parameters.AddWithValue("p_username", p_username);
                    cmd.Parameters.AddWithValue("p_Name", p_Name);
                    cmd.Parameters.AddWithValue("p_password", p_password);
                    cmd.Parameters.AddWithValue("p_mode", p_mode);
                    cmd.Parameters.AddWithValue("p_isactive", p_isactive);
                    cmd.Parameters.AddWithValue("p_role", p_role);
                    cmd.Parameters.AddWithValue("p_reason", p_reason);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dt);

                    }
                }
            }
            return dt;

        }


        public DataTable usermaster(int Pid,int userid,string p_username, string p_password, string p_Name, bool p_isactive, string p_mode, string p_role, string p_reason)
        {


            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(SqlconString))
            {
                using (SqlCommand cmd = new SqlCommand("p_usermaster", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_pid", Pid);
                    cmd.Parameters.AddWithValue("p_idusermaster", userid);
                    cmd.Parameters.AddWithValue("p_username", p_username);
                    cmd.Parameters.AddWithValue("p_Name", p_Name);
                    cmd.Parameters.AddWithValue("p_password", p_password);
                    cmd.Parameters.AddWithValue("p_mode", p_mode);
                    cmd.Parameters.AddWithValue("p_isactive", p_isactive);
                    cmd.Parameters.AddWithValue("p_role", p_role);
                    cmd.Parameters.AddWithValue("p_reason", p_reason);
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {

                        sda.Fill(dt);

                    }
                }
            }
            return dt;

        }

        public DataTable leadsCreation(int Pid, int leadid, string p_fullname, string p_phone1, string p_email, string p_dob, string p_details, string p_address)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_customerdetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_pid", Pid);
                        cmd.Parameters.AddWithValue("@p_id", leadid);
                        cmd.Parameters.AddWithValue("@p_fullname", checkempty(p_fullname));
                        cmd.Parameters.AddWithValue("@p_phone1", checkempty(p_phone1));
                        cmd.Parameters.AddWithValue("@p_email", checkempty(p_email));
                        cmd.Parameters.AddWithValue("@p_dob", checkempty(p_dob));
                        cmd.Parameters.AddWithValue("@p_details", checkempty(p_details));
                        cmd.Parameters.AddWithValue("@p_address", checkempty(p_address));
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);

                        }
                    }
                }
                return dt;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
        public string monthlyrental(int Pid, string p_year, string p_month, string p_tenantno, string p_idtenantmaster, string p_rentalamount, string p_recivedamount, string p_recieveddate,
            string p_recievedthrough, string p_qbankname, string p_chqdate, string p_chqcreditedon, string p_chqbouncedcarges, string p_transactionno, string p_addedby
            )
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_Rental", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_year", p_year);
                        cmd.Parameters.AddWithValue("p_month", p_month);
                        cmd.Parameters.AddWithValue("p_tenantno", p_tenantno);
                        cmd.Parameters.AddWithValue("p_idtenantmaster", p_idtenantmaster);
                        cmd.Parameters.AddWithValue("p_rentalamount", p_rentalamount);
                        cmd.Parameters.AddWithValue("p_recivedamount", p_recivedamount);
                        cmd.Parameters.AddWithValue("p_recieveddate", p_recieveddate);
                        cmd.Parameters.AddWithValue("p_recievedthrough", p_recievedthrough);
                        cmd.Parameters.AddWithValue("p_chqbankname", checkempty(p_qbankname));
                        cmd.Parameters.AddWithValue("p_chqdate", checkempty(p_chqdate));
                        cmd.Parameters.AddWithValue("p_chqcreditedon", checkempty(p_chqcreditedon));
                        cmd.Parameters.AddWithValue("p_chqbouncedcarges", checkempty(p_chqbouncedcarges));
                        cmd.Parameters.AddWithValue("p_transactionno", p_transactionno);
                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
                         result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                           
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                               

                                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                                {
                                    result = 1;

                                }
                            }
                        }
                        if (result > 0)
                        {
                            if (Pid == 1)
                            {
                                return "SUCCESS";
                            }
                            else
                            {
                                return "SUCCESS:this recorderd added SUCCESSfully";
                            }
                        }
                        else
                        {
                            if (Pid == 1)
                            {
                                return "FAILED";
                            }
                            else
                            {
                                return "Failed to submit, Contact a dminstartor";
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                return ex.Message + "Failed, Please contact administrator";
            }
            }
        public DataTable monthlyrentaldatatable(int Pid, string p_year, string p_month, string p_tenantno, string p_idtenantmaster, string p_rentalamount, string p_recivedamount, string p_recieveddate,
         string p_recievedthrough, string p_qbankname, string p_chqdate, string p_chqcreditedon, string p_chqbouncedcarges, string p_transactionno, string p_addedby
         )
        
        
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_Rental", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_year", p_year);
                        cmd.Parameters.AddWithValue("p_month", p_month);
                        cmd.Parameters.AddWithValue("p_tenantno", p_tenantno);
                        cmd.Parameters.AddWithValue("p_idtenantmaster", p_idtenantmaster);
                        cmd.Parameters.AddWithValue("p_rentalamount", checkempty(p_rentalamount));
                        cmd.Parameters.AddWithValue("p_recivedamount", checkempty(p_recivedamount));
                        cmd.Parameters.AddWithValue("p_recieveddate", checkempty(p_recieveddate));
                        cmd.Parameters.AddWithValue("p_recievedthrough", checkempty(p_recievedthrough));
                        cmd.Parameters.AddWithValue("p_chqbankname", checkempty(p_qbankname));
                        cmd.Parameters.AddWithValue("p_chqdate", checkempty(p_chqdate));
                        cmd.Parameters.AddWithValue("p_chqcreditedon", checkempty(p_chqcreditedon));
                        cmd.Parameters.AddWithValue("p_chqbouncedcarges", checkempty(p_chqbouncedcarges));
                        cmd.Parameters.AddWithValue("p_transactionno", p_transactionno);
                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                        }
                    }
                }
                return dt;
            }

            catch (Exception ex)
            {

                return null ;
            }
        }



        public string monthlymaintenance(int Pid, string p_year, string p_month, string p_Mtype, string p_meterno, string p_consumption, string p_previousreading, string p_presentreading,
          string p_billamount, string p_unit,string p_addedby, string p_buldingcode
          )
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_Maintenance", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_year", p_year);
                        cmd.Parameters.AddWithValue("p_month", p_month);
                        cmd.Parameters.AddWithValue("p_Mtype", p_Mtype);
                        cmd.Parameters.AddWithValue("p_meterno", checkempty(p_meterno ) );
                        cmd.Parameters.AddWithValue("p_consumption", checkempty(p_consumption));
                        cmd.Parameters.AddWithValue("p_previousreading", checkempty(p_previousreading));
                        cmd.Parameters.AddWithValue("p_presentreading", checkempty(p_presentreading));
                        cmd.Parameters.AddWithValue("p_billamount", checkempty(p_billamount));
                        cmd.Parameters.AddWithValue("p_unit", checkempty(p_unit));
                        
                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
                        cmd.Parameters.AddWithValue("p_buldingcode", p_buldingcode);
                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                       {

                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {


                                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                                {
                                    result = 1;

                                }
                            }
                        }
                        if (result > 0)
                        {
                            if (Pid == 1)
                            {
                                return "SUCCESS";
                            }
                            else
                            {
                                return "SUCCESS:this recorderd added SUCCESSfully";
                            }
                        }
                        else
                        {
                            if (Pid == 1)
                            {
                                return "FAILED";
                            }
                            else
                            {
                                return "Failed to submit, Contact a dminstartor";
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                return ex.Message + "Failed, Please contact administrator";
            }
        }
        public DataTable generateInvoice(int Pid, string p_year, string p_month, string p_idmAINTENANCEINVOICE, string p_buldingcode,
            string p_Generatedby
        )
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_Invoice", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_year", p_year);
                        cmd.Parameters.AddWithValue("p_month", p_month);
                        cmd.Parameters.AddWithValue("p_idmAINTENANCEINVOICE", p_idmAINTENANCEINVOICE);
                        cmd.Parameters.AddWithValue("p_buldingcode", checkempty(p_buldingcode));
                        cmd.Parameters.AddWithValue("p_Generatedby", checkempty(p_Generatedby));
                        



                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);

                        }

                    }
                }
                return dt;
            }

            catch (Exception ex)
            {

                return null;
            }
        }

        public DataTable monthlymaintenancedattable(int Pid, string p_year, string p_month, string p_Mtype, string p_meterno, string p_consumption, string p_previousreading, string p_presentreading,
         string p_billamount, string p_unit, string p_addedby, string p_buldingcode
         )
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_Maintenance", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_year", p_year);
                        cmd.Parameters.AddWithValue("p_month", p_month);
                        cmd.Parameters.AddWithValue("p_Mtype", p_Mtype);
                        cmd.Parameters.AddWithValue("p_meterno", checkempty(p_meterno));
                        cmd.Parameters.AddWithValue("p_consumption", checkempty(p_consumption));
                        cmd.Parameters.AddWithValue("p_previousreading", checkempty(p_previousreading));
                        cmd.Parameters.AddWithValue("p_presentreading", checkempty(p_presentreading));
                        cmd.Parameters.AddWithValue("p_billamount", checkempty(p_billamount));
                        cmd.Parameters.AddWithValue("p_unit", checkempty(p_unit));

                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
                        cmd.Parameters.AddWithValue("p_buldingcode", p_buldingcode);


                        
                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                           
                        }
                        
                    }
                }
                return dt;
            }

            catch (Exception ex)
            {

                return null;
            }
        }



        public string Uploaddocs(int Pid, string p_idtenantmaster, string p_DOCUMENTNAME, string p_documentnumber, string p_documentpath, string p_addedby
            
         )
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("Uploadsocs", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_idtenantmaster", p_idtenantmaster);
                        cmd.Parameters.AddWithValue("p_DOCUMENTNAME", p_DOCUMENTNAME);
                        cmd.Parameters.AddWithValue("p_documentnumber", p_documentnumber);
                        cmd.Parameters.AddWithValue("p_documentpath", checkempty(p_documentpath));
                  

                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
              
                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {


                                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                                {
                                    result = 1;

                                }
                            }
                        }
                        if (result > 0)
                        {
                            if (Pid == 1)
                            {
                                return "SUCCESS";
                            }
                            else
                            {
                                return "SUCCESS:this recorderd added SUCCESSfully";
                            }
                        }
                        else
                        {
                            if (Pid == 1)
                            {
                                return "FAILED";
                            }
                            else
                            {
                                return "Failed to submit, Contact a dminstartor";
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                return ex.Message + "Failed, Please contact administrator";
            }
        }
        public DataTable Uploaddocsdatatable(int Pid, string p_idtenantmaster, string p_DOCUMENTNAME, string p_documentnumber, string p_documentpath, string p_addedby

       )
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("Uploadsocs", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_idtenantmaster", p_idtenantmaster);
                        cmd.Parameters.AddWithValue("p_DOCUMENTNAME", p_DOCUMENTNAME);
                        cmd.Parameters.AddWithValue("p_documentnumber", p_documentnumber);
                        cmd.Parameters.AddWithValue("p_documentpath", checkempty(p_documentpath));


                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);

                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                           
                        }
                        
                    }
                }
                return dt;
            }
           
            catch (Exception ex)
            {

                return null;
            }
        }

        public string paymaintenance1(int Pid, string year, string month, string p_idtnantmaster, string p_addedby, string p_Actualamount,
            string p_amountobepaid, string p_paymentamount, string p_recievedon, string p_recievedthrough, string p_chqdate, string p_transactionno

       )
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("paymaintenance", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_year", year);
                        cmd.Parameters.AddWithValue("p_month", month);
                        cmd.Parameters.AddWithValue("p_idtnantmaster", p_idtnantmaster);
                        cmd.Parameters.AddWithValue("p_Actualamount", p_Actualamount);
                        cmd.Parameters.AddWithValue("p_amountobepaid", p_amountobepaid);
                        cmd.Parameters.AddWithValue("p_paymentamount", p_paymentamount);
                        cmd.Parameters.AddWithValue("p_balanceamount", "0");
                        cmd.Parameters.AddWithValue("p_recievedon", checkempty(p_recievedon));
                        cmd.Parameters.AddWithValue("p_recievedthrough", checkempty(p_recievedthrough));
                        cmd.Parameters.AddWithValue("p_chqdate", checkempty(p_chqdate));
                        cmd.Parameters.AddWithValue("p_transactionno", checkempty(p_transactionno));

                        cmd.Parameters.AddWithValue("p_addedby", checkempty(p_addedby));

                        

                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {


                                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                                {
                                    result = 1;

                                }
                            }
                        }
                        if (result > 0)
                        {
                            if (Pid == 1)
                            {
                                return "SUCCESS";
                            }
                            else
                            {
                                return "SUCCESS:this recorderd added SUCCESSfully";
                            }
                        }
                        else
                        {
                            if (Pid == 1)
                            {
                                return "FAILED";
                            }
                            else
                            {
                                return "Failed to submit, Contact a dminstartor";
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                return ex.Message + "Failed, Please contact administrator";
            }
        }
        public DataTable paymaintenance(int Pid, string year, string month, string p_idtnantmaster,string p_addedby, string p_Actualamount,
            string p_amountobepaid,string p_paymentamount,string p_recievedon, string p_recievedthrough, string p_chqdate, string p_transactionno
      )
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("paymaintenance", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_year", year);
                        cmd.Parameters.AddWithValue("p_month", month);
                        cmd.Parameters.AddWithValue("p_idtnantmaster", p_idtnantmaster);
                        cmd.Parameters.AddWithValue("p_Actualamount", p_Actualamount);
                        cmd.Parameters.AddWithValue("p_amountobepaid", p_amountobepaid);
                        cmd.Parameters.AddWithValue("p_paymentamount", p_paymentamount);
                        cmd.Parameters.AddWithValue("p_balanceamount", "0");
                        cmd.Parameters.AddWithValue("p_recievedon", checkempty(p_recievedon));
                        cmd.Parameters.AddWithValue("p_recievedthrough", checkempty(p_recievedthrough));
                        cmd.Parameters.AddWithValue("p_chqdate", checkempty(p_chqdate));
                        cmd.Parameters.AddWithValue("p_transactionno", checkempty(p_transactionno));
                     
                        cmd.Parameters.AddWithValue("p_addedby", checkempty(p_addedby));

                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);

                        }

                    }
                }
                return dt;
            }

            catch (Exception ex)
            {

                return null;
            }
        }

        public string tenants(int Pid, string p_buildingcode, string p_tenanthouseno, string p_Tenantname, string p_Aggrementname, string p_mobileno
            , string p_whatupno, string p_emailid, string p_contactpersonname, string p_contactpersonnumber, string p_advanceamount, string p_monthlyamount
            , string p_alternatephone, string p_alternatephone2, string p_alternatephone3, string p_Aggrementon, string p_nextincrementon, string p_rentalstarton
            , string p_incrementpercentate, string p_bankname, string p_bankaccountno, string p_bankifscno, string  p_residentailaddress, string p_addedby
            , string gstno, string panno, string email1,string email2,string email3,string startingrental


        )
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_tenant", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_buildingcode", p_buildingcode);
                        cmd.Parameters.AddWithValue("p_tenanthouseno", p_tenanthouseno);
                        cmd.Parameters.AddWithValue("p_Tenantname", p_Tenantname);
                        cmd.Parameters.AddWithValue("p_Aggrementname", checkempty(p_Aggrementname));
                        cmd.Parameters.AddWithValue("p_mobileno", checkempty(p_mobileno));
                        cmd.Parameters.AddWithValue("p_whatupno", checkempty(p_whatupno));
                        cmd.Parameters.AddWithValue("p_emailid", checkempty(p_emailid));
                        cmd.Parameters.AddWithValue("p_contactpersonname", checkempty(p_contactpersonname));
                        cmd.Parameters.AddWithValue("p_contactpersonnumber", checkempty(p_contactpersonnumber));
                        cmd.Parameters.AddWithValue("p_advanceamount", checkempty(p_advanceamount));
                        cmd.Parameters.AddWithValue("p_alternatephone", checkempty(p_alternatephone));
                        cmd.Parameters.AddWithValue("p_alternatephone2", checkempty(p_alternatephone2));
                        cmd.Parameters.AddWithValue("p_alternatephone3", checkempty(p_alternatephone3));
                        cmd.Parameters.AddWithValue("p_Aggrementon", checkempty(p_Aggrementon));
                        cmd.Parameters.AddWithValue("p_nextincrementon", checkempty(p_nextincrementon));
                        cmd.Parameters.AddWithValue("p_rentalstarton", checkempty(p_rentalstarton));
                        cmd.Parameters.AddWithValue("p_incrementpercentate", checkempty(p_incrementpercentate));
                        cmd.Parameters.AddWithValue("p_bankname", checkempty(p_bankname));
                        cmd.Parameters.AddWithValue("p_bankaccountno", checkempty(p_bankaccountno));
                        cmd.Parameters.AddWithValue("p_bankifscno", checkempty(p_bankifscno));
                        cmd.Parameters.AddWithValue("p_residentailaddress", checkempty(p_residentailaddress));
                        cmd.Parameters.AddWithValue("p_monthlyamount", checkempty(p_monthlyamount));
                        


                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
                        cmd.Parameters.AddWithValue("p_gstno", checkempty(gstno));
                        cmd.Parameters.AddWithValue("p_panno", checkempty(panno));
                        cmd.Parameters.AddWithValue("p_email1", checkempty(email1));
                        cmd.Parameters.AddWithValue("p_email2", checkempty(email2));
                        cmd.Parameters.AddWithValue("p_email3", checkempty(email3));

                        cmd.Parameters.AddWithValue("p_startingrental", checkempty(startingrental));
                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {


                                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                                {
                                    result = 1;

                                }
                            }
                        }
                        if (result > 0)
                        {
                            if (Pid == 1)
                            {
                                return "SUCCESS";
                            }
                            else
                            {
                                return "SUCCESS:this recorderd added SUCCESSfully";
                            }
                        }
                        else
                        {
                            if (Pid == 1)
                            {
                                return "FAILED";
                            }
                            else
                            {
                                return "FAILED to submit, Contact a dminstartor";
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                return ex.Message + "Failed, Please contact administrator";
            }
        }

        public DataTable tenantsdatatble(int Pid, string p_buildingcode, string p_tenanthouseno, string p_Tenantname, string p_Aggrementname, string p_mobileno
          , string p_whatupno, string p_emailid, string p_contactpersonname, string p_contactpersonnumber, string p_advanceamount, string p_monthlyamount
          , string p_alternatephone, string p_alternatephone2, string p_alternatephone3, string p_Aggrementon, string p_nextincrementon, string p_rentalstarton
          , string p_incrementpercentate, string p_bankname, string p_bankaccountno, string p_bankifscno, string p_residentailaddress, string p_addedby
            , string gstno, string panno, string email1, string email2, string email3,string startingrental


      )
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_tenant", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_buildingcode", p_buildingcode);
                        cmd.Parameters.AddWithValue("p_tenanthouseno", p_tenanthouseno);
                        cmd.Parameters.AddWithValue("p_Tenantname", p_Tenantname);
                        cmd.Parameters.AddWithValue("p_Aggrementname", checkempty(p_Aggrementname));
                        cmd.Parameters.AddWithValue("p_mobileno", checkempty(p_mobileno));
                        cmd.Parameters.AddWithValue("p_whatupno", checkempty(p_whatupno));
                        cmd.Parameters.AddWithValue("p_emailid", checkempty(p_emailid));
                        cmd.Parameters.AddWithValue("p_contactpersonname", checkempty(p_contactpersonname));
                        cmd.Parameters.AddWithValue("p_contactpersonnumber", checkempty(p_contactpersonnumber));
                        cmd.Parameters.AddWithValue("p_advanceamount", checkempty(p_advanceamount));
                        cmd.Parameters.AddWithValue("p_alternatephone", checkempty(p_alternatephone));
                        cmd.Parameters.AddWithValue("p_alternatephone2", checkempty(p_alternatephone2));
                        cmd.Parameters.AddWithValue("p_alternatephone3", checkempty(p_alternatephone3));
                        cmd.Parameters.AddWithValue("p_Aggrementon", checkempty(p_Aggrementon));
                        cmd.Parameters.AddWithValue("p_nextincrementon", checkempty(p_nextincrementon));
                        cmd.Parameters.AddWithValue("p_rentalstarton", checkempty(p_rentalstarton));
                        cmd.Parameters.AddWithValue("p_incrementpercentate", checkempty(p_incrementpercentate));
                        cmd.Parameters.AddWithValue("p_bankname", checkempty(p_bankname));
                        cmd.Parameters.AddWithValue("p_bankaccountno", checkempty(p_bankaccountno));
                        cmd.Parameters.AddWithValue("p_bankifscno", checkempty(p_bankifscno));
                        cmd.Parameters.AddWithValue("p_residentailaddress", checkempty(p_residentailaddress));
                        cmd.Parameters.AddWithValue("p_monthlyamount", checkempty(p_monthlyamount));

                        

                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
                        cmd.Parameters.AddWithValue("p_gstno", checkempty(gstno));
                        cmd.Parameters.AddWithValue("p_panno", checkempty(panno));
                        cmd.Parameters.AddWithValue("p_email1", checkempty(email1));
                        cmd.Parameters.AddWithValue("p_email2", checkempty(email2));
                        cmd.Parameters.AddWithValue("p_email3", checkempty(email3));

                        cmd.Parameters.AddWithValue("p_startingrental", checkempty(startingrental));


                        
                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                          
                        }
                       
                    }
                }
                return dt;
            }

            catch (Exception ex)
            {

                return null;
            }
        }
        public object checkempty(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str;
            }
            else
            {
                return DBNull.Value;
            }
        }
        public string spmaster(int Pid, int p_idbuildingid, string p_buildingcode, string p_buildingname, string p_buildingaddress,
            string p_buildingtype, string p_Block_floor, string p_house_flatno, string p_houseno, string p_carpetarea, string p_builduparea, string p_Superbuituparea,
            string p_addedby)
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_idbuildingid", p_idbuildingid);
                        cmd.Parameters.AddWithValue("p_buildingcode", p_buildingcode);
                        cmd.Parameters.AddWithValue("p_buildingname", checkempty(p_buildingname));
                       
                        cmd.Parameters.AddWithValue("p_buildingaddress", checkempty(p_buildingaddress));

                        cmd.Parameters.AddWithValue("p_buildingtype", checkempty(p_buildingtype));
                        cmd.Parameters.AddWithValue("p_Block_floor", checkempty(p_Block_floor));
                        cmd.Parameters.AddWithValue("p_house_flatno", checkempty(p_house_flatno));
                        cmd.Parameters.AddWithValue("p_houseno", checkempty(p_houseno));
                        cmd.Parameters.AddWithValue("p_carpetarea", checkempty(p_carpetarea));
                        cmd.Parameters.AddWithValue("p_builduparea", checkempty(p_builduparea));
                        cmd.Parameters.AddWithValue("p_Superbuituparea", checkempty(p_Superbuituparea));

                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {


                                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                                {
                                    result = 1;

                                }
                            }
                        }
                        if (result > 0)
                        {
                            if (Pid == 1)
                            {
                                return "SUCCESS";
                            }
                            else
                            {
                                return "SUCCESS:this recorderd added SUCCESSfully";
                            }
                        }
                        else
                        {
                            if (Pid == 1)
                            {
                                return "FAILED";
                            }
                            else
                            {
                                return "Failed to submit, Contact a dminstartor";
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                return ex.Message + "Failed, Please contact administrator";
            }
        }
        public DataTable spmasterdt(int Pid, int p_idbuildingid, string p_buildingcode, string p_buildingname, string p_buildingaddress,
                    string p_buildingtype, string p_Block_floor, string p_house_flatno, string p_houseno, string p_carpetarea, string p_builduparea, string p_Superbuituparea,
            string p_addedby)
        {
            try
            {


                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_master", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", Pid);
                        cmd.Parameters.AddWithValue("p_idbuildingid", p_idbuildingid);
                        cmd.Parameters.AddWithValue("p_buildingcode", p_buildingcode);
                        cmd.Parameters.AddWithValue("p_buildingname", checkempty(p_buildingname));

                        cmd.Parameters.AddWithValue("p_buildingaddress", checkempty(p_buildingaddress));
                        cmd.Parameters.AddWithValue("p_buildingtype", checkempty(p_buildingtype));
                        cmd.Parameters.AddWithValue("p_Block_floor", checkempty(p_Block_floor));
                        cmd.Parameters.AddWithValue("p_house_flatno", checkempty(p_house_flatno));
                        cmd.Parameters.AddWithValue("p_houseno", checkempty(p_houseno));
                        cmd.Parameters.AddWithValue("p_carpetarea", checkempty(p_carpetarea));
                        cmd.Parameters.AddWithValue("p_builduparea", checkempty(p_builduparea));
                        cmd.Parameters.AddWithValue("p_Superbuituparea", checkempty(p_Superbuituparea));
                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
                       
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                            return dt;
                        }
                        
                    }
                }
            }

            catch (Exception ex)
            {

                return null;
            }
        }




        public string sptaxmaster(int p_pid, int p_idTaxmaster, string p_effectivedate, string p_sgstpercentage, string p_cgstpercentage,
        string p_gstpercentage,        string p_addedby)
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_taxmaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", p_pid);
                        cmd.Parameters.AddWithValue("p_idTaxmaster", p_idTaxmaster);
                       
                        cmd.Parameters.AddWithValue("p_effectivedate", p_effectivedate);
                        cmd.Parameters.AddWithValue("p_sgstpercentage", p_sgstpercentage);
                        cmd.Parameters.AddWithValue("p_cgstpercentage",p_cgstpercentage);
                        cmd.Parameters.AddWithValue("p_gstpercentage", p_gstpercentage);


                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {


                                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                                {
                                    result = 1;

                                }
                            }
                        }
                        if (result > 0)
                        {
                            if (p_pid == 1)
                            {
                                return "SUCCESS";
                            }
                            else
                            {
                                return "SUCCESS:this recorderd added SUCCESSfully";
                            }
                        }
                        else
                        {
                            if (p_pid == 1)
                            {
                                return "FAILED";
                            }
                            else
                            {
                                return "Failed to submit, Contact a dminstartor";
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                return ex.Message + "Failed, Please contact administrator";
            }
        }


        public DataTable sptaxmasterdt(int p_pid, int p_idTaxmaster, string p_effectivedate, string p_sgstpercentage, string p_cgstpercentage,
    string p_gstpercentage, string p_addedby)
        {
            try
            {

                int result = 0;

                DataTable dt = new DataTable();
                using (SqlConnection con = new SqlConnection(SqlconString))
                {
                    using (SqlCommand cmd = new SqlCommand("p_taxmaster", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("p_pid", p_pid);
                        cmd.Parameters.AddWithValue("p_idTaxmaster", p_idTaxmaster);

                        cmd.Parameters.AddWithValue("p_effectivedate", p_effectivedate);
                        cmd.Parameters.AddWithValue("p_sgstpercentage", p_sgstpercentage);
                        cmd.Parameters.AddWithValue("p_cgstpercentage", checkempty(p_cgstpercentage));
                        cmd.Parameters.AddWithValue("p_gstpercentage", p_gstpercentage);



                        cmd.Parameters.AddWithValue("p_addedby", p_addedby);
                        result = 0;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {

                            sda.Fill(dt);
                            
                        }
                       
                    }
                }

                return dt;
            }

            catch (Exception ex)
            {

                return null;
            }
        }

    }
}