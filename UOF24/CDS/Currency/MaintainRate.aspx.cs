using AngleSharp.Io;
using DocumentFormat.OpenXml.Bibliography;
using Ede.Uof.EIP.SystemInfo;
using Ede.Uof.Utility.Page;
using Ede.Uof.Utility.Page.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Data;
using Training.UCO;
using static SupportClass;

public partial class CDS_Currency_MaintainRate : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {


        ((Master_DialogMasterPage)this.Master).Button1OnClick += CDS_Currency_MaintainRate_Button1OnClick;
        ((Master_DialogMasterPage)this.Master).Button2OnClick += CDS_Currency_MaintainRate_Button2OnClick;

        if (!string.IsNullOrEmpty(Request.QueryString["CURRENCY_ID"]))
        {
            ((Master_DialogMasterPage)this.Master).Button2Text = "";
        }

        if (!IsPostBack)
        {
            InitData();

            if (!string.IsNullOrEmpty( Request.QueryString["CURRENCY_ID"]))
            {
                ddlCurrency.SelectedValue = Request.QueryString["CURRENCY_ID"];
                ddlYear.SelectedValue = Request.QueryString["Year"];
                ddlMonth.SelectedValue = Request.QueryString["Month"];
                rnumRate.Value = Convert.ToDouble(Request.QueryString["CURRENCY_RATE"]);
         
                ddlCurrency.Enabled = false;
                ddlYear.Enabled = false;
                ddlMonth.Enabled = false;

            }

         

        }
    }

    private void CDS_Currency_MaintainRate_Button2OnClick()
    {
    
            CreateRate();
        
           
    }

    private void UpdateRate()
    {
        DemoUCO uco = new DemoUCO();
        CurrenyDataSet ds = new CurrenyDataSet();
        CurrenyDataSet.TB_IAL_CURRENCY_RATERow dr = ds.TB_IAL_CURRENCY_RATE.NewTB_IAL_CURRENCY_RATERow();

        dr.CURRENCY_ID = ddlCurrency.SelectedValue;
        dr.CURRENCY_RATE = Convert.ToDecimal(rnumRate.Value);
        dr.Year = Convert.ToInt32(ddlYear.SelectedValue);
        dr.Month = Convert.ToInt32(ddlMonth.SelectedValue);
        dr.MODIFYER = Current.UserGUID;

        uco.UpdateCurrencyRate(dr);
        Dialog.SetReturnValue2("NeedPostBack");
    }

    private void CreateRate()
    {
        DemoUCO uco = new DemoUCO();
        CurrenyDataSet ds = new CurrenyDataSet();
        CurrenyDataSet.TB_IAL_CURRENCY_RATERow dr = ds.TB_IAL_CURRENCY_RATE.NewTB_IAL_CURRENCY_RATERow();

        dr.CURRENCY_ID = ddlCurrency.SelectedValue;
        dr.CURRENCY_RATE = Convert.ToDecimal(rnumRate.Value);
        dr.Year= Convert.ToInt32(ddlYear.SelectedValue);
        dr.Month= Convert.ToInt32(ddlMonth.SelectedValue);
        dr.MODIFYER = Current.UserGUID;

        uco.InsertCurrencyRate(dr);
        Dialog.SetReturnValue2("NeedPostBack");

    }

    private void CDS_Currency_MaintainRate_Button1OnClick()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["CURRENCY_ID"]))
        {
            UpdateRate();
        }
        else
        {
            CreateRate();
        }
    }

    private void InitData()
    {
        DemoUCO uco = new DemoUCO();
        ddlCurrency.DataSource = uco.GetCurrency().TB_IAL_CURRENCY;
        ddlCurrency.DataBind();

        ddlCurrency.Items.Insert(0, new ListItem(lblSelected.Text, ""));

        ddlYear.Items.Insert(0, new ListItem(lblSelected.Text, ""));
        ddlYear.Items.Add((DateTime.Today.Year-1).ToString());
        ddlYear.Items.Add((DateTime.Today.Year ).ToString());
        ddlYear.Items.Add((DateTime.Today.Year +1).ToString());

        for (int i = 1; i <= 12; i++)
        {
            ddlMonth.Items.Add(i.ToString());
        }
        ddlMonth.Items.Insert(0, new ListItem(lblSelected.Text, ""));

        ddlYear.SelectedValue = DateTime.Today.Year.ToString();
        ddlMonth.SelectedValue = DateTime.Today.Month.ToString();

    }
}