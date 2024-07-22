<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NotificationInfo.aspx.cs" Inherits="web_1.NotificationInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #Panel1{
            padding:10px;
        }
    </style>
    <main aria-labelledby="title">
        <h2 id="title">通報系統 </h2>
        <asp:Panel ID="Panel1" runat="server" BackColor="#FF9999">
            通報單
         
            <br />
            長&nbsp; 者&nbsp; ID:<asp:TextBox ID="Noti_eId" runat="server"></asp:TextBox>
            <br />
            長者姓名:<asp:TextBox ID="Noti_eName" runat="server"></asp:TextBox>
            <br />
            跌倒地點:<asp:Label ID="Noti_pId" runat="server" Text="P01"></asp:Label>
            <br />
            跌倒時間:<asp:Label ID="Noti_fTime" runat="server" Text="Label"></asp:Label>
            <br />
            跌倒原因:<asp:TextBox ID="Noti_fwhy" runat="server"></asp:TextBox>
            <br />
            是否送醫:<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem>是</asp:ListItem>
                <asp:ListItem>否</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Panel ID="Panel3" runat="server" Visible="False">
                醫院名稱:<asp:TextBox ID="Noti_hId" runat="server"></asp:TextBox>
            </asp:Panel>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="送出" />
            <br />
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" BackColor="#CCCCFF">
            歷史資料
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </asp:Panel>
    </main>
</asp:Content>
