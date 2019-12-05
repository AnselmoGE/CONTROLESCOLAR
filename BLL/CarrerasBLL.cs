using DAO;
using DAL;
using MODELS;
using System.Collections.Generic;

namespace BLL
{
    public class CarrerasBLL
    {
        private readonly CarrerasDAL _CarrerasDAL;
        private string stringConnection;

        public CarrerasBLL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            _CarrerasDAL = new CarrerasDAL(this.stringConnection);
        }


        public DAOConecta Dao
        {
            get { return _CarrerasDAL.Dao; }
        }

        public BaseResponse<Carreras> GetCarrera(int IdCarrera)
        {
            var response = new BaseResponse<Carreras>();

            try
            {
                response.Results = _CarrerasDAL.GetCarreras(IdCarrera);

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

        public BaseResponse<List<Carreras>> GetCarrera()
        {
            var response = new BaseResponse<List<Carreras>>();

            try
            {
                response.Results = _CarrerasDAL.GetCarreras();

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

        public BaseResponse<int> UpdateCarrera(Carreras carrera)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_CarrerasDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _CarrerasDAL.Dao.Conectar();
                    desconecta = true;
                }

                _CarrerasDAL.Dao.IniciaTransaccion();

                response.Results = _CarrerasDAL.UpdateCarreras(carrera);
                response.CodeError = 0;
                _CarrerasDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _CarrerasDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _CarrerasDAL.Dao.Desconectar();
                }
            }
            return response;

        }

        public BaseResponse<int> InsertCarrera(Carreras carrera)
        {
            var response = new BaseResponse<int>();
            bool desconecta = false;
            try
            {
                if (_CarrerasDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _CarrerasDAL.Dao.Conectar();
                    desconecta = true;
                }

                _CarrerasDAL.Dao.IniciaTransaccion();

                response.Results = _CarrerasDAL.InsertCarreras(carrera);
                response.CodeError = 0;

                _CarrerasDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _CarrerasDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _CarrerasDAL.Dao.Desconectar();
                }
            }
            return response;
        }

        public BaseResponse<int> DeleteCarrera(int IdCarrera)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_CarrerasDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _CarrerasDAL.Dao.Conectar();
                    desconecta = true;
                }

                _CarrerasDAL.Dao.IniciaTransaccion();

                response.Results = _CarrerasDAL.DeleteCarreras(IdCarrera);
                response.CodeError = 0;
                _CarrerasDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _CarrerasDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _CarrerasDAL.Dao.Desconectar();
                }
            }
            return response;

        }
    }
}
