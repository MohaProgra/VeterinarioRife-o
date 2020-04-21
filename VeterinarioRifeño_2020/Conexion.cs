using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VeterinarioRifeño_2020
{
        class Conexion
        {
            public MySqlConnection conexion;

            public Conexion()

            {

                conexion = new MySqlConnection("Server = 192.168.71.166; Database = veterinario; Uid = root; Pwd =; Port = 3306");
            }
       

        public Boolean loginVeterinario(String DNI, String pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("SELECT * FROM usuario where DNI = @DNI AND pass = @pass", conexion);

                consulta.Parameters.AddWithValue("@DNI", DNI);               
                consulta.Parameters.AddWithValue("@pass", pass);

                //Esto hace la consulta y a continuación devuelve el resultado
                MySqlDataReader resultado = consulta.ExecuteReader();

                //Si he conseguido leer un dato devuelvo true, sino false.
                if (resultado.Read())
                {
                    return true;
                }

                conexion.Close();
                return false;
            }
            catch (MySqlException e)
            {
                return false;
            }

        }
        public String Registrar(String DNI, String Nombre, String pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta =
                    new MySqlCommand("INSERT INTO usuario (id, DNI, Nombre, pass) VALUES (NULL, @DNIregistro, @nombre, @contraseña)", conexion);
                consulta.Parameters.AddWithValue("@DNIregistro", DNI);
                consulta.Parameters.AddWithValue("@nombre", Nombre);
                consulta.Parameters.AddWithValue("@contraseña", pass);

                //Es una consulta de insercion, es decir, no espera recibir nada.
                consulta.ExecuteNonQuery();

                conexion.Close();
                return "ok";
            }
            catch (MySqlException e)
            {
                return "error";
            }

        }

    }
}

        
    
