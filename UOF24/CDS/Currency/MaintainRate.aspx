<%@ Page Title="" Language="C#" MasterPageFile="~/Master/DialogMasterPage.master" AutoEventWireup="true" CodeFile="MaintainRate.aspx.cs" Inherits="CDS_Currency_MaintainRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="PopTable" style="width:100%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="幣別"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCurrency"
                    DataTextField="CURRENCY_NAME"
                    DataValueField="CURRENCY_ID"
                    runat="server">

                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    Display="Dynamic" ControlToValidate="ddlCurrency"
                    runat="server" ErrorMessage="幣別必填!"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="年"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
    <td>
         <asp:Label ID="Label3" runat="server" Text="月"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>
    </td>
</tr>
        <tr>
            <td>
                 <asp:Label ID="Label4" runat="server" Text="匯率"></asp:Label>
            </td>
            <td>
                <telerik:RadNumericTextBox ID="rnumRate" runat="server"
                    MinValue="0" 
                    ></telerik:RadNumericTextBox>
            </td>
        </tr>
    </table>

    <asp:Label ID="lblSelected" runat="server" Text="--請選擇--"
        Visible="false"
        ></asp:Label>

</asp:Content>

