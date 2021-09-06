using System;
using Notes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json.Linq;

namespace Notes.Data
{
    public class QuestionDataBase
    {
        public FirebaseClient firebase;
        public QuestionDataBase()
        {
            firebase = new FirebaseClient(
            "https://ac666-28b14.firebaseio.com/");
            //,
            //new FirebaseOptions
            //{
            //    AuthTokenAsyncFactory = () => Task.FromResult("nmLdanAzmODftc3W756PklqRhFy0BchNght005ay")
            //});
        }
        public async Task PushTesting(Question question)
        {
            await firebase
                .Child("questions")
                .PostAsync(question);
        }
        public async Task<List<Question>> GetAllQuestions()
        {
            // firstime using let data could be structured
            // not doing this, line 44 .OnceAsync<Question>() will get failed
            //await PushTesting(new Question
            //{
            //    Title = "Title",
            //    A = "A",
            //    B = "B",
            //    C = "C",
            //    D = "D",
            //    Answer = "Ans"
            //});
            var ls = (await firebase
                .Child("questions")
                .OnceAsync<Question>()).Select(p => new Question
                {
                    A = p.Object.A,
                    B = p.Object.B,
                    C = p.Object.C,
                    D = p.Object.D,
                    Title = p.Object.Title,
                    Answer = p.Object.Answer
                }).ToList();
            ls.RemoveAt(ls.Count - 1);
            return ls;

        }

        public int[] getRandomIntArray(int start, int end)
        {
            int[] randomArray = new int[50];
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                randomArray[i] = rnd.Next(start, end + 1);

                for (int j = 0; j < i; j++)
                {
                    while (randomArray[j] == randomArray[i])
                    {
                        j = 0;
                        randomArray[i] = rnd.Next(start, end + 1);
                    }
                }
            }
            return randomArray;
        }

        public async Task<List<Question>> GetRandomQuestions()
        {
            var allquestions = await GetAllQuestions();
            var questionsIDX = getRandomIntArray(0, 791);
            var examquestions = new List<Question>();

            foreach (var index in questionsIDX)
            {
                examquestions.Add(allquestions[index]);
            }

            return examquestions;
        }

        public async Task PostNewRecord(Record record)
        {
            await firebase
                .Child("records")
                .PostAsync(record);

        }

        public async Task<List<Record>> GetRecords()
        {
            var ls = (await firebase
                .Child("records")
                .OnceAsync<Record>()).Select(p => new Record
                {
                    correct = p.Object.correct,
                    wrongQuestions = p.Object.wrongQuestions,
                    dateTime = p.Object.dateTime,
                }).ToList();
            return ls;
        }
    }
}
