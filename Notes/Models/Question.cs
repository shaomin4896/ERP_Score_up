using System;
using Newtonsoft.Json;
namespace Notes.Models
{
    public class Question
    {
        //[JsonProperty("A")]
        public string A { get; set; }
        //[JsonProperty("Answer")]
        public string Answer { get; set; }
        //[JsonProperty("B")]
        public string B { get; set; }
        //[JsonProperty("C")]
        public string C { get; set; }
        //[JsonProperty("D")]
        public string D { get; set; }
        //[JsonProperty("Title")]
        public string Title { get; set; }
    }
}
