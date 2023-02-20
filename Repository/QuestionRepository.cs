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
    public class QuestionRepository
    {

        static public string connectionString = @"data source=.; initial catalog=Homorodb;Integrated Security=True;";

        internal static eQuestionModel GetQuestion(string id)
        {
            string qry = "select * from Tbl_Question where id='" + id + "'";
            var Questions = selectReadertodb(qry);
            Questions.Read();
            var Questionsdetail = new eQuestionModel();
            try
            {
                Questionsdetail.Id = Questions["id"].ToString();
                Questionsdetail.Answer = Questions["Answer"].ToString();
                Questionsdetail.Question = Questions["Question"].ToString();
                Questionsdetail.Code = StatusCodes.Status200OK;
            }
            catch
            {
                Questionsdetail.Code = StatusCodes.Status422UnprocessableEntity;
            }
            return Questionsdetail;
        }


        internal static List<eQuestionModel> GetAllQuestion()
        {
            string qry = "select * from Tbl_Question";
            var Questions = selectReadertodb(qry);
            var Questionlist = new List<eQuestionModel>();
            while (Questions.Read())
            {
                var Questionsdetail = new eQuestionModel();
                try
                {
                    Questionsdetail.Id = Questions["id"].ToString();
                    Questionsdetail.Answer = Questions["Answer"].ToString();
                    Questionsdetail.Question = Questions["Question"].ToString();
                    Questionsdetail.Code = StatusCodes.Status200OK;
                }
                catch
                {
                    Questionsdetail.Code = StatusCodes.Status422UnprocessableEntity;
                }
                Questionlist.Add(Questionsdetail);
            }
            return Questionlist;
        }


        internal static int UpdateQuestion(eQuestionModel uu)
        {
            string qry = "update Tbl_Question set" +
                " Answer='" + uu.Answer+ 
                "',Question='" + uu.Question+
                 "',groupType='" + uu.groupType + "'" +
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

        internal static int IsertQuestion(eQuestionModel uu)

        {
            string qry = "INSERT INTO Tbl_Question" +
                "(Question,groupType ,Answer) VALUES(" +

                "'"+ uu.Question+ "'," +
                "'" + uu.groupType + "'," +
                "'" +uu.Answer+"'" +
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


        internal static int DeleteQuestion(string id)
        {
            //  DELETE TOP(5) PERCENT FROM Tbl_Question;
            string qry = "DELETE from Tbl_Question where id='" + id + "'";

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



