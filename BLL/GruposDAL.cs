using System;
using DAO;
using System.Data;
using System.Data.SqlClient;
using MODELS;
using System.Collections.Generic;

namespace DAL
{
    public class GruposDAL
    {
        private string stringConnection;
        internal DAOConecta Dao;

        public GruposDAL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            Dao = new DAOConecta(this.stringConnection);
        }

        internal int InsertGrupos(Grupos Grupos)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@Nombre", SqlDbType.VarChar).Value = Grupos.Nombre;
            parametros.Add("@IdCarrera", SqlDbType.Int).Value = Grupos.IdCarrera;
            return Dao.InsertaInformacion("insertGRUPOS", parametros);
        }

        internal Grupos GetGrupos(int idGrupos)
        {
            Grupos Grupos = new Grupos();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdGrupo", SqlDbType.Int).Value = idGrupos;

            DataTable dtGrupos = Dao.ConsultaInformacion("getGRUPOS", parametros);

            if (dtGrupos.Rows.Count > 0)
            {
                Grupos.IdGrupo = Convert.ToInt32(dtGrupos.Rows[0]["IdGrupo"]);
                Grupos.Nombre = dtGrupos.Rows[0]["Nombre"].ToString();
                Grupos.NombreCarrera = dtGrupos.Rows[0]["NombreCarrera"].ToString(); 
                Grupos.IdCarrera = Convert.ToInt32(dtGrupos.Rows[0]["IdCarrera"].ToString());
               
            }

            return Grupos;
        }

        
        internal List<Grupos> GetGrupos()
        {
            List<Grupos> GruposList = new List<Grupos>();
            

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;

            DataTable dtUsuario = Dao.ConsultaInformacion("getGRUPOS", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    Grupos Grupos = new Grupos();
                    Grupos.IdGrupo = Convert.ToInt32(dr["IdGrupo"]);
                    Grupos.Nombre = dr["Nombre"].ToString();
                    Grupos.NombreCarrera = dr["NombreCarrera"].ToString();
                    Grupos.IdCarrera = Convert.ToInt32(dr["IdCarrera"].ToString());

                    GruposList.Add(Grupos);
                }
            }

            return GruposList;
        }

        internal List<GruposMaterias> GetMateriasGrupos(int idGrupo)
        {
            List<GruposMaterias> GruposList = new List<GruposMaterias>();


            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdGrupo", SqlDbType.Int).Value = idGrupo;

            DataTable dtUsuario = Dao.ConsultaInformacion("getMATERIASBYGRUPOS", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    GruposMaterias Grupos = new GruposMaterias();
                    Grupos.IdGrupoMateria = Convert.ToInt32(dr["IdGrupoMateria"]);
                    Grupos.NombreGrupo = dr["NombreGrupo"].ToString();
                    Grupos.NombreMateria = dr["NombreMateria"].ToString();
                    Grupos.IdGrupo = Convert.ToInt32(dr["IdGrupo"].ToString());
                    Grupos.IdMateria = Convert.ToInt32(dr["IdMateria"].ToString());
                    Grupos.IdDocente = Convert.ToInt32(dr["IdDocente"].ToString());
                    Grupos.NombreDocente =dr["NombreDocente"].ToString();
                    Grupos.HoraEntrada = Convert.ToDateTime(dr["HoraEntrada"].ToString()).TimeOfDay;
                    Grupos.HoraSalida = Convert.ToDateTime(dr["HoraSalida"].ToString()).TimeOfDay;
                    Grupos.IdDia = Convert.ToInt32(dr["IdDia"].ToString());
                    Grupos.NombreDia = dr["NombreDia"].ToString();

                    GruposList.Add(Grupos);
                }
            }

            return GruposList;
        }

        internal int DeleteGrupos(int idGrupos)
        {
            Grupos Grupos = new Grupos();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdGrupo", SqlDbType.Int).Value = idGrupos;

            return Dao.EliminaInformacion("deleteGRUPOS", parametros);
        }

        internal int UpdateGrupos(Grupos Grupos)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdGrupo", SqlDbType.Int).Value = Grupos.IdGrupo;
            parametros.Add("@Nombre", SqlDbType.VarChar).Value = Grupos.Nombre;
            parametros.Add("@IdCarrera", SqlDbType.Int).Value = Grupos.IdCarrera;

            return Dao.ActualizaInformacion("updateGRUPOS", parametros);
        }

        //GRUPOS-MATERIA
        internal int InsertGruposMateria(GruposMaterias Grupos)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdGrupo", SqlDbType.VarChar).Value = Grupos.IdGrupo;
            parametros.Add("@IdMateria", SqlDbType.Int).Value = Grupos.IdMateria;
            return Dao.InsertaInformacion("insertGRUPOSMATERIAS", parametros);
        }

        internal int UpdateGruposMateria(GruposMaterias Grupos)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdGrupoMateria", SqlDbType.Int).Value = Grupos.IdGrupo;
            parametros.Add("@IdGrupo", SqlDbType.VarChar).Value = Grupos.IdGrupo;
            parametros.Add("@IdMateria", SqlDbType.Int).Value = Grupos.IdMateria;

            return Dao.ActualizaInformacion("updateGRUPOSMATERIAS", parametros);
        }

        internal int DeleteGruposMateria(int idGruposMateria)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdGrupoMateria", SqlDbType.Int).Value = idGruposMateria;

            return Dao.EliminaInformacion("deleteGRUPOSMATERIAS", parametros);
        }

        internal int GetGruposMateriasIN(int idGrupo, int IdMateria)
        {
            int result = 0;
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdGrupo", SqlDbType.Int).Value = idGrupo;
            parametros.Add("@IdMateria", SqlDbType.Int).Value = IdMateria;

            DataTable dtGrupos = Dao.ConsultaInformacion("getMATERIASINGRUPO", parametros);

            if (dtGrupos.Rows.Count > 0)
            {
                result = Convert.ToInt32(dtGrupos.Rows[0]["total"]);

            }

            return result;
        }

        //GRUPOS-CARRERA
        internal List<Grupos> GetGruposByCarrera(int IdCarrera)
        {
            List<Grupos> GruposList = new List<Grupos>();
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdCarrera", SqlDbType.Int).Value = IdCarrera;

            DataTable dtGrupos = Dao.ConsultaInformacion("getGRUPOSCARRERA", parametros);

            if (dtGrupos.Rows.Count > 0)
            {
                foreach (DataRow dr in dtGrupos.Rows)
                {
                    Grupos Grupos = new Grupos();
                    Grupos.IdGrupo = Convert.ToInt32(dr["IdGrupo"]);
                    Grupos.Nombre = dr["Nombre"].ToString();
                    Grupos.NombreCarrera = dr["NombreCarrera"].ToString();
                    Grupos.IdCarrera = Convert.ToInt32(dr["IdCarrera"].ToString());

                    GruposList.Add(Grupos);
                }
            }

            return GruposList;
        }

        internal List<GruposMaterias> GetMateriasByDocente(int idDocente)
        {
            List<GruposMaterias> GruposList = new List<GruposMaterias>();


            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdDocente", SqlDbType.Int).Value = idDocente;

            DataTable dtUsuario = Dao.ConsultaInformacion("getMATERIASBYDOCENTE", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    GruposMaterias Grupos = new GruposMaterias();
                    Grupos.IdGrupoMateria = Convert.ToInt32(dr["IdGrupoMateria"]);
                    Grupos.NombreGrupo = dr["NombreGrupo"].ToString();
                    Grupos.NombreMateria = dr["NombreMateria"].ToString();
                    Grupos.IdGrupo = Convert.ToInt32(dr["IdGrupo"].ToString());
                    Grupos.IdMateria = Convert.ToInt32(dr["IdMateria"].ToString());
                    Grupos.IdDocente = Convert.ToInt32(dr["IdDocente"].ToString());
                    Grupos.NombreDocente = dr["NombreDocente"].ToString();
                    Grupos.HoraEntrada = Convert.ToDateTime(dr["HoraEntrada"].ToString()).TimeOfDay;
                    Grupos.HoraSalida = Convert.ToDateTime(dr["HoraSalida"].ToString()).TimeOfDay;
                    Grupos.IdDia = Convert.ToInt32(dr["IdDia"].ToString());
                    Grupos.NombreDia = dr["NombreDia"].ToString();

                    GruposList.Add(Grupos);
                }
            }

            return GruposList;
        }

    }
}
