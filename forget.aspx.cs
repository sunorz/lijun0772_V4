using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;


public partial class forget: System.Web.UI.Page
{
	//载入
    protected void Page_Load(object sender, EventArgs e)
    {
        footerload();
    }


    //提交按钮，用于第一个对话框的验证
    protected void btnpwdfg_Click(object sender, ImageClickEventArgs e)
    {
  
            //初始化，加密变量
            yhm.Text = yhm.Text.Replace(" ", "");
            string txtname =Encryption.Encode(yhm.Text.Trim());//用户名

            ylyx.Text = ylyx.Text.Replace(" ", "");
            string txtmail = Encryption.Encode(ylyx.Text.Trim());//邮箱

            codes.Text = codes.Text.Replace(" ", "");
            string txtcode = codes.Text.ToLower().Trim();//验证码，不区分大小写

            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            
            //未输入信息
            if (txtname == "" || txtmail == "" ||txtcode=="")
            {
                aptips.InnerText = "请检查输入！ ";
            }

            //已经输入信息
            else
            {
                Session["fgpwd"] = txtname;//用于密码重置

                string st = "select * from Admin where adname='" + @txtname + "'and admail='" + @txtmail + "' and code='" + @txtcode + "'";
                cnn.Open();
                SqlCommand cmd = new SqlCommand(st, cnn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())//全部正确
                {
                    divforget.Visible = false;
                    divreset.Visible = true;
                }
                else
                {
                    aptips.InnerText = "请核对你的输入信息！ ";
                }
            }
        }



    //密码重置阶段，第二个对话框
     protected void btnpwdr_Click(object sender, ImageClickEventArgs e)
    {
        string newpwd = this.newpwd.Text;
        string conf = this.newconf.Text;
        if (newpwd == "")
        {
            aptips2.InnerText = "请输入新密码！";

        }
        else if (conf == "")
        {
            aptips2.InnerText = "请确认新密码！";


        }
        else if (newpwd != conf)
        {
            aptips2.InnerText = "两次输入的新密码不一致！";


        }
        else
        {
            string confs = Encryption.Auth(conf);
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            string st = "update Admin set adpwd='" + @confs + "',code=null where adname='" + Session["fgpwd"] + "'";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(st, cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
            Response.Write("<script type='text/javascript'>alert('设置成功,请重新登录！');window.location.href='adminlogin.aspx';</script>");
          
        }
    }  


//返回按钮

        protected void btnBack_click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("adminlogin.aspx");
    }

    //显示页脚
        protected void footerload()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            string st = "select * from Class where classid=7";
            cnn.Open();
            SqlCommand cmd = new SqlCommand(st, cnn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                this.Label3.Text = Server.HtmlDecode(rdr["content"].ToString());
                cnn.Close();
            }
        }
  
    //发送验证码（1.生成一个验证码并且录入数据库）
        protected void btnsend_Click(object sender, EventArgs e)
        {
            //初始化，加密变量
            yhm.Text = yhm.Text.Replace(" ", "");
            string txtname = Encryption.Encode(yhm.Text);//用户名

            ylyx.Text = ylyx.Text.Replace(" ", "");
            string txtmail = Encryption.Encode(ylyx.Text);//邮箱

            string connectionString = ConfigurationManager.ConnectionStrings["lijunConnectionString"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            string st = "select * from Admin where adname='" + @txtname + "'and admail='" + @txtmail + "'";
            SqlCommand cmd = new SqlCommand(st, cnn);
            cnn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())//信息正确
            {
                string flag = "";
                cnn.Close();
                string st2 = "select id from Admin where code is null and adname='" + @txtname + "'";
                cnn.Open();
                SqlCommand cmd2 = new SqlCommand(st2, cnn);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())//用户名对应的验证码为空
                {
                    cnn.Close();
                    flag = Rdom();
                    string st3 = "select * from Admin where code='" + @flag + "'";
                    SqlCommand cmd3 = new SqlCommand(st3, cnn);
                    cnn.Open();
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    if (reader3.Read())//避免验证码重复
                    {
                        flag = Rdom();
                        cnn.Close();                       
                    }
                    else
                    {
                        cnn.Close();                     
                       
                    }
                    

                }
                else//不为空
                {
                    cnn.Close();
                    string st4 = "select code from Admin where adname='" + @txtname + "'";
                    SqlCommand cmd4 = new SqlCommand(st4, cnn);
                    cnn.Open();
                    SqlDataReader reader4 = cmd4.ExecuteReader();
                    if (reader4.Read())
                    {
                        flag=reader4["code"].ToString();
                        cnn.Close();
                    }
                    else
                    {
                        cnn.Close();

                    }
                }
                string st5 = "update Admin set code='" + @flag + "' where adname='" + @txtname + "'";
                cnn.Open();
                SqlCommand cmd5 = new SqlCommand(st5, cnn);
                cmd5.ExecuteNonQuery();
                string tomail = Encryption.Decode(txtmail);
                sendmail(tomail, flag);//发送验证邮件
                aptips.InnerText = "验证码发送成功，请查看邮箱！";
                cnn.Close();
            }
        }
      

        //生成随机验证码

        protected string Rdom()
        {
            Random rd = new Random();
            string str = "0123456789abcdefghijklmnopqrstuvwxyz";
            string result = "";
            for (int i = 0; i < 6; i++)
            {
                result += str[rd.Next(str.Length)];
            }
              return result;
        }

        //发送邮件
        protected void sendmail(string tomail, string code)
        {
            MailAddress MessageFrom = new MailAddress("admin@lijun0772.com"); //发件人邮箱地址 
            string MessageTo = tomail;//收件人邮箱地址 
            string MessageSubject = "[丽军数码]重置密码"; //邮件主题 
            string MessageBody = "<p>您正在尝试重置密码，请将验证码：<h2>" + code + "</h2>填入以完成确认。</p><p align=\"right\">丽军数码</p>"; //邮件内容
            Send(MessageFrom, MessageTo, MessageSubject, MessageBody);
        }
        //发送邮件函数
        public bool Send(MailAddress MessageFrom, string MessageTo, string MessageSubject, string MessageBody)
        {
            MailMessage message = new MailMessage();

            // if (FileUpload1.PostedFile.FileName != "")
            // {
            // Attachment att = new Attachment("d://test.txt");//发送附件的内容
            //    message.Attachments.Add(att);
            // }

            message.From = MessageFrom;
            message.To.Add(MessageTo); //收件人邮箱地址可以是多个以实现群发 
            message.Subject = MessageSubject;
            message.Body = MessageBody;
            //message.Attachments.Add(objMailAttachment);
            message.IsBodyHtml = true; //是否为html格式 
            message.Priority = MailPriority.High; //发送邮件的优先等级 

            SmtpClient sc = new SmtpClient();
            sc.Host = "smtp.qq.com"; //指定发送邮件的服务器地址或IP 
            sc.Port = 25; //指定发送邮件端口 
            sc.Credentials = new System.Net.NetworkCredential("admin@lijun0772.com", "YZVpS2016s"); //指定登录服务器的用户名和密码(发件人的邮箱登陆密码)

            try
            {
                sc.Send(message); //发送邮件 
            }
            catch
            {
                return false;
            }
            return true;

        }
}
