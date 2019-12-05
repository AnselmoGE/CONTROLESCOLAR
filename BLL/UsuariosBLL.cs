using DAO;
using DAL;
using MODELS;
using System.Collections.Generic;

namespace BLL
{
    public class UsuariosBLL
    {
        private readonly UsuariosDAL _UsuariosDAL;
        private string stringConnection;

        public UsuariosBLL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            _UsuariosDAL = new UsuariosDAL(this.stringConnection);
        }


        public DAOConecta Dao
        {
            get { return _UsuariosDAL.Dao; }
        }

        public BaseResponse<Usuarios> GetStatus(int idStatus)
        {
            var response = new BaseResponse<Usuarios>();

            try
            {
                response.Results = _UsuariosDAL.GetUsuarios(idStatus);

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

        public BaseResponse<List<Usuarios>> GetStatus()
        {
            var response = new BaseResponse<List<Usuarios>>();

            try
            {
                response.Results = _UsuariosDAL.GetUsuarios();

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

        public BaseResponse<int> UpdateStatus(Usuarios usuario)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_UsuariosDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _UsuariosDAL.Dao.Conectar();
                    desconecta = true;
                }

                _UsuariosDAL.Dao.IniciaTransaccion();

                response.Results = _UsuariosDAL.UpdateUsuarios(usuario);
                response.CodeError = 0;
                _UsuariosDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _UsuariosDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _UsuariosDAL.Dao.Desconectar();
                }
            }
            return response;

        }

        public BaseResponse<int> InsertStatus(Usuarios usuario)
        {
            var response = new BaseResponse<int>();
            bool desconecta = false;
            try
            {
                if (_UsuariosDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _UsuariosDAL.Dao.Conectar();
                    desconecta = true;
                }

                _UsuariosDAL.Dao.IniciaTransaccion();

                response.Results = _UsuariosDAL.InsertUsuarios(usuario);
                response.CodeError = 0;

                _UsuariosDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _UsuariosDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _UsuariosDAL.Dao.Desconectar();
                }
            }
            return response;
        }

        public BaseResponse<int> DeleteStatus(int usuarioID)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_UsuariosDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _UsuariosDAL.Dao.Conectar();
                    desconecta = true;
                }

                _UsuariosDAL.Dao.IniciaTransaccion();

                response.Results = _UsuariosDAL.DeleteUsuarios(usuarioID);
                response.CodeError = 0;
                _UsuariosDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _UsuariosDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _UsuariosDAL.Dao.Desconectar();
                }
            }
            return response;

        }
    }
}
