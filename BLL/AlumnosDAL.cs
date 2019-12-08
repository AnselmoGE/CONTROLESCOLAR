using System;
using DAO;
using System.Data;
using System.Data.SqlClient;
using MODELS;
using System.Collections.Generic;

namespace DAL
{
    public class AlumnosDAL
    {
        private string stringConnection;
        internal DAOConecta Dao;

        public AlumnosDAL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            Dao = new DAOConecta(this.stringConnection);
        }

        internal int InsertAlumnos(Alumnos Alumnos)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@Nombre", SqlDbType.VarChar).Value = Alumnos.Nombre;
            parametros.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = Alumnos.ApellidoPaterno;
            parametros.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = Alumnos.ApellidoMaterno;
            parametros.Add("@telefono", SqlDbType.VarChar).Value = Alumnos.telefono;
            parametros.Add("@IdGrupo", SqlDbType.VarChar).Value = Alumnos.IdGrupo;
            parametros.Add("@IdCarrera", SqlDbType.VarChar).Value = Alumnos.IdCarrera;
            return Dao.InsertaInformacion("insertALUMNOS", parametros);
        }

        internal Alumnos GetAlumnos(int idAlumnos)
        {
            Alumnos Alumnos = new Alumnos();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdAlumno", SqlDbType.Int).Value = idAlumnos;

            DataTable dtAlumnos = Dao.ConsultaInformacion("getALUMNOS", parametros);

            if (dtAlumnos.Rows.Count > 0)
            {
                Alumnos.IdAlumno = Convert.ToInt32(dtAlumnos.Rows[0]["IdAlumno"]);
                Alumnos.Nombre = dtAlumnos.Rows[0]["Nombre"].ToString();
                Alumnos.ApellidoPaterno = dtAlumnos.Rows[0]["ApellidoPaterno"].ToString();
                Alumnos.ApellidoMaterno = dtAlumnos.Rows[0]["ApellidoMaterno"].ToString();
                Alumnos.telefono = dtAlumnos.Rows[0]["telefono"].ToString();
                Alumnos.NombreCarrera = dtAlumnos.Rows[0]["NombreCarrera"].ToString();
                Alumnos.NombreGrupo = dtAlumnos.Rows[0]["NombreGrupo"].ToString();
                Alumnos.IdCarrera = Convert.ToInt32(dtAlumnos.Rows[0]["IdCarrera"]);
                Alumnos.IdGrupo = Convert.ToInt32(dtAlumnos.Rows[0]["IdGrupo"]);
            }

            return Alumnos;
        }

        
        internal List<Alumnos> GetAlumnos()
        {
            List<Alumnos> AlumnosList = new List<Alumnos>();
            

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;

            DataTable dtUsuario = Dao.ConsultaInformacion("getALUMNOS", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    Alumnos Alumnos = new Alumnos();
                    Alumnos.IdAlumno = Convert.ToInt32(dr["IdAlumno"]);
                    Alumnos.Nombre = dr["Nombre"].ToString();
                    Alumnos.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                    Alumnos.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                    Alumnos.telefono = dr["telefono"].ToString();
                    Alumnos.NombreCarrera = dr["NombreCarrera"].ToString();
                    Alumnos.NombreGrupo = dr["NombreGrupo"].ToString();
                    Alumnos.IdCarrera = Convert.ToInt32(dr["IdCarrera"]);
                    Alumnos.IdGrupo = Convert.ToInt32(dr["IdGrupo"]);

                    AlumnosList.Add(Alumnos);
                }
            }

            return AlumnosList;
        }

        internal int DeleteAlumnos(int idAlumnos)
        {
            Alumnos Alumnos = new Alumnos();

            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdAlumno", SqlDbType.Int).Value = idAlumnos;

            return Dao.EliminaInformacion("deleteALUMNOS", parametros);
        }

        internal int UpdateAlumnos(Alumnos Alumnos)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdAlumno", SqlDbType.Int).Value = Alumnos.IdAlumno;
            parametros.Add("@Nombre", SqlDbType.VarChar).Value = Alumnos.Nombre;
            parametros.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = Alumnos.ApellidoPaterno;
            parametros.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = Alumnos.ApellidoMaterno;
            parametros.Add("@telefono", SqlDbType.VarChar).Value = Alumnos.telefono;
            parametros.Add("@IdGrupo", SqlDbType.VarChar).Value = Alumnos.IdGrupo;
            parametros.Add("@IdCarrera", SqlDbType.VarChar).Value = Alumnos.IdCarrera;

            return Dao.ActualizaInformacion("updateALUMNOS", parametros);
        }

        //HORARIO

        internal List<Horarios> GetAlumnosHorario(int idAlumnos)
        {
            List<Horarios> AlumnosList = new List<Horarios>();


            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdAlumno", SqlDbType.Int).Value = idAlumnos;

            DataTable dtUsuario = Dao.ConsultaInformacion("getALUMNOSHORARIO", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    Horarios Horario = new Horarios();
                    Horario.Hora = dr["Hora"].ToString();
                    Horario.Lunes = dr["Lunes"].ToString();
                    Horario.Martes = dr["Martes"].ToString();
                    Horario.Miercoles = dr["Miercoles"].ToString();
                    Horario.Jueves = dr["Juves"].ToString();
                    Horario.Viernes = dr["Viernes"].ToString();
                   

                    AlumnosList.Add(Horario);
                }
            }

            return AlumnosList;
        }


        internal List<AlumnosEncabezado> GetAlumnosEncabezado(int idAlumnos)
        {
            List<AlumnosEncabezado> AlumnosList = new List<AlumnosEncabezado>();


            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdAlumno", SqlDbType.Int).Value = idAlumnos;

            DataTable dtUsuario = Dao.ConsultaInformacion("getALUMNOSPDF", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    AlumnosEncabezado Alumno = new AlumnosEncabezado();
                    Alumno.Nombre = dr["Nombre"].ToString();
                    Alumno.Carrera = dr["NombreCarrera"].ToString();
                    Alumno.Grupo = dr["NombreGrupo"].ToString();

                    AlumnosList.Add(Alumno);
                }
            }

            return AlumnosList;
        }

        internal List<DocentesHorario> GetMateriasDocenteEncabezado(int idAlumnos)
        {
            List<DocentesHorario> AlumnosList = new List<DocentesHorario>();


            SqlCommand sqlCommand = new SqlCommand();
            SqlParameterCollection parametros = sqlCommand.Parameters;
            parametros.Add("@IdAlumno", SqlDbType.Int).Value = idAlumnos;

            DataTable dtUsuario = Dao.ConsultaInformacion("getALUMNOSPROFESORHORARIO", parametros);

            if (dtUsuario.Rows.Count > 0)
            {
                foreach (DataRow dr in dtUsuario.Rows)
                {
                    DocentesHorario Docente = new DocentesHorario();
                    Docente.Asignatura = dr["Asignatura"].ToString();
                    Docente.Docente = dr["Docente"].ToString();
                    Docente.Horas = dr["Horas"].ToString();

                    AlumnosList.Add(Docente);
                }
            }

            return AlumnosList;
        }


    }
}
