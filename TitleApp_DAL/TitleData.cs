using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace TitleApp_DAL
{
    public class TitleData
    {
        public static DataSet Get_TitleByTitleNameData(string strTitle)
        {

            DataSet dsTitle = new DataSet();
            string strStatus = string.Empty;
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString_Turner"].ConnectionString;
            SqlConnection connection = new SqlConnection(connString);
            //##################Please see my comment below#######################
            //I normally don't write inline queries but since i had to submit the stored procedure in mdf file i thought for now it would be easier if i use inline
            string sql = @"select distinct t.TitleId, t.TitleName, t.ReleaseYear, s.Language from Title t join StoryLine s on t.TitleId = s.TitleId where TitleName like '%" + strTitle + "%'";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command = new SqlCommand(sql, connection);
            connection.Open();
            try
            {
                
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dsTitle);

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                connection.Close();

            }

            return dsTitle;
        }


        public static DataSet Get_TitleDetailsByTitleIDData(string strTitleID)
        {

            DataSet dsTitleDetails = new DataSet();
            string strStatus = string.Empty;
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString_Turner"].ConnectionString;
            SqlConnection connection = new SqlConnection(connString);
            //##################Please see my comment below#######################
            //I normally don't use inline queries but since i had to submit the stored procedure in mdf file i thought for now it would be easier if i use inline
            string sql = @"select distinct t.TitleId, t.TitleName, t.ReleaseYear, s.Language from Title t join StoryLine s on t.TitleId = s.TitleId where t.TitleID ='" + strTitleID + "'";
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command = new SqlCommand(sql, connection);
            connection.Open();
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dsTitleDetails);

            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
                connection.Close();

            }

            return dsTitleDetails;
        }
    }
}
