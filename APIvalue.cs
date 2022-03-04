using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Customer_Details
{
    public class APIvalue
    {
        public DataTable getleadtasklist(int id, string value)
        {
            try
            {
                return loadgrid(id, value);

            }
            catch
            {
                return null;
            }
        }
        public string CAllPostAPI(string UniqueID,  string leadid, string fullname)
        {
            string results;



            try
            {
                string handlerUrl = ConfigurationManager.AppSettings.Get("baseurl").ToString();

                handlerUrl = handlerUrl.Replace("Default.aspx", "");

                handlerUrl = handlerUrl + "api/Values/TASK";



                var request = (HttpWebRequest)WebRequest.Create(handlerUrl);

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                // trust sender
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, cert, chain, errors) => cert.Subject.Contains(handlerUrl));
                // validate cert by calling a function
                //ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var postData = "UNO=" + Uri.EscapeDataString(UniqueID.ToString());
                postData += "&Leadid=" + Uri.EscapeDataString(leadid.ToString());
                postData += "&fullname=" + Uri.EscapeDataString(fullname.ToString());



                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";



                request.ContentType = "application/x-www-form-urlencoded";

                request.ContentLength = data.Length;

                request.KeepAlive = false;



                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                results = responseString;

            }
            catch (Exception ex)
            {
                results = "";
            }
            return results;
        }


        public string CAllPostAPILoginCredential(int UNO, string username, string password,string mode,string role)
        {
            string results;

            try
            {
                string handlerUrl = ConfigurationManager.AppSettings.Get("baseurl").ToString();

                handlerUrl = handlerUrl.Replace("Default.aspx", "");

                handlerUrl = handlerUrl + "api/Values/USERLOGIN";


                var request = (HttpWebRequest)WebRequest.Create(handlerUrl);

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                // trust sender
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, cert, chain, errors) => cert.Subject.Contains(handlerUrl));
                // validate cert by calling a function
                //ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var postData = "UNO=" + Uri.EscapeDataString(UNO.ToString());
                
                postData += "&username=" + Uri.EscapeDataString(username.ToString());

                postData += "&password=" + Uri.EscapeDataString(password.ToString());
                postData += "&mode=" + Uri.EscapeDataString(mode.ToString());
                postData += "&role=" + Uri.EscapeDataString(role.ToString());
               




                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";



                request.ContentType = "application/x-www-form-urlencoded";

                request.ContentLength = data.Length;

                request.KeepAlive = false;



                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                results = responseString;

            }
            catch (Exception ex)
            {
                results = "";
            }
            return results;
        }

        public string CAllPostAPIusermaster(int UNO , int userid ,string username ,string name , string password ,string mode ,string role ,bool isactive ,string reason )
        {
            string results;

            try
            {
                string handlerUrl = ConfigurationManager.AppSettings.Get("baseurl").ToString();

                handlerUrl = handlerUrl.Replace("Default.aspx", "");

                handlerUrl = handlerUrl + "api/Values/USER";


                var request = (HttpWebRequest)WebRequest.Create(handlerUrl);

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                // trust sender
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, cert, chain, errors) => cert.Subject.Contains(handlerUrl));
                // validate cert by calling a function
                //ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var postData = "UNO=" + Uri.EscapeDataString(UNO.ToString());
                postData += "&userid=" + Uri.EscapeDataString(userid.ToString());
                postData += "&username=" + Uri.EscapeDataString(username.ToString());
                postData += "&name=" + Uri.EscapeDataString(name.ToString());
                postData += "&password=" + Uri.EscapeDataString(password.ToString());
                postData += "&mode=" + Uri.EscapeDataString(mode.ToString());
                postData += "&role=" + Uri.EscapeDataString(role.ToString());
                postData += "&isactive=" + Uri.EscapeDataString(isactive.ToString());
                postData += "&reason=" + Uri.EscapeDataString(reason.ToString());
               



                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";



                request.ContentType = "application/x-www-form-urlencoded";

                request.ContentLength = data.Length;

                request.KeepAlive = false;



                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                results = responseString;

            }
            catch (Exception ex)
            {
                results = "";
            }
            return results;
        }
        
        public DataTable loadgrid( int id, string value)
        {
            try
            {
                spprocs sp = new spprocs();
                DataTable dt = new DataTable();

                dt = sp.Checkcredential(id, value, "");
                
                return dt;
            }
            catch (Exception ex) { return null; }
        }
        public DataTable SPUSERMASTER(int Pid, int userid, string p_username, string p_password, string p_Name, bool p_isactive, string p_mode, string p_role, string p_reason)
        {
            try
            {
                spprocs sp = new spprocs();
                DataTable dt = new DataTable();

                dt = sp.usermaster( Pid,  userid,  p_username,  p_password,  p_Name,  p_isactive,  p_mode,  p_role,  p_reason);



                return dt;
            }
            catch (Exception ex) { return null; }
        }

        public DataTable LoadUserLogin(int Pid, string p_username, string p_password, string p_mode, string p_role)
        {
            try
            {
                spprocs sp = new spprocs();
                DataTable dt = new DataTable();

                dt = sp.Checkcredential(Pid, p_username, p_password);
                return dt;
            }
            catch (Exception ex) { return null; }
        }



        public string CAllPostAPILeads(int UNO, int userid, string fullname, string phone1, string email,string dob, string details, string address)
        {
            string results;

            try
            {
                string handlerUrl = ConfigurationManager.AppSettings.Get("baseurl").ToString();

                handlerUrl = handlerUrl.Replace("Default.aspx", "");

                handlerUrl = handlerUrl + "api/Values/LEADS";

                var request = (HttpWebRequest)WebRequest.Create(handlerUrl);

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
                // trust sender
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, cert, chain, errors) => cert.Subject.Contains(handlerUrl));
                // validate cert by calling a function
                //ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                var postData = "UNO=" + Uri.EscapeDataString(UNO.ToString());
                postData += "&id=" + Uri.EscapeDataString(userid.ToString());
                postData += "&fullname=" + Uri.EscapeDataString(fullname.ToString());
                postData += "&phone1=" + Uri.EscapeDataString(phone1.ToString());
                postData += "&email=" + Uri.EscapeDataString(email.ToString());
                postData += "&dob=" + Uri.EscapeDataString(dob.ToString());
                postData += "&details=" + Uri.EscapeDataString(details.ToString());
                postData += "&address=" + Uri.EscapeDataString(address.ToString());

                
                var data = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";

                request.ContentType = "application/x-www-form-urlencoded";

                request.ContentLength = data.Length;

                request.KeepAlive = false;



                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                results = responseString;

            }
            catch (Exception ex)
            {
                results = "";
            }
            return results;
        }

        public DataTable SPLEADS(int Pid, int userid, string fullname, string phone1, string email, string dob, string Details,string address  )
        {
            try
            {
                spprocs sp = new spprocs();
                DataTable dt = new DataTable();

                dt = sp.leadsCreation(Pid, userid,  fullname,  phone1,  email, dob, Details,address);



                return dt;
            }
            catch (Exception ex) { return null; }
        }


    }
}