<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OptionFieldUC.ascx.cs" Inherits="WKF_OptionalFields_OptionFieldUC" %>
<%@ Reference Control="~/WKF/FormManagement/VersionFieldUserControl/VersionFieldUC.ascx" %>
<%@ Register Src="~/Common/ChoiceCenter/UC_ChoiceList.ascx" TagPrefix="uc1" TagName="UC_ChoiceList" %>

<%@ Register Assembly="Ede.Uof.Utility.Component.Grid" Namespace="Ede.Uof.Utility.Component" TagPrefix="Fast" %>


<table style="width:1000px">
    <tr>
        <td >
            <asp:Button ID="btnAdd" runat="server" Text="新增" OnClick="btnAdd_Click" />
<asp:Button ID="btnDelete" runat="server" Text="刪除" />
        </td>
    </tr>
    <tr>
        <td>
            <table class="PopTable">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="負責人"></asp:Label>
                    </td>
                    <td>
                        <uc1:UC_ChoiceList runat="server" ID="UC_ChoiceList" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="美金總額"></asp:Label>
                    </td>
                    <td>
                         <asp:Label ID="lblUSD" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                           <asp:Label ID="Label3" runat="server" Text="台幣總額"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblNTD" runat="server" Text="0"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<Fast:Grid ID="grid" runat="server" AutoGenerateCheckBoxColumn="true"
    AutoGenerateColumns="false" DataKeyNames="id">
    <Columns>
        <asp:BoundField HeaderText="品項" DataField="item" />
         <asp:BoundField HeaderText="幣別" DataField="currencyName" />
         <asp:BoundField HeaderText="匯率" DataField="rate" />
         <asp:BoundField HeaderText="金額" DataField="amount" />
         <asp:BoundField HeaderText="台幣金額" DataField="amountByNTD" />
    </Columns>
</Fast:Grid>

    <asp:TextBox ID="txtFieldValue" runat="server" 
        TextMode="MultiLine" Width="100%" Height="200px"
        ></asp:TextBox>

<asp:Label ID="lblHasNoAuthority" runat="server" Text="無填寫權限" ForeColor="Red" Visible="False" meta:resourcekey="lblHasNoAuthorityResource1"></asp:Label>
<asp:Label ID="lblToolTipMsg" runat="server" Text="不允許修改(唯讀)" Visible="False" meta:resourcekey="lblToolTipMsgResource1"></asp:Label>
<asp:Label ID="lblModifier" runat="server" Visible="False" meta:resourcekey="lblModifierResource1"></asp:Label>
<asp:Label ID="lblMsgSigner" runat="server" Text="填寫者" Visible="False" meta:resourcekey="lblMsgSignerResource1"></asp:Label>
<asp:Label ID="lblAuthorityMsg" runat="server" Text="具填寫權限人員" Visible="False" meta:resourcekey="lblAuthorityMsgResource1"></asp:Label>