<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TransportationManagementSystemMaintenanceModule._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
 

    <br /><br />  
  <%--  <table>  
        <tr>  
            <td>  
                First Name  
            </td>  
            <td>  
                <asp:TextBox runat="server" ID="txtFirstName" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
                Last Name  
            </td>  
            <td>  
                <asp:TextBox runat="server" ID="txtLastName" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
                Company  
            </td>  
            <td>  
                <asp:TextBox runat="server" ID="txtCompany" />  
            </td>  
        </tr>  
        <tr>  
            <td>  
            </td>  
            <td>  
                <asp:Button Text="Save" runat="server" ID="btnSave" />  
            </td>  
        </tr>  
    </table>  --%>
         

        <table class="table table-striped table-bordered table-hover" id="maintenanceTable" cellspacing="0" align="center" width="100%">
    <thead>
        <tr>
           <th>vehicle ID</th>
           <th>maintenance type</th>
           <th>Date</th>
           <th>Description</th>
           <th>Notes</th>
        </tr>
    </thead>
</table>          
    <br />  
      


    </main>
    <script src="Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function ()
        {

            $(document).ready(function () {
                $.ajax({
                    url: 'Default.aspx/GetMaintenanceDataForTable',
                    type: 'GET', // Change to POST if using web method
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response.d)
                        { // Check if the response contains data
                            $('#maintenanceTable').dataTable({
                                data: response.d,
                                columns: [
                                    { "data": "vehicleID" },
                                    { "data": "type" },
                                    { "data": "date" },
                                    { "data": "description" },
                                    { "data": "notes" },
                                ]
                            });
                        } else {
                            alert("No data received.");
                        }
                    },
                    error: function (xhr, status, error) {
                        console.error("Error occurred: " + error);
                        alert("An error occurred while fetching maintenance data: " + xhr.responseText);
                    }
                });

        });
        });
    </script>
</asp:Content>
