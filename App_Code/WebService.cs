using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web.Script.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]

public class WebService : System.Web.Services.WebService 
{
    private string connstring = ConfigurationManager.AppSettings["ConnectionString"];

    public WebService () 
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod(Description = "Montar Menus")]
    public DataSet montamenu(string opcao) 
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand(" Select codigo,descricao from [categoria] where tipo_categoria="+opcao+" order by descricao ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtCategoria = new DataTable("categoria");
        adpt.Fill(dtCategoria);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtCategoria);

        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Montar Banner Lateral")]
    public DataSet montabannerlateral(string localbanner)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;
        if (localbanner == "2")
        {
            string comando = "";

            comando = "select b.codigo,b.descricao,b.largura,b.altura,a.status from banner b " +
                      "inner join anuncio a on a.codigo_cliente = b.codigo_cliente " +
                      "inner join cliente c on c.codigo = b.codigo_cliente " +
                      "where b.codigo_local_banner = " + localbanner + " and b.status=1 and a.status=1  " +
                      "ORDER BY NEWID() ";

            SqlCommand cmd = new SqlCommand(comando, MyConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            // Cria e preenche o DataTable
            DataTable dtBanner = new DataTable("banner");
            adpt.Fill(dtBanner);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtBanner);
            cmd.Dispose();
            MyConnection.Close();

            return ds;
        }
        else
        {

            string comando = "";

            comando = "select b.codigo,b.descricao,b.largura,b.altura,a.status from banner b " +
                      "inner join anuncio a on a.codigo_cliente = b.codigo_cliente " +
                      "inner join cliente c on c.codigo = b.codigo_cliente " +
                      "where b.codigo_local_banner = " + localbanner + " and b.status=1 and a.status=1  ";

            SqlCommand cmd = new SqlCommand(comando, MyConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            // Cria e preenche o DataTable
            DataTable dtBanner = new DataTable("banner");
            adpt.Fill(dtBanner);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtBanner);
            cmd.Dispose();
            MyConnection.Close();

            return ds;
        }
    }

    [WebMethod(Description = "Alimenta Categoria")]
    public DataSet alimentacategoria(int tipoCategoria)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand(" Select codigo,descricao,texto from [categoria] where codigo=" + tipoCategoria.ToString() + "  ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("categoria");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Dados Categoria")]
    public DataSet DadosCategoria()
    {

        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand(" Select codigo,descricao,tipo_categoria,texto from [categoria] order by codigo ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("categoria");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    
    }

    [WebMethod(Description = "Alimenta Anunciante")]
    public DataSet alimentaAnunciante(int tipoCategoria,string order,int codAnunciante)
    {
        if (codAnunciante == -1)
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = connstring;

            SqlCommand cmd = new SqlCommand("SELECT anunciante.codigo,anunciante.descricao, anunciante.endereco, anunciante.telefone, anunciante.email, "+ 
                                            "anunciante.site, anunciante.bairro, anunciante.cidade,anunciante.razao_social, "+ 
                                            "imagem.descricao AS nomeimagem,imagem.codigo as codigo_imagem, imagem.tamanho, "+
                                            "imagem.tipo,imagem.configuracao,anunciante.status,bonus.codigo as bonus,anunciante.categoria_padrao  "+
                                            "FROM anunciante "+ 
                                            "INNER JOIN anuncio_categoria ON anunciante.codigo = anuncio_categoria.codigo_anunciante "+
                                            "INNER JOIN imagem ON anunciante.codigo = imagem.codigo_anunciante "+
                                            "LEFT JOIN bonus ON anunciante.codigo = bonus.codigo_anunciante "+
                                            "WHERE (anuncio_categoria.codigo_categoria = "+tipoCategoria.ToString()+" and anunciante.status=1 )  " + order + "  ", MyConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);

            // Cria e preenche o DataTable
            DataTable dtBanner = new DataTable("anunciante");
            adpt.Fill(dtBanner);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtBanner);
            cmd.Dispose();
            MyConnection.Close();

            return ds;
        }
        else
        {
            SqlConnection MyConnection = new SqlConnection();
            MyConnection.ConnectionString = connstring;

            SqlCommand cmd = new SqlCommand("SELECT anunciante.codigo,anunciante.descricao, anunciante.endereco, anunciante.telefone, "+
                                            "anunciante.email, anunciante.site, anunciante.bairro,0 as codigo_imagem, anunciante.cidade, "+
                                            "anunciante.razao_social,anunciante.endereco_boleto,anunciante.nome,anunciante.senha, "+
                                            "anunciante.cpf,anunciante.rg,anunciante.cnpj,anunciante.cep,anunciante.status,anunciante.categoria_padrao "+ 
                                            "FROM anunciante " +
                                            "WHERE (anunciante.codigo = "+ codAnunciante.ToString() +" )  ", MyConnection);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);

            // Cria e preenche o DataTable
            DataTable dtBanner = new DataTable("anunciante");
            adpt.Fill(dtBanner);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtBanner);
            cmd.Dispose();
            MyConnection.Close();

            return ds;
        
        
        } 
    }

    [WebMethod(Description = "Monta Banner Superior")]
    public DataSet montaBannerSuperior(int tipoCategoria,int local_banner)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if (tipoCategoria != 0)
        {

            comando = " Select banner.codigo,descricao,largura,altura from [banner] " +
                      " inner join banner_categoria on banner.codigo = banner_categoria.codigo_banner " +
                      " where codigo_categoria=" + tipoCategoria.ToString() + " and codigo_local_banner = " + local_banner.ToString() + " and status=1 ";
        }
        else
        {
            comando = " Select banner.codigo,descricao,largura,altura from [banner] " +
                      " where codigo_local_banner = " + local_banner.ToString() + " and status=1 ";        
        
        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("banner");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Monta Banner Permuta")]
    public DataSet montaBannerPermuta()
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";

        comando = " Select banner.codigo,descricao,largura,altura from [banner] " +
                  " left join banner_categoria on banner.codigo = banner_categoria.codigo_banner " +
                  " where codigo_local_banner = 1 and status=1 order by NEWID() ";

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("banner");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }


    [WebMethod(Description = "Inclui Anunciante")]
    public int IncluiAnunciante(int vAnunciante_Id,string vDescricao,string vEndereco,string vTelefone,string vEmail,string vSite,string vNome,int vStatus,string vSenha,string vBairro,string vCidade,string vRazao,string vCnpj,string vCpf, string vRg, string vEnderecoBoleto,string vCep,int vCategoriaPadrao)
    {
        #region anunciante

            SqlConnection MyConnection2 = new SqlConnection();
            MyConnection2.ConnectionString = connstring;

            SqlCommand MyCommand = new SqlCommand("sp_inclui_anunciante", MyConnection2);
            SqlTransaction transacao;
            MyConnection2.Open();

            transacao = MyConnection2.BeginTransaction("iTrans");
            MyCommand.Connection = MyConnection2;
            MyCommand.Transaction = transacao;

            try
            {
                MyCommand.CommandType = CommandType.StoredProcedure;
                MyCommand.Parameters.Add("@codigo", SqlDbType.Int).Value = vAnunciante_Id;
                MyCommand.Parameters.Add("@descricao", SqlDbType.NVarChar).Value = vDescricao;
                MyCommand.Parameters.Add("@endereco", SqlDbType.NVarChar).Value = vEndereco;
                MyCommand.Parameters.Add("@telefone", SqlDbType.NVarChar).Value = vTelefone;
                MyCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = vEmail;
                MyCommand.Parameters.Add("@site", SqlDbType.NVarChar).Value = vSite;
                MyCommand.Parameters.Add("@nome", SqlDbType.NVarChar).Value = vNome;
                MyCommand.Parameters.Add("@status", SqlDbType.Int).Value = vStatus;
                MyCommand.Parameters.Add("@senha", SqlDbType.NVarChar).Value = vSenha;
                MyCommand.Parameters.Add("@bairro", SqlDbType.NVarChar).Value = vBairro;
                MyCommand.Parameters.Add("@cidade", SqlDbType.NVarChar).Value = vCidade;
                MyCommand.Parameters.Add("@razao_social", SqlDbType.NVarChar).Value = vRazao;
                MyCommand.Parameters.Add("@cnpj", SqlDbType.NVarChar).Value = vCnpj;
                MyCommand.Parameters.Add("@cpf", SqlDbType.NVarChar).Value = vCpf;
                MyCommand.Parameters.Add("@rg", SqlDbType.NVarChar).Value = vRg;
                MyCommand.Parameters.Add("@endereco_boleto", SqlDbType.NVarChar).Value = vEnderecoBoleto;
                MyCommand.Parameters.Add("@cep", SqlDbType.NVarChar).Value = vCep;
                MyCommand.Parameters.Add("@categoria_padrao", SqlDbType.Int).Value = vCategoriaPadrao;

                MyCommand.ExecuteNonQuery();
                transacao.Commit();
                MyCommand.Dispose();
                MyConnection2.Close();

                SqlConnection MyConnection3 = new SqlConnection();
                MyConnection3.ConnectionString = connstring;

                SqlCommand MyCommand3 = new SqlCommand(" SELECT MAX(codigo) AS codigo_anunciante FROM anunciante ", MyConnection3);

                MyCommand3.CommandType = CommandType.Text;
                MyCommand3.Connection.Open();

                SqlDataReader MyDataReader3 = MyCommand3.ExecuteReader();

                if (MyDataReader3.Read())
                {
                    return MyDataReader3.GetInt32(0);
                }

                MyCommand3.Dispose();  //Dispose of the Command object.
                MyConnection3.Close(); //Close the connection.


            }
            catch (Exception ex)
            {
                // Attempt to roll back the transaction.
                try
                {
                    transacao.Rollback();
                }
                catch (Exception ex2)
                {
                }

            }
           #endregion
          return 0;           
    }

    [WebMethod(Description = "Inclui Categoria Anunciante")]
    public int IncluiCategoriaAnunciante(int codigo,int vCodigoAnunciante,int vCategoria)
    {
       SqlConnection MyConnection3 = new SqlConnection();
       MyConnection3.ConnectionString = connstring;

       SqlCommand MyCommand3 = new SqlCommand(" select * FROM anuncio_categoria WHERE codigo_anunciante = "+vCodigoAnunciante.ToString()+" and codigo_categoria = "+vCategoria.ToString()+"  ", MyConnection3);

       MyCommand3.CommandType = CommandType.Text;
       MyCommand3.Connection.Open();

       SqlDataReader MyDataReader3 = MyCommand3.ExecuteReader();

       if (! MyDataReader3.Read())
       {
          #region Inclui_anuncio_categoria


                SqlConnection MyConnection4 = new SqlConnection();
                MyConnection4.ConnectionString = connstring;

                SqlCommand MyCommand4 = new SqlCommand("sp_inclui_anuncio_categoria", MyConnection4);
                SqlTransaction transacao2;
                MyConnection4.Open();

                transacao2 = MyConnection4.BeginTransaction("iTrans");
                MyCommand4.Connection = MyConnection4;
                MyCommand4.Transaction = transacao2;

                try
                {
                    MyCommand4.CommandType = CommandType.StoredProcedure;
                    MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
                    MyCommand4.Parameters.Add("@codigo_anunciante", SqlDbType.Int).Value = vCodigoAnunciante;
                    MyCommand4.Parameters.Add("@codigo_categoria", SqlDbType.Int).Value = vCategoria;

                    MyCommand4.ExecuteNonQuery();
                    transacao2.Commit();
                    MyCommand4.Dispose();
                    MyConnection4.Close();
                }
                catch (Exception ex)
                {
                    // Attempt to roll back the transaction.
                    try
                    {
                        transacao2.Rollback();
                    }
                    catch (Exception ex2)
                    {
                    }

                }
                MyCommand4.Dispose();  //Dispose of the Command object.
                MyConnection4.Close(); //Close the connection.
                #endregion
       }
       return 0;    
    }

    [WebMethod(Description = "Incluir Categoria")]
    public int IncluirCategoria(int codigo,string nome,int tipocategoria,string observacao)
    {

        #region Categoria

            SqlConnection MyConnection2 = new SqlConnection();
            MyConnection2.ConnectionString = connstring;

            SqlCommand MyCommand = new SqlCommand("sp_inclui_categoria", MyConnection2);
            SqlTransaction transacao;
            MyConnection2.Open();

            transacao = MyConnection2.BeginTransaction("iTrans");
            MyCommand.Connection = MyConnection2;
            MyCommand.Transaction = transacao;

            try
            {
                MyCommand.CommandType = CommandType.StoredProcedure;
                MyCommand.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
                MyCommand.Parameters.Add("@descricao", SqlDbType.NVarChar).Value = nome;
                MyCommand.Parameters.Add("@tipo_categoria", SqlDbType.Int).Value = tipocategoria;
                MyCommand.Parameters.Add("@texto", SqlDbType.NVarChar).Value = observacao;

                MyCommand.ExecuteNonQuery();

                transacao.Commit();
                MyCommand.Dispose();
                MyConnection2.Close();

                SqlConnection MyConnection3 = new SqlConnection();
                MyConnection3.ConnectionString = connstring;

                SqlCommand MyCommand3 = new SqlCommand(" SELECT MAX(codigo) AS codigo_categoria FROM categoria ", MyConnection3);

                MyCommand3.CommandType = CommandType.Text;
                MyCommand3.Connection.Open();

                SqlDataReader MyDataReader3 = MyCommand3.ExecuteReader();

                if (MyDataReader3.Read())
                {
                    return MyDataReader3.GetInt32(0);
                }

                MyCommand3.Dispose();  //Dispose of the Command object.
                MyConnection3.Close(); //Close the connection.
                MyCommand.Dispose();
                MyConnection2.Close();

            }
            catch (Exception ex)
            {

                // Attempt to roll back the transaction.
                try
                {
                    transacao.Rollback();
                }
                catch (Exception ex2)
                {
                }

            }
            MyCommand.Dispose();
            MyConnection2.Dispose();

            return 0;
        #endregion  
    
    }

    [WebMethod(Description = "Incluir Banner")]
    public int IncluirBanner(int codigo,string descricao, int posicaoBanner,int largura,int altura,int status, int codigo_cliente)
    {
        #region Inclui Banner
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand MyCommand = new SqlCommand("sp_inclui_banner", MyConnection2);
        SqlTransaction transacao;
        MyConnection2.Open();

        transacao = MyConnection2.BeginTransaction("iTrans");
        MyCommand.Connection = MyConnection2;
        MyCommand.Transaction = transacao;

        try
        {
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand.Parameters.Add("@descricao", SqlDbType.NVarChar).Value = descricao;
            MyCommand.Parameters.Add("@codigo_local_banner", SqlDbType.Int).Value = posicaoBanner;
            MyCommand.Parameters.Add("@largura", SqlDbType.Int).Value = largura;
            MyCommand.Parameters.Add("@altura", SqlDbType.Int).Value = altura;
            MyCommand.Parameters.Add("@status", SqlDbType.Int).Value = status;
            MyCommand.Parameters.Add("@codigo_cliente", SqlDbType.Int).Value = codigo_cliente;

            MyCommand.ExecuteNonQuery();

            transacao.Commit();
            MyCommand.Dispose();
            MyConnection2.Close();

            SqlConnection MyConnection3 = new SqlConnection();
            MyConnection3.ConnectionString = connstring;

            SqlCommand MyCommand3 = new SqlCommand(" SELECT MAX(codigo) AS codigo_banner FROM banner ", MyConnection3);

            MyCommand3.CommandType = CommandType.Text;
            MyCommand3.Connection.Open();

            SqlDataReader MyDataReader3 = MyCommand3.ExecuteReader();

            if (MyDataReader3.Read())
            {
                return MyDataReader3.GetInt32(0);
            }

            MyCommand3.Dispose();  //Dispose of the Command object.
            MyConnection3.Close(); //Close the connection.
            MyCommand.Dispose();
            MyConnection2.Close();

        }
        catch (Exception ex)
        {
            try
            {
                transacao.Rollback();
            }
            catch (Exception ex2)
            {

            }
        }

        return 0;
        #endregion
    }

    [WebMethod(Description = "Incluir Banner Categoria")]
    public void IncluirBannerCategoria(int codigo,int codigoBanner,int codigoCategoria)
    {
       #region Inclui Banner Categoria
       SqlConnection MyConnection3 = new SqlConnection();
       MyConnection3.ConnectionString = connstring;

       SqlCommand MyCommand3 = new SqlCommand(" select * FROM banner_categoria WHERE codigo_banner = "+codigoBanner.ToString()+" and codigo_categoria = "+codigoCategoria.ToString()+"  ", MyConnection3);

       MyCommand3.CommandType = CommandType.Text;
       MyCommand3.Connection.Open();

       SqlDataReader MyDataReader3 = MyCommand3.ExecuteReader();

       if (!MyDataReader3.Read())
       {


           SqlConnection MyConnection4 = new SqlConnection();
           MyConnection4.ConnectionString = connstring;

           SqlCommand MyCommand4 = new SqlCommand("sp_inclui_banner_categoria", MyConnection4);
           SqlTransaction transacao2;
           MyConnection4.Open();

           transacao2 = MyConnection4.BeginTransaction("iTrans");
           MyCommand4.Connection = MyConnection4;
           MyCommand4.Transaction = transacao2;

           try
           {           

               MyCommand4.CommandType = CommandType.StoredProcedure;
               MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
               MyCommand4.Parameters.Add("@codigo_banner", SqlDbType.Int).Value = codigoBanner;
               MyCommand4.Parameters.Add("@codigo_categoria", SqlDbType.Int).Value = codigoCategoria;

               MyCommand4.ExecuteNonQuery();
               transacao2.Commit();

               MyCommand4.Dispose();
               MyConnection4.Close();

           }
           catch (Exception ex)
           {

               // Attempt to roll back the transaction.
               try
               {
                   transacao2.Rollback();
               }
               catch (Exception ex2)
               {
               }

           }
           MyCommand4.Dispose();
           MyConnection4.Close();
       }
       #endregion
    }


    [WebMethod(Description = "Incluir Imagem")]
    public void IncluirImagem(int codigo, int codigoAnuncio,string descricao,byte[] imagem,int tamanho,string tipo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand MyCommand = new SqlCommand("sp_inclui_imagem", MyConnection2);
        SqlTransaction transacao;
        MyConnection2.Open();

        transacao = MyConnection2.BeginTransaction("iTransI");
        MyCommand.Connection = MyConnection2;
        MyCommand.Transaction = transacao;

        try
        {
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand.Parameters.Add("@codigo_anunciante", SqlDbType.NVarChar).Value = codigoAnuncio;
            MyCommand.Parameters.Add("@descricao", SqlDbType.NVarChar).Value = descricao;
            MyCommand.Parameters.Add("@imagem", SqlDbType.Image).Value = imagem;
            MyCommand.Parameters.Add("@tamanho", SqlDbType.Int).Value = tamanho;
            MyCommand.Parameters.Add("@tipo", SqlDbType.NVarChar).Value = tipo;

            MyCommand.ExecuteNonQuery();

            transacao.Commit();
     


        }
        catch (Exception ex)
        {
         
            // Attempt to roll back the transaction.
            try
            {
                transacao.Rollback();
            }
            catch (Exception ex2)
            {
       
            }
        }               
    }

    [WebMethod(Description = "Incluir logo")]
    public int IncluirLogo(int codigo, string descricao,int codigo_anuncio)
    {
        #region Categoria

        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand MyCommand = new SqlCommand("sp_inclui_logo", MyConnection2);
        SqlTransaction transacao;
        MyConnection2.Open();

        transacao = MyConnection2.BeginTransaction("iTrans");
        MyCommand.Connection = MyConnection2;
        MyCommand.Transaction = transacao;

        try
        {
            MyCommand.CommandType = CommandType.StoredProcedure;
            MyCommand.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand.Parameters.Add("@descricao", SqlDbType.NVarChar).Value = descricao;
            MyCommand.Parameters.Add("@codigo_anuncio", SqlDbType.Int).Value = codigo_anuncio;

            MyCommand.ExecuteNonQuery();

            transacao.Commit();
            MyCommand.Dispose();
            MyConnection2.Close();

            SqlConnection MyConnection3 = new SqlConnection();
            MyConnection3.ConnectionString = connstring;

            SqlCommand MyCommand3 = new SqlCommand(" SELECT MAX(codigo) AS codigo_logo FROM logo ", MyConnection3);

            MyCommand3.CommandType = CommandType.Text;
            MyCommand3.Connection.Open();

            SqlDataReader MyDataReader3 = MyCommand3.ExecuteReader();

            if (MyDataReader3.Read())
            {
                return MyDataReader3.GetInt32(0);
            }

            MyCommand3.Dispose();  //Dispose of the Command object.
            MyConnection3.Close(); //Close the connection.
            MyCommand.Dispose();
            MyConnection2.Close();

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao.Rollback();
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand.Dispose();
        MyConnection2.Dispose();

        return 0;
        #endregion
    }



    [WebMethod(Description = "Retorna dados DataSet")]
    public DataSet RetornaDados(string tabela,int codigo,string order)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;
        string comando = "";
        if (codigo == 0)
        {
            comando = " Select * from [" + tabela + "] order by "+order+" ";
        }
        else
        {
            comando = " Select * from [" + tabela + "] where codigo ="+Convert.ToString(codigo)+" ";        
        }
        SqlCommand cmd = new SqlCommand(comando, MyConnection);

        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtTable = new DataTable(""+tabela+"");
        adpt.Fill(dtTable);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtTable);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
       
    
    }
    [WebMethod(Description = "Verifica tipo da imagem")]
    public Boolean fVerifica(string nome)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("SELECT tipo FROM IMAGEM WHERE DESCRICAO = @NOME", MyConnection2);
        k.Parameters.Add("@NOME", SqlDbType.VarChar, 200);
        k.Parameters["@NOME"].Value = nome;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.Read())
        {
            if (dr.GetString(1) == "application/x-shockwave-flash")
            {
               return true;
            }
            else
               return false;
        }
        return false;
    }


    [WebMethod(Description = "Deleta Anunciante")]
    public Boolean DeleteAnunciante(int codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from anunciante where = @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.Read())
        {
            if (dr.RecordsAffected > 0 )
            {
                return true;
            }
            else
                return false;
        }
        return false;
    }

    [WebMethod(Description = "Deleta Categoria")]
    public Boolean DeleteCategoria(int codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from categoria where codigo = @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.RecordsAffected > 0)
        {
                return true;
        }
        else
           return false;
    }

    [WebMethod(Description = "Deleta Imagem")]
    public Boolean DeleteImagem(int codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from imagem where codigo = @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.RecordsAffected > 0)
        {
            return true;
        }
        else
            return false;
    }

    [WebMethod(Description = "Deleta Imagem")]
    public Boolean DeleteLogo(int codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from logo where codigo = @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.RecordsAffected > 0)
        {
            return true;
        }
        else
            return false;
    }

    
    [WebMethod(Description = "Alimenta Banner")]
    public DataSet alimentaBanner(int codigoBanner)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand(" Select codigo,descricao,codigo_local_banner,largura,altura,status from [banner] where codigo=" + codigoBanner.ToString() + " ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("banner");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Dados Anunciante Categoria")]
    public DataSet DadosAnuncianteCategoria(int codigo_anunciante)
    {

        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand(" SELECT * FROM [anuncio_categoria] WHERE codigo_anunciante = "+codigo_anunciante.ToString()+" ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("categoria");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;

    }

    [WebMethod(Description = "Dados Imagem")]
    public DataSet DadosImagem(int codigo_anunciante)
    {

        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand(" SELECT * FROM [imagem] WHERE codigo_anunciante = " + codigo_anunciante.ToString() + " ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("imagem");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;

    }

    [WebMethod(Description = "Montar Menus")]
    public DataSet descricaoCategoria(string codigo_categoria)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand(" Select codigo,descricao from [categoria] where codigo=" + codigo_categoria + " ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtCategoria = new DataTable("categoria");
        adpt.Fill(dtCategoria);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtCategoria);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Codigo categoria por descrição")]
    public DataSet descricaoCodigoCategoria(string descricao)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand(" select codigo,descricao from [categoria] where descricao like '%" + descricao + "%' ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtCategoria = new DataTable("categoria");
        adpt.Fill(dtCategoria);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtCategoria);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Deleta Categoria Anunciante")]
    public Boolean DeleteCategoriaAnunciante(int codigo_anunciante,int codigo_categoria)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from anuncio_categoria where codigo_anunciante = @codigo_anunciante and codigo_categoria=@codigo_categoria ", MyConnection2);
        k.Parameters.Add("@codigo_anunciante", SqlDbType.Int);
        k.Parameters["@codigo_anunciante"].Value = codigo_anunciante;
        k.Parameters.Add("@codigo_categoria", SqlDbType.Int);
        k.Parameters["@codigo_categoria"].Value = codigo_categoria;

        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.RecordsAffected > 0)
        {
            return true;
        }
        else
            return false;
    }

    [WebMethod(Description = "Dados Banner Categoria")]
    public DataSet DadosBannerCategoria(int codigo_banner)
    {

        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand(" SELECT * FROM [banner_categoria] WHERE codigo_banner = " + codigo_banner.ToString() + " ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("banner");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Deleta Categoria Banner")]
    public Boolean DeleteCategoriaBanner(int codigo_banner, int codigo_categoria)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from banner_categoria where codigo_banner =@codigo_banner and codigo_categoria=@codigo_categoria ", MyConnection2);
        k.Parameters.Add("@codigo_banner", SqlDbType.Int);
        k.Parameters["@codigo_banner"].Value = codigo_banner;
        k.Parameters.Add("@codigo_categoria", SqlDbType.Int);
        k.Parameters["@codigo_categoria"].Value = codigo_categoria;

        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.RecordsAffected > 0)
        {
            return true;
        }
        else
            return false;
    }


    [WebMethod(Description = "Incluir Bonus")]
    public int IncluirBonus(int codigo, int codigo_anunciante, string bonus, int status)
    {
        #region Inclui Bonus
        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_inclui_bonus", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand4.Parameters.Add("@codigo_anunciante", SqlDbType.Int).Value = codigo_anunciante;
            MyCommand4.Parameters.Add("@bonus", SqlDbType.VarChar).Value = bonus;
            MyCommand4.Parameters.Add("@status", SqlDbType.Int).Value = status;

            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();
            MyCommand4.Dispose();
            MyConnection4.Close();

            SqlConnection MyConnection5 = new SqlConnection();
            MyConnection5.ConnectionString = connstring;

            SqlCommand MyCommand5 = new SqlCommand(" SELECT MAX(codigo) AS codigo_bonus FROM bonus ", MyConnection5);

            MyCommand5.CommandType = CommandType.Text;
            MyCommand5.Connection.Open();

            SqlDataReader MyDataReader5 = MyCommand5.ExecuteReader();

            if (MyDataReader5.Read())
            {
                return MyDataReader5.GetInt32(0);
            }

            MyCommand5.Dispose();
            MyConnection5.Close();

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return 0;
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand4.Dispose();
        MyConnection4.Close();

        return 0;
        #endregion
    }


    [WebMethod(Description = "Incluir Agenda")]
    public int IncluirAgenda(int codigo, int codigo_anuncio, string descricao, int status, DateTime data)
    {
        #region Inclui Agenda
        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_inclui_agenda", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand4.Parameters.Add("@codigo_anuncio", SqlDbType.Int).Value = codigo_anuncio;
            MyCommand4.Parameters.Add("@descricao", SqlDbType.VarChar).Value = descricao;
            MyCommand4.Parameters.Add("@data", SqlDbType.DateTime).Value = data;
            MyCommand4.Parameters.Add("@status", SqlDbType.Int).Value = status;

            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();
            MyCommand4.Dispose();
            MyConnection4.Close();

            SqlConnection MyConnection5 = new SqlConnection();
            MyConnection5.ConnectionString = connstring;

            SqlCommand MyCommand5 = new SqlCommand(" SELECT MAX(codigo) AS codigo_agenda FROM agenda ", MyConnection5);

            MyCommand5.CommandType = CommandType.Text;
            MyCommand5.Connection.Open();

            SqlDataReader MyDataReader5 = MyCommand5.ExecuteReader();

            if (MyDataReader5.Read())
            {
                return MyDataReader5.GetInt32(0);
            }

            MyCommand5.Dispose();
            MyConnection5.Close();

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return 0;
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand4.Dispose();
        MyConnection4.Close();

        return 0;
        #endregion
    }


    [WebMethod(Description = "Incluir Usuario")]
    public int IncluirUsuario(int codigo, int codigo_anunciante, string descricao, string senha)
    {
        #region Inclui Usuario
        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_inclui_usuario", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand4.Parameters.Add("@codigo_anunciante", SqlDbType.Int).Value = codigo_anunciante;
            MyCommand4.Parameters.Add("@descricao", SqlDbType.VarChar).Value = descricao;
            MyCommand4.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;

            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();
            MyCommand4.Dispose();
            MyConnection4.Close();

            SqlConnection MyConnection5 = new SqlConnection();
            MyConnection5.ConnectionString = connstring;

            SqlCommand MyCommand5 = new SqlCommand(" SELECT MAX(codigo) AS codigo_usuario FROM usuario ", MyConnection5);

            MyCommand5.CommandType = CommandType.Text;
            MyCommand5.Connection.Open();

            SqlDataReader MyDataReader5 = MyCommand5.ExecuteReader();

            if (MyDataReader5.Read())
            {
                return MyDataReader5.GetInt32(0);
            }

            MyCommand5.Dispose();
            MyConnection5.Close();

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return 0;
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand4.Dispose();
        MyConnection4.Close();

        return 0;
        #endregion
    }

    [WebMethod(Description = "Deleta Usuario")]
    public Boolean DeleteUsuario(int codigo)
    {
        #region Delete Usuario
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from usuario where codigo = @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.RecordsAffected > 0)
        {
            return true;
        }
        else
            return false;
        #endregion
    }

    [WebMethod(Description = "Consulta Usuario ")]
    public DataSet ConsultaUsuario(int codigo)
    {
        #region Consulta Usuario
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if (codigo == 0)
        {
            comando = "SELECT u.* FROM usuario u ";
        }
        else
        {
            comando = "SELECT u.* FROM usuario u " +
                      "WHERE u.codigo=" + codigo.ToString();
        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("usuario");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
        #endregion
    }

    [WebMethod(Description = "Alimenta Bonus")]
    public DataSet alimentacabonus(int codigo_bonus)
    {
        #region Alimenta Bonus
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand(" Select codigo,codigo_anunciante,bonus,status from [bonus] where codigo=" + codigo_bonus.ToString() + "  ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("bonus");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
        #endregion
    }

    [WebMethod(Description = "Consulta Bonus Anunciante")]
    public DataSet bonusAnunciante(int codAnunciante)
    {
        #region Consulta Bonus Anunciante
        SqlConnection MyConnection = new SqlConnection();
       MyConnection.ConnectionString = connstring;

       string comando = "";
       comando = "SELECT a.codigo,c.endereco, a.telefone, a.email,a.site, a.bairro, a.cidade, " +
                "a.status,b.codigo as cod_bonus,b.bonus,c.nome_fantasia " +
                "FROM anuncio a " +
                "INNER JOIN cliente c ON a.codigo_cliente = c.codigo " +
                "LEFT JOIN bonus b ON a.codigo_cliente = b.codigo_anunciante " +
                "WHERE (a.codigo=" + codAnunciante.ToString() + " and a.status=1 ) ";

      SqlCommand cmd = new SqlCommand(comando, MyConnection);
      SqlDataAdapter adpt = new SqlDataAdapter(cmd);

      // Cria e preenche o DataTable
      DataTable dtBanner = new DataTable("anunciante");
      adpt.Fill(dtBanner);
      DataSet ds = new DataSet();
      ds.Tables.Add(dtBanner);
      cmd.Dispose();
      MyConnection.Close();

      return ds;
        #endregion
    }


    [WebMethod(Description = "Incluir Bonus Retorno")]
    public int IncluirBonusRetorno(int codigo, int codigo_anunciante, string nome,string telefone,string email, DateTime data_impressao)
    {
        #region Incluir Bonus Retorno

        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_inclui_bonusretorno", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand4.Parameters.Add("@codigo_anunciante", SqlDbType.Int).Value = codigo_anunciante;
            MyCommand4.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
            MyCommand4.Parameters.Add("@telefone", SqlDbType.VarChar).Value = telefone;
            MyCommand4.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            MyCommand4.Parameters.Add("@data_impressao", SqlDbType.DateTime).Value = data_impressao;

            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();
            MyCommand4.Dispose();
            MyConnection4.Close();

            SqlConnection MyConnection5 = new SqlConnection();
            MyConnection5.ConnectionString = connstring;

            SqlCommand MyCommand5 = new SqlCommand(" SELECT MAX(codigo) AS codigo_bonus FROM bonus_retorno ", MyConnection5);

            MyCommand5.CommandType = CommandType.Text;
            MyCommand5.Connection.Open();

            SqlDataReader MyDataReader5 = MyCommand5.ExecuteReader();

            if (MyDataReader5.Read())
            {
                return MyDataReader5.GetInt32(0);
            }

               
            MyCommand5.Dispose();
            MyConnection5.Close();

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return 0;
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand4.Dispose();
        MyConnection4.Close();
       
        return 0;
        #endregion
    }

    [WebMethod(Description = "Set Status Chat")]
    public int SetStatusChat(int codigo, int codigo_cliente, int status)
    {
        #region Set Status Chat
        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_set_status_chat", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand4.Parameters.Add("@codigo_cliente", SqlDbType.Int).Value = codigo_cliente;
            MyCommand4.Parameters.Add("@status", SqlDbType.Int).Value = status;

            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();
            MyCommand4.Dispose();
            MyConnection4.Close();

            SqlConnection MyConnection5 = new SqlConnection();
            MyConnection5.ConnectionString = connstring;

            SqlCommand MyCommand5 = new SqlCommand(" SELECT MAX(codigo) AS codigo_sessao FROM status_chat ", MyConnection5);

            MyCommand5.CommandType = CommandType.Text;
            MyCommand5.Connection.Open();

            SqlDataReader MyDataReader5 = MyCommand5.ExecuteReader();

            if (MyDataReader5.Read())
            {
                return MyDataReader5.GetInt32(0);
            }

            MyCommand5.Dispose();
            MyConnection5.Close();


        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return 0;
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand4.Dispose();
        MyConnection4.Close();

        return 0;
        #endregion
    }

    [WebMethod(Description = "Deleta do chat")]
    public Boolean DeleteChat(int codigo)
    {
        #region Delete Chat
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from status_chat where codigo_cliente = @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.RecordsAffected > 0)
        {
            return true;
        }
        else
            return false;
        #endregion
    }

    [WebMethod(Description = "Consulta Anunciante Campo")]
    public DataSet ConsultaAnuncianteDescricao(string valor)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand("SELECT anunciante.codigo,anunciante.descricao, anunciante.endereco, anunciante.telefone, "+
                                        "anunciante.email,anunciante.site, anunciante.bairro, anunciante.cidade,anunciante.razao_social, "+
                                        "imagem.descricao AS nomeimagem,imagem.codigo as codigo_imagem, imagem.tamanho, " +
                                        "imagem.tipo,imagem.configuracao,anunciante.status,bonus.codigo as bonus, " +
                                        "anunciante.status FROM anunciante "+
                                        "INNER JOIN imagem ON anunciante.codigo = imagem.codigo_anunciante "+
                                        "LEFT JOIN bonus ON anunciante.codigo = bonus.codigo_anunciante " +
                                        "WHERE (anunciante.descricao like '%"+valor+"%' and anunciante.status=1 ) ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("anunciante");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    //Daqui pra baixo modificações na estrutura da base de dados 
                     
    [WebMethod(Description = "Consulta Cliente ")]
    public DataSet ConsultaCliente(int codigo,string nome)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;
        string comando = "";

        if (codigo == 0)
        {
            if (nome == "0")
            {
                comando = "SELECT c.codigo,c.razao_social,c.cnpj,c.cpf,c.rg,c.endereco,c.cep,c.bairro,c.cidade, " +
                          "c.email,c.responsavel,c.telefone,c.nome_fantasia " +
                          "FROM cliente c ";
            }
            else
            {
                comando = "SELECT c.codigo,c.razao_social,c.cnpj,c.cpf,c.rg,c.endereco,c.cep,c.bairro,c.cidade, " +
                          "c.email,c.responsavel,c.telefone,c.nome_fantasia " +
                          "FROM cliente c "+
                          "Where c.nome_fantasia like '%" + nome + "%'  ";
            }
        }
        else
        {
            comando = "SELECT c.codigo,c.razao_social,c.cnpj,c.cpf,c.rg,c.endereco,c.cep,c.bairro,c.cidade, " +
                      "c.email,c.responsavel,c.telefone,c.nome_fantasia " +
                      "FROM cliente c  " +
                      "WHERE c.codigo ="+codigo.ToString();
        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("cliente");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Consulta Anuncio ")]
    public DataSet ConsultaAnuncio(int codigo,string nome)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if (codigo == 0)
        {
            if (nome == "0")
            {
                comando = "SELECT a.codigo,a.codigo_cliente,a.cep, " +
                          "a.bairro,a.cidade,a.endereco, " +
                          "a.telefone,a.email,a.site,a.status , " +
                          "a.senha,a.acesso " +
                          "FROM anuncio a " +
                          "INNER JOIN cliente c ON a.codigo_cliente = c.codigo " +
                          "LEFT JOIN link l on a.codigo = l.codigo_anuncio "+
                          " order by c.nome_fantasia ";
            }
            else
            {
                comando = "SELECT a.codigo,a.codigo_cliente,a.cep, " +
                          "a.bairro,a.cidade,a.endereco, " +
                          "a.telefone,a.email,a.site,a.status , " +
                          "a.senha,a.acesso " +
                          "FROM anuncio a " +
                          "INNER JOIN cliente c ON a.codigo_cliente = c.codigo " +
                          "LEFT JOIN link l on a.codigo = l.codigo_anuncio "+
                          "Where c.nome_fantasia like '%" + nome + "%'  ";

            
            }
        }
        else
        {
            comando = "SELECT a.codigo,a.codigo_cliente,a.cep, " +
                      "a.bairro,a.cidade,a.endereco, " +
                      "a.telefone,a.email,a.site,a.status , " +
                      "a.senha,a.acesso " +
                      "FROM anuncio a " +
                      "INNER JOIN cliente c ON a.codigo_cliente = c.codigo " +
                      "LEFT JOIN link l on a.codigo = l.codigo_anuncio " +
                      "WHERE a.codigo=" + codigo.ToString() +
                      " order by c.nome_fantasia ";
        
        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("anuncio");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Consulta Anuncio ")]
    public DataSet ConsultaRelAnuncio()
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        comando = "SELECT a.codigo,a.codigo_cliente,a.cep, " +
                  "a.bairro,a.cidade,a.endereco,c.nome_fantasia, " +
                  "a.telefone,a.email,a.site,a.status as codigo_status, " +
                  "s.descricao as status,a.senha,a.acesso " +
                  "FROM anuncio a " +
                  "INNER JOIN status s ON a.status = s.codigo " +
                  "INNER JOIN cliente c ON a.codigo_cliente = c.codigo " +
                  "LEFT JOIN link l on a.codigo = l.codigo_anuncio " +
                  " order by c.nome_fantasia ";

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("anuncio");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }


    [WebMethod(Description = "Consulta Financeiro ")]
    public DataSet ConsultaFinanceiro(int codigo)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;
        
        string comando = "";
        if (codigo == 0)
        {
            comando = "SELECT f.codigo,f.codigo_cliente,c.nome_fantasia,f.mes ,f.vencimento,f.mensalidade,f.boleto,f.observacao "+
                      "FROM financeiro f "+
                      "INNER JOIN cliente c ON c.codigo = f.codigo_cliente ";
        }
        else 
        {
            comando = "SELECT f.codigo,f.codigo_cliente,c.nome_fantasia,f.mes ,f.vencimento,f.mensalidade,f.boleto,f.observacao "+
                      "FROM financeiro f "+
                      "INNER JOIN cliente c ON c.codigo = f.codigo_cliente "+
                      "WHERE f.codigo=" + codigo.ToString();
        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("financeiro");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Consulta Anuncio categoria ")]
    public DataSet ConsultaAnuncioCategoria(int codigo_anunciante)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if (codigo_anunciante == 0)
        {
            comando = "SELECT ac.codigo,ac.codigo_anunciante, "+
                      "ac.codigo_categoria,c.descricao "+
                      "FROM anuncio_categoria ac " +
                      "INNER JOIN categoria c ON ac.codigo_categoria = c.codigo order by ac.codigo_anunciante";
        }
        else
        {
            comando = "SELECT ac.codigo,ac.codigo_anunciante, "+
                      "ac.codigo_categoria,c.descricao "+
                      "FROM anuncio_categoria ac " +
                      "INNER JOIN categoria c ON ac.codigo_categoria = c.codigo "+
                      "WHERE codigo_anunciante=" + codigo_anunciante.ToString();

        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("anuncio_categoria");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Consulta Mes ")]
    public DataSet ConsultaMes()
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        comando = "SELECT codigo,descricao " +
                  "FROM tipo_mes ";

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("tipo_mes");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Consulta status ")]
    public DataSet ConsultaStatus()
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        comando = "SELECT codigo,descricao " +
                  "FROM status ";

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("status");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Consulta Local Banner ")]
    public DataSet ConsultaLocalBanner()
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        comando = "SELECT codigo,descricao " +
                  "FROM local_banner ";

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("local_banner");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Popula Anunciante ")]
    public DataSet PopulaAnunciante()
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        comando = "select codigo,razao_social from cliente";

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("cliente");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Popula Categoria ")]
    public DataSet PopulaCategoria()
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        comando = "select codigo,descricao from categoria";

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("categoria");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Popula Anuncio ")]
    public DataSet PopulaAnuncio()
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        comando = "select c.codigo,c.nome_fantasia from cliente c order by c.nome_fantasia";

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("categoria");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

     
    [WebMethod(Description = "Consulta Logo ")]
    public DataSet ConsultaLogo(int codigo)
    {
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if (codigo == 0)
        {
            comando = "SELECT l.codigo,l.descricao,c.nome_fantasia,l.codigo_anuncio "+ 
                      "FROM logo l "+
                      "INNER JOIN cliente c ON c.codigo = l.codigo_anuncio ";
        }
        else
        {
            comando = "SELECT l.codigo,l.descricao,c.nome_fantasia,l.codigo_anuncio "+ 
                      "FROM logo l "+
                      "INNER JOIN cliente c ON c.codigo = l.codigo_anuncio "+
                      "WHERE codigo=" + codigo.ToString();
        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("logo");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }


    [WebMethod(Description = "Excluir Cliente")]
    public Boolean ExcluirCliente(Int32 codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from cliente where codigo= @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.Read())
        {
            if (dr.RecordsAffected > 0)
            {
                return true;
            }
            else
                return false;
        }
        return false;
    }

    [WebMethod(Description = "Excluir Anuncio")]
    public Boolean ExcluirAnuncio(int codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from anuncio where codigo= @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.Read())
        {
            if (dr.RecordsAffected > 0)
            {
                return true;
            }
            else
                return false;
        }
        return false;
    }

    [WebMethod(Description = "Excluir Financeiro")]
    public Boolean ExcluirFinanceiro(int codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from financeiro where codigo= @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.Read())
        {
            if (dr.RecordsAffected > 0)
            {
                return true;
            }
            else
                return false;
        }
        return false;
    }

    [WebMethod(Description = "Excluir Banner")]
    public Boolean ExcluirBanner(int codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from banner where codigo= @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.Read())
        {
            if (dr.RecordsAffected > 0)
            {
                return true;
            }
            else
                return false;
        }
        return false;
    }

    [WebMethod(Description = "Excluir Bonus")]
    public Boolean ExcluirBonus(int codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from bonus where codigo= @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.Read())
        {
            if (dr.RecordsAffected > 0)
            {
                return true;
            }
            else
                return false;
        }
        return false;
    }

    [WebMethod(Description = "Excluir Agenda")]
    public Boolean ExcluirAgenda(int codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from agenda where codigo= @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.Read())
        {
            if (dr.RecordsAffected > 0)
            {
                return true;
            }
            else
                return false;
        }
        return false;
    }


    [WebMethod(Description = "Excluir Categoria")]
    public Boolean ExcluirCategoria(int codigo)
    {
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from categoria where codigo= @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.Read())
        {
            if (dr.RecordsAffected > 0)
            {
                return true;
            }
            else
                return false;
        }
        return false;
    }

    [WebMethod(Description = "Excluir Link")]
    public Boolean ExcluirLink(int codigo)
    {
        #region Excluir Link
        SqlConnection MyConnection2 = new SqlConnection();
        MyConnection2.ConnectionString = connstring;

        SqlCommand k = new SqlCommand("delete from link where codigo= @codigo", MyConnection2);
        k.Parameters.Add("@codigo", SqlDbType.Int);
        k.Parameters["@codigo"].Value = codigo;
        k.Connection.Open();
        SqlDataReader dr = k.ExecuteReader();
        if (dr.Read())
        {
            if (dr.RecordsAffected > 0)
            {
                return true;
            }
            else
                return false;
        }
        return false;
        #endregion
    }

    [WebMethod(Description = "Incluir Cliente")]
    public int IncluirCliente(int codigo, string razao_social, string cnpj, string cpf, string rg, string endereco, string cep, string bairro, string cidade, string email, string responsavel, string telefone,string nome_fantasia)
    {
        #region Incluir Cliente
        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_inclui_cliente", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {
            if (cpf == null)
                cpf = "";
            if (rg == null)
                rg = "";
            if (endereco == null)
                endereco = "";
            if (cep == null)
                cep = "";
            if (bairro == null)
                bairro = "";
            if (cidade == null)
                cidade = "";
            if (email == null)
                email = "";
            if (responsavel == null)
                responsavel = "";
            if (telefone == null)
                telefone = "";

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand4.Parameters.Add("@razao_social", SqlDbType.NVarChar).Value = razao_social;
            MyCommand4.Parameters.Add("@cnpj", SqlDbType.NVarChar).Value = cnpj;
            MyCommand4.Parameters.Add("@cpf", SqlDbType.NVarChar).Value = cpf;
            MyCommand4.Parameters.Add("@rg", SqlDbType.NVarChar).Value = rg;
            MyCommand4.Parameters.Add("@endereco", SqlDbType.NVarChar).Value = endereco;
            MyCommand4.Parameters.Add("@cep", SqlDbType.NVarChar).Value = cep;
            MyCommand4.Parameters.Add("@bairro", SqlDbType.NVarChar).Value = bairro;
            MyCommand4.Parameters.Add("@cidade", SqlDbType.NVarChar).Value = cidade;
            MyCommand4.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            MyCommand4.Parameters.Add("@responsavel", SqlDbType.NVarChar).Value = responsavel;
            MyCommand4.Parameters.Add("@telefone", SqlDbType.NVarChar).Value = telefone;
            MyCommand4.Parameters.Add("@nome_fantasia", SqlDbType.NVarChar).Value = nome_fantasia;

            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();
            MyCommand4.Dispose();
            MyConnection4.Close();

            SqlConnection MyConnection5 = new SqlConnection();
            MyConnection5.ConnectionString = connstring;

            SqlCommand MyCommand5 = new SqlCommand(" SELECT MAX(codigo) AS codigo_cliente FROM cliente ", MyConnection5);

            MyCommand5.CommandType = CommandType.Text;
            MyCommand5.Connection.Open();

            SqlDataReader MyDataReader5 = MyCommand5.ExecuteReader();

            if (MyDataReader5.Read())
            {
                return MyDataReader5.GetInt32(0);
            }

            MyCommand5.Dispose();
            MyConnection5.Close();

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return 0;
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand4.Dispose();
        MyConnection4.Close();

        return 0;
        #endregion
    }

    [WebMethod(Description = "Incluir Anuncio")]
    public int IncluirAnuncio(int codigo, int codigo_cliente,string cep,string bairro,string cidade,string endereco,string telefone,string email,string site,int status,string senha)
    {
        #region Incluir Anuncio
        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_inclui_anuncio", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {
            if (cep == null) cep = "";

            if (bairro == null) bairro = "";

            if (cidade == null) cidade = "";

            if (endereco == null) endereco = "";

            if (telefone == null) telefone = "";

            if (email == null) email = "";

            if (site == null) site = "";

            if (status == null) status = 0;

            if (senha == null) senha = "";

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand4.Parameters.Add("@codigo_cliente", SqlDbType.Int).Value = codigo_cliente;
            MyCommand4.Parameters.Add("@cep", SqlDbType.NVarChar).Value = cep;
            MyCommand4.Parameters.Add("@bairro", SqlDbType.NVarChar).Value = bairro;
            MyCommand4.Parameters.Add("@cidade", SqlDbType.NVarChar).Value = cidade;
            MyCommand4.Parameters.Add("@endereco", SqlDbType.NVarChar).Value = endereco;
            MyCommand4.Parameters.Add("@telefone", SqlDbType.NVarChar).Value = telefone;
            MyCommand4.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            MyCommand4.Parameters.Add("@site", SqlDbType.NVarChar).Value = site;
            MyCommand4.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            MyCommand4.Parameters.Add("@senha", SqlDbType.NVarChar).Value = senha;

            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();
            MyCommand4.Dispose();
            MyConnection4.Close();

            SqlConnection MyConnection5 = new SqlConnection();
            MyConnection5.ConnectionString = connstring;

            SqlCommand MyCommand5 = new SqlCommand(" SELECT MAX(codigo) AS codigo_cliente FROM anuncio ", MyConnection5);

            MyCommand5.CommandType = CommandType.Text;
            MyCommand5.Connection.Open();

            SqlDataReader MyDataReader5 = MyCommand5.ExecuteReader();

            if (MyDataReader5.Read())
            {
                return MyDataReader5.GetInt32(0);
            }

            MyCommand5.Dispose();
            MyConnection5.Close();

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return 0;
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand4.Dispose();
        MyConnection4.Close();

        return 0;
        #endregion
    }

    [WebMethod(Description = "Incluir Financeiro")]
    public int IncluirFinanceiro(int codigo,int codigo_cliente,int mes,DateTime vencimento,float mensalidade,string boleto,string observacao)
    {
        #region Inclui Financeiro
        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_inclui_financeiro", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand4.Parameters.Add("@codigo_cliente", SqlDbType.Int).Value = codigo_cliente;
            MyCommand4.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
            MyCommand4.Parameters.Add("@vencimento", SqlDbType.DateTime).Value = vencimento;
            MyCommand4.Parameters.Add("@mensalidade", SqlDbType.Real).Value = mensalidade;
            MyCommand4.Parameters.Add("@boleto", SqlDbType.NVarChar).Value = boleto;
            MyCommand4.Parameters.Add("@observacao", SqlDbType.Text).Value = observacao;

            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();
            MyCommand4.Dispose();
            MyConnection4.Close();

            SqlConnection MyConnection5 = new SqlConnection();
            MyConnection5.ConnectionString = connstring;

            SqlCommand MyCommand5 = new SqlCommand(" SELECT MAX(codigo) AS codigo_financeiro FROM financeiro ", MyConnection5);

            MyCommand5.CommandType = CommandType.Text;
            MyCommand5.Connection.Open();

            SqlDataReader MyDataReader5 = MyCommand5.ExecuteReader();

            if (MyDataReader5.Read())
            {
                return MyDataReader5.GetInt32(0);
            }

            MyCommand5.Dispose();
            MyConnection5.Close();

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return 0;
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand4.Dispose();
        MyConnection4.Close();

        return 0;
        #endregion
    }

    [WebMethod(Description = "Incluir Link")]
    public int IncluirLink(int codigo, int codigo_anuncio, string orkut,string facebook,string twitter)
    {
        #region Incluir Link
        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_inclui_link", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo", SqlDbType.Int).Value = codigo;
            MyCommand4.Parameters.Add("@codigo_anuncio", SqlDbType.Int).Value = codigo_anuncio;
            MyCommand4.Parameters.Add("@orkut", SqlDbType.VarChar).Value = orkut;
            MyCommand4.Parameters.Add("@facebook", SqlDbType.VarChar).Value = facebook;
            MyCommand4.Parameters.Add("@twitter", SqlDbType.VarChar).Value = twitter;

            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();
            MyCommand4.Dispose();
            MyConnection4.Close();

            SqlConnection MyConnection5 = new SqlConnection();
            MyConnection5.ConnectionString = connstring;

            SqlCommand MyCommand5 = new SqlCommand(" SELECT MAX(codigo) AS codigo_link FROM link ", MyConnection5);

            MyCommand5.CommandType = CommandType.Text;
            MyCommand5.Connection.Open();

            SqlDataReader MyDataReader5 = MyCommand5.ExecuteReader();

            if (MyDataReader5.Read())
            {
                return MyDataReader5.GetInt32(0);
            }

            MyCommand5.Dispose();
            MyConnection5.Close();

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return 0;
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand4.Dispose();
        MyConnection4.Close();

        return 0;
        #endregion
    }

    [WebMethod(Description = "Consulta Banner ")]
    public DataSet ConsultaBanner(int codigo_banner)
    {
        #region Consulta Banner
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if (codigo_banner == 0)
        {
            comando = "Select b.codigo,b.descricao,b.codigo_local_banner,b.largura,b.altura, "+
                      "b.status as codigo_status,s.descricao as status,l.descricao as local,b.codigo_cliente "+
                      "from [banner] b "+
                      "inner join status s on s.codigo = b.status "+
                      "inner join local_banner l on l.codigo = b.codigo_local_banner";
        }
        else
        {
            comando = "Select b.codigo,b.descricao,b.codigo_local_banner,b.largura,b.altura, "+
                      "b.status as codigo_status,s.descricao as status,l.descricao as local,b.codigo_cliente  " +
                      "from [banner] b  "+
                      "inner join status s on s.codigo = b.status  "+
                      "inner join local_banner l on l.codigo = b.codigo_local_banner " +
                      "WHERE b.codigo=" + codigo_banner.ToString();

        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("banner");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
        #endregion
    }

    [WebMethod(Description = "Consulta Dados Bonus ")]
    public DataSet ConsultaDadosBonus(int codigo_bonus)
    {
        #region Consulta Dados Bonus
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if (codigo_bonus == 0)
        {
            comando = "select b.codigo,b.bonus,b.codigo_anunciante,b.status as codigo_status, s.descricao as status,c.nome_fantasia as anunciante from bonus b "+
                      "inner join status s on s.codigo = b.status "+
                      "inner join anuncio a on b.codigo_anunciante = a.codigo " +
                      "inner join cliente c on c.codigo = a.codigo_cliente ";
        }
        else
        {
            comando = "select b.codigo,b.bonus,b.codigo_anunciante,b.status as codigo_status, s.descricao as status,c.nome_fantasia as anunciante from bonus b "+
                      "inner join status s on s.codigo = b.status "+
                      "inner join anuncio a on b.codigo_anunciante = a.codigo " +
                      "inner join cliente c on c.codigo = a.codigo_cliente "+
                      "WHERE b.codigo=" + codigo_bonus.ToString();

        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("bonus");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
        #endregion
    }


    [WebMethod(Description = "Consulta Dados Agenda ")]
    public DataSet ConsultaDadosAgenda(int codigo_agenda)
    {
        #region Consulta Dados Bonus
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if (codigo_agenda == 0)
        {
            comando = "select b.codigo,b.descricao,b.codigo_anuncio,b.status as codigo_status, b.data, s.descricao as status,c.nome_fantasia as anunciante from agenda b " +
                      "inner join status s on s.codigo = b.status " +
                      "inner join anuncio a on b.codigo_anuncio = a.codigo " +
                      "inner join cliente c on c.codigo = a.codigo_cliente ";
        }
        else
        {
            comando = "select b.codigo,b.descricao,b.codigo_anuncio,b.status as codigo_status, b.data, s.descricao as status,c.nome_fantasia as anunciante from agenda b " +
                      "inner join status s on s.codigo = b.status " +
                      "inner join anuncio a on b.codigo_anuncio = a.codigo " +
                      "inner join cliente c on c.codigo = a.codigo_cliente "+
                      "WHERE b.codigo=" + codigo_agenda.ToString();

        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("agenda");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
        #endregion
    }


    [WebMethod(Description = "Consulta Dados Categoria ")]
    public DataSet ConsultaDadosCategoria(int codigo_categoria)
    {
        #region Consulta Dados Categoria
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if (codigo_categoria == 0)
        {
            comando = "select codigo,descricao,tipo_categoria,texto from categoria ";
        }
        else
        {
            comando = "select codigo,descricao,tipo_categoria,texto from categoria " +
                      "WHERE codigo=" + codigo_categoria.ToString();

        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("categoria");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
        #endregion
    }

    [WebMethod(Description = "Consulta Categoria Banner ")]
    public DataSet ConsultaCategoriaBanner(int codigo_banner)
    {
        #region Consulta Categoria Banner
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if ((codigo_banner ==0))
        {
            comando = "select bc.*,c.descricao from banner_categoria bc "+
                      "inner join categoria c on c.codigo = bc.codigo_categoria ";
        }
        else
        {
            comando = "select bc.*,c.descricao from banner_categoria bc "+
                      "inner join categoria c on c.codigo = bc.codigo_categoria "+
                      "WHERE bc.codigo=" + codigo_banner.ToString();

        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("banner_categoria");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
        #endregion
    }


    [WebMethod(Description = "Consulta Link ")]
    public DataSet ConsultaLink(int codigo_link)
    {
        #region Consulta Link
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if ((codigo_link == 0))
        {
            comando = "SELECT l.codigo,l.codigo_anuncio,c.nome_fantasia,l.orkut,l.facebook,l.twitter " +
                      "FROM link l " +
                      "INNER JOIN cliente c ON c.codigo = l.codigo_anuncio ";

        }
        else
        {
            comando = "SELECT l.codigo,l.codigo_anuncio,c.nome_fantasia,l.orkut,l.facebook,l.twitter " +
                      "FROM link l " +
                      "INNER JOIN cliente c ON c.codigo = l.codigo_anuncio "+
                      "WHERE l.codigo=" + codigo_link.ToString();

        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("link");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
        #endregion
    }

    [WebMethod(Description = "Consulta Imagem ")]
    public DataSet ConsultaImagem(int codigo_imagem)
    {
        #region Consulta Imagem
        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        string comando = "";
        if ((codigo_imagem == 0))
        {
            comando = "select * from imagem ";
        }
        else
        {
            comando = "select * from imagem " +
                      "WHERE codigo=" + codigo_imagem.ToString();

        }

        SqlCommand cmd = new SqlCommand(comando, MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("imagem");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
        #endregion
    }

    [WebMethod(Description = "Consulta Anuncio q aparece no site ")]
    public DataSet ConsultaAnuncioTela(int codigo_categoria, string nome_fantasia,string ordem)
    {
        #region Consulta Anuncio Tela

        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_consulta_anuncio", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo_categoria", SqlDbType.Int).Value = codigo_categoria;
            MyCommand4.Parameters.Add("@nome_fantasia", SqlDbType.VarChar).Value = nome_fantasia;
            MyCommand4.Parameters.Add("@ordem", SqlDbType.VarChar).Value = ordem;



            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();

            SqlDataAdapter adpt = new SqlDataAdapter(MyCommand4);

            // Cria e preenche o DataTable
            DataTable dtBanner = new DataTable("anuncio");
            adpt.Fill(dtBanner);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtBanner);
            MyCommand4.Dispose();

            
            MyCommand4.Dispose();
            MyConnection4.Close();

            return ds;

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return null;
            }
            catch (Exception ex2)
            {
            }

        }

        return null;

        MyCommand4.Dispose();
        MyConnection4.Close();

        #endregion
    }

    [WebMethod(Description = "Retorna nome anunciante ")]
    [ScriptMethod] 
    public List<String> RetornaNomeCliente(string prefixText, int count)
    {
        #region Retorna Nome Anunciante
        List<String> resultados = new List<String>();
        DataSet ds = new DataSet();

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("anunciante");


        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand("select c.nome_fantasia from cliente c "+
                                        "INNER JOIN anuncio a ON a.codigo_cliente = c.codigo "+
                                        "WHERE (c.nome_fantasia like '%" + prefixText + "%' and a.status=1 ) order by c.nome_fantasia ", MyConnection);

        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        adpt.Fill(dtBanner);

        ds.Tables.Add(dtBanner);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
           resultados.Add(ds.Tables[0].Rows[i][0].ToString());
        }
        return resultados;

        cmd.Dispose();
        MyConnection.Close();
        #endregion
    }

    private string tableName = string.Empty;
    public string TableName
    {
        get { return tableName; }
        protected set { tableName = value; }
    }

    private string[] primaryKeyColumnNames = { };
    public string[] PrimaryKeyColumnNames
    {
        get { return primaryKeyColumnNames; }
        protected set { primaryKeyColumnNames = value; }
    }

    protected void SetPrimaryKeys(DataTable dataTable)
    {
        DataColumn[] keys = new DataColumn[PrimaryKeyColumnNames.Length - 1];

        for (int i = 0; i < PrimaryKeyColumnNames.Length; i++)
        {
            keys[i] = dataTable.Columns[PrimaryKeyColumnNames[i]];
        }

        dataTable.PrimaryKey = keys;
    }


    [WebMethod(Description = "Conta Acesso")]
    public int contaClicks(int codigo_anuncio)
    {
        SqlConnection MyConnection4 = new SqlConnection();
        MyConnection4.ConnectionString = connstring;

        SqlCommand MyCommand4 = new SqlCommand("sp_conta_acesso_anuncio", MyConnection4);
        SqlTransaction transacao2;
        MyConnection4.Open();

        transacao2 = MyConnection4.BeginTransaction("iTrans");
        MyCommand4.Connection = MyConnection4;
        MyCommand4.Transaction = transacao2;

        try
        {

            MyCommand4.CommandType = CommandType.StoredProcedure;
            MyCommand4.Parameters.Add("@codigo_anuncio", SqlDbType.Int).Value = codigo_anuncio;

            MyCommand4.ExecuteNonQuery();
            transacao2.Commit();
            MyCommand4.Dispose();
            MyConnection4.Close();

        }
        catch (Exception ex)
        {

            // Attempt to roll back the transaction.
            try
            {
                transacao2.Rollback();
                return 0;
            }
            catch (Exception ex2)
            {
            }

        }
        MyCommand4.Dispose();
        MyConnection4.Close();

        return 0;

    }

    [WebMethod(Description = "Usuarios Chat")]
    public DataSet DadosUsuariosChat()
    {

        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand("select c.codigo,c.nome_fantasia,c.login,sc.status,a.site from cliente c "+
                                        "inner join status_chat sc on sc.codigo_cliente = c.codigo " +
                                        "inner join anuncio a on a.codigo_cliente = c.codigo  ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("chat");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;
    }

    [WebMethod(Description = "Consulta Mes Agenda")]
    public DataSet ConsultaMesAgenda(int codigo_anuncio, int mes)
    {

        SqlConnection MyConnection = new SqlConnection();
        MyConnection.ConnectionString = connstring;

        SqlCommand cmd = new SqlCommand("select * from agenda where codigo_anuncio="+codigo_anuncio.ToString()+" and month(data)="+mes.ToString()+"  ", MyConnection);
        SqlDataAdapter adpt = new SqlDataAdapter(cmd);

        // Cria e preenche o DataTable
        DataTable dtBanner = new DataTable("agenda");
        adpt.Fill(dtBanner);
        DataSet ds = new DataSet();
        ds.Tables.Add(dtBanner);
        cmd.Dispose();
        MyConnection.Close();

        return ds;

    }

}