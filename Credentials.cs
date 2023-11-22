using Class;

public class Credentials{
     public void CreateAccount()
    {
        Console.WriteLine("Nombre del usuario");
        string name=Console.ReadLine()!;
        Console.WriteLine("Apellidos");
        string surname=Console.ReadLine()!;

       int age;

        while (true)
        {
            Console.WriteLine("Introduce tu edad");

            if (int.TryParse(Console.ReadLine(), out age))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Por favor, introduce una edad válida.");
            }
        }
        
        Console.WriteLine("Dime una contraseña para tu cuenta");
        string passw=Console.ReadLine()!;
    do{
            if (DictionaryUsers.dictionaryAccounts.ContainsKey(passw) || passw == UserData.account_Seed.ToString())
            {
                Console.WriteLine("Dime una contraseña para tu cuenta que no exista ya");
                passw=Console.ReadLine()!;
            }else if(EsNumero(passw)){
                Console.WriteLine("La contraseña tiene que contener caracteres númericos y letras");
                passw=Console.ReadLine()!;
            }
            else
            {
                UserData user=new UserData(passw,name,surname,age);
                DictionaryUsers.dictionaryAccounts.Add(passw, user);
                Console.WriteLine("Usuario creado correctamente");
                break;
            }
        } while (true);
    }

    static bool EsNumero(string input){
        double resultado;
        return double.TryParse(input, out resultado);
    }
}