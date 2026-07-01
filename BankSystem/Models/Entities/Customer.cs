using BankSystem.Models.Abstractions;
namespace BankSystem.Models.Entities
{
    public class Customer:User
    {
        public string Pin {  get; private set; }
        public List<Account>Accounts {  get; set; } = new List<Account>();

        public Customer(int id, string name, string phone,string pin) : base(id, name, phone)
        {
            Pin = pin;
        }

        public bool ValidatePin(string pin)
        {
            return Pin == pin;
        }
            

    }
}
