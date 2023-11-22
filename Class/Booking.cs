namespace Class;

public class Booking{


    public DateTime datebooked {get;set;}

    public bool? userLogged {get; set;}

    public decimal? desknumber {get;set;}

    public int? numberpeople {get;set;}

    public bool? booked {get;set;}

    public string? notes {get;set;}


    public Booking(){

    }

    public Booking(DateTime datebooked, bool userLogged = false, decimal desknumber,int numberpeople,bool booked=false,string notes=""){
         this.datebooked = datebooked == default ? DateTime.Now.Date : datebooked;
         this.userLogged = userLogged;
         this.desknumber=desknumber;
         this.numberpeople=numberpeople;
         this.booked=booked;
         this.notes=notes;
    }
}