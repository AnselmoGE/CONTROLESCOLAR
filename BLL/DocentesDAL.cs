using System;
using DAO;
using System.Data;
using System.Data.SqlClient;
using MODELS;
using System.Collections.Generic;

namespace DAL
{
    public class DocentesDAL
    {
        private string stringConnection;
        internal DAOConecta Dao;

        public DocentesDAL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            Dao = new DAOConecta(this.stringConnection);
        }

        internal int InsertDocentes(Docentes Docentes)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@Nombre", SqlDbType.VarChar).Value = Docentes.Nombre;
            parametros.Add("@telefono", SqlDbType.VarChar).Value = Docentes.telefono;
            return Dao.InsertaInformacion("insertDOCENTES", parametros);
        }

        internal Docentes GetDocentes(int idDocentes)
        {
            Docentes Docentes = new Docentes();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdDocente", SqlDbType.Int).Value = idDocentes;

            DataTable dtDocentes = Dao.ConsultaInformacion("getDOCENTES", parametros);

            if (dtDocentes.Rows.Count > 0)
            {
                Docentes.IdDocente = Convert.ToInt32(dtDocentes.Rows[0]["IdDocente"]);
                Docentes.Nombre = dtDocentes.Rows[0]["Nombre"].ToString();
                Docentes.telefono = dtDocentes.Rows[0]["telefono"].ToString();
            }

            return Docentes;
        }

        
        internal List<Docentes> GetDocentes()
        {
            List<Docentes> DocentesList = new List<Docentes>();
            

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;

            DataTable dtUsuario = Dao.ConsultaInformacion("getDOCENTES", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    Docentes Docentes = new Docentes();
                    Docentes.IdDocente = Convert.ToInt32(dr["IdDocente"]);
                    Docentes.Nombre = dr["Nombre"].ToString();
                    Docentes.telefono = dr["telefono"].ToString();

                    DocentesList.Add(Docentes);
                }
            }

            return DocentesList;
        }

        internal int DeleteDocentes(int idDocentes)
        {
            Docentes Docentes = new Docentes();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdDocente", SqlDbType.Int).Value = idDocentes;

            return Dao.EliminaInformacion("deleteDOCENTES", parametros);
        }

        internal int UpdateDocentes(Docentes Docentes)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdDocente", SqlDbType.Int).Value = Docentes.IdDocente;
            parametros.Add("@Nombre", SqlDbType.VarChar).Value = Docentes.Nombre;
            parametros.Add("@telefono", SqlDbType.VarChar).Value = Docentes.telefono;

            return Dao.ActualizaInformacion("updateDOCENTES", parametros);
        }

        
    }
}
