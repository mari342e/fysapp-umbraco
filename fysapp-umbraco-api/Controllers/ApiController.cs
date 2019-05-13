using fysapp_umbraco_api.Models;
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

namespace fysapp_umbraco_api.Controllers
{
    public class ApiController : UmbracoApiController
    {
        public string apiURL = "https://fysapp-umbraco.azurewebsites.net";

        // GET: Exercise by exercise id
        [HttpGet]
        public Exercise GetExercise(int id)
        {
            IContentService cs = Services.ContentService;

            var exercise = cs.GetById(id);

            Exercise e = new Exercise();
            e.Id = exercise.Id;
            e.Title = exercise.GetValue<string>("Title");
            if (exercise.GetValue<string>("ImageLinks") != "")
            {
                var imageString = exercise.GetValue<string>("ImageLinks");
                var imageGuidUdi = GuidUdi.Parse(imageString);
                var imageNodeId = ApplicationContext.Current.Services.EntityService.GetIdForKey(imageGuidUdi.Guid, (UmbracoObjectTypes)Enum.Parse(typeof(UmbracoObjectTypes), imageGuidUdi.EntityType, true));
                var imageNode = Umbraco.TypedMedia(imageNodeId.Result);
                e.ImageLinks = imageNode.Url;
            }
            else
            {
                e.ImageLinks = null;
            }

            e.Description = exercise.GetValue<string>("Description");
            e.Repetition = exercise.GetValue<string>("Repetition");

            if (exercise.GetValue<string>("Breaks") != "")
            {
                e.Breaks = exercise.GetValue<string>("Breaks");
            }
            else
            {
                e.Breaks = null;
            }

            if (exercise.GetValue<string>("Focus") != "")
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
    }
}
