using System;
using System.Collections.Generic;
using Notes.Models;

using Xamarin.Forms;

namespace Notes
{
    public partial class ExamPage : ContentPage
    {
        List<Question> examQuestions;
        
        int count = 0;
        string[] userAnswer = new string[100];
        int correct = 0;

        public ExamPage(List<Question> getquestions)
        {
            InitializeComponent();
            examQuestions = getquestions;
            BindingContext = examQuestions[count];
        }

        void NextButton_Clicked(System.Object sender, System.EventArgs e)
        {
            
            count++;
            if (count >= 50)
            {
                count--;
                return;
            }
            BindingContext = examQuestions[count];
            initRadioButtonSelect();

            labelno.Text = $"{count + 1}.";
        }

        void PreButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (labelno.Text == "1.")
            {
                return;
            }
            count--;
            BindingContext = examQuestions[count];
            initRadioButtonSelect();
            labelno.Text = $"{count + 1}.";
        }
        async void DoenButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool answer = await DisplayAlert("Done?", "Confirm submission.", "Yes", "No");
            if (answer)
            {
                List<Question> wrong = new List<Question>();
                for (int i = 0; i < 50; i++)
                {
                    if (userAnswer[i] == examQuestions[i].Answer)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong.Add(examQuestions[i]);
                    }
                }
                var newRec = new Record
                {
                    correct = correct,
                    wrongQuestions = wrong,
                    dateTime = DateTime.Now
                };
                await App.Questions_io.PostNewRecord(newRec);
                await Navigation.PopAsync();
            }
        }
        void initRadioButtonSelect()
        {
            var answer = userAnswer[count];
            switch (answer)
            {
                case "A":
                    RadioA.IsChecked = true;
                    break;
                case "B":
                    RadioB.IsChecked = true;
                    break;
                case "C":
                    RadioC.IsChecked = true;
                    break;
                case "D":
                    RadioD.IsChecked = true;
                    break;
                default:
                    RadioA.IsChecked = false;
                    RadioB.IsChecked = false;
                    RadioC.IsChecked = false;
                    RadioD.IsChecked = false;
                    break;
            }
        }

        void RadioButton_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            userAnswer[count] = ((RadioButton)sender).Value.ToString();
        }

        
    }
}
