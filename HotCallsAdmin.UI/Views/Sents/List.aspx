<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HotCallsAdmin.Domain.Entities.Sent>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Sent Mail List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% foreach (var sent in Model)
	   { %>
		<div>
			<h3><%= Html.Encode(sent.Id) %></h3>
			<h4><%= Html.Encode(sent.Eid) %></h4>
			<%= Html.Encode(sent.Ag_Id) %>, &nbsp;
			<%= Html.Encode(sent.Tycod) %>&#47; &nbsp;
			<%= Html.Encode(sent.Sub_Tycod) %>
			<br />
			<h4><%= Html.Encode(sent.Sent_Dt) %></h4>
			<%= Html.Encode(sent.Email_Sent) %>
		</div>
    <% } %>

</asp:Content>
