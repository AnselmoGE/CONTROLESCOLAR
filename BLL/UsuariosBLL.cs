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

        public BaseResponse<Usuarios> GetUsuario(int IdUsuario)
        {
            var response = new BaseResponse<Usuarios>();

            try
            {
                response.Results = _UsuariosDAL.GetUsuarios(IdUsuario);

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

        public BaseResponse<bool> GetUsuarioLOG(string usuario, string password)
        {
            var response = new BaseResponse<bool>();

            try
            {
                Usuarios usuarioResult = _UsuariosDAL.GetUsuarios(usuario, password);

                response.Results = usuarioResult.IdUsuario>0 ? true : false;

                if (response.Results )
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

        public BaseResponse<List<Usuarios>> GetUsuario()
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

        public BaseResponse<int> UpdateUsuario(Usuarios usuario)
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

        public BaseResponse<int> InsertUsuario(Usuarios usuario)
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

        public BaseResponse<int> DeleteUsuario(int usuarioID)
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
