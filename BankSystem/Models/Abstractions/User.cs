namespace BankSystem.Models.Abstractions
{
    public abstract class User
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Phone { get; set; }
        public User(int id,string name,string phone) 
        {
            Id = id;
            Name = name;
            Phone = phone;
        
        }
    }
}
