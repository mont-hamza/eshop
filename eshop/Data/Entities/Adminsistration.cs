namespace eshop.Data.Entities
{
    public class Adminsistration
    {
        public Adminsistration() 
        {
            DateOfBirth = DateTime.MinValue; // Default value for DateTime
            DateOfJoining = DateTime.MinValue; // Default value for DateTime
            Status = "Active"; // Default status
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Status { get; set; }
        public string? AdminNumber { get; set; }
        public decimal? Salary { get; set; } 
        public string? AdminType { get; set; } // e.g., "SuperAdmin", "Admin", etc.
        public string? AdminRole { get; set; } // e.g., "Manager", "Support", etc.

    }
}