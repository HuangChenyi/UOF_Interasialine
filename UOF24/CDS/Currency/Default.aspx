<%@ Page Title="" Language="C#" MasterPageFile="~/Master/DefaultMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CDS_Currency_Default" %>

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
        }

        function OpenDialogResult(returnValue) {
            if (typeof (returnValue) == "undefined")
                return false;
            else
                return true;
        }


    </script>

    <telerik:RadToolBar ID="toolBar" runat="server" Width="100%"
        OnClientButtonClicking="RadToolBar1_ButtonClicking"
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
</asp:Content>

