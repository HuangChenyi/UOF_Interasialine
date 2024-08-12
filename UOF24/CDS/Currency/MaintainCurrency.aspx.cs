
using Ede.Uof.EIP.SystemInfo;
using Ede.Uof.Utility.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Data;
using Training.UCO;

public partial class CDS_Currency_MaintainCurrency : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ((Master_DialogMasterPage)this.Master).Button1Text = "";
        ((Master_DialogMasterPage)this.Master).Button2Text = "";
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    private void BindGrid()
    {
        DemoUCO uco = new DemoUCO();
        CurrenyDataSet ds = uco.GetCurrency();
        grid.DataSource = ds.TB_IAL_CURRENCY;
        grid.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CurrenyDataSet ds = new CurrenyDataSet();
        CurrenyDataSet.TB_IAL_CURRENCYRow row = ds.TB_IAL_CURRENCY.NewTB_IAL_CURRENCYRow();
        row.CURRENCY_ID = txtCuurencyID.Text;
        row.CURRENCY_NAME=txtCuurencyName.Text;
        row.MODIFYER = Current.UserGUID;

        DemoUCO uco = new DemoUCO();
        uco.InsertCurrency(row);

        BindGrid();
        txtCuurencyID.Text = "";    
        txtCuurencyName.Text = "";
    }

    protected void btnDelte_Click(object sender, EventArgs e)
    {
        string[] ids = grid.GetSelectedRowGUIDs();
        DemoUCO uco = new DemoUCO();

        foreach (string id in ids)
        {
            uco.DeleteCurrency(id);
        }

        BindGrid();
    }

    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        BindGrid();
    }
}