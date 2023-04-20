namespace qlts.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }


        public string Center { get; set; }

        public string Phone { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public string Note { get; set; }

        public string Position { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        
    }
}