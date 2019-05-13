using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fysapp_umbraco_api.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageLinks { get; set; }
        public string Description { get; set; }
        public string Repetition { get; set; }
        public string Breaks { get; set; }
        public string Focus { get; set; }
        public int ExerciseID { get; set; }
        public int UserGroupID { get; set; }
        public string ApiExerciseID { get; set; }
    }
}