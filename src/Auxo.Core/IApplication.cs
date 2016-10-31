using Auxo.Models;

namespace Auxo
{
    public interface IApplication
    {
         IUser User { get; set; }
         IUserSetting UserSettings { get; set; }
    }
}