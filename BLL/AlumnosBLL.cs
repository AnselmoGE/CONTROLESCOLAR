using DAO;
using DAL;
using MODELS;
using System.Collections.Generic;

namespace BLL
{
    public class AlumnosBLL
    {
        private readonly AlumnosDAL _AlumnosDAL;
        private string stringConnection;

        public AlumnosBLL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            _AlumnosDAL = new AlumnosDAL(this.stringConnection);
        }


        public DAOConecta Dao
        {
            get { return _AlumnosDAL.Dao; }
        }

        public BaseResponse<Alumnos> GetAlumno(int IdAlumno)
        {
            var response = new BaseResponse<Alumnos>();

            try
            {
                response.Results = _AlumnosDAL.GetAlumnos(IdAlumno);

                if (response.Results != null)
                    response.CodeError = 0;
                else
                {
                    response.SetErrorCode(7);
                }
            }
            catch
            {
                throw;
            }

            return response;
        }

        public BaseResponse<List<Alumnos>> GetAlumno()
        {
            var response = new BaseResponse<List<Alumnos>>();

            try
            {
                response.Results = _AlumnosDAL.GetAlumnos();

                if (response.Results != null)
                    response.CodeError = 0;
                else
                {
                    response.SetErrorCode(7);
                }
            }
            catch
            {
                throw;
            }

            return response;
        }

        public BaseResponse<int> UpdateAlumno(Alumnos Alumno)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_AlumnosDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _AlumnosDAL.Dao.Conectar();
                    desconecta = true;
                }

                _AlumnosDAL.Dao.IniciaTransaccion();

                response.Results = _AlumnosDAL.UpdateAlumnos(Alumno);
                response.CodeError = 0;
                _AlumnosDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _AlumnosDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _AlumnosDAL.Dao.Desconectar();
                }
            }
            return response;

        }

        public BaseResponse<int> InsertAlumno(Alumnos Alumno)
        {
            var response = new BaseResponse<int>();
            bool desconecta = false;
            try
            {
                if (_AlumnosDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _AlumnosDAL.Dao.Conectar();
                    desconecta = true;
                }

                _AlumnosDAL.Dao.IniciaTransaccion();

                response.Results = _AlumnosDAL.InsertAlumnos(Alumno);
                response.CodeError = 0;

                _AlumnosDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _AlumnosDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _AlumnosDAL.Dao.Desconectar();
                }
            }
            return response;
        }

        public BaseResponse<int> DeleteAlumno(int IdAlumno)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_AlumnosDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _AlumnosDAL.Dao.Conectar();
                    desconecta = true;
                }

                _AlumnosDAL.Dao.IniciaTransaccion();

                response.Results = _AlumnosDAL.DeleteAlumnos(IdAlumno);
                response.CodeError = 0;
                _AlumnosDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _AlumnosDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _AlumnosDAL.Dao.Desconectar();
                }
            }
            return response;

        }
    }
}
