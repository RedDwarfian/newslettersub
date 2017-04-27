<%@ Page Language="C#" AutoEventWireup="true" CodeFile="users.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>All Subscribed Users</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script> 
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1 class="text-center">
                    All subscriptions
                </h1>
                <form id="form1" runat="server">
                    <asp:GridView ID="userinfo" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="usersDB" BorderWidth="0" CssClass="table table-hover" style="max-height:500px;overflow-y:scroll;">
                        <Columns>
                            <asp:BoundField DataField="First Name" HeaderText="First Name" SortExpression="First Name" />
                            <asp:BoundField DataField="Last Name" HeaderText="Last Name" SortExpression="Last Name" />
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:BoundField DataField="Date Subscribed" HeaderText="Date Subscribed" SortExpression="Date Subscribed" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="usersDB" runat="server" ConnectionString="<%$ ConnectionStrings:usersConnectionString %>" SelectCommand="SELECT [first_name] AS &quot;First Name&quot;, [last_name] AS &quot;Last Name&quot;, [email] AS &quot;Email&quot;, [date_subscribed] AS &quot;Date Subscribed&quot; FROM [users] ORDER BY &quot;Date Subscribed&quot; DESC"></asp:SqlDataSource>
                </form>
                <nav id="pagination-area" class="text-center" aria-label="User Page Navigation"></nav>
            </div>
            <div class="col-xs-12 text-center"><small><a href="default.html">Home</a></small></div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {//wrap your code here
            var $rows = $("#userinfo").find("tr");
            var $pages = $("#pagination-area");
            console.log($rows.length);
            if ($rows.length > 10) {
                // Start generating a pagination area
                var $pagination = $("<ul/>",{class:"pagination"});
                for (var i = 0; i * 10 < $rows.length; i++) {
                    // This generates something like: "<li><a href='#' data-offset='10'>2</a></li>"
                    // For each group of 10.
                    $pagination.append($("<li/>").append($("<a/>", { href: "#" }).data("offset",i*10).text(i + 1)));
                }
                $pages.append($pagination);
                $pages.on("click", "li:not(.active)>a", function (e) {
                    e.preventDefault();
                    $pages.find("li.active").removeClass("active");
                    var $this = $(this);
                    $this.parent("li").addClass("active")
                    var min = $this.data("offset");
                    var max = min + 10;
                    $rows.each(function (i, v) {
                        if (i >= min && i < max) {
                            $(v).removeClass("hidden");
                        } else {
                            $(v).addClass("hidden");
                        }
                    })
                });
                $pagination.find("a:first").click();
            }
        });
    </script>
</body>
</html>
