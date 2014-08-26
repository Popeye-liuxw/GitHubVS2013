using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Web;
using System.Web.UI;
using Microsoft.VisualBasic;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Net;

namespace EAPP.CRM.Common
{
    public class Utils
    {
        /// <summary>
        /// 对字符串进行url编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string JSEscape(string str)
        {
            return Microsoft.JScript.GlobalObject.escape(str);
        }
        /// <summary>
        /// 对字符串进行url解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string JSunescape(string str)
        {
            return Microsoft.JScript.GlobalObject.unescape(str);
        }
        /// <summary>
        /// 校验SQL语句，替换" ' "字符
        /// </summary>
        /// <param name="str">SQL语句</param>
        /// <returns>经过替换后的SQL语句</returns>
        public static string ChkSQL(string str)
        {
            if (str == null)
            {
                return "";
            }
            str = str.Replace("'", "''");
            return str;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strIn"></param>
        /// <returns></returns>
        public static string CleanInput(string strIn)
        {
            return Regex.Replace(strIn.Trim(), @"[^\w\.@-]", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ClearBR(string str)
        {
            Regex regex = null;
            Match match = null;
            regex = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);
            for (match = regex.Match(str); match.Success; match = match.NextMatch())
            {
                str = str.Replace(match.Groups[0].ToString(), "");
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string ClearHtml(string strHtml)
        {
            if (strHtml != "")
            {
                Regex regex = null;
                Match match = null;
                regex = new Regex(@"<\/?[^>]*>", RegexOptions.IgnoreCase);
                for (match = regex.Match(strHtml); match.Success; match = match.NextMatch())
                {
                    strHtml = strHtml.Replace(match.Groups[0].ToString(), "");
                }
            }
            return strHtml;
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileFullPath">文件在服务器中的全路径</param>
        /// <returns>成功或失败 false为文件不存在或者删除失败</returns>
        public static bool DeleteFile(string fileFullPath)
        {
            if (File.Exists(fileFullPath))
            {
                try
                {
                    File.Delete(fileFullPath);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns
        [DllImport("dbgHelp", SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string name);
        public static bool CreateDir(string name)
        {
            return MakeSureDirectoryPathExists(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length = length * -1;
                    if (startIndex - length < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex = startIndex - length;
                    }
                }

                if (startIndex > str.Length) return "";
            }
            else
            {
                if (length < 0) return "";

                if (length + startIndex > 0)
                {
                    length = length + startIndex;
                    startIndex = 0;
                }
                else
                {
                    return "";
                }
            }

            if (str.Length - startIndex < length)
            {
                length = str.Length - startIndex;
            }

            return str.Substring(startIndex, length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string EncodeHtml(string strHtml)
        {
            if (strHtml != "")
            {
                strHtml = strHtml.Replace(",", "&def");
                strHtml = strHtml.Replace("'", "&dot");
                strHtml = strHtml.Replace(";", "&dec");
                return strHtml;
            }
            return "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string[] FindNoUTF8File(string Path)
        {
            StringBuilder builder = new StringBuilder();
            FileInfo[] files = new DirectoryInfo(Path).GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension.ToLower().Equals(".htm"))
                {
                    FileStream sbInputStream = new FileStream(files[i].FullName, FileMode.Open, FileAccess.Read);
                    bool flag = IsUTF8(sbInputStream);
                    sbInputStream.Close();
                    if (!flag)
                    {
                        builder.Append(files[i].FullName);
                        builder.Append("\r\n");
                    }
                }
            }
            return SplitString(builder.ToString(), "\r\n");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string FormatBytesStr(int bytes)
        {
            if (bytes > 0x40000000)
            {
                double num = bytes / 0x40000000;
                return (num.ToString("0") + "G");
            }
            if (bytes > 0x100000)
            {
                double num2 = bytes / 0x100000;
                return (num2.ToString("0") + "M");
            }
            if (bytes > 0x400)
            {
                double num3 = bytes / 0x400;
                return (num3.ToString("0") + "K");
            }
            return (bytes.ToString() + "Bytes");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyProductName()
        {
            return FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyVersion()
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            return string.Format("{0}.{1}.{2}", versionInfo.FileMajorPart, versionInfo.FileMinorPart, versionInfo.FileBuildPart);
        }



        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static string GetDate(string datetimestr, string replacestr)
        {
            if (datetimestr == null)
            {
                return replacestr;
            }
            if (datetimestr.Equals(""))
            {
                return replacestr;
            }
            try
            {
                datetimestr = Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
            }
            catch
            {
                return replacestr;
            }
            return datetimestr;
        }

        //时间转换
        public static string Gettime(string date)
        {
            string dtime = "";
            if (date.ToString() != "")
            {
                dtime = Convert.ToDateTime(date).ToString("yyyy-MM-dd");
            }
            else
            {
                dtime = "";
            }
            return dtime;

        }

        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        public static string GetEmailHostName(string strEmail)
        {
            if (strEmail.IndexOf("@") < 0)
            {
                return "";
            }
            return strEmail.Substring(strEmail.LastIndexOf("@")).ToLower();
        }

        public static string GetFilename(string url)
        {
            if (url == null)
            {
                return "";
            }
            string[] textArray = url.Split(new char[] { '/' });
            return textArray[textArray.Length - 1].Split(new char[] { '?' })[0];
        }

        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }

        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else if (strSearch == stringArray[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public static string GetMapPath(string strPath)
        {
            return HttpContext.Current.Server.MapPath(strPath);
        }

        /// <summary>
        /// 获取字符串字节长度
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            string text = p_SrcString;
            if (p_Length < 0)
            {
                return text;
            }
            byte[] sourceArray = Encoding.Default.GetBytes(p_SrcString);
            if (sourceArray.Length <= p_Length)
            {
                return text;
            }
            int length = p_Length;
            int[] numArray = new int[p_Length];
            byte[] destinationArray = null;
            int num2 = 0;
            for (int i = 0; i < p_Length; i++)
            {
                if (sourceArray[i] > 0x7f)
                {
                    num2++;
                    if (num2 == 3)
                    {
                        num2 = 1;
                    }
                }
                else
                {
                    num2 = 0;
                }
                numArray[i] = num2;
            }
            if ((sourceArray[p_Length - 1] > 0x7f) && (numArray[p_Length - 1] == 1))
            {
                length = p_Length + 1;
            }
            destinationArray = new byte[length];
            Array.Copy(sourceArray, destinationArray, length);
            return (Encoding.Default.GetString(destinationArray) + p_TailString);
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string GetTrueForumPath()
        {
            string path = HttpContext.Current.Request.Path;
            if (path.LastIndexOf("/") != path.IndexOf("/"))
            {
                return path.Substring(path.IndexOf("/"), path.LastIndexOf("/") + 1);
            }
            return "/";
        }

        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        #region InArray InIPArray
        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }

        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }

        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }

        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return (GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0);
        }

        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }

        public static bool InIPArray(string ip, string[] iparray)
        {
            string[] textArray = SplitString(ip, ".");
            for (int i = 0; i < iparray.Length; i++)
            {
                string[] textArray2 = SplitString(iparray[i], ".");
                int num2 = 0;
                for (int j = 0; j < textArray2.Length; j++)
                {
                    if (textArray2[j] == "*")
                    {
                        return true;
                    }
                    if ((textArray.Length <= j) || (textArray2[j] != textArray[j]))
                    {
                        break;
                    }
                    num2++;
                }
                if (num2 == 4)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 运用正则表达式
        public static bool IsBase64String(string str)
        {
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }
        public static bool IsImgFilename(string filename)
        {
            if (filename.EndsWith(".") || (filename.IndexOf(".") == -1))
            {
                return false;
            }
            string text = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            return ((((text == "jpg") || (text == "jpeg")) || ((text == "png") || (text == "bmp"))) || (text == "gif"));
        }

        public static bool IsIP(string ip)
        {
            return new Regex(@"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$").IsMatch(ip);
        }

        public static bool IsNumber(string strNumber)
        {
            return new Regex(@"^\d+$").IsMatch(strNumber);
        }
        public static bool IsFloat(string strNumber)
        {
            return new Regex(@"^\d+\.{0,1}\d*$").IsMatch(strNumber);
        }

        public static bool IsNumberArray(string[] strNumber)
        {
            if (strNumber == null)
            {
                return false;
            }
            if (strNumber.Length < 1)
            {
                return false;
            }
            foreach (string text in strNumber)
            {
                if (!IsNumber(text))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, "^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        private static bool IsUTF8(FileStream sbInputStream)
        {
            bool flag = true;
            long length = sbInputStream.Length;
            byte num2 = 0;
            for (int i = 0; i < length; i++)
            {
                byte num3 = (byte)sbInputStream.ReadByte();
                if ((num3 & 0x80) != 0)
                {
                    flag = false;
                }
                if (num2 == 0)
                {
                    if (num3 >= 0x80)
                    {
                        do
                        {
                            num3 = (byte)(num3 << 1);
                            num2 = (byte)(num2 + 1);
                        }
                        while ((num3 & 0x80) != 0);
                        num2 = (byte)(num2 - 1);
                        if (num2 == 0)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if ((num3 & 0xc0) != 0x80)
                    {
                        return false;
                    }
                    num2 = (byte)(num2 - 1);
                }
            }
            if (num2 > 0)
            {
                return false;
            }
            if (flag)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        #endregion

        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        public static string ReplaceStrToScript(string str)
        {
            str = str.Replace(@"\", @"\\");
            str = str.Replace("'", @"\'");
            str = str.Replace("\"", "\\\"");
            return str;
        }

        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            Stream stream = null;
            byte[] buffer = new byte[0x2710];
            try
            {
                stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
                long length = stream.Length;
                HttpContext.Current.Response.ContentType = filetype;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + UrlEncode(filename.Trim()));
                while (length > 0)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        int count = stream.Read(buffer, 0, 0x2710);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, count);
                        HttpContext.Current.Response.Flush();
                        buffer = new byte[0x2710];
                        length -= count;
                    }
                    else
                    {
                        length = -1;
                    }
                }
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("Error : " + exception.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// 去除字符串右边的 回车符 和 换行符
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>没有回车换行符的字符串</returns>
        public static string RTrim(string str)
        {
            for (int i = str.Length; i >= 0; i--)
            {
                char ch = str[i];
                if (!ch.Equals(" "))
                {
                    char ch2 = str[i];
                    if (!ch2.Equals("\r"))
                    {
                        char ch3 = str[i];
                        if (!ch3.Equals("\n"))
                        {
                            continue;
                        }
                    }
                }
                str.Remove(i, 1);
            }
            return str;
        }

        /// <summary>
        /// 在字符串末尾添加 指定个数的空格
        /// </summary>
        /// <param name="nSpaces">要添加的空格的个数</param>
        /// <returns>添加了N个空格的字符串</returns>
        public static string Spaces(int nSpaces)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < nSpaces; i++)
            {
                builder.Append(" &nbsp;&nbsp;");
            }
            return builder.ToString();
        }
        /// <summary>
        /// 字符串分割
        /// </summary>
        /// <param name="strContent">原始字符串</param>
        /// <param name="strSplit">分隔符号</param>
        /// <returns>字符数组</returns>
        public static string[] SplitString(string strContent, string strSplit)
        {
            if (strContent.IndexOf(strSplit) < 0)
            {
                return new string[] { strContent };
            }
            return Regex.Split(strContent, strSplit.Replace(".", @"\."), RegexOptions.IgnoreCase);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="bantext"></param>
        /// <returns></returns>
        public static string StrFilter(string str, string bantext)
        {
            string oldValue = "";
            string newValue = "";
            string[] textArray = SplitString(bantext, "\r\n");
            for (int i = 0; i < textArray.Length; i++)
            {
                oldValue = textArray[i].Substring(0, textArray[i].IndexOf("="));
                newValue = textArray[i].Substring(textArray[i].IndexOf("=") + 1);
                str = str.Replace(oldValue, newValue);
            }
            return str;
        }
        /// <summary>
        /// 格式化字符串 替换 回车换行符号
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>替换后的字符串</returns>
        public static string StrFormat(string str)
        {
            if (str == null)
            {
                return "";
            }
            str = str.Replace("\r\n", "<br />");
            str = str.Replace("\n", "<br />");
            return str;
        }

        #region 数据类型转换
        /// <summary>
        /// 字符串转换成为 Float 型
        /// </summary>
        /// <param name="strValue">字符串</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换得到的浮点数</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }
            float num = defValue;
            if ((strValue != null) && new Regex(@"^([-]|[0-9])[0-9]*(\.\w*)?$").IsMatch(strValue.ToString()))
            {
                num = Convert.ToSingle(strValue);
            }
            return num;
        }
        /// <summary>
        /// 字符串转换成为 Int 型
        /// </summary>
        /// <param name="strValue">字符串</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换得到的Int数</returns>
        public static int StrToInt(object strValue, int defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 9))
            {
                return defValue;
            }
            int num = defValue;
            if ((strValue != null) && new Regex("^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString()))
            {
                num = Convert.ToInt32(strValue);
            }
            return num;
        }
        /// <summary>
        /// 字符串转换成为 Int64 型
        /// </summary>
        /// <param name="strValue">字符串</param>
        /// <param name="defValue">默认值</param>
        /// <returns>转换得到的Int数</returns>
        public static Int64 StrToInt64(object strValue, int defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 9))
            {
                return defValue;
            }
            Int64 num = defValue;
            if ((strValue != null) && new Regex("^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString()))
            {
                num = Convert.ToInt64(strValue);
            }
            return num;
        }
        /// <summary>
        /// 把原始字符串转换为简体中文字符串
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>简体中文字符串</returns>
        //public static string ToSChinese(string str)
        //{
        //    return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0);
        //}
        /// <summary>
        /// 把原始字符串转换为
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>繁体中文字符串</returns>
        //public static string ToTChinese(string str)
        //{
        //    return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0);
        //}
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="outpath"></param>
        public void transHtml(string path, string outpath)
        {
            FileStream stream;
            Page page = new Page();
            StringWriter writer = new StringWriter();
            page.Server.Execute(path, writer);
            if (File.Exists(page.Server.MapPath("") + @"\" + outpath))
            {
                File.Delete(page.Server.MapPath("") + @"\" + outpath);
                stream = File.Create(page.Server.MapPath("") + @"\" + outpath);
            }
            else
            {
                stream = File.Create(page.Server.MapPath("") + @"\" + outpath);
            }
            byte[] bytes = Encoding.Default.GetBytes(writer.ToString());
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
        }

        #region 获取年数
        public static string GetYear(DateTime begin, DateTime end)
        {
            string year = "";

            if (end.Year == begin.Year)
            {
                if (end.Month == begin.Month)
                {
                    if (end.Day - begin.Day > 0)
                        year = "1";
                    else
                        year = "0";
                }
                else
                {
                    if (end.Month - begin.Month > 0)
                    {

                        year = "1";

                    }
                    else
                    {
                        if (end.Day - begin.Day > 0)
                            year = "1";
                        else
                            year = "0";
                    }
                }
            }
            else
            {
                if (end.Year - begin.Year > 0)
                {
                    if (end.Month == begin.Month)
                    {
                        if (end.Day - begin.Day > 0)
                            year = Convert.ToString(end.Year - begin.Year + 1);
                        else
                            year = Convert.ToString(end.Year - begin.Year);
                    }
                    else
                    {
                        if (end.Day - begin.Day > 0)
                            year = Convert.ToString(end.Year - begin.Year + 1);
                        else
                            year = Convert.ToString(end.Year - begin.Year);
                    }
                }
                else
                {
                    year = "0";
                }
            }

            return year;
        }
        #endregion

        #region 对给定的 Url 进行编码
        /// <summary>
        /// 对给定的 Url 进行解码
        /// </summary>
        /// <param name="str">编码过的 Url</param>
        /// <returns>解码后的 Url</returns>
        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }


        /// <summary>
        /// 对给定的 Url 进行编码
        /// </summary>
        /// <param name="str">给定的Url</param>
        /// <returns>编码后的 Url</returns>
        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }
        #endregion


        #region 读写 cookie
        /// <summary>
        /// 读写 cookie
        /// </summary>
        /// <param name="strName">信息名称</param>
        /// <param name="strValue">信息内容</param>
        public static void WriteCookie(string strName, string strValue, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            if (!String.IsNullOrEmpty(domain)) cookie.Domain = domain;
            strValue = JSEscape(strValue);
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 写 cookie
        /// </summary>
        /// <param name="strName">信息名称</param>
        /// <param name="strValue">信息内容</param>
        /// <param name="expires">过期时间</param>
        public static void WriteCookie(string strName, string strValue, int expires, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            if (!String.IsNullOrEmpty(domain)) cookie.Domain = domain;
            cookie.Value = JSEscape(strValue);
            cookie.Expires = DateTime.Now.AddMonths((int)expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static string GetCookie(string strName)
        {
            if ((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[strName] != null))
            {
                string value = HttpContext.Current.Request.Cookies[strName].Value.ToString();

                return JSunescape(value);
            }
            return "";
        }

        public static void ClearCookie(string strName, string domainName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                cookie.Values.Clear();
                if (!domainName.Trim().Equals("")) cookie.Domain = domainName;
                HttpContext.Current.Response.SetCookie(cookie);
            }
        }

        public static void ClearCookie(string strName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];

            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-1);
                cookie.Values.Clear();
                HttpContext.Current.Response.SetCookie(cookie);
            }
        }
        #endregion

        #region 读写Session

        public static void SetSession(string sessionName, object value)
        {
            if (null == HttpContext.Current.Session[sessionName])
            {
                HttpContext.Current.Session.Add(sessionName, value);
            }
            else
            {
                HttpContext.Current.Session[sessionName] = value;
            }
        }

        public static object GetSessionObj(string sessionName)
        {
            return HttpContext.Current.Session[sessionName];
        }

        public static string GetSession(string sessionName)
        {
            object val = GetSessionObj(sessionName);
            if (null == val)
                return "";
            else
                return val.ToString();
        }

        public static void ClearSession(string sessionName)
        {
            HttpContext.Current.Session.Remove(sessionName);
        }

        #endregion

        #region 获取POST
        /// <summary>
        /// 获取POST
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }
        #endregion

        #region 转换价格
        /// <summary>
        /// 转换价格
        /// </summary>
        /// <param name="P_Price">价格</param>
        /// <returns>价格</returns>
        public static string GetMoney(string P_Price)
        {
            int idex = P_Price.IndexOf(".");
            if (idex > 0 && P_Price.Length > idex + 2)
                return P_Price.Substring(0, idex + 3);
            else
                return P_Price;

        }
        #endregion

        #region 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="length">要显示的字符串长度</param>
        /// <param name="str">要检测的字符串</param>
        /// <returns>检测过的字符串</returns>
        public static string IsLength(int length, string str)
        {
            str = RemoveHTML(str);

            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(str);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }

                try
                {
                    tempString += str.Substring(i, 1);
                }
                catch
                {
                    break;
                }

                if (tempLen > length)
                    break;
            }
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(str);
            if (mybyte.Length > length)
                tempString += "";

            return tempString;
        }
        #endregion

        #region 拼接标签
        /// <summary>
        /// 拼接标签
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <returns>拼接好的字符串</returns>
        public static string LableSet(string strName, string strValue)
        {
            return "┆" + strName + "$" + strValue;
        }
        #endregion

        #region 过滤html代码
        /// <summary>
        /// 过滤所有HTML代码
        /// </summary>
        /// <param name="strHTML"></param>
        /// <returns></returns>
        public static string RemoveHTML(string html)
        {
            //html = FilterScript(html);

            //html = FilterAHrefScript(html);

            //html = FilterSrc(html);

            //html = FilterInclude(html);

            //html = FilterObject(html);

            //html = FilterIframe(html);

            //html = FilterFrameset(html);

            html = FilterHtml(html);

            return html;

        }
        /// <summary>
        /// 过滤部分html危险代码
        /// </summary>
        /// <param name="strHTML"></param>
        /// <returns></returns>
        public static string RemoveHTMLForEditor(string html)
        {
            html = FilterScript(html);

            html = FilterAHrefScript(html);

            html = FilterSrc(html);

            //html = FilterInclude(html);

            //html = FilterObject(html);

            html = FilterIframe(html);

            html = FilterFrameset(html);

            return html;
        }

        public static string FilterScript(string content)
        {
            string commentPattern = @"(?'comment'<!--.*?--[ \n\r]*>)";
            string embeddedScriptComments = @"(\/\*.*?\*\/|\/\/.*?[\n\r])";
            string scriptPattern = String.Format(@"(?'script'<[ \n\r]*script[^>]*>(.*?{0}?)*<[ \n\r]*/script[^>]*>)", embeddedScriptComments);
            // 包含注释和Script语句
            string pattern = String.Format(@"(?s)({0}|{1})", commentPattern, scriptPattern);

            return StripScriptAttributesFromTags(Regex.Replace(content, pattern, string.Empty, RegexOptions.IgnoreCase));
        }

        private static string StripScriptAttributesFromTags(string content)
        {
            string eventAttribs = @"on(blur|c(hange|lick)|dblclick|focus|keypress|(key|mouse)(down|up)|(un)?load
                            |mouse(move|o(ut|ver))|reset|s(elect|ubmit))";

            string pattern = String.Format(@"(?inx)
                \<(\w+)\s+
                    (
                        (?'attribute'
                        (?'attributeName'{0})\s*=\s*
                        (?'delim'['""]?)
                        (?'attributeValue'[^'"">]+)
                        (\3)
                    )
                    |
                    (?'attribute'
                        (?'attributeName'href)\s*=\s*
                        (?'delim'['""]?)
                        (?'attributeValue'javascript[^'"">]+)
                        (\3)
                    )
                    |
                    [^>]
                )*
            \>", eventAttribs);
            Regex re = new Regex(pattern);
            // 使用MatchEvaluator的委托
            return re.Replace(content, new MatchEvaluator(StripAttributesHandler));
        }


        private static string StripAttributesHandler(Match m)
        {
            if (m.Groups["attribute"].Success)
            {
                return m.Value.Replace(m.Groups["attribute"].Value, "");
            }
            else
            {
                return m.Value;
            }
        }

        private static string FilterAHrefScript(string content)
        {
            string newstr = FilterScript(content);
            string regexstr = @" href[ ^=]*= *[\s\S]*script *:";
            return Regex.Replace(newstr, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterSrc(string content)
        {
            string newstr = FilterScript(content);
            string regexstr = @" src *= *['""]?[^\.]+\.(js|vbs|asp|aspx|php|jsp)['""]";
            return Regex.Replace(newstr, regexstr, @"", RegexOptions.IgnoreCase);
        }

        private static string FilterInclude(string content)
        {
            string newstr = FilterScript(content);
            string regexstr = @"<[\s\S]*include *(file|virtual) *= *[\s\S]*\.(js|vbs|asp|aspx|php|jsp)[^>]*>";
            return Regex.Replace(newstr, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterObject(string content)
        {
            string regexstr = @"(?i)<Object([^>])*>(\w|\W)*</Object([^>])*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterIframe(string content)
        {
            string regexstr = @"(?i)<Iframe([^>])*>(\w|\W)*</Iframe([^>])*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterFrameset(string content)
        {
            string regexstr = @"(?i)<Frameset([^>])*>(\w|\W)*</Frameset([^>])*>";
            return Regex.Replace(content, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterHtml(string content)
        {
            string newstr = FilterScript(content);
            string regexstr = @"<[^>]*>";
            return Regex.Replace(newstr, regexstr, string.Empty, RegexOptions.IgnoreCase);
        }

        #endregion

        #region 字符串中是否还有汉字
        /// <summary>
        /// 字符串中是否还有汉字
        /// </summary>
        /// <param name="testString"></param>
        /// <returns></returns>
        public static bool IsIncludeChineseCode(string testString)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(testString, @"[\u4e00-\u9fa5]+"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 从数组中删除重复的项
        /// tc 08-11-18 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] RepaceSpilthItem(string[] str)
        {
            System.Collections.ArrayList list = new System.Collections.ArrayList();

            string tempStr = "";

            foreach (string s in str)
            {
                tempStr = s.ToLower();

                if (list.Contains(tempStr)) continue;

                list.Add(tempStr);
            }

            return (string[])list.ToArray(typeof(string));
        }

        /// <summary>
        /// 把字符串数组转换成以，号隔开的字符串
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string ArrayToString(string[] strs)
        {
            string result = "";

            foreach (string s in strs)
            {
                result += "," + s;
            }

            return result.Substring(1);
        }

        /// <summary>
        /// 分类列表左右追加逗号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string AppendComma(string s)
        {
            if (!s.StartsWith(","))
                s = "," + s;

            if (!s.EndsWith(","))
                s = s + ",";

            s = s.Replace(",,", ",");

            return s;
        }
        /// <summary>
        /// 删除分类列表左右逗号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoveComma(string s)
        {
            s = s.Replace(",,", ",");

            if (s.StartsWith(",")) s = s.Substring(1);

            if (s.EndsWith(",")) s = s.Substring(0, s.Length - 1);

            return s;
        }

        /// <summary>
        /// 删除分类列表开始位置逗号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoveStartComma(string s)
        {
            s = s.Replace(",,", ",");

            if (s.StartsWith(",")) s = s.Substring(1);

            return s;
        }

        /// <summary>
        /// 删除分类列表结束位置逗号
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoveEndComma(string s)
        {
            s = s.Replace(",,", ",");

            if (s.EndsWith(",")) s = s.Substring(0, s.Length - 1);

            return s;
        }

        public static string GetDomainHost()
        {
            string host = "";
            string currentFullHost = HttpContext.Current.Request.Params["HTTP_HOST"].ToString();
            if (currentFullHost.Contains("localhost")
                || currentFullHost.Contains("127.0.0.1"))
            {
                host = "0.0.1";
            }
            else
            {
                host = HttpContext.Current.Request.Params["HTTP_HOST"].Substring(HttpContext.Current.Request.Params["HTTP_HOST"].IndexOf('.'));
            }
            return host;
        }
    }
}
