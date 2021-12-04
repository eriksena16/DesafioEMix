using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace TesteCandidato
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            /*
            Bem vindo ao teste de Back-end da e.Mix!

            Abaixo está desenvolvido de uma forma bem simples e com alguns erros uma consulta de CEP.

            O que esperamos de você neste teste é que faça um novo projeto WEB da forma mais correta, segura e performática na sua avaliação com base no código abaixo.

            Entre os códigos você pode notar que existem observações "To Do" que também devem ser realizadas para que o teste esteja correto.
            Exemplo: "TODO: Criar banco de dados - LocalDB com o nome CEP"

            Observação: Você poderá utilizar qualquer tecnologia ou framework da sua preferência.

            */

            //TODO: Fazer um projeto WEB

            //TODO: Perguntar se o usuário quer consultar se logradouro existe na base

            //TODO: Criar banco de dados - LocalDB com o nome CEP
            //TODO: Adicionar tabela conforme script abaixo
            //USE [CEP]
            //GO

            //SET ANSI_NULLS ON
            //GO

            //SET QUOTED_IDENTIFIER ON
            //GO

            //         CREATE TABLE[dbo].[CEP] (

            //            [Id]          INT IDENTITY(1, 1) NOT NULL,

            //[cep]         CHAR(9)       NULL,
            //             [logradouro]  NVARCHAR(500) NULL,
            //             [complemento] NVARCHAR(500) NULL,
            //             [bairro]      NVARCHAR(500) NULL,
            //             [localidade]  NVARCHAR(500) NULL,
            //             [uf]          CHAR(2)       NULL,
            //             [unidade]     BIGINT NULL,
            //             [ibge]        INT NULL,
            //             [gia]         NVARCHAR(500) NULL
            //         );

            string cep = Console.ReadLine();
            string result = string.Empty;

            //TODO: Implementar forma de fazer o usuário poder errar várias vezes o CEP informado
            //TODO: Melhorar validação do CEP.
            while (cep.Length != 8)
            {
                Console.WriteLine("CEP Inválido");

                cep = Console.ReadLine();
            }

            //Exemplo CEP 13050020
            string viaCEPUrl = "https://viacep.com.br/ws/" + cep + "/json/";

            //TODO: Resolver dados com caracter especial no retorno do JSON 
            WebClient client = new WebClient();
            result = client.DownloadString(viaCEPUrl);

            //TODO: Tratar CEP Inválido.

            JObject jsonRetorno = JsonConvert.DeserializeObject<JObject>(result);

            //jsonRetorno.re("â", "a");
            //TODO: Validar CEP existente
            string query = "INSERT INTO [dbo].[CEP] ([cep], [logradouro], [complemento], [bairro], [localidade], [uf], [unidade], [ibge], [gia]) VALUES (";
            query = query + "'" + jsonRetorno["cep"] + "'";
            query = query + ",'" + jsonRetorno["logradouro"] + "'";
            query = query + ",'" + jsonRetorno["complemento"] + "'";
            query = query + ",'" + jsonRetorno["bairro"] + "'";
            query = query + ",'" + jsonRetorno["localidade"] + "'";
            query = query + ",'" + jsonRetorno["uf"] + "'";
            query = query + ",'" + jsonRetorno["unidade"] + "'";
            query = query + ",'" + jsonRetorno["ibge"] + "'";
            query = query + ",'" + jsonRetorno["gia"] + "'" + ")";

            //Server = DESKTOP - OL590ME\\SQLEXPRESS; Database = SGPContext; user id = sa; password = tacanha
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-OL590ME\\SQLEXPRESS;Initial Catalog=CEP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False; User ID=sa;Password=(tacanha)");
            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-OL590ME\\SQLEXPRESS;Initial Catalog=CEP;Persist Security Info=True;User ID=sa;Password=(tacanha)");
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            sqlCommand.CommandType = CommandType.Text;

            try
            {
                connection.Open();

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            sqlCommand.Dispose();
            connection.Close();
            connection.Dispose();

            //TODO: Retornar os dados do CEP infomado no início para o usuário

            Console.WriteLine("Deseja visualizar todos os CEPs alguma UF? Se sim, informar UF, se não, informar sair.");
            string resposta = Console.ReadLine();

            if (resposta == "sair")
            {
                return;
            }

            if (resposta.Length > 2)
            {
                Console.WriteLine("UF inválida");
                resposta = Console.ReadLine();
            }

            if (resposta == "sair")
            {
                return;
            }



            sqlCommand = new SqlCommand("Select * from CEP", connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            DataView dv;
            sqlCommand.CommandType = CommandType.Text;

            try
            {
                connection.Open();
                adapter.SelectCommand = sqlCommand;
                adapter.Fill(ds, "Create DataView");
                adapter.Dispose();

                dv = ds.Tables[0].DefaultView;

                for (int i = 0; i < dv.Count; i++)
                {
                    if (dv[i]["uf"].ToString() == resposta)
                    {
                        if (i == 0)
                        {
                            Console.Write(dv[i]["cep"]);
                        }
                        else
                        {
                            Console.Write(";" + dv[i]["cep"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            sqlCommand.Dispose();
            connection.Close();
            connection.Dispose();

            Console.ReadLine();
        }
    }
}
