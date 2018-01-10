<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestaurantsInformation.aspx.cs" Inherits="RestaurantWebAPI.RestaurantsInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/materialize/0.100.2/css/materialize.min.css">
        <script src="Scripts/jquery-1.10.2.js"></script>
        <script type="text/javascript">
        $(document).ready(function () {
            var unorderedList = $('#unorderedList');
            $('#btnGetRestaurants').click(function () {
                $.ajax({
                    type: 'GET',
                    url: "api/restaurant/",
                    dataType: 'json',
                    success: function (data) {
                        unorderedList.empty();
                        $.each(data, function (index, val) {
                            var RestaurantName = val.restaurantName;
                            unorderedList.append('<li>' + RestaurantName + '</li>');
                        });
                    }
                });
            });
            $('#btnClear').click(function () {
                unorderedList.empty();
            });
        });
    </script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
    <script type="text/javascript" src="js/materialize.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                <td><asp:Button ID="btnGetRestaurants" text="Get Restaurants" runat="server"/>
                <td><asp:Button ID="btnClear" text="Clear" runat="server"/>
                </tr>
                <tr>
                    <td>
                        <ul id="unorderedList">

                        </ul>
                    </td>
                </tr>
                    </table>
        </div>
    </form>
</body>
</html>
