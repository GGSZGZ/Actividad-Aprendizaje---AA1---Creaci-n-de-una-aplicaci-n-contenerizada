namespace Class;
using Models;

public class User{

    public string? name{get;set;}

    public string? surname{get;set;}

    public int? age{get;set;}
    
    private List<Booking> bookings=new List<Booking>();
    
    private List<Coffee> userCoffees=new List<Coffee>();

    public DateTime date {get;set;}

    public string? password{get;set;}
    public string? email{get;set;}

    public static string account_Seed = "1000";

    //CONSTRUCTOR
    public User(string password,string name = "GUEST", string surname = "GUEST", int age = 0,string email="guest@gmail.com"){
    date = DateTime.Now.Date;
    this.name = name;
    this.surname = surname;
    this.age = age;
    this.password = password;
    this.email=email;
    

    if (isLogged()==false)
    {   
        this.password = account_Seed.ToString();
        account_Seed += 1;
    }
}

public bool isLogged(){
    if (name == "GUEST" && surname == "GUEST")
    {   
        return false;
    }else{
        return true;
    }
}

 public override string ToString()
    {
        return $"Name: {name ?? "N/A"}, Surname: {surname ?? "N/A"}, Age: {age?.ToString() ?? "N/A"}, Password: {password ?? "N/A"}";
    }
}