<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HotCallsAdmin.Domain.Entities.Curent>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Current Calls
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% foreach (var curents in Model)
	   { %>
		<div>
			<h3><%= Html.Encode(curents.Eid) %></h3>
			<%= Html.Encode(curents.Ad_Ts) %>,&nbsp;
			<%= Html.Encode(curents.Udts) %>,&nbsp;
			<%= Html.Encode(curents.Ag_Id) %>
			<br />
			<%= Html.Encode(curents.Estnum) %>&nbsp;
			<%= Html.Encode(curents.Edirpre) %>&nbsp;
			<%= Html.Encode(curents.Efeanme) %>&nbsp;
			<%= Html.Encode(curents.Efeatyp) %>&nbsp;
			<%= Html.Encode(curents.Edirsuf) %>&nbsp;
			<%= Html.Encode(curents.Eapt) %>&nbsp;
			<%= Html.Encode(curents.Ccity) %>
			<br />
			<%= Html.Encode(curents.Tycod) %>&nbsp;
			<%= Html.Encode(curents.Sub_Tycod) %>&nbsp;
			<%= Html.Encode(curents.Unit_Count) %>&nbsp;
			<br />
			<%= Html.Encode(curents.Hc_Sent) %>&nbsp;
			<%= Html.Encode(curents.Loi_Sent) %>&nbsp;
			<%= Html.Encode(curents.Loc_Sent) %>&nbsp;
			<%= Html.Encode(curents.Tr_Sent) %>
		</div>
	<% } %>

</asp:Content>
