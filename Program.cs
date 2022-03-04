using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;


namespace Cajero
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int idClient;

            Console.Write("Insert ID from receptor: ");
            idClient = Convert.ToInt32(Console.ReadLine());

            /*    ==== Menu ====    */
            Console.WriteLine("Criptos ATM\n");
            Console.WriteLine("1.- Depositar");
            Console.WriteLine("2.- Withdraw");
            Console.WriteLine("3.- Transfer");
            Console.WriteLine("4.- Salir");

            int menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Depositar(idClient);
                    break;
                case 2:
                    Whithdraw(idClient);
                    break;
                case 3:
                    Transfer(idClient);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
            Console.ReadKey();
        }

        static void Depositar(int idClient)
        {
            SqlConnection connectionDB = new SqlConnection("SERVER=CLIENTE\\SQLEXPRESS; DATABASE=criptos; integrated security=true");
            SqlCommand comand = new SqlCommand();
            string query;
            int menu;

            Console.Clear();
            Console.WriteLine("Que moneda desea depositar?");
            Console.WriteLine("1.- xrp");
            Console.WriteLine("2.- etherium");
            Console.WriteLine("3.- bitcoin");
            Console.WriteLine("4.- Dollars");
            menu = Convert.ToInt32(Console.ReadLine());
            switch (menu)
            {
                case 1:    // XRP
                    connectionDB.Open();
                    string? xrpTxt = null;

                    Console.Write("Insert xrp mount: ");
                    xrpTxt = Console.ReadLine();

                    query = "UPDATE billetera SET xrp = xrp + '" + xrpTxt + "' WHERE id_billetera = '" +idClient +"';";
                    comand = new SqlCommand(query, connectionDB);
                    // comand.Parameters.AddWithValue("@xrp", xrpTxt);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
                case 2:    // ETHERIUM
                    connectionDB.Open();
                    string? etherium = null;

                    Console.Write("Insert etherium mount: ");
                    etherium = Console.ReadLine();

                    query = "UPDATE billetera SET etherium = etherium + '" + etherium + "' WHERE id_billetera = '"+ idClient +"';";
                    comand = new SqlCommand(query, connectionDB);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
                case 3:    // BITCOIN
                    connectionDB.Open();
                    string? bitcoin = null;

                    Console.Write("Insert bitcoin mount: ");
                    bitcoin = Console.ReadLine();

                    query = "UPDATE billetera SET bitcoin = bitcoin + '" + bitcoin + "' WHERE id_billetera = '"+ idClient +"';";
                    comand = new SqlCommand(query, connectionDB);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
                case 4:    // DOLLARS
                    connectionDB.Open();
                    string? dollars = null;

                    Console.Write("Insert dollars mount: ");
                    dollars = Console.ReadLine();

                    query = "UPDATE billetera SET dollars = dollars + '" + dollars + "' WHERE id_billetera = '"+ idClient +"';";
                    comand = new SqlCommand(query, connectionDB);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
            }
        }

        static void Transfer(int idClient)
        {
            SqlConnection connectionDB = new SqlConnection("SERVER=CLIENTE\\SQLEXPRESS; DATABASE=criptos; integrated security=true");
            SqlCommand comand = new SqlCommand();
            SqlCommand comand2 = new SqlCommand();
            string? query;
            string? idReceptor;
            int menu;

            Console.Clear();
            Console.WriteLine("Que moneda desea retirar?");
            Console.WriteLine("1.- xrp");
            Console.WriteLine("2.- etherium");
            Console.WriteLine("3.- bitcoin");
            Console.WriteLine("4.- Dolares");
            menu = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insert ID from receptor: ");
            idReceptor = Console.ReadLine();

            switch (menu)
            {
                case 1:    // XRP
                    connectionDB.Open();
                    string? xrpTxt = null;

                    Console.Write("Insert xrp mount: ");
                    xrpTxt = Console.ReadLine();

                    query = "UPDATE billetera SET xrp = xrp - '" + xrpTxt + "' WHERE id_billetera = '"+ idClient +"';\n" +
                    "UPDATE billetera SET xrp = xrp + '" + xrpTxt + "' WHERE id_billetera = '" + idReceptor + "';";
                    comand = new SqlCommand(query, connectionDB);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
                case 2:    // ETHERIUM
                    connectionDB.Open();
                    string? etherium = null;

                    Console.Write("Insert etherium mount: ");
                    etherium = Console.ReadLine();

                    query = "UPDATE billetera SET etherium = etherium - '" + etherium + "' WHERE id_billetera = '"+ idClient +"';\n" +
                    "UPDATE billetera SET xrp = xrp + '" + etherium + "' WHERE id_billetera = '" + idReceptor + "';";
                    comand = new SqlCommand(query, connectionDB);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
                case 3:    // BITCOIN
                    connectionDB.Open();
                    string? bitcoin = null;

                    Console.Write("Insert bitcoin mount: ");
                    bitcoin = Console.ReadLine();

                    query = "UPDATE billetera SET bitcoin = bitcoin - '" + bitcoin + "' WHERE id_billetera = '"+ idClient +"';\n" +
                    "UPDATE billetera SET xrp = xrp + '" + bitcoin + "' WHERE id_billetera = '" + idReceptor + "';";
                    comand = new SqlCommand(query, connectionDB);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
                case 4:    // DOLLARS
                    connectionDB.Open();
                    string? dollars = null;

                    Console.Write("Insert dollars mount: ");
                    dollars = Console.ReadLine();

                    query = "UPDATE billetera SET dollars = dollars - '" + dollars + "' WHERE id_billetera = '"+ idClient +"';\n" +
                    "UPDATE billetera SET xrp = xrp + '" + dollars + "' WHERE id_billetera = '" + idReceptor + "';";
                    comand = new SqlCommand(query, connectionDB);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
            }
        }

        static void Whithdraw(int idClient)
        {
            SqlConnection connectionDB = new SqlConnection("SERVER=CLIENTE\\SQLEXPRESS; DATABASE=criptos; integrated security=true");
            SqlCommand comand = new SqlCommand();
            string query;
            int menu;

            Console.Clear();
            Console.WriteLine("Que moneda desea transferir?");
            Console.WriteLine("1.- xrp");
            Console.WriteLine("2.- etherium");
            Console.WriteLine("3.- bitcoin");
            Console.WriteLine("4.- Dolares");
            menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case 1:    // XRP
                    connectionDB.Open();
                    string? xrpTxt = null;

                    Console.Write("Insert xrp mount: ");
                    xrpTxt = Console.ReadLine();

                    query = "UPDATE billetera SET xrp = xrp - '" + xrpTxt + "' WHERE id_billetera = '"+ idClient +"';";
                    comand = new SqlCommand(query, connectionDB);
                    // comand.Parameters.AddWithValue("@xrp", xrpTxt);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
                case 2:    // ETHERIUM
                    connectionDB.Open();
                    string? etherium = null;

                    Console.Write("Insert etherium mount: ");
                    etherium = Console.ReadLine();

                    query = "UPDATE billetera SET etherium = etherium - '" + etherium + "' WHERE id_billetera = '"+ idClient +"';";
                    comand = new SqlCommand(query, connectionDB);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
                case 3:    // BITCOIN
                    connectionDB.Open();
                    string? bitcoin = null;

                    Console.Write("Insert bitcoin mount: ");
                    bitcoin = Console.ReadLine();

                    query = "UPDATE billetera SET bitcoin = bitcoin - '" + bitcoin + "' WHERE id_billetera = '"+ idClient +"';";
                    comand = new SqlCommand(query, connectionDB);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
                case 4:    // DOLLARS
                    connectionDB.Open();
                    string? dollars = null;

                    Console.Write("Insert dollars mount: ");
                    dollars = Console.ReadLine();

                    query = "UPDATE billetera SET dollars = dollars - '" + dollars + "' WHERE id_billetera = '"+ idClient +"';";
                    comand = new SqlCommand(query, connectionDB);
                    comand.ExecuteNonQuery();
                    connectionDB.Close();
                    break;
            }
        }

    }
}