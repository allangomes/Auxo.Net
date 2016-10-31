namespace Auxo.Models
{
    public interface IUser
    {
         string Name { get; set; }
         string Email { get; set; }
         string Login { get; set; }
         Secure Password { get; set; }
         IUserSetting Settings { get; }
    }
}