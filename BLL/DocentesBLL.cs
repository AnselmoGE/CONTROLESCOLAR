using DAO;
using DAL;
using MODELS;
using System.Collections.Generic;

namespace BLL
{
    public class DocentesBLL
    {
        private readonly DocentesDAL _DocentesDAL;
        private string stringConnection;

        public DocentesBLL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            _DocentesDAL = new DocentesDAL(this.stringConnection);
        }


        public DAOConecta Dao
        {
            get { return _DocentesDAL.Dao; }
        }

        public BaseResponse<Docentes> GetDocente(int IdDocente)
        {
            var response = new BaseResponse<Docentes>();

            try
            {
                response.Results = _DocentesDAL.GetDocentes(IdDocente);

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

        public BaseResponse<List<Docentes>> GetDocente()
        {
            var response = new BaseResponse<List<Docentes>>();

            try
            {
                response.Results = _DocentesDAL.GetDocentes();

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

        public BaseResponse<int> UpdateDocente(Docentes docente)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_DocentesDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _DocentesDAL.Dao.Conectar();
                    desconecta = true;
                }

                _DocentesDAL.Dao.IniciaTransaccion();

                response.Results = _DocentesDAL.UpdateDocentes(docente);
                response.CodeError = 0;
                _DocentesDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _DocentesDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _DocentesDAL.Dao.Desconectar();
                }
            }
            return response;

        }

        public BaseResponse<int> InsertDocente(Docentes docente)
        {
            var response = new BaseResponse<int>();
            bool desconecta = false;
            try
            {
                if (_DocentesDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _DocentesDAL.Dao.Conectar();
                    desconecta = true;
                }

                _DocentesDAL.Dao.IniciaTransaccion();

                response.Results = _DocentesDAL.InsertDocentes(docente);
                response.CodeError = 0;

                _DocentesDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _DocentesDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _DocentesDAL.Dao.Desconectar();
                }
            }
            return response;
        }

        public BaseResponse<int> DeleteDocente(int IdDocente)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_DocentesDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _DocentesDAL.Dao.Conectar();
                    desconecta = true;
                }

                _DocentesDAL.Dao.IniciaTransaccion();

                response.Results = _DocentesDAL.DeleteDocentes(IdDocente);
                response.CodeError = 0;
                _DocentesDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _DocentesDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _DocentesDAL.Dao.Desconectar();
                }
            }
            return response;

        }
    }
}
