<%@ Control Language="C#" AutoEventWireup="true" CodeFile="articlelist.ascx.cs" Inherits="articlelist" %>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:lijunConnectionString %>"
                    
    SelectCommand="SELECT top 10 [artid], [artitle] FROM [Article] ORDER BY [artid] DESC" 
    ProviderName="System.Data.SqlClient">
                </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" DataKeyNames="artid" DataSourceID="SqlDataSource1" 
    ForeColor="#333333" GridLines="None" Width="100%" 
    style="text-align: center" Font-Size="14pt" ShowHeader="False">
    <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" Height="30px" />
        <EmptyDataRowStyle HorizontalAlign="Center" />
    <Columns>
        <asp:BoundField DataField="artid" HeaderText="artid" InsertVisible="False" 
            ReadOnly="True" SortExpression="artid" Visible="False">
        <HeaderStyle Height="0px" />
        </asp:BoundField>
        <asp:TemplateField>
            <ItemTemplate>
                &nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl='<%# Eval("artid", "detail.aspx?id={0}") %>' 
                     Text='<%# SubStr(Eval("artitle"),20) %>' ToolTip='<%# Eval("artitle") %>' 
                     ForeColor="Black"></asp:HyperLink>
            </ItemTemplate>          
            <ControlStyle ForeColor="#336699" />
            <ItemStyle Font-Size="11pt" ForeColor="#336699" />
        </asp:TemplateField>
    </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <EmptyDataTemplate><br/>
        <span style="font-size:small">没有文章！</span>
    </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" 
            Height="30px" />
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
    <AlternatingRowStyle BackColor="White" HorizontalAlign="Left" 
            CssClass="newl" Height="30px" />
</asp:GridView>

