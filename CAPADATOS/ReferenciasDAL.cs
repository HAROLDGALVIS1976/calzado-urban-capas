using CAPAENTIDAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPADATOS
{
    public class ReferenciasDAL:CadenaDAL
    {
        public List<ReferenciasCLS> ListarReferencias()
        {
            List<ReferenciasCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarReeferencias", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<ReferenciasCLS>();
                            ReferenciasCLS oReferenciasCLS;

                            int posid = drd.GetOrdinal("IDREF");
                            int posref = drd.GetOrdinal("REF");
                            int posdescripcion = drd.GetOrdinal("DESCRIPCION");
                            int poscant = drd.GetOrdinal("CANT");
                            int posvaluni = drd.GetOrdinal("VALUNI_VENTA");

                            while (drd.Read())
                            {
                                oReferenciasCLS = new ReferenciasCLS();
                                oReferenciasCLS.idref = drd.IsDBNull(posid) ? 0 : drd.GetInt32(posid);
                                oReferenciasCLS.referencia = drd.IsDBNull(posref) ? "" : drd.GetString(posref);
                                oReferenciasCLS.descripcion = drd.IsDBNull(posdescripcion) ? "" : drd.GetString(posdescripcion);
                                oReferenciasCLS.cant = drd.IsDBNull(poscant) ? 0 : drd.GetDouble(poscant);
                                oReferenciasCLS.valventa = drd.IsDBNull(posvaluni) ? 0 : drd.GetDouble(posvaluni);
                                lista.Add(oReferenciasCLS);
                            }
                        }

                    }

                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return lista;
        }


        public List<ReferenciasCLS> FiltrarReferencias(string descripcion)
        {
            List<ReferenciasCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarReferencias", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<ReferenciasCLS>();
                            ReferenciasCLS oReferenciasCLS;

                            int posid = drd.GetOrdinal("IDREF");
                            int posref = drd.GetOrdinal("REF");
                            int posdescripcion = drd.GetOrdinal("DESCRIPCION");
                            int poscant = drd.GetOrdinal("CANT");
                            int posvaluni = drd.GetOrdinal("VALUNI_VENTA");

                            while (drd.Read())
                            {
                                oReferenciasCLS = new ReferenciasCLS();
                                oReferenciasCLS.idref = drd.IsDBNull(posid) ? 0 : drd.GetInt32(posid);
                                oReferenciasCLS.referencia = drd.IsDBNull(posref) ? "" : drd.GetString(posref);
                                oReferenciasCLS.descripcion = drd.IsDBNull(posdescripcion) ? "" : drd.GetString(posdescripcion);
                                oReferenciasCLS.cant = drd.IsDBNull(poscant) ? 0 : drd.GetDouble(poscant);
                                oReferenciasCLS.valventa = drd.IsDBNull(posvaluni) ? 0 : drd.GetDouble(posvaluni);
                                lista.Add(oReferenciasCLS);
                            }
                        }

                    }

                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return lista;


        }








    }
}
