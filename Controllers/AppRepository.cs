using CryptoExchange.Net.CommonObjects;
using HomoroApi.Models;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Serializers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using Skender.Stock.Indicators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace HomoroApi.Controllers
{
    public class AppRepository
    {

        static public string connectionString = @"data source=.; initial catalog=Homorodb;Integrated Security=True;";

        internal static eUserModel GetUser(string id)
        {
            string qry = "select * from tblTimaz where id='" + id + "'";
            var users = selectReadertodb(qry);
            users.Read();
            var usersdetail = new eUserModel();
            try
            {
                usersdetail.Id = users["id"].ToString();
                usersdetail.FirstName = users["firstname"].ToString();
                usersdetail.LastName = users["lastname"].ToString();
                usersdetail.Code = StatusCodes.Status200OK;
            }
            catch
            {
                usersdetail.Code = StatusCodes.Status422UnprocessableEntity;
            }
            return usersdetail;
        }


        internal static List<eUserModel> GetAllUser()
        {
            string qry = "select * from tblTimaz";
            var users = selectReadertodb(qry);
            var userlist = new List<eUserModel>();
            while (users.Read())
            {
                var usersdetail = new eUserModel();
                try
                {
                    usersdetail.Id = users["id"].ToString();
                    usersdetail.FirstName = users["firstname"].ToString();
                    usersdetail.LastName = users["lastname"].ToString();
                    usersdetail.Code = StatusCodes.Status200OK;
                }
                catch
                {
                    usersdetail.Code = StatusCodes.Status422UnprocessableEntity;
                }
                userlist.Add(usersdetail);
            }
            return userlist;
        }


        internal static int UpdateUser(eUserModel uu)
        {
            string qry = "update tblTimaz set firstname='"+uu.FirstName+"',lastname='"+uu.LastName+"' where id='"+uu.Id+"'";
            int code = 200;
            try
            {
                Updatedb(qry);
            }
            catch
            {
                code = 422;
            }
            return code;
        }

        internal static int IsertUser(eUserModel uu)

        {
            string qry = "INSERT INTO tblTimaz(FirstName,LastName) VALUES('" + uu.FirstName+ "','" + uu.LastName+ "')";
            int code = 200;
            try
            {
                Updatedb(qry);
            }
            catch
            {
                code = 422;
            }
            return code;
        }


        internal static int DeleteUser(string id)
        {
            //  DELETE TOP(5) PERCENT FROM tblTimaz;
            string qry = "DELETE from tblTimaz where id='" + id + "'";

            int code = 200;
            try
            {
                Updatedb(qry);
            }
            catch
            {
                code = 422;
            }
            return code;
        }
        static public SqlDataReader selectReadertodb(string selectquery)
        {
            SqlDataReader result = null;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(selectquery, conn);
            try
            {
                result = command.ExecuteReader();
                //result.Read();
            }
            catch { }
            //conn.Close();
            return result;
        }

        static public int Updatedb(string uquery)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(uquery, conn);
            result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }


    }
}



