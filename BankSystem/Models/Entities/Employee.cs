using BankSystem.Models.Abstractions;
namespace BankSystem.Models.Entities
{
    public class Employee : User
    {
        public string Position { get; set; }
        public string Password { get; private set; }
        public Employee (int id,string name,string phone,string position, string password) : base(id, name, phone)
        {
            Position = position;
            Password = password;
        }

        public bool ValidatePassword(string password)
        {
            return Password == password;
        }
        
    }
}
