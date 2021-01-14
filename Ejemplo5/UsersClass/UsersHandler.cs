using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplo5.UsersClass
{
    public class UsersHandler
    {
        public ObservableCollection<User> userList { get; set; }

        public UsersHandler()
        {
            this.userList = new ObservableCollection<User>();
        }

        public void AddUser(User user)
        {
            userList.Add(user);
        }
        public void ModifyUser(User user, int pos) 
        {
            userList[pos] = user;
        }
        public void RemoveUser(int pos) 
        {
            userList.RemoveAt(pos);
        }
        

    }
}
