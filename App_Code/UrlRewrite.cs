using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for UrlRewrite
/// </summary>
public class UrlRewrite
{
	public UrlRewrite()
	{
		//
		// TODO: Add constructor logic here
		//


	}

    public void escreveUrl()
    {
        try
        {
            HttpRequest Request = HttpContext.Current.Request;

            XElement objXElement = XElement.Load(Request.PhysicalApplicationPath + "xml\\UrlRewrite.xml");

            if (objXElement.HasElements)
            {
                var xml = from rule in objXElement.Descendants("rule")
                          select rule;

                if (xml.Count<XElement>() > 0)
                {
                    Dictionary<Regex, string> urlRewrite = new Dictionary<Regex, string>();

                    foreach (XElement element in xml)
                    {
                        urlRewrite.Add(new Regex(Request.ApplicationPath + element.Element("url").Value, RegexOptions.IgnoreCase),
                                       Request.ApplicationPath + element.Element("rewrite").Value);
                    }

                    foreach (KeyValuePair<Regex, string> url in urlRewrite)
                    {
                        if (url.Key.Match(HttpContext.Current.Request.Path).Success)
                        {
                            //HttpContext.Current.Response.Write(HttpContext.Current.Request.Path + "<br>" + url.Value);
                            //HttpContext.Current.Response.End();
                            HttpContext.Current.RewritePath(url.Key.Replace(HttpContext.Current.Request.Path, url.Value));
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}