namespace Class;

public class UserData{

    public string? NAME{get;set;}

    public string? SURNAME{get;set;}

    public int? AGE{get;set;}
    
    private List<Booking> bookings=new List<Booking>();

    public DateTime DATE {get;set;}

    public string? PASSWORD{get;set;}

    public static int account_Seed = 1000;

    //CONSTRUCTOR
    public UserData(string name = "GUEST", string surname = "GUEST", int age = 0, DateTime date, string pass){
    DATE = date == default ? DateTime.Now.Date : date;
    NAME = name;
    SURNAME = surname;
    AGE = age;
    PASSWORD = pass;
    if (name == "GUEST" && surname == "GUEST")
    {   
        PASSWORD = account_Seed.ToString();
        account_Seed += 1;
    }
}


}