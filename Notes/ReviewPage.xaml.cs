using System;
using System.Collections.Generic;
using Notes.Models;
using Xamarin.Forms;

namespace Notes
{
    public partial class ReviewPage : ContentPage
    {
        List<Question> wrongQuestions = new List<Question>();

        int count = 0;
        public ReviewPage(Record record)
        {
            InitializeComponent();
            wrongQuestions = record.wrongQuestions;
            BindingContext = wrongQuestions[count];
            initRadioButtonSelect();
        }
        void NextButton_Clicked(System.Object sender, System.EventArgs e)
        {

            count++;
            if (count >= wrongQuestions.Count)
            {
                count--;
                return;
            }
            BindingContext = wrongQuestions[count];
            initRadioButtonSelect();

        }

        void PreButton_Clicked(System.Object sender, System.EventArgs e)
        {
            count--;
            BindingContext = wrongQuestions[count];
            initRadioButtonSelect();
        }
        
        void initRadioButtonSelect()
        {
            RadioA.TextColor = Color.Black;
            RadioB.TextColor = Color.Black;
            RadioC.TextColor = Color.Black;
            RadioD.TextColor = Color.Black;
            var answer = wrongQuestions[count].Answer;
            switch (answer)
            {
                case "A":
                    RadioA.IsChecked = true;
                    RadioA.TextColor = Color.Red;
                    break;
                case "B":
                    RadioB.IsChecked = true;
                    RadioB.TextColor = Color.Red;
                    break;
                case "C":
                    RadioC.IsChecked = true;
                    RadioC.TextColor = Color.Red;
                    break;
                case "D":
                    RadioD.IsChecked = true;
                    RadioD.TextColor = Color.Red;
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
            
        }
    }
}
