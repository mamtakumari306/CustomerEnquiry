using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Customer_Details.Controllers
{
    public class getinputs
    {
        public string UNO { get; set; }
        public string Leadid { get; set; }
        public string fullname { get; set; }

    }
    public class usermaster
    {
        public string UNO { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string mode { get; set; }
        public string role { get; set; }
        public string isactive { get; set; }
        public string reason { get; set; }

    }

    public class leads
    {
        public string UNO { get; set; }
        public string id { get; set; }
        public string fullname { get; set; }
        public string phone1 { get; set; }
        public string email { get; set; }
        public string dob { get; set; }
        public string details { get; set; }
        public string address { get; set; }

    }

    public class ValuesController : ApiController
    {
        //// GET: api/Values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Values/5
       [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Values

        


        [HttpPost]
        public DataTable TASK([FromBody]getinputs value)
        {

            try
            {
                DataTable dt = new DataTable();
                string str = "";
                if ((value.UNO=="2") || (value.UNO == "3"))
                {
                   
                   APIvalue  aPIvalue = new APIvalue();
                    dt = aPIvalue.getleadtasklist(Convert.ToInt32( value.UNO), value.Leadid);
                }
                
                return dt;
            }
            catch { return null; }
        }

        [HttpPost]
        public DataTable USER([FromBody] usermaster value)
        {

            try
            {
                DataTable dt = new DataTable();
                string str = "";


                APIvalue aPIvalue = new APIvalue();
                dt = aPIvalue.SPUSERMASTER(Convert.ToInt32(value.UNO), Convert.ToInt32(value.userid), value.username, value.password, value.name, Convert.ToBoolean(value.isactive), value.mode, value.role, value.reason);




                return dt;
            }
            catch { return null; }
        }
        [HttpPost]
        public DataTable USERLOGIN([FromBody] usermaster value)
        {
            try
            {
                DataTable dt = new DataTable();
                string str = "";

                APIvalue aPIvalue = new APIvalue();
                dt = aPIvalue.LoadUserLogin(Convert.ToInt32(value.UNO),value.username, value.password, value.mode, value.role);

                return dt;
            }
            catch { return null; }
        }

        [HttpPost]
        public DataTable LEADS([FromBody] leads value)
        {

            try
            {
                DataTable dt = new DataTable();
                string str = "";


                APIvalue aPIvalue = new APIvalue();
                dt = aPIvalue.SPLEADS(Convert.ToInt32(value.UNO), Convert.ToInt32(value.id), value.fullname, value.phone1,value.email,value.dob,value.details,value.address);


                return dt;
            }
            catch { return null; }
        }
        // PUT: api/Values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Values/5
        public void Delete(int id)
        {
        }
    }
}
