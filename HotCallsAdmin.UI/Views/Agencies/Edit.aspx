<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<HotCallsAdmin.Domain.Entities.Agency>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Hot Calls Admin : Edit <% Model.Id.ToString(); %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit <% Model.Id.ToString(); %></h1>
    
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm("Edit", "Agencies", FormMethod.Post, new { enctype = "multipart/form-data" }))
	   { %>
		<% Html.EditorForModel(); %>
		
		<input type="submit" value="Save" />
		<% Html.ActionLink("Cancel and return to List", "List"); %>
	   <% } %>

</asp:Content>
