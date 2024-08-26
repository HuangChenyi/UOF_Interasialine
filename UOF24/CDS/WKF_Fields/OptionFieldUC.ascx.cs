using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Ede.Uof.WKF.Design;
using System.Collections.Generic;
using Ede.Uof.WKF.Utility;
using Ede.Uof.EIP.Organization.Util;
using Ede.Uof.WKF.Design.Data;
using Ede.Uof.WKF.VersionFields;
using System.Xml;
using System.Linq;
using Ede.Uof.Utility.Page.Common;
using System.Xml.Linq;
using Training.UCO;

public partial class WKF_OptionalFields_OptionFieldUC : WKF_FormManagement_VersionFieldUserControl_VersionFieldUC
{

	#region ==============公開方法及屬性==============
    //表單設計時
	//如果為False時,表示是在表單設計時
    private bool m_ShowGetValueButton = true;
    public bool ShowGetValueButton
    {
        get { return this.m_ShowGetValueButton; }
        set { this.m_ShowGetValueButton = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
		//這裡不用修改
		//欄位的初始化資料都到SetField Method去做
        SetField(m_versionField);
    }    


    /// <summary>
    /// 外掛欄位的條件值(多條件)
    /// </summary>
    public override string ConditionValue
    {
        get
        {
			//此字串的內容將會被表單拿來當做條件判斷的值
            XmlDocument returnXmlDoc = new XmlDocument();
            XmlElement returnValueElement = returnXmlDoc.CreateElement("ReturnValue");

            returnXmlDoc.AppendChild(returnValueElement);
            XmlElement Amount_USDElement = returnXmlDoc.CreateElement("Amount_USD");
            returnValueElement.AppendChild(Amount_USDElement);
            //加入Amount_USD Tag的條件
            Amount_USDElement.InnerText = "";

            XmlElement Amount_NTDElement = returnXmlDoc.CreateElement("Amount_NTD");
            returnValueElement.AppendChild(Amount_NTDElement);
            //加入Amount_NTD Tag的條件
            Amount_NTDElement.InnerText = "";

            return returnXmlDoc.OuterXml;
        }
    }

    /// <summary>
    /// 是否被修改
    /// </summary>
    public override bool IsModified
    {
        get
        {
			//請自行判斷欄位內容是否有被修改
			//有修改回傳True
			//沒有修改回傳False
            //若實作產品標準的控制修改權限必需實作
            //一般是用 m_versionField.FieldValue (表單開啟前的值)
            //      和this.FieldValue (當前的值) 作比對
			return false;
        }
    }

    /// <summary>
    /// 查詢顯示的標題
    /// </summary>
    public override string DisplayTitle
    {
        get
        {
			//表單查詢或WebPart顯示的標題
			//回傳字串
            return String.Empty;
        }
    }

    /// <summary>
    /// 訊息通知的內容
    /// </summary>
    public override string Message
    {
        get
        {
			//表單訊息通知顯示的內容
			//回傳字串
            return String.Empty;
        }
    }


    /// <summary>
    /// 真實的值
    /// </summary>
    public override string RealValue
    {
        get
        {
            //回傳字串
            //取得表單欄位簽核者的UsetSet字串
            //內容必須符合EB UserSet的格式
            return UC_ChoiceList.XML;
        }
        set
        {
			//這個屬性不用修改
            base.m_fieldValue = value;
        }
    }


    /// <summary>
    /// 欄位的內容
    /// </summary>
    public override string FieldValue
    {
        get
        {
            //回傳字串
			//取得表單欄位填寫的內容

            XElement xe = XElement.Parse(txtFieldValue.Text);
            xe.SetAttributeValue("user", UC_ChoiceList.XML);
            xe.SetAttributeValue("amountByUSD", lblUSD.Text);
            xe.SetAttributeValue("amountByNTD", lblNTD.Text);

            txtFieldValue.Text = xe.ToString();

            return xe.ToString();
        }
        set
        {
			//這個屬性不用修改
            base.m_fieldValue = value;
        }
    }

    /// <summary>
    /// 是否為第一次填寫
    /// </summary>
    public override bool IsFirstTimeWrite
    {
        get
        {
            //這裡請自行判斷是否為第一次填寫
            //若實作產品標準的控制修改權限必需實作
            //實作此屬性填寫者可修改也才會生效
            //一般是用 m_versionField.Filler == null(沒有記錄填寫者代表沒填過)
            //      和this.FieldValue (當前的值是否為預設的空白) 作比對
            return false;
        }
        set
        {
            //這個屬性不用修改
            base.IsFirstTimeWrite = value;
        }
    }

    /// <summary>
    /// 設定元件狀態
    /// </summary>
    /// <param name="Enabled">是否啟用輸入元件</param>
    public void EnabledControl(bool Enabled)
    {

    }

    /// <summary>
    /// 顯示時欄位初始值
    /// </summary>
    /// <param name="versionField">欄位集合</param>
    public override void SetField(Ede.Uof.WKF.Design.VersionField versionField)
    {
        FieldOptional fieldOptional = versionField as FieldOptional;

        if (fieldOptional != null)
        {

            //若有擴充屬性，可以用該屬性存取
            // fieldOptional.ExtensionSetting

            Dialog.Open2(btnAdd,"~/CDS/WKF_Fields/MaintainItem.aspx",
                "維護品項" , 800,600, Dialog.PostBackType.AfterReturn);


            if(!IsPostBack)
            {
                XElement xe;
                if(string.IsNullOrEmpty(fieldOptional.FieldValue))
                {
                    xe= new XElement("FieldValue");
                    txtFieldValue.Text = xe.ToString(); 
                }
                else
                {
                    txtFieldValue.Text = fieldOptional.FieldValue;
                    xe= XElement.Parse(fieldOptional.FieldValue);
                    UC_ChoiceList.XML = xe.Attribute("user").Value;
                    lblUSD.Text = xe.Attribute("amountByUSD").Value;
                    lblNTD.Text = xe.Attribute("amountByNTD").Value;
                    BindGrid();
                }

            }

            switch(fieldOptional.FieldMode)
            {
                case FieldMode.Print:
                case FieldMode.View:
                    //觀看和列印都需作沒有權限的處理
                    EnabledControl(false);
                    break;

            }
            
            #region ==============屬性說明==============『』
			//fieldOptional.IsRequiredField『是否為必填欄位,如果是必填(True),如果不是必填(False)』
			//fieldOptional.DisplayOnly『是否為純顯示,如果是(True),如果不是(False),一般在觀看表單及列印表單時,屬性為True』
			//fieldOptional.HasAuthority『是否有填寫權限,如果有填寫權限(True),如果沒有填寫權限(False)』
			//fieldOptional.FieldValue『如果已有人填寫過欄位,則此屬性為記錄其內容』
			//fieldOptional.FieldDefault『如果欄位有預設值,則此屬性為記錄其內容』
			//fieldOptional.FieldModify『是否允許修改,如果允許(fieldOptional.FieldModify=FieldModifyType.yes),如果不允許(fieldOptional.FieldModify=FieldModifyType.no)』
			//fieldOptional.Modifier『如果欄位有被修改過,則Modifier的內容為EBUser,如果沒有被修改過,則會等於Null』
            #endregion

            #region ==============如果有修改，要顯示修改者資訊==============
            if (fieldOptional.Modifier != null)
            {
                lblModifier.Visible = true;
                lblModifier.ForeColor = System.Drawing.Color.FromArgb(0x52, 0x52, 0x52);
                lblModifier.Text = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(fieldOptional.Modifier.Name, true);
            } 
            #endregion
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //<FieldValue>
        //  <Item id="35ef6b33-7642-4afd-9052-3bf59dbf9d06" currencyID="JPY" currencyName="日幣" item="品項1" rate="0.21" amount="10000" amountByNTD="2100" />
        //  <Item id="3c48d608-7df0-4791-94fc-d3dd71d728d6" currencyID="JPY" currencyName="日幣" item="品項2" rate="0.21" amount="10000" amountByNTD="2100" />
        //</FieldValue>

        XElement xe = XElement.Parse(txtFieldValue.Text);

        if(!string.IsNullOrEmpty(Dialog.GetReturnValue()))
        {
            XElement returnXE = XElement.Parse(Dialog.GetReturnValue());
            xe.Add(returnXE.Elements("Item"));

            txtFieldValue.Text = xe.ToString();
            BindGrid();
        }


    }

    private void BindGrid()
    {
        XElement xe = XElement.Parse(txtFieldValue.Text);

        DataTable dt = new DataTable();
        dt.Columns.Add("id");
        dt.Columns.Add("currencyID");
        dt.Columns.Add("currencyName");
        dt.Columns.Add("item");
        dt.Columns.Add("rate");
        dt.Columns.Add("amount");
        dt.Columns.Add("amountByNTD");

        decimal totalAmountByNTD = 0;

        foreach (XElement item in xe.Elements("Item"))
        {
            DataRow dr = dt.NewRow();
            dr["id"] = item.Attribute("id").Value;
            dr["currencyID"] = item.Attribute("currencyID").Value;
            dr["currencyName"] = item.Attribute("currencyName").Value;
            dr["item"] = item.Attribute("item").Value;
            dr["rate"] = item.Attribute("rate").Value;
            dr["amount"] = item.Attribute("amount").Value;
            dr["amountByNTD"] = item.Attribute("amountByNTD").Value;


            totalAmountByNTD += Convert.ToDecimal(item.Attribute("amountByNTD").Value);

            dt.Rows.Add(dr);
        }

        grid.DataSource = dt;
        grid.DataBind();

        DemoUCO uco = new DemoUCO();

        int year = DateTime.Today.Year;
        int month = DateTime.Today.Month;

        //取得申請表單的年月，如果沒有申請表單，則預設為當前年月
        if(base.taskObj != null)
        {
            year=base.taskObj.BeginTime.Value.Year;
            month=base.taskObj.BeginTime.Value.Month;
        }

        lblNTD.Text = totalAmountByNTD.ToString();
        decimal usdRate = uco.GetCurrentRate("USD", year.ToString(),month.ToString());
        lblUSD.Text = (totalAmountByNTD / usdRate).ToString();

    }
}