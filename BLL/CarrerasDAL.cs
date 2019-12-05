using System;
using DAO;
using System.Data;
using System.Data.SqlClient;
using MODELS;
using System.Collections.Generic;

namespace DAL
{
    public class CarrerasDAL
    {
        private string stringConnection;
        internal DAOConecta Dao;

        public CarrerasDAL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            Dao = new DAOConecta(this.stringConnection);
        }

        internal int InsertCarreras(Carreras Carreras)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@Nombre", SqlDbType.VarChar).Value = Carreras.Nombre;
            parametros.Add("@Abreviatura", SqlDbType.VarChar).Value = Carreras.Abreviatura;
            return Dao.InsertaInformacion("insertCARRERAS", parametros);
        }

        internal Carreras GetCarreras(int idCarreras)
        {
            Carreras Carreras = new Carreras();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdCarrera", SqlDbType.Int).Value = idCarreras;

            DataTable dtCarreras = Dao.ConsultaInformacion("getCarreras", parametros);

            if (dtCarreras.Rows.Count > 0)
            {
                Carreras.IdCarrera = Convert.ToInt32(dtCarreras.Rows[0]["IdCarrera"]);
                Carreras.Nombre = dtCarreras.Rows[0]["Nombre"].ToString();
                Carreras.Abreviatura = dtCarreras.Rows[0]["Abreviatura"].ToString();
            }

            return Carreras;
        }

        
        internal List<Carreras> GetCarreras()
        {
            List<Carreras> CarrerasList = new List<Carreras>();
            

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;

            DataTable dtUsuario = Dao.ConsultaInformacion("getCARRERAS", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    Carreras Carreras = new Carreras();
                    Carreras.IdCarrera = Convert.ToInt32(dr["IdCarrera"]);
                    Carreras.Nombre = dr["Nombre"].ToString();
                    Carreras.Abreviatura = dr["Abreviatura"].ToString();

                    CarrerasList.Add(Carreras);
                }
            }

            return CarrerasList;
        }

        internal int DeleteCarreras(int idCarreras)
        {
            Carreras Carreras = new Carreras();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdCarrera", SqlDbType.Int).Value = idCarreras;

            return Dao.EliminaInformacion("deleteCARRERAS", parametros);
        }

        internal int UpdateCarreras(Carreras Carreras)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdCarrera", SqlDbType.Int).Value = Carreras.IdCarrera;
            parametros.Add("@Nombre", SqlDbType.VarChar).Value = Carreras.Nombre;
            parametros.Add("@Abreviatura", SqlDbType.VarChar).Value = Carreras.Abreviatura;

            return Dao.ActualizaInformacion("updateCARRERAS", parametros);
        }

        
    }
}
