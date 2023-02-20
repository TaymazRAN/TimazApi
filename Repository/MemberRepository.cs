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

namespace HomoroApi.Repository
{
    public class MemberRepository
    {

        static public string connectionString = @"data source=.; initial catalog=Homorodb;Integrated Security=True;";

        internal static eMemberModel GetMember(string id)
        {
            string qry = "select * from Tbl_Member where id='" + id + "'";
            var Members = selectReadertodb(qry);
            Members.Read();
            var Membersdetail = new eMemberModel();
            
            try
            {
                //fullName, image, responsible, body, description
                Membersdetail.Id = Members["id"].ToString();
                Membersdetail.fullName = Members["fullName"].ToString();
                Membersdetail.image = Members["image"].ToString();
                Membersdetail.responsible = Members["responsible"].ToString();
                Membersdetail.body = Members["body"].ToString();
                Membersdetail.image = Members["description"].ToString();
                Membersdetail.Code = StatusCodes.Status200OK;
            }
            catch
            {
                Membersdetail.Code = StatusCodes.Status422UnprocessableEntity;
            }
            return Membersdetail;
        }


        internal static List<eMemberModel> GetAllMember()
        {
            string qry = "select * from Tbl_Member";
            var Members = selectReadertodb(qry);
            var Memberlist = new List<eMemberModel>();
            while (Members.Read())
            {
                var Membersdetail = new eMemberModel();
                try
                {
                    Membersdetail.Id = Members["id"].ToString();
                    Membersdetail.fullName = Members["fullName"].ToString();
                    Membersdetail.image = Members["image"].ToString();
                    Membersdetail.responsible = Members["responsible"].ToString();
                    Membersdetail.body = Members["body"].ToString();
                    Membersdetail.image = Members["description"].ToString();
                    Membersdetail.Code = StatusCodes.Status200OK;
                }
                catch
                {
                    Membersdetail.Code = StatusCodes.Status422UnprocessableEntity;
                }
                Memberlist.Add(Membersdetail);
            }
            return Memberlist;
        }


        internal static int UpdateMember(eMemberModel uu)
        {
            //fullName, image, responsible, body, description
            string qry = "update Tbl_Member set" +
                " fullName='" + uu.fullName +
                "',image='" + uu.image +
                 "',responsible='" + uu.responsible + "'" +
                 "',body='" + uu.body + "'" +
                 "',description='" + uu.description + "'" +
                
                " where id='" +uu.Id+"'";
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

        internal static int IsertMember(eMemberModel uu)

        {
            //fullName, image, responsible, body, description
            string qry = "INSERT INTO Tbl_Member" +
                "(fullName, image, responsible, body, description) VALUES(" +

                "'" + uu.fullName + "'," +
                "'" + uu.image + "'," +
                "'" + uu.responsible + "'," +
                "'" + uu.body + "'," +
                "'" + uu.description + "'" + 
                 ")";
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


        internal static int DeleteMember(string id)
        {
            //  DELETE TOP(5) PERCENT FROM Tbl_Member;
            string qry = "DELETE from Tbl_Member where id='" + id + "'";

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



