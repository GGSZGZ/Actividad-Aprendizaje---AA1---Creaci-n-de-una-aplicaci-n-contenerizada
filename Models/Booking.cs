namespace Models;

public class Booking{


    public DateTime datebooked {get;set;}

    public bool? userLogged {get; set;}

    public decimal? desknumber {get;set;}

    public int? numberpeople {get;set;}

    public bool? booked {get;set;}

    public string? notes {get;set;}


    public Booking(){

    }

    public Booking(DateTime datebooked, bool userLogged = false, decimal desknumber=0,int numberpeople=0,bool booked=false,string notes=""){
         this.datebooked = datebooked == default ? DateTime.Now.Date : datebooked;
         this.userLogged = userLogged;
         this.desknumber=desknumber;
         this.numberpeople=numberpeople;
         this.booked=booked;
         this.notes=notes;
    }

    public override string ToString()
        {
            return $"Desk Number: {desknumber}, Number of People: {numberpeople}";
        }
}