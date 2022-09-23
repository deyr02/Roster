using System.ComponentModel.DataAnnotations;

namespace API.models
{
    public class Schedhule
    {
        [Key]
        public long ID {get; set;}
        public DateTime Date  {get; set;}
        public DateTime Start {get; set;}
        public DateTime Finish {get; set;}

        public string UserID {get; set;} = "";
    }
}