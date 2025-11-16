using ProjectWeb_1.Clases;
using ProjectWeb_1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ProjectWeb_1.Metodos
{
    public class TipoPropiedadMetodo
    {
        private static TipoPropiedadMetodo _instancia = null;

        public TipoPropiedadMetodo()
        {

        }

        public static TipoPropiedadMetodo Instancia
        {
            get 
            {
                if (_instancia == null) 
                {
                    _instancia= new TipoPropiedadMetodo();
                }

                return _instancia;
            }
        }
        
        public List<TipoPropiedad> Listar() 
        {
            List<TipoPropiedad> rptListaTipoPropiedad = new List<TipoPropiedad>();

            using (SqlConnection oConnection = new SqlConnection(cnn.db))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerTipoPropiedad", oConnection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        oConnection.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                rptListaTipoPropiedad.Add(new TipoPropiedad()
                                {
                                    IdTipoPropiedad = Convert.ToInt32(dr["IdTipoPropiedad"]),
                                    Descripcion = dr["Descripcion"].ToString(),
                                    Activo = Convert.ToBoolean(dr["Activo"])
                                });
                            }
                        }

                        return rptListaTipoPropiedad;
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }  
                }
            }
        }

        public bool Registrar(TipoPropiedad oTipoPropiedad)
        {
            bool respuesta = true;

            using (SqlConnection oConnection = new SqlConnection(cnn.db))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarTipoPropiedad", oConnection);

                    cmd.Parameters.AddWithValue("Descripcion", oTipoPropiedad.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConnection.Open();
                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception)
                {

                    respuesta = false;
                }

                return respuesta;
            }
        }

        public bool Modificar(TipoPropiedad oTipoPropiedad)
        {

            bool respuesta = true;

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                try
                {
                    cxn.Open();

                    SqlCommand cmd = new SqlCommand("sp_ModificaTipoPropiedad", cxn);

                    cmd.Parameters.AddWithValue("IdTipoPropiedad", oTipoPropiedad.IdTipoPropiedad);
                    cmd.Parameters.AddWithValue("Descripcion", oTipoPropiedad.Descripcion);
                    cmd.Parameters.AddWithValue("Activo", oTipoPropiedad.Activo);
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

            using (SqlConnection cxn = new SqlConnection(cnn.db))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BorraRegistroTipoPropiedad", cxn);

                    cmd.Parameters.AddWithValue("IdTipoPropiedad", Id);
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