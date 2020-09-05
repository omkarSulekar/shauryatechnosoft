using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_MicroServices.Models;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Npgsql;

namespace API_MicroServices
{
    public class CRUDOperations
    {
        public static string strConnectionString = "User ID=postgres;Password=password;Host=localhost;Port=5432;Database=microdb;";
        public static IEnumerable<User> GetGroupMeetings()
        {
            List<User> groupMeetingsList = new List<User>();

            using (IDbConnection con = new SqlConnection(strConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                groupMeetingsList = con.Query<User>("GetGroupMeetingDetails").ToList();
            }

            return groupMeetingsList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public static IDbConnection OpenConnection(string connStr)
        {
            var conn = new NpgsqlConnection(connStr);
            conn.Open();
            return conn;
        }

        public bool InsertRecord(User objeUser)
        {

            bool isInserted = false;
            try
            {
                using (var conn = OpenConnection(strConnectionString))
                {
                    var insertSQL = string.Format(@"INSERT INTO public.tblUser (userid , Name , Mobile , Organization , Address , Email , Location , Photopath )
VALUES({0}, '{1}', '{2}','{3}','{4}','{5}','{6}','{7}');",objeUser.userid,objeUser.Name,objeUser.Mobile,objeUser.Organization,objeUser.Address,objeUser.Email,objeUser.Location,objeUser.Photopath);
                    var res = conn.Execute(insertSQL);
                    isInserted = true;
                }
            }
            catch (Exception ex)
            {

            }

            return isInserted;
        }

        public List<Vehicle> GetVehicleList(searchModel SCModel)
        {
            List<Vehicle> lstVehicle = new List<Vehicle>();
            using (var conn = OpenConnection(strConnectionString))
            {
                string querySQL = string.Empty;
                if (SCModel.VehicleNumber != 0)
                {
                    querySQL = string.Format(@"SELECT * from tblVehicle where VehicleNumber ={0};", SCModel.VehicleNumber);
                    List<Vehicle> lstVehiclewithVNO = conn.Query<Vehicle>(querySQL).ToList();
                    lstVehicle.AddRange(lstVehiclewithVNO);
                }
                if (!string.IsNullOrEmpty(SCModel.VehicleType))
                {
                    querySQL = string.Format(@"SELECT * from tblVehicle where VehicleType ='{0}';", SCModel.VehicleType);
                    List<Vehicle> lstVehiclewithVT = conn.Query<Vehicle>(querySQL).ToList();
                    lstVehicle.AddRange(lstVehiclewithVT);
                }
                if (!string.IsNullOrEmpty(SCModel.EngineNumber))
                {
                    querySQL = string.Format(@"SELECT * from tblVehicle where EngineNumber ='{0}';", SCModel.EngineNumber);
                    List<Vehicle> lstVehiclewithVT = conn.Query<Vehicle>(querySQL).ToList();
                    lstVehicle.AddRange(lstVehiclewithVT);
                }

            }
            return lstVehicle.Distinct().ToList();
        }
    }
}
