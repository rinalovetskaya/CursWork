using CursWork.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CursWork
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static CursWorkEntities context = new CursWorkEntities();

        public static User enteredUser;

        public static User selectedAuthor;

        public static Tag selectedTag;

        public static Reference selectedRef;

        public static Pack selectedPack;

        public static PackRef selectedPackRef;


    }
}
