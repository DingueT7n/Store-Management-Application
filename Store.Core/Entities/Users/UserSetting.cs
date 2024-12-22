namespace Store.Core.Entities.Users
{
    public class UserSetting : BaseEntity<int>
    {
        public UserSetting(bool b)
        {
            UserPermession = b;
            ApplicationSettings = b;
        }
        public UserSetting()
        {

        }

        public int User_Id { get; set; }
        public bool UserPermession { get; set; }
        public bool ApplicationSettings { get; set; }
        public User User { get; set; }
    }
}
