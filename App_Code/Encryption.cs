using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
///Encryption 的摘要说明
/// </summary>
public class Encryption
{

    public static string Auth(string words)
    {     
    //密码加密，16位MD5加密（两次）  

        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(words + Encry().ToString(), "MD5").ToUpper().Substring(8, 16), "MD5").ToUpper().Substring(8, 16);	

    }
    public static string Encry()
    {
        string key = "sPgy478h8&g78ghG&^GNG*(HUIGHijohgiu";
        return key;
    }
    public static string _KEY = "jUG*BN^1";  //密钥
    public static string _IV = ";M*&BV%$";   //向量

    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string Encode(object dat)
    {
        string data = dat.ToString();
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(_KEY);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(_IV);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();

            string strRet = Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
            return strRet;
        
       
    }

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string Decode(object dat)
    {
        string data = dat.ToString();
              byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(_KEY);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(_IV);

            byte[] byEnc;

            try
            {
                data.Replace("_%_", "/");
                data.Replace("-%-", "#");
                byEnc = Convert.FromBase64String(data);

            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        
    }


   
   
}
