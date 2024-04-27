namespace MeetingProject.Models
{
    public class Repository
    {
        private static List<UserRepostory> _userRepostories = new List<UserRepostory>();


        static Repository() 
        {
            _userRepostories.Add(new UserRepostory() {Id= 1, Name = "Kadir BABAOĞLU" , Email="kadirbabaoglu@outook.com" , Phone="05555555555" , Status = true});
        }

        public static List<UserRepostory> AllUser 
        {
            get { return _userRepostories; }
        }

        public static void CreateUser(UserRepostory User)
        {
            User.Id = AllUser.Count + 1;
            _userRepostories.Add(User); 
        }

        public static UserRepostory GetUser(int id) 
        {
            return _userRepostories.FirstOrDefault(i => i.Id ==id); 
        }
    }
}
