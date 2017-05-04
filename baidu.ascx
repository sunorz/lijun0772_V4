<%@ Control Language="C#" ClassName="baidu" %>
<SCRIPT language=javascript>
    function g(formname) {
        var url = "http://www.baidu.com/baidu";
        if (formname.s[1].checked) {
            formname.ct.value = "2097152";
        }
        else {
            formname.ct.value = "0";
        }
        formname.action = url;
        return true;
    }
</SCRIPT>
<form name="f1" onsubmit="return g(this)"><table bgcolor="#FFFFFF" style="font-size:11pt; color:CCCCCC;">
<tr height="60">
<td style="margin:0px auto;">
<img algin="center" src="http://img.baidu.com/img/logo-137px.gif" border="0" alt="baidu" style="text-align: center"><br />
    <br />
<input name=word maxlength="100" style="border: 1px solid #4B8DF7; width: 402px; height: 19px;font-size:17px; padding:5px; margin:auto;">
<input  type="submit" value="百度一下" style="border-style: none; border-color: #3079ED; background-color: #4B8DF7; padding: 3px; color: #FFFFFF; font-family: 宋体, Arial, Helvetica, sans-serif; height: 31px; width: 88px; font-size: 15px; font-weight: bold; margin:auto;">
<br/><br/>
<input name=tn type=hidden value="bds">
<input name=cl type=hidden value="3">
<input name=ct type=hidden>
<input name=si type=hidden value="www.lijun0772.com">
<div class="mt10"><input name=s type=radio>全网搜索&nbsp;&nbsp; <input name=s type=radio checked> www.lijun0772.com站内搜索</div></td></tr></table></form>

