using System;
using DAO;
using System.Data;
using System.Data.SqlClient;
using MODELS;
using System.Collections.Generic;

namespace DAL
{
    public class UsuariosDAL
    {
        private string stringConnection;
        internal DAOConecta Dao;

        public UsuariosDAL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            Dao = new DAOConecta(this.stringConnection);
        }

        internal int InsertUsuarios(Usuarios Usuarios)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@Usario", SqlDbType.VarChar).Value = Usuarios.Usario;
            parametros.Add("@Password", SqlDbType.VarChar).Value = Usuarios.Password;
            return Dao.InsertaInformacion("insertUSUARIOS", parametros);
        }

        internal Usuarios GetUsuarios(int idUsuarios)
        {
            Usuarios Usuarios = new Usuarios();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdUsuario", SqlDbType.Int).Value = idUsuarios;

            DataTable dtUsuarios = Dao.ConsultaInformacion("getUSUARIOS", parametros);

            if (dtUsuarios.Rows.Count > 0)
            {
                Usuarios.IdUsuario = Convert.ToInt32(dtUsuarios.Rows[0]["IdUsuario"]);
                Usuarios.Usario = dtUsuarios.Rows[0]["Usario"].ToString();
                Usuarios.Password = dtUsuarios.Rows[0]["Password"].ToString();
            }

            return Usuarios;
        }

        internal Usuarios GetUsuarios(string Usuario, string password)
        {
            Usuarios Usuarios = new Usuarios();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
            parametros.Add("@Password", SqlDbType.VarChar).Value = password;

            DataTable dtUsuarios = Dao.ConsultaInformacion("getUSUARIOSLOG", parametros);

            if (dtUsuarios.Rows.Count > 0)
            {
                Usuarios.IdUsuario = Convert.ToInt32(dtUsuarios.Rows[0]["IdUsuario"]);
                Usuarios.Usario = dtUsuarios.Rows[0]["Usario"].ToString();
                Usuarios.Password = dtUsuarios.Rows[0]["Password"].ToString();
            }

            return Usuarios;
        }

        internal List<Usuarios> GetUsuarios()
        {
            List<Usuarios> UsuariosList = new List<Usuarios>();
            

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;

            DataTable dtUsuario = Dao.ConsultaInformacion("getUSUARIOS", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    Usuarios Usuarios = new Usuarios();
                    Usuarios.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    Usuarios.Usario = dr["Usario"].ToString();
                    Usuarios.Password = dr["Password"].ToString();

                    UsuariosList.Add(Usuarios);
                }
            }

            return UsuariosList;
        }

        internal int DeleteUsuarios(int idUsuarios)
        {
            Usuarios Usuarios = new Usuarios();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdUsuario", SqlDbType.Int).Value = idUsuarios;

            return Dao.EliminaInformacion("deleteUSUARIOS", parametros);
        }

        internal int UpdateUsuarios(Usuarios Usuarios)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdUsuario", SqlDbType.Int).Value = Usuarios.IdUsuario;
            parametros.Add("@Usario", SqlDbType.VarChar).Value = Usuarios.Usario;
            parametros.Add("@Password", SqlDbType.VarChar).Value = Usuarios.Password;

            return Dao.ActualizaInformacion("updateUSUARIOS", parametros);
        }

        
    }
}
