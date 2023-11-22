
namespace Services;
using System.Text.RegularExpressions;
using Class;

public class UserService{
     public string CreateUser()
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
        
        Console.WriteLine("Email");
        string email=Console.ReadLine()!;
        do{
        if(DictionaryUsers.dictionaryAccounts.ContainsKey(email) || ValidarEmail(email)==false){
            Console.WriteLine("Dime un correo válido");
            email=Console.ReadLine()!;
        }else{
        
            break;
        }
        }while(true);

        Console.WriteLine("Dime una contraseña para tu cuenta");
        string passw=Console.ReadLine()!;
    do{
            if (passw == User.account_Seed.ToString())
            {
                Console.WriteLine("Dime una contraseña para tu cuenta que no exista ya");
                passw=Console.ReadLine()!;
            }else if(EsNumero(passw)){
                Console.WriteLine("La contraseña tiene que contener caracteres númericos y letras");
                passw=Console.ReadLine()!;
            }
            else
            {
                User user=new User(passw,name,surname,age,email);
                DictionaryUsers.dictionaryAccounts.Add(email, user);
                Console.WriteLine("Usuario creado correctamente");
                return email;
                
            }
        } while (true);
    }

    public void CreateGuest(){
                User user=new User(User.account_Seed.ToString());
                DictionaryUsers.dictionaryAccounts.Add(user.email!, user);

    }

    public static bool EsNumero(string input){
        double resultado;
        return double.TryParse(input, out resultado);
    }

public bool ValidarEmail(string email){
    return email != null && Regex.IsMatch(email, "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$");
}
    public bool Login(){

        Console.WriteLine("Dime tu correo");
        string email=Console.ReadLine()!;

        Console.WriteLine("Dime la contraseña");
        string pass=Console.ReadLine()!;

        if (DictionaryUsers.dictionaryAccounts.ContainsKey(email) && DictionaryUsers.dictionaryAccounts[email].password == pass)
        {
           Console.WriteLine("Inicio de sesión exitoso");
           return true;
        }
        else
        {
            Console.WriteLine("Contraseña incorrecta");
            return false;
        }
    }
}