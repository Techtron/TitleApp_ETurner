using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections.Specialized;
using System.Collections;
using System.Configuration;
using TitleApp_BAL;

namespace TitleApp_ETurner
{
    public partial class Title : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "")
            {
                Session["Title"] = txtTitle.Text.Trim();
                DataSet dsTitleDetails = GetData(txtTitle.Text.Trim());
                if (dsTitleDetails != null)
                {
                    if (dsTitleDetails.Tables.Count > 0)
                    {
                        pnlResults.Visible = true;
                        gvSearchResults.DataSource = dsTitleDetails;
                        gvSearchResults.DataBind();
                    }
                    else
                    {
                        pnlResults.Visible = false;
                    }

                }
                else
                {
                    pnlResults.Visible = false;
                }
            }
        }

        protected DataSet GetData(string strTitleName)
        {
            DataSet dsTitleDetails = TitleBusiness.Get_TitleByTitleNameBusiness(txtTitle.Text.Trim());
            return dsTitleDetails;
           
        }

        
        protected void gvSearchResults_RowCommand(Object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "NodeSelected")
            {
                int RowIndex = int.Parse(e.CommandArgument.ToString());// Current row
                GridViewRow row = gvSearchResults.Rows[RowIndex];
                LinkButton lbtnTitleId = (LinkButton)row.FindControl("lbtnSelect");
                TitleInfo title = new TitleInfo();
                title.TitleID = lbtnTitleId.Text;

                    
                    pnlSearch.Visible = false;
                    pnlTitleDetail.Visible = true;


                    LoadTitleDetail(title.TitleID);
                   

                
               
            }
        }

        protected void LoadTitleDetail(string strTitleID)
        {
            if (strTitleID != "")
            {
                DataSet dsTitleDetail = TitleBusiness.Get_TitleDetailsByTitleIDBusiness(strTitleID);
                if (dsTitleDetail != null)
                {
                    if (dsTitleDetail.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dsTitleDetail.Tables[0].Rows)
                        {
                            lblTitleID.Text = strTitleID;
                            if (dr["TitleID"] != null) { lblTitleID.Text = dr["TitleID"].ToString(); }
                            if (dr["TitleName"] != null) { lblTitleName.Text = dr["TitleName"].ToString(); }
                            if (dr["ReleaseYear"] != null) { lblReleaseYear.Text = dr["ReleaseYear"].ToString(); }
                            if (dr["Language"] != null) { lblLanguage.Text = dr["Language"].ToString(); }
                        }
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            pnlTitleDetail.Visible = false;
            pnlSearch.Visible = true;
        }
        protected void gvSearchResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Session["searched_grid_page"] = e.NewPageIndex.ToString();
            gvSearchResults.PageIndex = e.NewPageIndex;
            gvSearchResults.DataBind();
            if (Session["Title"] == null)
            {
                lblMessage.Text = "Session Timed Out.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                GetData(Session["Title"].ToString());
            }
            
        }
        protected void gvSearchResults_OnSorting(object sender, GridViewSortEventArgs e)
        {
            if (Session["Title"] == null)
            {
                lblMessage.Text = "Session Timed Out.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                DataSet ds = GetData(Session["Title"].ToString());

                if (ds != null)
                {

                    DataView dview = ds.Tables[0].DefaultView;
                    if (Session["sort"] == null || Session["sort"].ToString() == "ASC")
                    {
                        e.SortDirection = SortDirection.Ascending;
                        dview.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                        Session["sort"] = "DESC";
                    }
                    else
                    {
                        e.SortDirection = SortDirection.Descending;
                        dview.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
                        Session["sort"] = "ASC";
                    }


                    gvSearchResults.DataSource = dview;
                    gvSearchResults.DataBind();
                }
            }
        }

        protected string ConvertSortDirectionToSql(SortDirection sDirection)
        {
            string newSortDirection = string.Empty;
            switch (sDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "DESC";
                    break;
                case SortDirection.Descending:
                    newSortDirection = "ASC";
                    break;
                default:
                    break;
            }
            return newSortDirection;
        }

       
       }
}