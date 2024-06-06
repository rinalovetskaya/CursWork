using Diplom.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static DB_Kanev_diplomEntities context = new DB_Kanev_diplomEntities();

        public static User enteredUser;

        public static Participant selectedParticipant;
    }
}
