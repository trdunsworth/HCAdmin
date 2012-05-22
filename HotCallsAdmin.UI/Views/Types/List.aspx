<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<HotCallsAdmin.Domain.Entities.Atype>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Types List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% foreach (var atype in Model)
	   { %>
		<div>
			<h3><%= Html.Encode(atype.Id) %></h3>
			<h4><%= Html.Encode(atype.Agency) %></h4>
			<%= Html.Encode(atype.Priority) %>, &nbsp;
			<%= Html.Encode(atype.Tycod) %>&#47; &nbsp;
			<%= Html.Encode(atype.Sub_Tycod) %>, &nbsp;
			<%= Html.Encode(atype.Un_Cnt) %>
			<br />
			<%= Html.Encode(atype.Alwys_Snd) %>, &nbsp;
			<%= Html.Encode(atype.Nevr_Snd) %>, &nbsp;
			<%= Html.Encode(atype.Not4Pub) %>
		</div>
    <% } %>

</asp:Content>
