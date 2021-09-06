using System;
using System.Collections.Generic;

namespace Notes.Models
{
    public class Record
    {
        public int correct { get; set; }
        public List<Question> wrongQuestions { get; set; }
        public DateTime dateTime { get; set; }
    }
}
