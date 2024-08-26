using Ede.Uof.EIP.AddressBook;
using Ede.Uof.Utility.Page;
using Ede.Uof.Utility.Page.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Training.UCO;

public partial class CDS_WKF_Fields_MaintainItem : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Master_DialogMasterPage)this.Master).Button1OnClick += CDS_WKF_Fields_MaintainItem_Button1OnClick;
        ((Master_DialogMasterPage)this.Master).Button2OnClick += CDS_WKF_Fields_MaintainItem_Button2OnClick;

        if(!IsPostBack)
        {
            BindDDL();

            XElement xe = new XElement("FieldValue");
            txtFieldValue.Text= xe.ToString();    
        }
    }

    private void CDS_WKF_Fields_MaintainItem_Button2OnClick()
    {
        AddItem();
    }

    private void AddItem()
    {
        XElement itemXe = new XElement("Item",
            new XAttribute("id", Guid.NewGuid().ToString()),
            new XAttribute("currencyID",ddlCurrency.SelectedValue),
             new XAttribute("currencyName", ddlCurrency.SelectedItem.Text),
              new XAttribute("item", txtItem.Text),
               new XAttribute("rate", rnumRate.Value.ToString()),
                new XAttribute("amount", rnumAmount.Value.ToString()),
                 new XAttribute("amountByNTD", rnumAmountByNTD.Value.ToString())
            );

        XElement xe = XElement.Parse(txtFieldValue.Text);
        xe.Add(itemXe);

        Dialog.SetReturnValue2(xe.ToString());

        txtFieldValue.Text = xe.ToString();
    }

    private void CDS_WKF_Fields_MaintainItem_Button1OnClick()
    {
        AddItem();
    }

    private void BindDDL()
    {
        DemoUCO uco = new DemoUCO();

        ddlCurrency.DataSource = uco.GetCurrency().TB_IAL_CURRENCY;
        ddlCurrency.DataBind();

        ddlCurrency.Items.Insert(0, new ListItem(lblSelected.Text, ""));
    }

    protected void ddlCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        DemoUCO uco = new DemoUCO();
        decimal rate = uco.GetCurrentRate(ddlCurrency.SelectedValue, DateTime.Today.Year.ToString(),
            DateTime.Today.Month.ToString());

        rnumRate.Value = Convert.ToDouble(rate);

        rnumAmountByNTD.Value = Convert.ToDouble(rnumAmount.Value) * Convert.ToDouble(rnumRate.Value);
    }

    protected void rnumAmount_TextChanged(object sender, EventArgs e)
    {

       rnumAmountByNTD.Value = Convert.ToDouble(rnumAmount.Value) * Convert.ToDouble(rnumRate.Value);
    }
}