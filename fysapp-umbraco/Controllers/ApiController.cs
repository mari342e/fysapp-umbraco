using fysapp_umbraco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web.WebApi;
using Newtonsoft.Json;
using Umbraco.Web;

namespace fysapp_umbraco.Controllers
{
    public class ApiController : UmbracoApiController
    {
        public string apiUrl = "https://fysapp-umbraco.azurewebsites.net";

        // GET: Exercise by exercise id
        [HttpGet]
        public Exercise GetExercise(int id)
        {
            IContentService cs = Services.ContentService;

            var exercise = cs.GetById(id);

            Exercise e = new Exercise();
            e.Id = exercise.Id;
            e.Name = exercise.Name;
            e.Title = exercise.GetValue<string>("Title");
            if (exercise.GetValue<string>("ImageLinks") != null)
            {
                var imageString = exercise.GetValue<string>("ImageLinks");
                var imageGuidUdi = GuidUdi.Parse(imageString);
                var imageNodeId = ApplicationContext.Current.Services.EntityService.GetIdForKey(imageGuidUdi.Guid, (UmbracoObjectTypes)Enum.Parse(typeof(UmbracoObjectTypes), imageGuidUdi.EntityType, true));
                var imageNode = Umbraco.TypedMedia(imageNodeId.Result);
                e.ImageLinks = apiUrl + imageNode.Url;
            }
            else
            {
                e.ImageLinks = null;
            }

            e.Description = exercise.GetValue<string>("Description");
            e.Repetition = exercise.GetValue<string>("Repetition");

            if (exercise.GetValue<string>("Breaks") != null)
            {
                e.Breaks = exercise.GetValue<string>("Breaks");
            }
            else
            {
                e.Breaks = null;
            }

            if (exercise.GetValue<string>("Focus") != null)
            {
                e.Focus = exercise.GetValue<string>("Focus");
            }
            else
            {
                e.Breaks = null;
            }

            e.ExerciseID = exercise.GetValue<int>("ExerciseID");
            e.UserGroupID = exercise.GetValue<int>("UserGroupID");
            e.ApiExerciseID = exercise.GetValue<string>("ApiExerciseID");

            return e;
        }

        private readonly IEnumerable<IContent> exerciseList;

        public ApiController()
        {
            var contentType = Services.ContentTypeService.GetContentType("ovelse");
            exerciseList = Services.ContentService.GetContentOfContentType(contentType.Id).Where(c => c.Published);
        }

        [HttpGet]
        public IEnumerable<Exercise> GetAllExercises()
        {
            var exercises = (from c in exerciseList
                             select new Exercise()
                             {
                                 Id = c.Id
                             }).ToList();

            var newList = new List<Exercise>();

            foreach (var item in exercises){
                newList.Add(GetExercise(item.Id));
            }

            return newList;
        }

        // GET: Accordion by accordion id
        [HttpGet]
        public Accordion GetAccordion(int id)
        {
            IContentService cs = Services.ContentService;

            var accordion = cs.GetById(id);

            Accordion a = new Accordion();
            a.Id = accordion.Id;
            a.Title = accordion.GetValue<string>("Title");
            a.Text = accordion.GetValue<string>("Text");
            a.UserGroupID = accordion.GetValue<int>("UserGroupID");

            return a;
        }
    }
}
