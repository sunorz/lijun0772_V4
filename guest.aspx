<%@ Page Language="C#" AutoEventWireup="true" CodeFile="guest.aspx.cs" Inherits="guest" Debug="true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html" />
<link rel="stylesheet" type="text/css" href="adminsty.css" />
<title>访客管理</title>
<script src="http://code.jquery.com/jquery-1.2.1.min.js" type="text/javascript"></script>
 <script type="text/javascript">
     $(function() {
         //全选 
         $("#btn1").click(function() {
         $("input[name$='CheckBox3'][name^='gvguest']").attr("checked", "true");
         })
         //取消全选 
         $("#btn2").click(function() {
         $("input[name$='CheckBox3'][name^='gvguest']").removeAttr("checked");
         })
     });
    </script>
   <script type="text/javascript" src="http://z.cnzz.net/o.php?sid=1253974593"></script></head>
<body>
<script language="JavaScript" type="text/javascript">
    var lang = navigator.language || navigator.userLanguage;
    if (lang.substr(0, 3) == "zh-") {
        document.write("<style type=\"text/css\" media=\"screen\">center{display:none;}</style>");
    }
</script>
<form id="form1" runat="server" autocomplete="off">
  <table width="1038" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td height="15" colspan="9" bgcolor="#585858"></td></tr>
  <tr>
  <td  align="left" valign="middle" bgcolor="#ff7d23" class="style1">丽军数码</td>
   
  </tr>  <tr>
  <td height="15" colspan="9" align="center" bgcolor="#FFFFFF">
        <p><br />
        </p>
       
        <table width="90%" border="0" cellspacing="0" cellpadding="12">
          <tr>
            <td width="547" align="left"><h1>后台管理</h1>
             </td>
            <td align="right" nowrap="nowrap"><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
            <td width="200" align="right">
                &nbsp;<asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/imgs/back.gif" Height="32" Width="32" title="返回" OnClick="btnBack_click"/>&nbsp;&nbsp;<asp:ImageButton ID="btnLogout" runat="server" ImageUrl="~/imgs/logout.gif" Height="32" Width="32" title="登出" OnClick="btnLogout_click"/></td>
          </tr>
          <tr>
            <td height="3" colspan="3" align="left">&nbsp;
                
                          </td>
          </tr>
          <tr>
            <td colspan="3" align="center" valign="middle">
              <table border="0" cellspacing="0" cellpadding="12" 
                    style="width: 100%;">
                <tr>
                  <td align="right">
                      <asp:Image ID="Image1" runat="server" ImageUrl="~/imgs/guest.gif" />
                    </td>
                  <td align="left" width="50%"><strong>访客管理：<strong></tr>
                <tr>
                  <td colspan="2" align="center" style="text-align: left">
                      <asp:GridView ID="gvguest" runat="server"    AutoGenerateColumns="False" 
                          BackColor="LightGoldenrodYellow" BorderColor="Tan" 
                          BorderWidth="1px" CellPadding="2" DataKeyNames="guid" ForeColor="Black" 
                          Width="100%" CssClass="txt3" AllowPaging="True" HorizontalAlign="Center" 
                          onrowupdating="gvguest_RowUpd" onrowediting="gvguest_RowEdt" 
                          onpageindexchanging="gvguest_OnPageIndexChanging" 
                          onrowdeleting="gvguest_RowsDel">
                          <Columns>
                              <asp:TemplateField>
                                  <EditItemTemplate>
                                      <asp:CheckBox ID="CheckBox3" runat="server" />
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:CheckBox ID="CheckBox3" runat="server" />
                                  </ItemTemplate>
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                              <asp:BoundField DataField="rowsid" HeaderText="序号" ReadOnly="True" 
                                  SortExpression="rowsid" >
                              <ItemStyle HorizontalAlign="Center" Width="10%" />
                              </asp:BoundField>
                              <asp:BoundField DataField="guid" HeaderText="guid" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="guid" Visible="False" />
                              <asp:TemplateField HeaderText="昵称" SortExpression="gname">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox1" runat="server" Text='<%#Encryption.Decode(Eval("gname")) %>'></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                          ControlToValidate="TextBox1" CssClass="aptips" ErrorMessage="必填" 
                                          ValidationGroup="EVC" Display="Dynamic"></asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                          ControlToValidate="TextBox1" CssClass="aptips" ErrorMessage="昵称不符合规定！" 
                                          ValidationExpression="^[\u4E00-\u9FA5A\a-zA-Z][\u4E00-\u9FA5A-Za-z0-9]{3,15}$" 
                                          ValidationGroup="EVC" Display="Dynamic"></asp:RegularExpressionValidator>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label1" runat="server" Text='<%# Encryption.Decode(Eval("gname")) %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="邮箱" SortExpression="gmail">
                                  <EditItemTemplate>
                                      <asp:TextBox ID="TextBox2" runat="server" Text='<%# Encryption.Decode(Eval("gmail")) %>'></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                          ControlToValidate="TextBox2" CssClass="aptips" ErrorMessage="必填" 
                                          ValidationGroup="EVC" Display="Dynamic"></asp:RequiredFieldValidator>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                          ControlToValidate="TextBox2" CssClass="aptips" ErrorMessage="邮箱格式有误！" 
                                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                          ValidationGroup="EVC" Display="Dynamic"></asp:RegularExpressionValidator>
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:Label ID="Label2" runat="server" Text='<%# Encryption.Decode(Eval("gmail")) %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="禁言" SortExpression="gflag">
                                  <ItemTemplate>
                                      <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("gflag") %>' 
                                          Enabled="false" />
                                  </ItemTemplate>
                                  <EditItemTemplate>
                                      <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("gflag") %>' />
                                  </EditItemTemplate>
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="管理员">
                                  <EditItemTemplate>
                                      <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("ismgr") %>' 
                                       />
                                  </EditItemTemplate>
                                  <ItemTemplate>
                                      <asp:CheckBox ID="CheckBox2" runat="server" Checked='<%# Bind("ismgr") %>' 
                                          Enabled="false" />
                                  </ItemTemplate>
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                              <asp:TemplateField ShowHeader="False">
                                  <ItemTemplate>
                                      <asp:Button ID="Button1" runat="server" CausesValidation="false" 
                                          CommandName="edit" Text="修改" />
                                  </ItemTemplate>
                                   <EditItemTemplate>
                                  <asp:Button ID="Button3" runat="server" CausesValidation="True" 
                                    CommandName="Update" Text="保存" ValidationGroup="EVC"/>
                                  </EditItemTemplate>
                                  <ControlStyle BackColor="#FF7D23" BorderColor="#FF7D23" BorderStyle="Solid" 
                                Font-Bold="True" Font-Names="宋体" Font-Size="Medium" ForeColor="White" />
                                  <ItemStyle HorizontalAlign="Center" />
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                              <asp:TemplateField ShowHeader="False">
                                  <ItemTemplate>
                                      <asp:Button ID="Button2" runat="server" CausesValidation="false" CommandName="delete" 
                                          Text="删除" />
                                  </ItemTemplate>
                                  <ControlStyle BackColor="#FF7D23" BorderColor="#FF7D23" BorderStyle="Solid" 
                                      Font-Bold="True" Font-Names="宋体" Font-Size="Medium" ForeColor="White" />
                                  <ItemStyle HorizontalAlign="Center" />
                              </asp:TemplateField>
                          </Columns>
                          <FooterStyle BackColor="Tan" />
                          <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                              HorizontalAlign="Center" />
                          <EmptyDataTemplate>
                              <p style="text-align:center">没有访客信息！</p>
                          </EmptyDataTemplate>
                          <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                          <HeaderStyle BackColor="Tan" Font-Bold="True" />
                          <AlternatingRowStyle BackColor="PaleGoldenrod" />
                      </asp:GridView>
                                            <br />
                      <div style="width:700px; text-align:left;"><input type="button" id="btn1" value="全选">&nbsp;&nbsp;<input type="button" id="btn2" value="取消全选">&nbsp;&nbsp;<asp:Button 
                              ID="Button4" runat="server"  
                             
                              Text="删除" onclick="deletemore" UseSubmitBehavior="False" />
                      </div>
                      </td>
                </tr>
                </table>
</td>
          </tr>
          </table>

 <br />

            
  </tr>

  <tr>
    <td align="center" valign="middle" bgcolor="#FFFFFF" >
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
</td>
  </tr>
  <tr>
    <td height="40" bgcolor="#A1A1A1"  class="footer"><p>&nbsp;</p>
                  <p> &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></p></td></tr></table>          
    </form>
</body>
</html>
