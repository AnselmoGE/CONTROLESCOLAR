using DAO;
using DAL;
using MODELS;
using System.Collections.Generic;

namespace BLL
{
    public class GruposBLL
    {
        private readonly GruposDAL _GrupoDAL;
        private readonly MateriasDAL _MateriaDAL;

        private string stringConnection;

        public GruposBLL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            _GrupoDAL = new GruposDAL(this.stringConnection);
            _MateriaDAL = new MateriasDAL(this.stringConnection);
        }


        public DAOConecta Dao
        {
            get { return _GrupoDAL.Dao; }
        }

        public BaseResponse<Grupos> GetGrupos(int IdGrupo)
        {
            var response = new BaseResponse<Grupos>();

            try
            {
                response.Results = _GrupoDAL.GetGrupos(IdGrupo);

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

        public BaseResponse<List<Grupos>> GetGrupos()
        {
            var response = new BaseResponse<List<Grupos>>();

            try
            {
                response.Results = _GrupoDAL.GetGrupos();

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

        public BaseResponse<List<GruposMaterias>> GetGruposMaterias(int IdGrupo)
        {
            var response = new BaseResponse<List<GruposMaterias>>();

            try
            {
                response.Results = _GrupoDAL.GetMateriasGrupos(IdGrupo);

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

        public BaseResponse<int> UpdateGrupo(Grupos Grupo)
        {
            var response = new BaseResponse<int>();
            bool desconecta = false;
            try
            {
                if (_GrupoDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _GrupoDAL.Dao.Conectar();
                    desconecta = true;
                }

                _GrupoDAL.Dao.IniciaTransaccion();
                response.Results = _GrupoDAL.UpdateGrupos(Grupo);
                response.CodeError = 0;
                _GrupoDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _GrupoDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _GrupoDAL.Dao.Desconectar();
                }
            }
            return response;

        }

        public BaseResponse<int> InsertGrupo(Grupos Grupo)
        {
            var response = new BaseResponse<int>();
            bool desconecta = false;

            try
            {
                if (_GrupoDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _GrupoDAL.Dao.Conectar();
                    desconecta = true;
                }

                _GrupoDAL.Dao.IniciaTransaccion();

                response.Results = _GrupoDAL.InsertGrupos(Grupo);
                response.CodeError = 0;

                _GrupoDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _GrupoDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _GrupoDAL.Dao.Desconectar();
                }
            }
            return response;
        }

        public BaseResponse<int> DeleteGrupo(int idGrupo)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_GrupoDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _GrupoDAL.Dao.Conectar();
                    desconecta = true;
                }

                _GrupoDAL.Dao.IniciaTransaccion();

                response.Results = _GrupoDAL.DeleteGrupos(idGrupo);
                response.CodeError = 0;
                _GrupoDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _GrupoDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _GrupoDAL.Dao.Desconectar();
                }
            }
            return response;

        }

