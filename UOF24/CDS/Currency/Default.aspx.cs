using Ede.Uof.Utility.Page;
using Ede.Uof.Utility.Page.Common;
using Google.Apis.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.UCO;

public partial class CDS_Currency_Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        DemoUCO uco=new DemoUCO();
        grid.DataSource=uco.GetCurrencyRate().TB_IAL_CURRENCY_RATE;
        grid.DataBind();
    }

    protected void toolBar_ButtonClick(object sender, Telerik.Web.UI.RadToolBarEventArgs e)
    {
        if(e.Item.Value == "Rate")
        {
            
        }

        BindGrid();
    }

    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView row= (DataRowView)e.Row.DataItem;
            LinkButton lbtnCurrency=(LinkButton)e.Row.FindControl("lbtnCurrency");

            ExpandoObject param = new {
                CURRENCY_ID = row["CURRENCY_ID"].ToString(),
                Year = row["YEAR"].ToString(),
                Month = row["MONTH"].ToString(),
                CURRENCY_RATE = row["CURRENCY_RATE"].ToString()
            }.ToExpando();

            Dialog.Open2(lbtnCurrency,
                "~/CDS/Currency/MaintainRate.aspx",
                "維護匯率", 600, 400,
                 Dialog.PostBackType.AfterReturn, param);

            //e.Row.Attributes.Add("ondblclick", "OpenEditPage('" + grid.DataKeys[e.Row.RowIndex].Value + "')");
        }
    }

    protected void grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName== "lbtnCurrency")
        {
            BindGrid();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}