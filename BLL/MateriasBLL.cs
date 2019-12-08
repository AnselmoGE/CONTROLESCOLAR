using DAO;
using DAL;
using MODELS;
using System.Collections.Generic;

namespace BLL
{
    public class MateriasBLL
    {
        private readonly MateriasDAL _MateriaDAL;
        private string stringConnection;

        public MateriasBLL(string stringConnection)
        {
            this.stringConnection = stringConnection;
            _MateriaDAL = new MateriasDAL(this.stringConnection);
        }


        public DAOConecta Dao
        {
            get { return _MateriaDAL.Dao; }
        }

        public BaseResponse<Materias> GetMaterias(int IdMateria)
        {
            var response = new BaseResponse<Materias>();

            try
            {
                response.Results = _MateriaDAL.GetMaterias(IdMateria);

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

        public BaseResponse<List<Materias>> GetMaterias()
        {
            var response = new BaseResponse<List<Materias>>();

            try
            {
                response.Results = _MateriaDAL.GetMaterias();

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

       /* public BaseResponse<List<Materias>> GetMateriasHoras(int IdDocente)
        {
            var response = new BaseResponse<List<Materias>>();

            try
            {
                response.Results = _MateriaDAL.GetMateriasHoras(IdDocente);

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
        }*/

        public BaseResponse<int> UpdateMateria(Materias materia)
        {
            var response = new BaseResponse<int>();

            List<Materias> horario = _MateriaDAL.GetMateriasHoras(materia.IdDocente,materia.IdDia);

            if (horario.Count > 0)
            {
                foreach (Materias hora in horario)
                {
                    if (materia.HoraEntrada >= hora.HoraEntrada && materia.HoraSalida <= hora.HoraSalida && materia.IdMateria != hora.IdMateria ||
                   materia.HoraEntrada >= hora.HoraEntrada && materia.HoraEntrada <= hora.HoraSalida && materia.IdMateria != hora.IdMateria)
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
                if (_MateriaDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _MateriaDAL.Dao.Conectar();
                    desconecta = true;
                }
      
                _MateriaDAL.Dao.IniciaTransaccion();
                response.Results = _MateriaDAL.UpdateMaterias(materia);
                response.CodeError = 0;
                _MateriaDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _MateriaDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _MateriaDAL.Dao.Desconectar();
                }
            }
            return response;

        }

        public BaseResponse<int> InsertMateria(Materias materia)
        {
            var response = new BaseResponse<int>();
            bool desconecta = false;

            List<Materias> horario = _MateriaDAL.GetMateriasHoras(materia.IdDocente,materia.IdDia);

            if (horario.Count > 0)
            {
                foreach (Materias hora in horario)
                {
                    if (materia.HoraEntrada >= hora.HoraEntrada && materia.HoraSalida <= hora.HoraSalida ||
                   materia.HoraEntrada >= hora.HoraEntrada && materia.HoraEntrada <= hora.HoraSalida)
                    {
                        response.SetErrorCode(16);
                        response.MessageError += " en el horario : " + hora.HoraEntrada + " - " + hora.HoraSalida;
                        return response;
                    }
                }
            }



            try
            {
                if (_MateriaDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _MateriaDAL.Dao.Conectar();
                    desconecta = true;
                }

                _MateriaDAL.Dao.IniciaTransaccion();

                response.Results = _MateriaDAL.InsertMaterias(materia);
                response.CodeError = 0;

                _MateriaDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _MateriaDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _MateriaDAL.Dao.Desconectar();
                }
            }
            return response;
        }

        public BaseResponse<int> DeleteMateria(int idMateria)
        {
            var response = new BaseResponse<int>();

            bool desconecta = false;
            try
            {
                if (_MateriaDAL.Dao.Conectado())
                {
                    desconecta = false;

                }
                else
                {
                    _MateriaDAL.Dao.Conectar();
                    desconecta = true;
                }

                _MateriaDAL.Dao.IniciaTransaccion();

                response.Results = _MateriaDAL.DeleteMaterias(idMateria);
                response.CodeError = 0;
                _MateriaDAL.Dao.ConfirmaTransaccion();

            }
            catch
            {
                response.SetErrorCode(8);
                _MateriaDAL.Dao.CancelarTransaccion();
                throw;
            }
            finally
            {
                if (desconecta)
                {
                    _MateriaDAL.Dao.Desconectar();
                }
            }
            return response;

        }

        //DIAS

        public BaseResponse<List<Materias>> GetDias()
        {
            var response = new BaseResponse<List<Materias>>();

            try
            {
                response.Results = _MateriaDAL.GetDias();

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
