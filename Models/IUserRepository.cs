using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SIRHU.Models
{
    public interface IUserRepository
    {
        bool NoRepeatNickname(UserModel userModel);
        bool RepeatNickname(UserModel userModel);
        bool AuthentificateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(UserModel userModel);
        void Read(UserModel userModel);
        ObservableCollection<UserModel> Get();
        ObservableCollection<UserModel> GetByAll(string cadenaBusqueda);

        UserModel GetById(string id);
        UserModel GetByUsername(string nickname);

        IEnumerable<UserModel> GetByAll();
        // ...

    }
}
