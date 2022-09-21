namespace API.models
{
    public class Schedhule
    {
        public long ID {get; set;}
        public DateTime Date  {get; set;}
        public DateTime Start {get; set;}
        public DateTime Finish {get; set;}

        public string UserID {get; set;} = "";
    }
}