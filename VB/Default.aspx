<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.1, Version=15.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to use ASPxListBox inside the EditForm for editing ASPxGridView</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>How to use ASPxListBox inside the EditForm for editing ASPxGridView</h1>
            <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" DataSourceID="AccessDataSource1"
                KeyFieldName="CategoryID" OnRowUpdating="ASPxGridView1_RowUpdating"  OnRowValidating="ASPxGridView1_RowValidating">
                <Columns>
                    <dx:GridViewCommandColumn VisibleIndex="0" ShowEditButton="true">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataTextColumn FieldName="CategoryID" ReadOnly="True" VisibleIndex="0">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="CategoryName" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                </Columns>
                <Templates>
                    <EditForm>
                        <dx:ASPxListBox ID="ASPxListBox1" runat="server" DataSourceID="AccessDataSource2"
                            SelectionMode="CheckColumn" TextField="ProductName" ValueField="ProductName" ValueType="System.String" OnDataBound="ASPxListBox1_DataBound">
                        </dx:ASPxListBox>
                        <br />
                        <dx:ASPxGridViewTemplateReplacement ID="btnUpdate" runat="server" ReplacementType="EditFormUpdateButton"></dx:ASPxGridViewTemplateReplacement>
                        <dx:ASPxGridViewTemplateReplacement ID="btnCancel" runat="server" ReplacementType="EditFormCancelButton"></dx:ASPxGridViewTemplateReplacement>
                    </EditForm>
                </Templates>
            </dx:ASPxGridView>
        </div>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [CategoryID], [CategoryName], [Description] FROM [Categories]"
            DeleteCommand="DELETE FROM [Categories] WHERE [CategoryID] = ?"
            InsertCommand="INSERT INTO [Categories] ([CategoryID], [CategoryName], [Description]) VALUES (?, ?, ?)"
            UpdateCommand="UPDATE [Categories] SET [CategoryName] = ?, [Description] = ? WHERE [CategoryID] = ?">
            <DeleteParameters>
                <asp:Parameter Name="CategoryID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="CategoryName" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="CategoryID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="CategoryID" Type="Int32" />
                <asp:Parameter Name="CategoryName" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
            </InsertParameters>
        </asp:AccessDataSource>
        <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/nwind.mdb"
            SelectCommand="SELECT [ProductName] FROM [Products]"></asp:AccessDataSource>

    </form>
</body>
</html>