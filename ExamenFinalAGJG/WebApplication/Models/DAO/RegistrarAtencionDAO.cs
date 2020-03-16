using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication.Models.BEAN;
using WebApplication.Models.Conection;

namespace WebApplication.Models.DAO
{
    public class RegistrarAtencionDAO
    {

        public List<ClienteBEAN> listaClientes()
        {
            //CREATE PROCEDURE SP_CATEGORIA_List
            //as
            //select idCategoria, nombreCategoria
            //from tb_Categoria

            List<ClienteBEAN> lista = new List<ClienteBEAN>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader lector;
            ClienteBEAN clienBEAN;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "";
                cmd.Connection = BD_ExamenFinalEntities.GetConnection();
                lector = cmd.ExecuteReader();
                while (lector.Read())
                {
                    clienBEAN = new ClienteBEAN();
                    clienBEAN.Cliente = lector.GetInt32(0);
                    clienBEAN.TipoAtencion = lector.GetString(1);
                    lista.Add(clienBEAN);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

            public ClienteBEAN datosCliente(int id)
            {
                //CREATE PROCEDURE SP_COLABORADOR_Edit
                //@id int
                //as
                //select idColaborador, nombreColaborador, apellidoColaborador, 
                //numeroDocumentoColaborador--, idRol, idTipoDocumento
                //from tb_Colaborador
                //where idColaborador = @id

                ClienteBEAN clienBEAN = new ClienteBEAN();
                SqlCommand cmd = new SqlCommand();
                SqlDataReader lector;
                try
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_COLABORADOR_Edit";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = ConexionBD.GetConnection();
                    lector = cmd.ExecuteReader();
                    while (lector.Read())
                    {
                        clienBEAN.IdCliente = lector.GetInt32(0);
                        clienBEAN.Nombre= lector.GetString(1);
                        clienBEAN.Apellido = (string)lector[2];
                        clienBEAN.NumDocumento = (string)lector[3];
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return colBEAN;
            }


            public bool editarColaborador(ColaboradorBEAN colBEAN)
            {
                //CREATE PROCEDURE SP_COLABORADOR_Editar
                //@idColaborador int,
                //@nombreColaborador varchar(50),
                //@apellidoColaborador varchar(50),
                //@numeroDocumentoColaborador varchar(50)
                //as
                //UPDATE tb_Colaborador
                //SET nombreColaborador = @nombreColaborador,
                //apellidoColaborador = @apellidoColaborador,
                //numeroDocumentoColaborador = @numeroDocumentoColaborador
                //WHERE idColaborador = @idColaborador

                bool rpta = false;
                SqlCommand cmd = new SqlCommand();
                try
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_COLABORADOR_Editar";
                    cmd.Parameters.AddWithValue("@idColaborador", colBEAN.IdColaborador);
                    cmd.Parameters.AddWithValue("@nombreColaborador", colBEAN.NombreColaborador);
                    cmd.Parameters.AddWithValue("@apellidoColaborador", colBEAN.ApellidoColaborador);
                    cmd.Parameters.AddWithValue("@numeroDocumentoColaborador", colBEAN.NumDocColaborador);
                    cmd.Connection = ConexionBD.GetConnection();
                    cmd.ExecuteNonQuery();
                    rpta = true;
                }
                catch (Exception)
                {
                    throw;
                }
                return rpta;
            }
        }
    }
}