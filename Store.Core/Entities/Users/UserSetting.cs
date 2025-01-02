namespace Store.Core.Entities.Users
{
    public class UserSetting : BaseEntity<int>
    {
        public UserSetting(bool b)
        {
            UserPermession = b;
            ApplicationSettings = b;
            Statistics = b;
            Pos = b;
            ProductDiscounts = b;
            BackUp = b;
            Restore = b;
        }
        public UserSetting()
        {

        }

        public int User_Id { get; set; }
        public bool UserPermession { get; set; }
        public bool ApplicationSettings { get; set; }
        public bool Pos { get; set; }
        public bool Statistics { get; set; }
        public bool ProductDiscounts { get; set; }
        public bool BackUp { get; set; }
        public bool Restore { get; set; }
        public User User { get; set; }
    }
}
