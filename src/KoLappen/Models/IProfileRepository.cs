using KoLappen.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.Models
{
    public interface IProfileRepository
    {
        ProfileVM GetProfile(string userName);
        void EditProfile(EditProfileVM model);
        //List<ProfileVM> GetOneClass(int edu);
        List<ProfileVM> GetOneClass(int edu, int courseId);
    }
}
