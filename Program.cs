using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;


namespace Cajero
{
    public class Program
    {
        int idCajero = 1;

        public static void Main(string[] args)
        {
          /*    ==== Menu ====    */
            Console.WriteLine("Bienvenido al cajero de criptomonedas! \n");
            Console.WriteLine("1.- Depositar");
            Console.WriteLine("2.- Enviar");
            Console.WriteLine("3.- Retirar");
            Console.WriteLine("4 - caso de pruebas");

            int menu = Convert.ToInt32(Console.ReadLine());

            switch(menu) 
            {
              case 1:
              Depositar();
                break;
              case 2:
              Whithdraw();
                break;
              case 3:
              Transfer();
                break;
              default:
                Console.WriteLine("Opcion no valida");
                break;
            }
            Console.ReadKey();
        }

      static void crearBilletera()
      {
        string back = "R.- Regresar";

        Console.WriteLine("Crea una billetera de criptomonedas ! \n");
        Console.WriteLine("{0} \n1.- Ingresa tu nombre o nombres: ", back);
        Console.WriteLine("{0} \n2.- Ingresa apellido paterno:", back);
        Console.WriteLine("{0} \n3.- Ingresa apellido materno:", back);
        Console.WriteLine("{0} \n3.- Crea un nup unico:", back);
      }

      static void Depositar()
      {
        SqlConnection connectionDB = new SqlConnection("SERVER=CLIENTE\\SQLEXPRESS; DATABASE=criptos; integrated security=true");
        SqlCommand comand = new SqlCommand();
        string query;
        int menu;
        //int cantidad;

        Console.Clear();
        Console.WriteLine("Que moneda desea depositar?");
        Console.WriteLine("1.- xrp");
        Console.WriteLine("2.- etherium");
        Console.WriteLine("3.- bitcoin");
        Console.WriteLine("4.- Dollars");
        menu = Convert.ToInt32(Console.ReadLine());

        switch(menu)
        {
          case 1:
            connectionDB.Open();
            string? xrpTxt = null;

            Console.Write("Insert xrp mount: ");
            xrpTxt = Console.ReadLine();

            query = "UPDATE billetera SET xrp = '"+ xrpTxt +"' WHERE id_billetera = '00001';";
            comand = new SqlCommand(query, connectionDB);
            // comand.Parameters.AddWithValue("@xrp", xrpTxt);
            comand.ExecuteNonQuery();
            connectionDB.Close();
              break;
          case 2:
            connectionDB.Open();
            string? etherium = null;

            Console.Write("Insert etherium mount: ");
            etherium = Console.ReadLine();

            query = "UPDATE billetera SET etherium = '"+ etherium +"' WHERE id_billetera = '00001';";
            comand = new SqlCommand(query, connectionDB);
            comand.ExecuteNonQuery();
            connectionDB.Close();
              break;
          case 3:
            connectionDB.Open();
            string? bitcoin = null;

            Console.Write("Insert bitcoin mount: ");
            bitcoin = Console.ReadLine();

            query = "UPDATE billetera SET bitcoin = '"+ bitcoin +"' WHERE id_billetera = '00001';";
            comand = new SqlCommand(query, connectionDB);
            comand.ExecuteNonQuery();
            connectionDB.Close();
              break;
          case 4:
            connectionDB.Open();
            string? dollars = null;

            Console.Write("Insert dollars mount: ");
            dollars = Console.ReadLine();

            query = "UPDATE billetera SET dollars = '"+ dollars +"' WHERE id_billetera = '00001';";
            comand = new SqlCommand(query, connectionDB);
            comand.ExecuteNonQuery();
            connectionDB.Close();
              break;
        }
      }

      static void Whithdraw()
      {
        int menu;
        int cantidad;

        Console.Clear();
        Console.WriteLine("Que moneda desea transferir?");
        Console.WriteLine("1.- xrp");
        Console.WriteLine("2.- etherium");
        Console.WriteLine("3.- bitcoin");
        Console.WriteLine("4.- Dolares");
        menu = Convert.ToInt32(Console.ReadLine());

        switch(menu)
        {
          case 1:
            Console.WriteLine("Ingrese cantidad de xrp a transferir");
            cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Deposito exitoso");
              break;
          case 2:
            Console.WriteLine("Ingrese cantidad de etherium a transferir");
            cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Deposito exitoso");
              break;
          case 3:
            Console.WriteLine("Ingrese cantidad de bitcoin a transferir");
            cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Deposito exitoso");
              break;
          case 4:
            Console.WriteLine("Ingrese cantidad de dolares a ingresar");
            cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Deposito exitoso");
              break;
        }
      }

      static void Transfer()
      {
        int menu;
        int cantidad;

        Console.Clear();
        Console.WriteLine("Que moneda desea retirar?");
        Console.WriteLine("1.- xrp");
        Console.WriteLine("2.- etherium");
        Console.WriteLine("3.- bitcoin");
        Console.WriteLine("4.- Dolares");
        menu = Convert.ToInt32(Console.ReadLine());
      
        switch(menu)
        {
          case 1:
            Console.WriteLine("Ingrese cantidad de xrp a ingresar");
            cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Puede retirar el dinero \nRetiro exitoso!");
              break;
          case 2:
            Console.WriteLine("Ingrese cantidad de etherium a ingresar");
            cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Puede retirar el dinero \nRetiro exitoso!");
              break;
          case 3:
            Console.WriteLine("Ingrese cantidad de bitcoin a ingresar");
            cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Puede retirar el dinero \nRetiro exitoso!");
              break;
          case 4:
            Console.WriteLine("Ingrese cantidad de dolares a ingresar");
            cantidad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Puede retirar el dinero \nRetiro exitoso!");
              break;
        }
      }

    }
}