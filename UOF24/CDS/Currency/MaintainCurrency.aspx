<%@ Page Title="" Language="C#" MasterPageFile="~/Master/DialogMasterPage.master" AutoEventWireup="true" CodeFile="MaintainCurrency.aspx.cs" Inherits="CDS_Currency_MaintainCurrency" %>
<%@ Register Assembly="Ede.Uof.Utility.Component.Grid" Namespace="Ede.Uof.Utility.Component" TagPrefix="Ede" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="PopTable" style="width:100%">
        <tr>
           <td>
               <asp:Label ID="Label1" runat="server" Text="幣別代碼"></asp:Label>
           </td>
            <td>
                <asp:TextBox ID="txtCuurencyID" runat="server"></asp:TextBox>
            </td>
        </tr>
                <tr>
           <td>
               <asp:Label ID="Label2" runat="server" Text="幣別名稱"></asp:Label>
           </td>
            <td>
                <asp:TextBox ID="txtCuurencyName" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <asp:Button ID="btnSave" runat="server" Text="儲存" OnClick="btnSave_Click" />
    <asp:Button ID="btnDelte" runat="server" Text="刪除" OnClick="btnDelte_Click"
        OnClientClick="return confirm('確定要刪除?');"
        />

    <Ede:Grid ID="grid" runat="server" AutoGenerateColumns="false" AllowPaging="true"
        PageSize="4" OnPageIndexChanging="grid_PageIndexChanging"
        AutoGenerateCheckBoxColumn="true" DataKeyNames="CURRENCY_ID" >
        <Columns>
            <asp:BoundField HeaderText="幣別代碼" DataField="CURRENCY_ID" />
             <asp:BoundField HeaderText="幣別名稱" DataField="CURRENCY_Name" />
        </Columns>
    </Ede:Grid>

</asp:Content>

