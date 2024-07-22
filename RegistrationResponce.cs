using embackend.Models;

public class RegistrationResponce 
{
    public User? User {get;set;} 
    public string Message {get;set;}
    public RegistrationResponce(User newUser,string respMesg){
        User = newUser;
        Message = respMesg;
    }
}