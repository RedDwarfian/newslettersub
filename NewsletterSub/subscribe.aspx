<%@ Page Language="C#" AutoEventWireup="true" CodeFile="subscribe.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Subscribe to our Newsletter</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script> 
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style>
html {
    min-height:100%;
}
body {
    min-height: 100%;
    /* SRC: https://www.pexels.com/photo/dawn-landscape-mountains-nature-3961/ */
    background-image: url(http://localhost:60396/background.jpg);
    background-position:center;
    background-size:cover;
}
#wrapper {
    margin: 30px;
    background: rgba(255,253,250,0.8);
    padding: 30px;
    border-radius: 15px;
}
@media(max-width:767px) {
    #wrapper {
        margin:0;
        padding:0;
        border-radius:15px;
        background:none;
    }
    body {
        background: rgba(255,253,250,1);
    }
}
    </style>
</head>
<body>
    <div class="container">
        <div id="wrapper">
            <div class="row">
                <div class="col-xs-12">
                    <h1 class="text-center">Subscribe to our monthly newsletter!</h1>
                    <h2 class="text-center">Here's a sample of the Lorem Ipsum you'll recieve in our newsletters:</h2>
                </div>
                <div class="col-sm-4">
                    <h3 class="text-center">Lorem Ipsum</h3>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                    </p>
                </div>
                <div class="col-sm-4">
                    <h3 class="text-center">Bacon Ipsum</h3>
                    <p>
                        Bacon ipsum dolor amet ribeye fatback pastrami, pork spare ribs biltong picanha tri-tip. Meatball short ribs kielbasa t-bone salami ball tip cupim flank tail venison turducken bresaola alcatra ham beef ribs. 
                    </p>
                </div>
                <div class="col-sm-4">
                    <h3 class="text-center">Hipsum</h3>
                    <p>
                        Cliche succulents put a bird on it locavore, cray fanny pack mustache typewriter 3 wolf moon celiac meditation air plant. Austin marfa try-hard, tousled gluten-free live-edge shoreditch you probably haven't heard of them. 
                    </p>
                </div>
                <div class="col-xs-12">
                    <h1 class="text-center">Fill out the form below</h1>
                    <h2 class="text-center">To subscribe to our newsletter</h2>
                </div>
                <div class="col-sm-offset-2 col-sm-8 col-md-offset-4 col-md-4" id="formarea" runat="server">
                </div>
            </div>
        </div>
        <div class="text-center"><small><a href="default.html">Home</a></small></div>
    </div>
</body>
</html>
