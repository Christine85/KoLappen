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
        Task<int> EditProfile(EditProfileVM model);
        EditProfileVM GetProfileToEdit(string userName);

        List<ProfileVM> GetOneClass(int semesterId, int courseId);
    }
}
