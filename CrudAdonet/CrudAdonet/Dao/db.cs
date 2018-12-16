using CrudAdonet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudAdonet.Dao
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);

        public void AddRecord(Customer customer)
        {
            SqlCommand com = new SqlCommand("Sp_Customer_Add", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FirstName",customer.FirstName);
            com.Parameters.AddWithValue("@LastName",customer.LastName);
            com.Parameters.AddWithValue("@Email",customer.Email);
            com.Parameters.AddWithValue("@MobileNumber",customer.MobileNumber);
            com.Parameters.AddWithValue("@Gender",customer.Gender);
            com.Parameters.AddWithValue("@DOB",customer.DOB);
            com.Parameters.AddWithValue("@Address",customer.Address);
            com.Parameters.AddWithValue("@IsActive",customer.IsActive);
            com.Parameters.AddWithValue("@CountryId",customer.CountryId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateRecord(Customer customer)
        {
            SqlCommand com = new SqlCommand("Sp_Customer_Update", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", customer.Id);
            com.Parameters.AddWithValue("@FirstName", customer.FirstName);
            com.Parameters.AddWithValue("@LastName", customer.LastName);
            com.Parameters.AddWithValue("@Email", customer.Email);
            com.Parameters.AddWithValue("@MobileNumber", customer.MobileNumber);
            com.Parameters.AddWithValue("@Gender", customer.Gender);
            com.Parameters.AddWithValue("@DOB", customer.DOB);
            com.Parameters.AddWithValue("@Address", customer.Address);
            com.Parameters.AddWithValue("@IsActive", customer.IsActive);
            com.Parameters.AddWithValue("@CountryId", customer.CountryId);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public DataSet ShowRecordById(int id)
        {
            SqlCommand com = new SqlCommand("Sp_Customer_Id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public void DeleteRecord(int id)
        {
            SqlCommand com = new SqlCommand("Sp_Customer_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public DataSet ShowAllRecordsActive(bool IsActive)
        {
            SqlCommand com = new SqlCommand("Sp_ActiveCustomers", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@IsActive", IsActive);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public DataSet ShowAllRecords()
        {
            SqlCommand com = new SqlCommand("Sp_Customers", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }


    }
}