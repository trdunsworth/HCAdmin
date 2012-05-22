<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HotCallsAdmin.Domain.Entities.Agency>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Agencies
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% foreach(var agency in Model) { %>
		<div>
			<h3><%= Html.Encode(agency.Ag_Id) %></h3>
			<%= Html.Encode(agency.Units) %>
		</div>
	<% } %>

</asp:Content>
