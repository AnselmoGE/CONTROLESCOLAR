using System;
using DAO;
using System.Data;
using System.Data.SqlClient;
using MODELS;
using System.Collections.Generic;

namespace DAL
{
    public class MateriasDAL
    {
        private string stringConnection;
        internal DAOConecta Dao;

        public MateriasDAL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            Dao = new DAOConecta(this.stringConnection);
        }

        internal int InsertMaterias(Materias materias)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@Nombre", SqlDbType.VarChar).Value = materias.Nombre;
            parametros.Add("@IdDocente", SqlDbType.Int).Value = materias.IdDocente;
            parametros.Add("@HoraEntrada", SqlDbType.Time).Value = materias.HoraEntrada;
            parametros.Add("@HoraSalida", SqlDbType.Time).Value = materias.HoraSalida;
            parametros.Add("@IdDia", SqlDbType.Int).Value = materias.IdDia;
            return Dao.InsertaInformacion("insertMATERIAS", parametros);
        }

        internal Materias GetMaterias(int idMaterias)
        {
            Materias Materias = new Materias();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdMateria", SqlDbType.Int).Value = idMaterias;

            DataTable dtMaterias = Dao.ConsultaInformacion("getMATERIAS", parametros);

            if (dtMaterias.Rows.Count > 0)
            {
                Materias.IdMateria = Convert.ToInt32(dtMaterias.Rows[0]["IdMateria"]);
                Materias.Nombre = dtMaterias.Rows[0]["Nombre"].ToString();
                Materias.NombreDocente = dtMaterias.Rows[0]["NombreDocente"].ToString(); 
                Materias.IdDocente = Convert.ToInt32(dtMaterias.Rows[0]["IdDocente"].ToString());
                Materias.HoraEntrada = Convert.ToDateTime(dtMaterias.Rows[0]["HoraEntrada"].ToString()).TimeOfDay;
                Materias.HoraSalida = Convert.ToDateTime(dtMaterias.Rows[0]["HoraSalida"].ToString()).TimeOfDay;
                Materias.NombreDia = dtMaterias.Rows[0]["NombreDia"].ToString();
                Materias.IdDia = Convert.ToInt32(dtMaterias.Rows[0]["IdDia"].ToString());
            }

            return Materias;
        }

        
        internal List<Materias> GetMaterias()
        {
            List<Materias> MateriasList = new List<Materias>();
            

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;

            DataTable dtUsuario = Dao.ConsultaInformacion("getMATERIAS", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    Materias Materias = new Materias();
                    Materias.IdMateria = Convert.ToInt32(dr["IdMateria"]);
                    Materias.Nombre = dr["Nombre"].ToString();
                    Materias.NombreDocente = dr["NombreDocente"].ToString();
                    Materias.IdDocente = Convert.ToInt32(dr["IdDocente"].ToString());
                    Materias.HoraEntrada = Convert.ToDateTime(dr["HoraEntrada"].ToString()).TimeOfDay;
                    Materias.HoraSalida = Convert.ToDateTime(dr["HoraSalida"].ToString()).TimeOfDay;
                    Materias.NombreDia = dr["NombreDia"].ToString();
                    Materias.IdDia = Convert.ToInt32(dr["IdDia"].ToString());

                    MateriasList.Add(Materias);
                }
            }

            return MateriasList;
        }

        internal List<Materias> GetMateriasHoras(int idDocente, int IdDia)
        {
            List<Materias> MateriasList = new List<Materias>();


            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdDocente", SqlDbType.Int).Value = idDocente;
            parametros.Add("@IdDia", SqlDbType.Int).Value = IdDia;

            DataTable dtUsuario = Dao.ConsultaInformacion("getMATERIASHORA", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    Materias Materias = new Materias();
                    Materias.IdMateria = Convert.ToInt32(dr["IdMateria"]);
                    Materias.Nombre = dr["Nombre"].ToString();
                    Materias.NombreDocente = dr["NombreDocente"].ToString();
                    Materias.IdDocente = Convert.ToInt32(dr["IdDocente"].ToString());
                    Materias.HoraEntrada = Convert.ToDateTime(dr["HoraEntrada"].ToString()).TimeOfDay;
                    Materias.HoraSalida = Convert.ToDateTime(dr["HoraSalida"].ToString()).TimeOfDay;

                    MateriasList.Add(Materias);
                }
            }

            return MateriasList;
        }

        internal int DeleteMaterias(int idMaterias)
        {
            Materias Materias = new Materias();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdMateria", SqlDbType.Int).Value = idMaterias;

            return Dao.EliminaInformacion("deleteMATERIAS", parametros);
        }

        internal int UpdateMaterias(Materias materias)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdMateria", SqlDbType.Int).Value = materias.IdMateria;
            parametros.Add("@Nombre", SqlDbType.VarChar).Value = materias.Nombre;
            parametros.Add("@IdDocente", SqlDbType.Int).Value = materias.IdDocente;
            parametros.Add("@HoraEntrada", SqlDbType.Time).Value = materias.HoraEntrada;
            parametros.Add("@HoraSalida", SqlDbType.Time).Value = materias.HoraSalida;
            parametros.Add("@IdDia", SqlDbType.Int).Value = materias.IdDia;

            return Dao.ActualizaInformacion("updateMATERIAS", parametros);
        }

        //dias
        internal List<Materias> GetDias()
        {
            List<Materias> MateriasList = new List<Materias>();


            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;

            DataTable dtUsuario = Dao.ConsultaInformacion("getDIAS", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    Materias Materias = new Materias();
                    Materias.IdDia = Convert.ToInt32(dr["IdDias"]);
                    Materias.NombreDia = dr["Nombre"].ToString();

                    MateriasList.Add(Materias);
                }
            }

            return MateriasList;
        }


    }
}
