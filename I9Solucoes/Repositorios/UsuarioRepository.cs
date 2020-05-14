﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace I9Solucoes.Repositorios
{
	public class UsuarioRepository : DataBase
	{
		private SqlConnection _conexao;
		public UsuarioRepository()
		{
			_conexao = Conectar();
		}

		public bool Autenticar(string usuario, string senha)
		{
			bool retorno = false;
						SqlCommand query = new SqlCommand("select * from dbo.usuario where email=@email and senha=@senha", _conexao);
			_conexao.Open();
			SqlParameter parametroEmail = new SqlParameter();
			parametroEmail.ParameterName = "@email";
			parametroEmail.SqlDbType = SqlDbType.VarChar;
			parametroEmail.Value = usuario;
			SqlParameter parametroSenha = new SqlParameter();
			parametroSenha.ParameterName = "@senha";
			parametroSenha.SqlDbType = SqlDbType.VarChar;
			parametroSenha.Value = senha;
			query.Parameters.Add(parametroEmail);
			query.Parameters.Add(parametroSenha);
						SqlDataReader dados = query.ExecuteReader();
			if (dados.Read())
				if (dados.GetString(dados.GetOrdinal("email")) == usuario && dados.GetString(dados.GetOrdinal("senha")) == senha)
					retorno = true;

				else
					retorno = false;

			return retorno;
		}
	}
}