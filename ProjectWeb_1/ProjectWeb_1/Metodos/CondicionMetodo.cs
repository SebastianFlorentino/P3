using ProjectWeb_1.Clases;
using ProjectWeb_1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace ProjectWeb_1.Metodos
{
    public class CondicionMetodo
    {
        private static CondicionMetodo _instance = null;

        public CondicionMetodo() {}

        public static CondicionMetodo Instancia
        {
            get
            {
                if( _instance == null)
                {
                    _instance = new CondicionMetodo();
                }

                return _instance;
            }
        }

        public List<CondicionViewModel> Consultar()
        {
            List<CondicionViewModel> objCondicion = new List<CondicionViewModel>();

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerCondicionPropiedad", cxn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        cxn.Open();

                        using(SqlDataReader rcd  = cmd.ExecuteReader())
                        {
                            while (rcd.Read())
                            {
                                objCondicion.Add(new CondicionViewModel()
                                {
                                    IdCondicion = Convert.ToInt32(rcd["IdCondicion"]),
                                    Descripcion = rcd["Descripcion"].ToString(),
                                    Activo = Convert.ToBoolean(rcd["Activo"])
                                });
                            }
                        }

                        return objCondicion;
                    }
                    catch (Exception ex)
                    {

                        return null;
                    }
                }
            }
        }

        public bool Registrar(CondicionViewModel oCondicion)
        {
            bool respuesta = true;

            using(SqlConnection cxn = new SqlConnection(cnn.db))
            {
                try
                {
                    cxn.Open();

                    SqlCommand cmd = new SqlCommand("sp_RegistraCondicionPropiedad", cxn);

                    cmd.Parameters.AddWithValue("Descripcion", oCondicion.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {

                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Modificar(CondicionViewModel oCondicion)
        {

            bool respuesta = true;

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                try
                {
                    cxn.Open();

                    SqlCommand cmd = new SqlCommand("sp_ModificaCondicionPropiedad", cxn);

                    cmd.Parameters.AddWithValue("IdCondicion", oCondicion.IdCondicion);
                    cmd.Parameters.AddWithValue("Descripcion", oCondicion.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oCondicion.Activo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {

                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Eliminar(int Id)
        {
            bool respuesta = true;

            using(SqlConnection cxn = new SqlConnection(cnn.db))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BorraRegistroCondicion", cxn);

                    cmd.Parameters.AddWithValue("IdCondicion", Id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    respuesta = true;
                }
                catch (Exception ex)
                {

                    respuesta = false;
                }
            }

            return respuesta;
        }
    }
}