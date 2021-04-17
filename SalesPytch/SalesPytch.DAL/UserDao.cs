using System;
using SalesPytch.Model;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using SalesPytch.DAL.Contracts;
using System.Threading.Tasks;

namespace SalesPytch.DAL
{
    public class UserDao : IUserDao
    {
        string _connStrng = "";

        public UserDao(string connString)
        {
            _connStrng = connString;
        }

        public Task<User> ValidateUser(string emailAddress, string password)
        {
            User user = null;

            return Task<User>.Factory.StartNew(() =>
            {
                try
                {
                    using (SqlConnection sqlconnection = new SqlConnection(_connStrng))
                    {
                        DataSet dataset = new DataSet();
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = new SqlCommand("dbo.sp_ValidateUser", sqlconnection);
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        adapter.SelectCommand.Parameters.AddWithValue("@EmailAddress", emailAddress);
                        adapter.SelectCommand.Parameters.AddWithValue("@Password", password);
                        adapter.Fill(dataset);

                        if (dataset != null && dataset.Tables.Count > 0)
                        {
                            if (dataset.Tables[0] != null && dataset.Tables[0].Rows.Count > 0)
                            {
                                user = new User();

                                user.UserId = (int)dataset.Tables[0].Rows[0]["UserId"];
                                user.UserName = (dataset.Tables[0].Rows[0]["UserName"] != DBNull.Value ? (string)dataset.Tables[0].Rows[0]["UserName"] : null);
                                user.Password = (dataset.Tables[0].Rows[0]["Password"] != DBNull.Value ? (string)dataset.Tables[0].Rows[0]["Password"] : null);
                                user.EmailAddress = (dataset.Tables[0].Rows[0]["EmailAddress"] != DBNull.Value ? (string)dataset.Tables[0].Rows[0]["EmailAddress"] : null);
                                user.MobileNumber = (dataset.Tables[0].Rows[0]["MobileNumber"] != DBNull.Value ? (string)dataset.Tables[0].Rows[0]["MobileNumber"] : null);
                                user.IsProfileComplete = (dataset.Tables[0].Rows[0]["IsProfileComplete"] != DBNull.Value ? (bool)dataset.Tables[0].Rows[0]["IsProfileComplete"] : false);
                                user.IsActive = (dataset.Tables[0].Rows[0]["IsActive"] != DBNull.Value ? (bool)dataset.Tables[0].Rows[0]["IsActive"] : false);
                                user.Role.RoleId = (int)dataset.Tables[0].Rows[0]["RoleId"];
                                user.Role.RoleName = (dataset.Tables[0].Rows[0]["RoleName"] != DBNull.Value ? (string)dataset.Tables[0].Rows[0]["RoleName"] : null);
                            }
                        }

                    }
                    return user;

                }
                catch (SqlException ex)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            });
        }
            
    }

}
