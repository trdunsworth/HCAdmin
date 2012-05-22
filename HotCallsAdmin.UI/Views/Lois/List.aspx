<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HotCallsAdmin.Domain.Entities.Loi>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Locations of Interest
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <% foreach (var loi in Model)
	  { %>
		<div>
			<h3><%= Html.Encode(loi.Id)%></h3>
			<%= Html.Encode(loi.Estnum)%>&nbsp;
			<%= Html.Encode(loi.Edirpre) %>&nbsp;
			<%= Html.Encode(loi.Efeanme) %>&nbsp;
			<%= Html.Encode(loi.Efeatyp) %>&nbsp;
			<%= Html.Encode(loi.Edirsuf) %>&nbsp;
			<%= Html.Encode(loi.Zip) %>
			<br />
			<%= Html.Encode(loi.Hndr_Blck) %>,&nbsp;
			<%= Html.Encode(loi.Esz) %>,&nbsp;
			<%= Html.Encode(loi.Loi_Grp_Id) %>
		</div>
	<% } %>

</asp:Content>
