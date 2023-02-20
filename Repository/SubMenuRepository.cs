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
    public class SubMenuRepository
    {

        static public string connectionString = @"data source=.; initial catalog=Homorodb;Integrated Security=True;";

        internal static eSubMenuModel GetSubMenu(string id)
        {
            string qry = "select * from Tbl_SubMenu where id='" + id + "'";
            var SubMenus = selectReadertodb(qry);
            SubMenus.Read();
            var SubMenusdetail = new eSubMenuModel();
            
            try
            {
               // title, body, groupType, description
                SubMenusdetail.Id = SubMenus["id"].ToString();
                SubMenusdetail.title = SubMenus["title"].ToString();
                SubMenusdetail.body = SubMenus["body"].ToString();
                SubMenusdetail.groupType = SubMenus["groupType"].ToString();
                SubMenusdetail.description = SubMenus["description"].ToString();
             
                SubMenusdetail.Code = StatusCodes.Status200OK;
            }
            catch
            {
                SubMenusdetail.Code = StatusCodes.Status422UnprocessableEntity;
            }
            return SubMenusdetail;
        }


        internal static List<eSubMenuModel> GetAllSubMenu()
        {
            string qry = "select * from Tbl_SubMenu";
            var SubMenus = selectReadertodb(qry);
            var SubMenulist = new List<eSubMenuModel>();
            while (SubMenus.Read())
            {
                var SubMenusdetail = new eSubMenuModel();
                try
                {
                    SubMenusdetail.Id = SubMenus["id"].ToString();
                    SubMenusdetail.title = SubMenus["title"].ToString();
                    SubMenusdetail.body = SubMenus["body"].ToString();
                    SubMenusdetail.groupType = SubMenus["groupType"].ToString();
                    SubMenusdetail.description = SubMenus["description"].ToString();
                    SubMenusdetail.Code = StatusCodes.Status200OK;
                }
                catch
                {
                    SubMenusdetail.Code = StatusCodes.Status422UnprocessableEntity;
                }
                SubMenulist.Add(SubMenusdetail);
            }
            return SubMenulist;
        }


        internal static int UpdateSubMenu(eSubMenuModel uu)
        {
            // title, body, groupType, description
            string qry = "update Tbl_SubMenu set" +
                " title='" + uu.title +
                "',body='" + uu.body +
                 "',groupType='" + uu.groupType +
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

        internal static int IsertSubMenu(eSubMenuModel uu)

        {
            //fullName, image, responsible, body, description
            // title, body, groupType, description
            string qry = "INSERT INTO Tbl_SubMenu" +
                "(title, body, groupType, description) VALUES(" +

                "'" + uu.title + "'," +
                "'" + uu.body + "'," +
                "'" + uu.groupType + "'," +
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


        internal static int DeleteSubMenu(string id)
        {
            //  DELETE TOP(5) PERCENT FROM Tbl_SubMenu;
            string qry = "DELETE from Tbl_SubMenu where id='" + id + "'";

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



