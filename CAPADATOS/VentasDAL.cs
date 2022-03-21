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
    public class VentasDAL:CadenaDAL
    {
        public List<ReferenciasCLS> ListarReferencia()
        {
            List<ReferenciasCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspListarRef", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<ReferenciasCLS>();
                            ReferenciasCLS oReferenciasCLS;
                            int posid = drd.GetOrdinal("IDREF");
                            int posdescripcion = drd.GetOrdinal("REF");
                            while (drd.Read())
                            {
                                oReferenciasCLS = new ReferenciasCLS();
                                oReferenciasCLS.idref = drd.IsDBNull(posid) ? 0 : drd.GetInt32(posid);
                                oReferenciasCLS.referencia = drd.IsDBNull(posdescripcion) ? "" : drd.GetString(posdescripcion);
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
        public ReferenciasCLS RecuperarRef(string descripcion)
        {
            ReferenciasCLS oReferenciasCLS = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarRef", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@descripcion", descripcion);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            int posId = drd.GetOrdinal("IDREF");
                            int posstock = drd.GetOrdinal("CANT");
                            int posvalmin = drd.GetOrdinal("VALUNI_VENTA");
                            int posdescripcion = drd.GetOrdinal("DESCRIPCION");
                            int poscosto = drd.GetOrdinal("VALCOSTO_UNI");
                            while (drd.Read())
                            {
                                oReferenciasCLS = new ReferenciasCLS();

                                oReferenciasCLS.idref = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oReferenciasCLS.cant = drd.IsDBNull(posstock) ? 0 : drd.GetDouble(posstock);
                                oReferenciasCLS.valventa = drd.IsDBNull(posvalmin) ? 0 : drd.GetDouble(posvalmin);
                                oReferenciasCLS.descripcion = drd.IsDBNull(posdescripcion) ? "" : drd.GetString(posdescripcion);
                                oReferenciasCLS.valcosto = drd.IsDBNull(poscosto) ? 0 : drd.GetDouble(poscosto);
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
            return oReferenciasCLS;
        }
        public List<VentasCLS> FiltarVentasWeb(string usuario)
        {
            List<VentasCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarventasweb", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<VentasCLS>();
                            VentasCLS oVentaswebCLS;
                            int posid = drd.GetOrdinal("IDWEB");
                            int posref = drd.GetOrdinal("REF");
                            int poscant = drd.GetOrdinal("CANT");
                            int poscliente = drd.GetOrdinal("INFO1");
                            int posfecha = drd.GetOrdinal("FECHAVENTA");

                            while (drd.Read())
                            {
                                oVentaswebCLS = new VentasCLS();
                                oVentaswebCLS.idweb = drd.IsDBNull(posid) ? 0 : drd.GetInt32(posid);
                                oVentaswebCLS.referencia = drd.IsDBNull(posref) ? "" : drd.GetString(posref);
                                oVentaswebCLS.cant = drd.IsDBNull(poscant) ? 0 : drd.GetDouble(poscant);
                                oVentaswebCLS.info1 = drd.IsDBNull(poscliente) ? "" : drd.GetString(poscliente);
                                //fecha se toma como un string
                                oVentaswebCLS.fechapagocadena = drd.GetDateTime(posfecha).ToString("yyyy/MM/dd");
                                lista.Add(oVentaswebCLS);
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
        public List<VentasCLS> ListarVentasWeb()
        {
            List<VentasCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarVentasWeb", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<VentasCLS>();
                            VentasCLS oVentaswebCLS;
                            int posid = drd.GetOrdinal("IDWEB");
                            int posref = drd.GetOrdinal("REF");
                            int poscant = drd.GetOrdinal("CANT");
                            int poscliente = drd.GetOrdinal("INFO1");
                            int posfecha = drd.GetOrdinal("FECHAVENTA");

                            while (drd.Read())
                            {
                                oVentaswebCLS = new VentasCLS();
                                oVentaswebCLS.idweb = drd.IsDBNull(posid) ? 0 : drd.GetInt32(posid);
                                oVentaswebCLS.referencia = drd.IsDBNull(posref) ? "" : drd.GetString(posref);
                                oVentaswebCLS.cant = drd.IsDBNull(poscant) ? 0 : drd.GetDouble(poscant);
                                oVentaswebCLS.info1 = drd.IsDBNull(poscliente) ? "" : drd.GetString(poscliente);
                                //fecha se toma como un string
                                oVentaswebCLS.fechapagocadena = drd.GetDateTime(posfecha).ToString("yyyy/MM/dd");
                                lista.Add(oVentaswebCLS);
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
        public int GuardarVenta(VentasCLS oVentaswebCLS)
        {
            //error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarVentas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idref", oVentaswebCLS.idref);
                        cmd.Parameters.AddWithValue("@descripcion", oVentaswebCLS.descripcion);
                        cmd.Parameters.AddWithValue("@valventauni", oVentaswebCLS.valventa);
                        cmd.Parameters.AddWithValue("@cant", oVentaswebCLS.cant);
                        cmd.Parameters.AddWithValue("@montoventa", oVentaswebCLS.monto_total);
                        cmd.Parameters.AddWithValue("@tipo", oVentaswebCLS.tipo);
                        cmd.Parameters.AddWithValue("@fechaventa", oVentaswebCLS.fechaventa);
                        cmd.Parameters.AddWithValue("@usuario", oVentaswebCLS.usuario);
                        cmd.Parameters.AddWithValue("@info1", oVentaswebCLS.info1);
                        cmd.Parameters.AddWithValue("@info2", oVentaswebCLS.info2);
                        cmd.Parameters.AddWithValue("@info3", oVentaswebCLS.info3);
                        rpta = cmd.ExecuteNonQuery();
                       
                    }
                    using (SqlCommand cmd = new SqlCommand("uspModificaReferencia", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ref", oVentaswebCLS.idref2);
                        cmd.Parameters.AddWithValue("@cant", oVentaswebCLS.stock2);
                        cmd.Parameters.AddWithValue("@valtotcosto", oVentaswebCLS.valcostototal);
                        cmd.Parameters.AddWithValue("@valtotventa", oVentaswebCLS.valventatotal);
                        rpta = cmd.ExecuteNonQuery();

                    }
                    cn.Close();
                }
                catch (Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }

            }

            return rpta;
        }
        public int ActualizaReferencia(VentasCLS oVentaswebCLS)
        {
            //error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                   
                    using (SqlCommand cmd = new SqlCommand("uspModificaReferencia", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ref", oVentaswebCLS.idref2);
                        cmd.Parameters.AddWithValue("@cant", oVentaswebCLS.stock2);
                        cmd.Parameters.AddWithValue("@valtotcosto", oVentaswebCLS.valcostototal);
                        cmd.Parameters.AddWithValue("@valtotventa", oVentaswebCLS.valventatotal);
                        rpta = cmd.ExecuteNonQuery();

                    }

                    cn.Close();
                }
                catch (Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }

            }

            return rpta;
        }
        public int ModificaReferencia(VentasCLS oVentaswebCLS)
        {
            //error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspModificaReferencia", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ref", oVentaswebCLS.idref2);
                        cmd.Parameters.AddWithValue("@cant", oVentaswebCLS.stock2);
                        cmd.Parameters.AddWithValue("@valtotcosto", oVentaswebCLS.valcostototal);
                        cmd.Parameters.AddWithValue("@valtotventa", oVentaswebCLS.valventatotal);
                        rpta = cmd.ExecuteNonQuery();

                    }

                    cn.Close();
                }
                catch (Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }

            }

            return rpta;
        }
        public VentasCLS RecuperarVenta(int idweb)
        {
            VentasCLS oVentasCLS = null;
           
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand("uspRecuperarVenta", cn))
                    {
                        //Buena practica (Opcional)->Indicamos que es un procedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idweb", idweb);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            int posweb = drd.GetOrdinal("IDWEB");
                            int posId = drd.GetOrdinal("IDREF");
                            int posdescrip = drd.GetOrdinal("DESCRIPCION");
                            int posvaluni = drd.GetOrdinal("VALUNI_VENTA");
                            int poscant = drd.GetOrdinal("CANT");
                            int posmontotot = drd.GetOrdinal("MONTO_TOTAL");
                            int postipo = drd.GetOrdinal("TIPO");
                            int posfecha = drd.GetOrdinal("FECHAVENTA");
                            int posusuario = drd.GetOrdinal("USUARIO");
                            int poscliente = drd.GetOrdinal("INFO1");
                            
                            while (drd.Read())
                            {
                                oVentasCLS = new VentasCLS();
                                oVentasCLS.idweb = drd.IsDBNull(posweb) ? 0 : drd.GetInt32(posweb);
                                oVentasCLS.idref = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oVentasCLS.descripcion = drd.IsDBNull(posdescrip) ? "" : drd.GetString(posdescrip);
                                oVentasCLS.valventa = drd.IsDBNull(posvaluni) ? 0 : drd.GetDouble(posvaluni);
                                oVentasCLS.cant = drd.IsDBNull(poscant) ? 0 : drd.GetDouble(poscant);
                                oVentasCLS.monto_total = drd.IsDBNull(posmontotot) ? 0 : drd.GetDouble(posmontotot);
                                oVentasCLS.tipo = drd.IsDBNull(postipo) ? "" : drd.GetString(postipo);
                                //formato para poder recuperrar una fecha usando el string  fechacadena
                                oVentasCLS.fechapagocadena = drd.GetDateTime(posfecha).ToString("yyyy-MM-dd");
                                oVentasCLS.usuario = drd.IsDBNull(posusuario) ? "" : drd.GetString(posusuario);
                                oVentasCLS.info1 = drd.IsDBNull(poscliente) ? "" : drd.GetString(poscliente);
                               

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
            return oVentasCLS;
        }
        public int EliminarVenta(int idweb)
        {
            //error
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarVentaWeb", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", idweb);
                        rpta = cmd.ExecuteNonQuery();
                        cn.Close();
                    }

                }
                catch (Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }

            }
            return rpta;
        }
        public List<ReferenciasCLS> ListarReferencias()
        {
            List<ReferenciasCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    //Abro la conexion
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarReeferencias2", cn))
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
                           

                            while (drd.Read())
                            {
                                oReferenciasCLS = new ReferenciasCLS();
                                oReferenciasCLS.idref = drd.IsDBNull(posid) ? 0 : drd.GetInt32(posid);
                                oReferenciasCLS.referencia = drd.IsDBNull(posref) ? "" : drd.GetString(posref);
                                oReferenciasCLS.descripcion = drd.IsDBNull(posdescripcion) ? "" : drd.GetString(posdescripcion);
                                oReferenciasCLS.cant = drd.IsDBNull(poscant) ? 0 : drd.GetDouble(poscant);
                                
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
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarReferencias2", cn))
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
                            
                            while (drd.Read())
                            {
                                oReferenciasCLS = new ReferenciasCLS();
                                oReferenciasCLS.idref = drd.IsDBNull(posid) ? 0 : drd.GetInt32(posid);
                                oReferenciasCLS.referencia = drd.IsDBNull(posref) ? "" : drd.GetString(posref);
                                oReferenciasCLS.descripcion = drd.IsDBNull(posdescripcion) ? "" : drd.GetString(posdescripcion);
                                oReferenciasCLS.cant = drd.IsDBNull(poscant) ? 0 : drd.GetDouble(poscant);
                                
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
