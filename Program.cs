using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

/*    Class for database conection    */
class ControllerDB
{
    private SqlConnection connectionDB = new SqlConnection("SERVER=CLIENTE\\SQLEXPRESS; DATABASE=criptos; integrated security=true");
    private SqlCommand comand = new SqlCommand();
    private string? query;
    private int? menu;
    public int? Menu {get { return menu; }set { menu = value; }}
    public string? xrp { get; set; }
    public string? etherium { get; set; }
    public string? bitcoin { get; set; }
    public string? dollars { get; set; }


    public void openConection()
    {
        this.connectionDB.Open();
    }

    public void closeConection()
    {
        this.connectionDB.Close();
    }

    public void CommandDB(string query)
    {
        this.query = query;
        this.comand = new SqlCommand(this.query, this.connectionDB);
        this.comand.ExecuteNonQuery();
        // comand.Parameters.AddWithValue("@xrp", xrpTxt);
    }
}

class Clients
{
    private int? id_client;
    public int? id_Client
    {
        get { return id_client; }
        set { id_client = value; }
    }
    private int? id_reciver;
    public int? id_Reciver
    {
        get { return id_reciver; }
        set { id_reciver = value; }
    }
    

}

namespace Cajero
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int idClient;
            string? result = null;

            Console.Write("Insert your client ID: ");
            idClient = Convert.ToInt32(Console.ReadLine());

            /*    ==== Menu ====    */
            Console.WriteLine("Criptos ATM\n");
            Console.WriteLine("1.- Deposit");
            Console.WriteLine("2.- Withdraw");
            Console.WriteLine("3.- Transfer");
            Console.WriteLine("4.- Salir");

            int menu = Convert.ToInt32(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    result = Deposit(idClient);
                    Console.WriteLine(result);
                    break;
                case 2:
                    result = Whithdraw(idClient);
                    Console.WriteLine(result);
                    break;
                case 3:
                    result = Transfer(idClient);
                    Console.WriteLine(result);
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

        public static string Deposit(int idClient)
        {
            ControllerDB controller = new ControllerDB();   

            /*    Deposit Menu    */
            Console.Clear();
            Console.WriteLine("Select coin to deposit?");
            Console.WriteLine("1.- xrp");
            Console.WriteLine("2.- etherium");
            Console.WriteLine("3.- bitcoin");
            Console.WriteLine("4.- Dollars");
            controller.Menu = Convert.ToInt32(Console.ReadLine());
            switch (controller.Menu)
            {
                case 1:    // XRP
                    controller.openConection();
                    Console.Write("Insert xrp amount: ");
                    controller.xrp = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET xrp = xrp + '" + controller.xrp + "' WHERE id_billetera = '" + controller.xrp +"';");
                    controller.closeConection();
                    break;
                case 2:    // ETHERIUM
                    controller.openConection();
                    Console.Write("Insert etherium amount: ");
                    controller.etherium = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET etherium = etherium + '" + controller.etherium + "' WHERE id_billetera = '"+ idClient +"';");
                    controller.closeConection();
                    break;
                case 3:    // BITCOIN
                    controller.openConection();
                    Console.Write("Insert bitcoin amount: ");
                    controller.bitcoin = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET bitcoin = bitcoin + '" + controller.bitcoin + "' WHERE id_billetera = '"+ idClient +"';");
                    controller.closeConection();
                    break;
                case 4:    // DOLLARS
                    controller.openConection();
                    Console.Write("Insert dollars amount: ");
                    controller.dollars = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET dollars = dollars + '" + controller.dollars + "' WHERE id_billetera = '"+ idClient +"';");
                    controller.closeConection();
                    break;
            }
            return "Deposit completed";
        }

        static string Transfer(int idClient)
        {
            ControllerDB controller = new ControllerDB();  
            Clients Client = new Clients();

            /*    Transfer Menu    */
            Console.Clear();
            Console.WriteLine("Que moneda desea retirar?");
            Console.WriteLine("1.- xrp");
            Console.WriteLine("2.- etherium");
            Console.WriteLine("3.- bitcoin");
            Console.WriteLine("4.- Dolares");
            controller.Menu = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insert ID from reciver: ");
            Client.id_Reciver = Convert.ToInt32(Console.ReadLine());

            switch (controller.Menu)
            {
               case 1:    // XRP
                    controller.openConection();
                    Console.Write("Insert xrp amount: ");
                    controller.xrp = Console.ReadLine();
                    controller.CommandDB( "UPDATE billetera SET xrp = xrp - '" + controller.xrp + "' WHERE id_billetera = '"+ idClient +"';\n" +
                    "UPDATE billetera SET xrp = xrp + '" + controller.xrp + "' WHERE id_billetera = '" + Client.id_Reciver + "';");
                    controller.closeConection();
                    break;
                case 2:    // ETHERIUM
                    controller.openConection();
                    Console.Write("Insert etherium amount: ");
                    controller.etherium = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET xrp = xrp - '" + controller.etherium + "' WHERE id_billetera = '"+ idClient +"';\n" +
                    "UPDATE billetera SET xrp = xrp + '" + controller.etherium + "' WHERE id_billetera = '" + Client.id_Reciver + "';");
                    controller.closeConection();
                    break;
                case 3:    // BITCOIN
                    controller.openConection();
                    Console.Write("Insert bitcoin amount: ");
                    controller.bitcoin = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET xrp = xrp - '" + controller.bitcoin + "' WHERE id_billetera = '"+ idClient +"';\n" +
                    "UPDATE billetera SET xrp = xrp + '" + controller.bitcoin + "' WHERE id_billetera = '" + Client.id_Reciver + "';");
                    controller.closeConection();
                    break;
                case 4:    // DOLLARS
                    controller.openConection();
                    Console.Write("Insert dollars amount: ");
                    controller.dollars = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET xrp = xrp - '" + controller.dollars + "' WHERE id_billetera = '"+ idClient +"';\n" +
                    "UPDATE billetera SET xrp = xrp + '" + controller.dollars + "' WHERE id_billetera = '" + Client.id_Reciver + "';");
                    controller.closeConection();
                    break;
            }
            return "Transfer completed";
        }

        static string Whithdraw(int idClient)
        {
            ControllerDB controller = new ControllerDB();
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
                    controller.openConection();
                    Console.Write("Insert xrp amount: ");
                    controller.xrp = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET xrp = xrp - '" + controller.xrp + "' WHERE id_billetera = '" + controller.xrp +"';");
                    controller.closeConection();
                    break;
                case 2:    // ETHERIUM
                    controller.openConection();
                    Console.Write("Insert etherium amount: ");
                    controller.etherium = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET etherium = etherium - '" + controller.etherium + "' WHERE id_billetera = '"+ idClient +"';");
                    controller.closeConection();
                    break;
                case 3:    // BITCOIN
                    controller.openConection();
                    Console.Write("Insert bitcoin amount: ");
                    controller.bitcoin = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET bitcoin = bitcoin - '" + controller.bitcoin + "' WHERE id_billetera = '"+ idClient +"';");
                    controller.closeConection();
                    break;
                case 4:    // DOLLARS
                    controller.openConection();
                    Console.Write("Insert dollars amount: ");
                    controller.dollars = Console.ReadLine();
                    controller.CommandDB("UPDATE billetera SET dollars = dollars - '" + controller.dollars + "' WHERE id_billetera = '"+ idClient +"';");
                    controller.closeConection();
                    break;
            }
            return "Whithdraw completed";
        }

    }
}