using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RewriteUrl
/// </summary>
  public class RewriteUrl : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
            //
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            string path = context.Request.Path.ToUpperInvariant();
            string url = context.Request.RawUrl.ToUpperInvariant();

            if (url.Contains("/Categoria/"))
            {
                string[] parameters = url.Substring(url.IndexOf("/Categoria/")+1).Split('/');
                string type = parameters[0];
                string product = parameters[1];
                string operation = parameters[2];

                if (type.Equals("Categoria")/* && operation.Contains("VISUALIZAR")*/)
                {
                    WebService ws = new WebService();
                    DataSet dados = new DataSet();
                    dados = ws.descricaoCategoria(Convert.ToString(HttpContext.Current.Request.QueryString["tipo_categoria"].ToString()));

                    context.RewritePath("~/Categoria.aspx?id=" + HttpContext.Current.Request.QueryString["tipo_categoria"].ToString());
                }
            }
        }

        #endregion
    }
