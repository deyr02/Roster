using Microsoft.AspNetCore.Identity;

namespace API.models{
    public class User: IdentityUser{
        
        public string FirstName {get; set;} = null!;
        public string LastName{get; set;} = null!;
        public string MobileNumber {get; set;}= null!;
        public string IRD {get; set; } = null!;
        public DateTime DOB {get; set;}= DateTime.Now;
        public string ProfileImage {get; set;} = "";
        public string Address {get; set;} = "";


    }
}
