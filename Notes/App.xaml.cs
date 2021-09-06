using System;
using System.IO;
using Notes.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    public partial class App : Application
    {
        static NoteDatabase database;

        

        public static NoteDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }
        static QuestionDataBase question_io;

        public static QuestionDataBase Questions_io
        {
            get
            {
                if (question_io == null)
                {
                    question_io = new QuestionDataBase();
                }
                return question_io;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new NotesPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
