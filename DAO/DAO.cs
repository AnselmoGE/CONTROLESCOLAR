using System;
using System.Data.SqlClient; //Libreria agregada.
using System.Data; //Libreria agregada.

namespace DAO
{
    public class DAOConecta
    {
        private SqlConnection _SqlConexion;
        private string stringConnection;

        public DAOConecta(string stringConnection)
        {
            this.stringConnection = stringConnection;
            //En el data source va doble diagonal para que funcione correcto
            _SqlConexion = new SqlConnection(this.stringConnection);//Cadena de conexion
        }

        public int InsertaInformacion(string strConsulta, SqlParameterCollection parametros)
        {
            int Id = 0;
            // Conectar();
            EjecutaSP(strConsulta, parametros, false);
            Id = GetIdentity();
            // Desconectar();
            return Id;
        }

        public int GetIdentity()
        {
            SqlDataReader dr = null;
            int iResult = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("Select @@IDENTITY as identidad", _SqlConexion)
                {
                    CommandType = CommandType.Text
                };

                if (_transaccion != null)
                    cmd.Transaction = _transaccion;

                dr = cmd.ExecuteReader();
                if (dr.Read())
                    iResult = dr[0] == DBNull.Value ? 0 : Convert.ToInt32(dr[0]);

                dr.Close();
            }
            catch
            {
                if (dr != null)
                    dr.Close();
                throw;
            }
            finally
            {
                if (dr != null)
                    dr.Dispose();
            }

            return iResult;
        }


        public void Desconectar() //Metodo para desconectar la BD.
        {
            _SqlConexion.Close();
        }


        public bool Conectar()//Metodo para conectar la BD.
        {
            bool Ok = false;

            try
            {
                _SqlConexion.Open();
                Ok = true;
            }
            catch (DataException)
            {
                throw;
            }

            return Ok;
        }

        public int EliminaInformacion(string strConsulta, SqlParameterCollection parametros)
        {
            return EjecutaSP(strConsulta, parametros);
        }

        public int ActualizaInformacion(string strConsulta, SqlParameterCollection parametros)
        {
            return EjecutaSP(strConsulta, parametros, true);
        }

        private int EjecutaSP(string strConsulta, SqlParameterCollection parametros)
        {
            return EjecutaSP(strConsulta, parametros, true);
        }

        private int EjecutaSP(string strConsulta, SqlParameterCollection parametros, bool Conectarp)
        {
            int iResult = 0;

            bool desconectar = false;

            try
            {
                if (Conectarp)
                    if (!this.Conectado())
                    {
                        Conectar();
                        desconectar = true;
                    }


                SqlCommand cmd = new SqlCommand(strConsulta, _SqlConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                if (_transaccion != null)
                {
                    cmd.Transaction = _transaccion;
                }

                if (parametros != null)
                {
                    foreach (SqlParameter param in parametros)
                    {
                        cmd.Parameters.Add(param.ParameterName, param.SqlDbType);
                        cmd.Parameters[cmd.Parameters.Count - 1].Value = param.Value;
                        //cmd.Parameters.Add(param);
                    }
                }

                iResult = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (Conectarp && desconectar)
                    Desconectar();
            }
            return iResult;
        }


        public DataTable ConsultaInformacion(String strConsulta, SqlParameterCollection parametros)
        {
            //Este es un tipo de tabla que se puede utilizar para recibir una consulta.
            DataTable dt = new DataTable();

            try
            {
                //
                SqlCommand cmd = new SqlCommand(strConsulta, _SqlConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (SqlParameter param in parametros)
                    {
                        cmd.Parameters.Add(param.ParameterName, param.SqlDbType);
                        cmd.Parameters[cmd.Parameters.Count - 1].Value = param.Value;
                        //cmd.Parameters.Add(param);
                    }
                }

                SqlDataAdapter daConsulta = new SqlDataAdapter(cmd);
                daConsulta.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Desconectar();
            }
            return dt;
        }

        //transacciones

        public bool Conectado()
        {
            bool _conectado = false;
            if (_SqlConexion != null)
                if (!_SqlConexion.State.Equals(ConnectionState.Closed))
                    _conectado = true;

            return _conectado;
        }

        private SqlTransaction _transaccion = null;

        public bool IniciaTransaccion()
        {
            bool Ok = false;

            if (_transaccion == null)
            {
                _transaccion = _SqlConexion.BeginTransaction();
                Ok = true;
            }

            return Ok;
        }

        public void CancelarTransaccion()
        {
            if (_transaccion != null)
            {
                _transaccion.Rollback();
                _transaccion.Dispose();
                _transaccion = null;
            }
        }

        public void ConfirmaTransaccion()
        {
            if (_transaccion != null)
            {
                _transaccion.Commit();
                _transaccion.Dispose();
                _transaccion = null;
            }
        }





    }
}
