using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using static System.Console;

namespace RestaurantSystem.AccessLayer
{
    public class RestaurantDataAccessLayer
    {
        string connString = "Data Source=MC1JUNB251;Initial Catalog=datapool;User ID=sa;Password=pass@word1";
        public void RegisterUser()
        {
            WriteLine("enter userid :");
            int userId = Convert.ToInt32(ReadLine());
            WriteLine("enter first name :");
            string firstName = ReadLine();
            WriteLine("enter last name ");
            string lastName = ReadLine();
            WriteLine("enter gender");
            string gender = ReadLine();
            WriteLine("enter date of birth");
            string book_date = ReadLine();
            WriteLine("enter email");
            string email = ReadLine();
            WriteLine("enter password ");
            string password = ReadLine();






            using (SqlConnection conection = new SqlConnection(connString))
            {
                string spName = "Register";

                //set sqlCommand object 
                SqlCommand cmd = new SqlCommand(spName, conection);

                //set sqlparameter 
                SqlParameter param1 = new SqlParameter { ParameterName = "@userid", SqlDbType = SqlDbType.Int, Value = userId, Direction = ParameterDirection.Input };
                cmd.Parameters.Add(param1);
                SqlParameter param2 = new SqlParameter { ParameterName = "@firstName", SqlDbType = SqlDbType.VarChar, Value = firstName, Direction = ParameterDirection.Input };
                cmd.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter { ParameterName = "@LastName", SqlDbType = SqlDbType.VarChar, Value = lastName, Direction = ParameterDirection.Input };
                cmd.Parameters.Add(param3);
                SqlParameter param4 = new SqlParameter { ParameterName = "@gender", SqlDbType = SqlDbType.VarChar, Value = gender, Direction = ParameterDirection.Input };
                cmd.Parameters.Add(param4);
                SqlParameter param5 = new SqlParameter { ParameterName = "book_date", SqlDbType = SqlDbType.Date, Value = book_date, Direction = ParameterDirection.Input };
                cmd.Parameters.Add(param5);
                SqlParameter param6 = new SqlParameter { ParameterName = "email", SqlDbType = SqlDbType.VarChar, Value = email, Direction = ParameterDirection.Input };
                cmd.Parameters.Add(param6);
                SqlParameter param7 = new SqlParameter { ParameterName = "@Pasword", SqlDbType = SqlDbType.VarChar, Value = password, Direction = ParameterDirection.Input };
                cmd.Parameters.Add(param7);

                //open connection
                conection.Open();

                //set sqlCommand type to stored procedure and execute 
                cmd.CommandType = CommandType.StoredProcedure;

                //SqlDataReader reader = cmd.ExecuteReader();
                int status;
                status = Convert.ToInt32(cmd.ExecuteScalar());
                if (status == 1)
                {
                    WriteLine("Already Present");
                }
                else
                {
                    WriteLine("Registered");
                }
            }

        }



        public int Login(int flag)
        {

            WriteLine("Enter email ");
            string email = ReadLine();
            WriteLine("Enter password");
            string password = ReadLine();

            try
            {

                using (SqlConnection conection = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("Login", conection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param1 = new SqlParameter { ParameterName = "@email", SqlDbType = SqlDbType.Int, Value = email, Direction = ParameterDirection.Input };
                    cmd.Parameters.Add(param1);
                    SqlParameter param2 = new SqlParameter { ParameterName = "@password", SqlDbType = SqlDbType.VarChar, Value = password, Direction = ParameterDirection.Input };
                    cmd.Parameters.Add(param2);
                    conection.Open();

                    int result;
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result == 1)
                    {
                        WriteLine("login sucessfull");
                        flag = 1;
                    }
                    else
                    {
                        WriteLine("Invalid Credential");
                    }

                }
            }
            catch (Exception e)
            {
                WriteLine("", e.Message);
            }
            return flag;
        }

        //DISPLAYALL
        public void DisplayAllRestaurant()
        {
            SqlConnection con = new SqlConnection(connString);
            SqlDataAdapter da = new SqlDataAdapter("select * from restaurant", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            WriteLine("---------Library table-----------");
            foreach (DataRow row in dt.Rows)
            {
                WriteLine("restaurant_id:{0} ,resName-{1} , resCity-{2}", row[0], row[1], row[2]);
            }

        }
        //SEARCH RESTAURANT
        public void SearchRestaurant()
        {
            WriteLine("eneter the restaurant id which you want to search ");
            int search_rid = Convert.ToInt32(ReadLine());


            SqlConnection con = new SqlConnection(connString);
            string querySearch = "select * from restaurant where restaurant_id = " + search_rid;
            con.Open();

        }
        public void CancelRestaurant()
        {
            WriteLine("eneter the restaurant id which you want to delete");
            int delete_resid = Convert.ToInt32(ReadLine());

            SqlConnection con = new SqlConnection(connString);s
            string  deleteQuerry = "Delete from restaurant where restaurant_id =" + delete_resid; 
            con.Open();
            SqlCommand deleteCommand = new SqlCommand(deleteQuerry, con);
            deleteCommand.ExecuteNonQuery();
            WriteLine("Deletion is sucessful");
            con.Close();

        }
    }
}
