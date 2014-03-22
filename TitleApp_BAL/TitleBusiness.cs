using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TitleApp_DAL;
namespace TitleApp_BAL
{
    public class TitleBusiness
    {
        public static DataSet Get_TitleByTitleNameBusiness(string strTitle)
        {
            try
            {
                DataSet dsTitleDetailBusiness = new DataSet();
                dsTitleDetailBusiness = TitleData.Get_TitleByTitleNameData(strTitle);
                return dsTitleDetailBusiness;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static DataSet Get_TitleDetailsByTitleIDBusiness(string strTitleID)
        {
            try
            {
                DataSet dsTitleDetailBusiness = new DataSet();
                dsTitleDetailBusiness = TitleData.Get_TitleDetailsByTitleIDData(strTitleID);
                return dsTitleDetailBusiness;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
