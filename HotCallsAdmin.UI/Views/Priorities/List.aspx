<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HotCallsAdmin.Domain.Entities.Priority>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Priority Matrix
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% foreach (var priority in Model)
	   { %>
		<div>
			<h3><%= Html.Encode(priority.Ag_Id)%></h3>
			<h4><%= Html.Encode(priority.Priority) %></h4>
			<%= Html.Encode(priority.Un_Cnt) %>, &nbsp;
			<%= Html.Encode(priority.Alwys_Snd) %>, &nbsp;
			<%= Html.Encode(priority.Nevr_Snd) %>	
		</div>
	<% } %>

</asp:Content>