        //GRUPOSMETARIAS
        public BaseResponse<int> UpdateGrupoMateria(GruposMaterias Grupo)
        {
            var response = new BaseResponse<int>();

            int existe = _GrupoDAL.GetGruposMateriasIN(Grupo.IdGrupo, Grupo.IdMateria);

            if (existe > 0)
            {
                response.SetErrorCode(17);
                return response;
            }

            List<GruposMaterias> materiasList = _GrupoDAL.GetMateriasGrupos(Grupo.IdGrupo);
            Materias currentMateria = _MateriaDAL.GetMaterias(Grupo.IdMateria);

            if (materiasList.Count > 0)
            {
                foreach (GruposMaterias materia in materiasList)
                {
                    if (currentMateria.IdDia == materia.IdDia && materia.HoraEntrada >= currentMateria.HoraEntrada && materia.HoraSalida <= currentMateria.HoraSalida && materia.IdMateria != currentMateria.IdMateria ||
                 currentMateria.IdDia == materia.IdDia &&  materia.HoraEntrada >= currentMateria.HoraEntrada && materia.HoraEntrada <= currentMateria.HoraSalida && materia.IdMateria != currentMateria.IdMateria)
                    {
                        response.SetErrorCode(16);
                        response.MessageError += " en el horario : " + currentMateria.HoraEntrada + " - " + currentMateria.HoraSalida;
                        return response;
                    }
                }
            }

            List<GruposMaterias> horario = _GrupoDAL.GetMateriasByDocente(currentMateria.IdDocente);

            if (horario.Count > 0)
            {
                foreach (GruposMaterias hora in horario)
                {
                    if (currentMateria.HoraEntrada >= hora.HoraEntrada && currentMateria.HoraSalida <= hora.HoraSalida && currentMateria.IdMateria != hora.IdMateria ||
                   currentMateria.HoraEntrada >= hora.HoraEntrada && currentMateria.HoraEntrada <= hora.HoraSalida && currentMateria.IdMateria != hora.IdMateria)
                    {
                        response.SetErrorCode(16);
                        response.MessageError += " en el horario : " + hora.HoraEntrada + " - " + hora.HoraSalida;
                        return response;
                    }
                }
            }


            bool desconecta = false;
            try
            {
                if (_GrupoDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _GrupoDAL.Dao.Conectar();
                    desconecta = true;
                }

                _GrupoDAL.Dao.IniciaTransaccion();
                response.Results = _GrupoDAL.UpdateGruposMateria(Grupo);
                response.CodeError = 0;
                _GrupoDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _GrupoDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _GrupoDAL.Dao.Desconectar();
                }
            }
            return response;

        }

        public BaseResponse<int> InsertGrupoMateria(GruposMaterias Grupo)
        {
            var response = new BaseResponse<int>();

            int existe = _GrupoDAL.GetGruposMateriasIN(Grupo.IdGrupo, Grupo.IdMateria);

            if (existe > 0)
            {
                response.SetErrorCode(17);
                return response;
            }

            List<GruposMaterias> materiasList = _GrupoDAL.GetMateriasGrupos(Grupo.IdGrupo);
            Materias currentMateria = _MateriaDAL.GetMaterias(Grupo.IdMateria);

            if (materiasList.Count > 0)
            {
                foreach (GruposMaterias materia in materiasList)
                {
                    if (currentMateria.IdDia == materia.IdDia && materia.HoraEntrada >= currentMateria.HoraEntrada && materia.HoraSalida <= currentMateria.HoraSalida ||
                 currentMateria.IdDia == materia.IdDia &&  materia.HoraEntrada >= currentMateria.HoraEntrada && materia.HoraEntrada <= currentMateria.HoraSalida)
                    {
                        response.SetErrorCode(16);
                        response.MessageError += " en el horario : " + currentMateria.HoraEntrada + " - " + currentMateria.HoraSalida;
                        return response;
                    }
                }
            }

            List<GruposMaterias> horario = _GrupoDAL.GetMateriasByDocente(currentMateria.IdDocente);

            if (horario.Count > 0)
            {
                foreach (GruposMaterias hora in horario)
                {
                    if (currentMateria.HoraEntrada >= hora.HoraEntrada && currentMateria.HoraSalida <= hora.HoraSalida  ||
                   currentMateria.HoraEntrada >= hora.HoraEntrada && currentMateria.HoraEntrada <= hora.HoraSalida )
                    {
                        response.SetErrorCode(16);
                        response.MessageError += " en el horario : " + hora.HoraEntrada + " - " + hora.HoraSalida;
                        return response;
                    }
                }
            }

            bool desconecta = false;

            try
            {
                if (_GrupoDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _GrupoDAL.Dao.Conectar();
                    desconecta = true;
                }

                _GrupoDAL.Dao.IniciaTransaccion();

                response.Results = _GrupoDAL.InsertGruposMateria(Grupo);
                response.CodeError = 0;

                _GrupoDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _GrupoDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _GrupoDAL.Dao.Desconectar();
                }
            }
            return response;
        }

        public BaseResponse<int> DeleteGrupoMateria(int idGrupo)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_GrupoDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _GrupoDAL.Dao.Conectar();
                    desconecta = true;
                }

                _GrupoDAL.Dao.IniciaTransaccion();

                response.Results = _GrupoDAL.DeleteGruposMateria(idGrupo);
                response.CodeError = 0;
                _GrupoDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _GrupoDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _GrupoDAL.Dao.Desconectar();
                }
            }
            return response;

        }

        //GruposCarrera
        public BaseResponse<List<Grupos>> GetGruposByCarrera(int IdCarrera)
        {
            var response = new BaseResponse<List<Grupos>>();

            try
            {
                response.Results = _GrupoDAL.GetGruposByCarrera(IdCarrera);

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
    }
}
