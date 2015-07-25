﻿<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WebAppCrawler.Models.LoginModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Выполнить вход
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Вход.</h1>
    </hgroup>

    <section id="loginForm">
    <h2>Используйте для входа локальную учетную запись.</h2>
    <% using (Html.BeginForm(new { ReturnUrl = ViewBag.ReturnUrl })) { %>
        <%: Html.AntiForgeryToken() %>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Форма входа</legend>
            <ol>
                <li>
                    <%: Html.LabelFor(m => m.UserName) %>
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </li>
                <li>
                    <%: Html.LabelFor(m => m.Password) %>
                    <%: Html.PasswordFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </li>
                <li>
                    <%: Html.CheckBoxFor(m => m.RememberMe) %>
                    <%: Html.LabelFor(m => m.RememberMe, new { @class = "checkbox" }) %>
                </li>
            </ol>
            <input type="submit" value="Выполнить вход" />
        </fieldset>
        <p>
            <%: Html.ActionLink("Регистрация", "Register") %> если у вас нет учетной записи.
        </p>
    <% } %>
    </section>

    <section class="social" id="socialLoginForm">
        <h2>Используйте для входа другую службу.</h2>
        <%: Html.Action("ExternalLoginsList", new { ReturnUrl = ViewBag.ReturnUrl }) %>
    </section>
</asp:Content>

<asp:Content ID="scriptsContent" ContentPlaceHolderID="ScriptsSection" runat="server">
    <%: Scripts.Render("~/bundles/jqueryval") %>
</asp:Content>
