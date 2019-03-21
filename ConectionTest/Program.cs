using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

// LUIS XAVIER PÉREZ TORRES 3/13/2019
namespace ConectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cancion> canciones = new List<Cancion>();
            String name = "";
            SqlConnection conexion = new SqlConnection("server=HGDLAPPEREZLX\\SQLEXPRESS; database = Spotify; integrated security = true");
            try
            {

                conexion.Open();
                Console.WriteLine("Conexion abierta! ");

                String cadena = "Select ID, Name from Song";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();

                Console.WriteLine("{0} || {1}", registros.GetName(0), registros.GetName(1));

                //Leer datos de la BAse de datos e introducirlos a una lista
                while (registros.Read())
                {
                    Cancion song = new Cancion();
                    song.SetData((int)registros.GetValue(0), (String)registros.GetValue(1));
                    canciones.Add(song);
                }
                Console.WriteLine("-------------");

                //mostrar los datos desde la lista
                foreach (Cancion i in canciones)
                {
                    i.PrintData();
                }

                Console.ReadKey();

                //Introducir el nombre al elemento por buscar.
                Console.WriteLine(" - introduce el nombre que quieres buscar: \nR = ");
                name = Console.ReadLine();

                //Busqueda con LINQ
                var searchQuery = from s in canciones
                                  where s.Name.Contains(name)
                                  select s;

                if(searchQuery != null)
                {
                    foreach (var i in searchQuery)
                    {
                        i.PrintData();

                    }
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("-No hay resultados-");
                    Console.ReadKey();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("{0}, Detected!", ex);
            }
            //Cerramos conexion
            conexion.Close();
            Console.WriteLine("Conexion cerrada! ");
            Console.ReadKey();
        }
    }
}
