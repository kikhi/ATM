Console.WriteLine("Bienvenido al cajero de criptomonedas! \n");

Console.WriteLine("1.- Depositar");
Console.WriteLine("2.- Enviar");
Console.WriteLine("3.- Retirar");

int menu = Convert.ToInt32(Console.ReadLine());

switch(menu) 
{
  case 1:
    Depositar();
    break;
  case 2:
    Enviar();
    break;
  case 3:
    Retirar();
    break;
  default:
    Console.WriteLine("Opcion no valida");
    break;
}

static void Depositar(){
    int menu;
    int deposito;
    Dinero xrp = new Dinero();

    Console.Clear();
    Console.WriteLine("Que moneda deseas depositar");
    Console.WriteLine("1.- xrp");
    Console.WriteLine("2.- etherium");
    Console.WriteLine("3.- bitcoin");
    menu = Convert.ToInt32(Console.ReadLine());

    switch(menu)
    {
        case 1:
            Console.WriteLine("Ingresa el monto a depositar");
            deposito = Convert.ToInt32(Console.ReadLine());
            //xrp = deposito + xrp;
            break;
    }
}

static void Enviar(){
    Console.Write("Enviar");
}

static void Retirar(){
    Console.WriteLine("Retirar");
}

class Dinero
{
    int dolares;
    int xrp;
    int etherium;
    int bitcoin;


}