<%@ Page Title="" Language="C#" MasterPageFile="~/Master/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CDS_Currency_Default" %>
<%@ Register Assembly="Ede.Uof.Utility.Component.Grid" Namespace="Ede.Uof.Utility.Component" TagPrefix="Ede" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>

        function RadToolBar1_ButtonClicking(sender, args) {
            var value = args.get_item().get_value();

            if (value == "Currency") {

                var width = 800;
                var height = 600;
                var title = "維護幣別";
               
                $uof.dialog.open2("~/CDS/Currency/MaintainCurrency.aspx", sender, title, width, height, OpenDialogResult);
                args.set_cancel(true);
            }
            if (value == "Rate") {

                var width = 600;
                var height = 400;
                var title = "維護匯率";

                $uof.dialog.open2("~/CDS/Currency/MaintainRate.aspx", sender, title, width, height, OpenDialogResult);
                args.set_cancel(true);
            }
        }

        function OpenDialogResult(returnValue) {
            console.log(returnValue);
            if (typeof (returnValue) == "undefined")
                return false;
            else {
                $('#<%=btnTmp.ClientID%>').click();
                return true;
            }
              
        }


    </script>

    <telerik:RadToolBar ID="toolBar" runat="server" Width="100%"
        OnClientButtonClicking="RadToolBar1_ButtonClicking"
        OnButtonClick="toolBar_ButtonClick"
        >
        <Items>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton Text="維護幣別" Value="Currency"
               
                ></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton Text="維護匯率" Value="Rate"
               
                ></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
        </Items>
    </telerik:RadToolBar>
    <Ede:Grid ID="grid" runat="server" AutoGenerateColumns="false"
        OnRowDataBound="grid_RowDataBound"
        OnRowCommand="grid_RowCommand"
        AutoGenerateCheckBoxColumn="false">
            <Columns>
                <asp:TemplateField HeaderText="幣別">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnCurrency" runat="server" 
                            CommandName="lbtnCurrency"
                            Text='<%# Bind("CURRENCY_NAME") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="YEAR" HeaderText="年" />
                <asp:BoundField DataField="MONTH" HeaderText="月" />
                <asp:BoundField DataField="CURRENCY_RATE" HeaderText="匯率" 
                   ItemStyle-HorizontalAlign="Right" />
            </Columns>
    </Ede:Grid>
    <asp:Button ID="btnTmp" runat="server" Text="Button" style="display:none" OnClick="Button1_Click" />
</asp:Content>

