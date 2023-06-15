namespace HandyMan_Techlift.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? UserFirstName { get; set; }

        public string? UserLastName { get; set; }
        public string? UserFullName
        {
            get
            {
                return UserFirstName + " " + UserLastName;
            }
        }

        public string? UserEmailAddress { get; set; }

        public string? UserPassword { get; set; }

        public string? UserContactDetails { get; set; }


        
    }
}
