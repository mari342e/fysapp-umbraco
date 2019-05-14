using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fysapp_umbraco.Models
{
    public class Exercise
    {
        public Exercise()
        {
        }

        public Exercise(int id, string name, string title, string imageLinks, string description, string repetition, string breaks, string focus, int exerciseID, int userGroupID, string apiExerciseID)
        {
            Id = id;
            Name = name;
            Title = title;
            ImageLinks = imageLinks;
            Description = description;
            Repetition = repetition;
            Breaks = breaks;
            Focus = focus;
            ExerciseID = exerciseID;
            UserGroupID = userGroupID;
            ApiExerciseID = apiExerciseID;
        }

        public int Id { get; set; }
        public string Name { get; set; }
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