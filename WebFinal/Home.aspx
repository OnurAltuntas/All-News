<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs"  Inherits="WebFinal.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">
</head>
<body>
    <form id="form1" runat="server">
        
         <asp:Button runat="server" id="btnDisHaberler" Text="Dış Haberler" OnClick="btnDisHaberler_Click" />
         <asp:Button runat="server" id="btnEgitim" Text="Egitim" OnClick="btnEgitim_Click" />
         <asp:Button runat="server" id="btnEkonomi" Text="Ekonomi" OnClick="btnEkonomi_Click" />
         <asp:Button runat="server" id="btnGundem" Text="Gündem" OnClick="btnGundem_Click" />
         <asp:Button runat="server" id="btnSiyaset" Text="Siyaset" OnClick="btnSiyaset_Click" />
         <asp:Button runat="server" id="btnSpor" Text="Spor" OnClick="btnSpor_Click" />

        <div>
            <div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
                  <ol class="carousel-indicators">
                    <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
                       <% for (int i = 1; i < NewsAll.Count; i++) {%>
                            <li  data-target="#carouselExampleCaptions" data-slide-to=><%i.ToString();%></li>
                          <% } //foreach %>
                  </ol>
                 <div class="container-fluid ">

              
                 <div class="carousel-inner">
                     <div class="carousel-item active">
                      <img src="https://mdbootstrap.com/img/Photos/Slides/img%20(68).jpg" class="d-block w-100" alt="...">
                      <div class="carousel-caption d-none d-md-block">
                       
                      </div>
                    </div>

                  <% foreach(var item in NewsAll) { %>
                      <div  class="carousel-item" >
                      <img  style="height:100vh" src="<%: (item as News).ImageUrl %>" class="d-block w-100" onclick="" alt="..."  >
                      <div class="carousel-caption d-none d-md-block">
                          
                       <h5><a href="NewsDetail.aspx?id=<<%: (item as News).Title %>>"><%: (item as News).Title %></a></h5>
                        <p> <%: (item as News).Category %></p>
                      
                         
                      </div>
                    </div>
                  <% } //foreach %>

                    
                   
                  </div>
                  <a class="carousel-control-prev" href="#carouselExampleCaptions" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                  </a>
                  <a class="carousel-control-next" href="#carouselExampleCaptions" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                  </a>
                </div>
        </div>
           </div>
    </form>
</body>
</html>

 <style>
   <!--
     .carousel .item img {
  max-height: 768px;
  min-width: auto;
}
   -->
   </style>
