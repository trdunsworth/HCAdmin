<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HotCallsAdmin.Domain.Entities.User>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Users List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% foreach (var user in Model)
	   { %>
		<h3><%= Html.Encode(user.Id) %></h3>
		<h4><%= Html.Encode(user.Lname) %>, <%= Html.Encode(user.Fname) %></h4>
		<p><%= Html.Encode(user.Ag_Id) %>, <%= Html.Encode(user.Email) %></p>
		<p><%= Html.Encode(user.Leo) %>, <%= Html.Encode(user.Loi_Grps) %></p>
		<p><%= Html.Encode(user.Esz) %>, <%= Html.Encode(user.Zip) %>
		<%= Html.Encode(user.Zip2) %>, <%= Html.Encode(user.Zip3) %></p>
		<%= Html.Encode(user.Oof) %>
    <% } %>

</asp:Content>
