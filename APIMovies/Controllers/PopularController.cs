using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace APIMovies.Controllers
{
    public class PopularController : Controller
    {
        // GET: Popular      
        public ActionResult Index()
        {

            Models.Movie movie = new Models.Movie();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.themoviedb.org/3/");
                var responseTask = client.GetAsync("movie/popular?api_key=8871ea5ac46d94640a6ce8e944b80faa&language=en-US&page=1");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    dynamic resultJSON = JObject.Parse(readTask.Result.ToString());
                    readTask.Wait();
                    movie.Movies = new List<object>();

                    foreach (var resultItem in resultJSON.results)
                    {
                        Models.Movie movieItem = new Models.Movie();
                        movieItem.id = resultItem.id;
                        movieItem.original_title = resultItem.original_title;
                        movieItem.overview = resultItem.overview;
                        movie.Movies.Add(movieItem);
                    }   
                }
            }
                return View(movie);
        }
    }
}