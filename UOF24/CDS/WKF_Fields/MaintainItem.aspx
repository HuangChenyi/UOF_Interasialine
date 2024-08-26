<%@ Page Title="" Language="C#" MasterPageFile="~/Master/DialogMasterPage.master" AutoEventWireup="true" CodeFile="MaintainItem.aspx.cs" Inherits="CDS_WKF_Fields_MaintainItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="PopTable">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="品項"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtItem" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="幣別"></asp:Label>
            </td>
            <td>
                               <asp:DropDownList ID="ddlCurrency"
                    DataTextField="CURRENCY_NAME"
                                   AutoPostBack="true"
                    DataValueField="CURRENCY_ID" OnSelectedIndexChanged="ddlCurrency_SelectedIndexChanged"
                    runat="server">

                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="匯率"></asp:Label>
            </td>
            <td>
                     <telerik:RadNumericTextBox ID="rnumRate" Value="0" runat="server" ReadOnly="true" >

     </telerik:RadNumericTextBox>
            </td>
        </tr>
    <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="金額"></asp:Label>
            </td>
            <td>
               <telerik:RadNumericTextBox ID="rnumAmount" Value="0" runat="server"
                   AutoPostBack="true"   OnTextChanged="rnumAmount_TextChanged"
                   >
                  
               </telerik:RadNumericTextBox>
            </td>
        </tr>
            <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="台幣金額"></asp:Label>
            </td>
            <td>
               <telerik:RadNumericTextBox ID="rnumAmountByNTD" Value="0" runat="server" ReadOnly="true" >

               </telerik:RadNumericTextBox>
            </td>
        </tr>
    </table>

    <asp:Label ID="lblSelected" runat="server" Text="--請選擇--" Visible="false"></asp:Label>

    <asp:TextBox ID="txtFieldValue" runat="server" 
        TextMode="MultiLine" Width="100%" Height="200px"
        ></asp:TextBox>

</asp:Content>

