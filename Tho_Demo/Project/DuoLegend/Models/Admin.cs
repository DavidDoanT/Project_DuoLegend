

namespace DuoLegend.Models
{
    public class Admin
    {
        private int _adminId;
        private string _adminPassword;
        private string _adminName;
        private string _email;

        public int AdminId { get => _adminId; set => _adminId = value; }
        public string AdminPassword { get => _adminPassword; set => _adminPassword = value; }
        public string AdminName { get => _adminName; set => _adminName = value; }
        public string Email { get => _email; set => _email = value; }
    }
}