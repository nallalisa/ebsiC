using ebsiC.Assets.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebsiC.Assets.MVVM.Model
{
    class Admin : ObservableObject
    {
        [Key]
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged();
            }
        }

        private string username;

        public required string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;
        public required string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
