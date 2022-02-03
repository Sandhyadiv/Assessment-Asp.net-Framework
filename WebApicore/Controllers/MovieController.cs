using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApicore.Models;

namespace WebApicore.Controllers
{
    [Auzthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly Moviedbcontext moviedbcontext;
        public MovieController(Moviedbcontext movieDbContext)
        {
            moviedbcontext = movieDbContext;
        }



        [HttpGet]
        public IEnumerable<movie> GetMovies()
        {
            return moviedbcontext.movies.ToList();
        }
        [HttpGet("GetMovieById")]
        public movie GetMovieById(int Id)
        {
            return moviedbcontext.movies.Find(Id);
        }
        [HttpPost("InsertMovie")]
        public IActionResult InsertMovie([FromBody] movie movie)
        {
            if (movie.Id.ToString() != "")
            {

                moviedbcontext.movies.Add(movie);
                moviedbcontext.SaveChanges();
                return Ok("Movie details saved successfully");
            }
            else
                return BadRequest();
        }
        [HttpPut("UpdateMovie")]
        public IActionResult UpdateTutorial([FromBody] movie movie)
        {
            if (movie.ID.ToString() != "")
            {

                moviedbcontext.Entry(movie).State = EntityState.Modified;
                moviedbcontext.SaveChanges();
                return Ok("Updated successfully");
            }
            else
                return BadRequest();
        }
        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteTutorial(int ID)
        {
            //select * from tutorial where tutorialId=3
            var result = moviedbcontext.movies.Find(ID);
            moviedbcontext.movies.Remove(result);
            moviedbcontext.SaveChanges();
            return Ok("Deleted successfully");
        }
    }

    internal class AuzthorizeAttribute : Attribute
    {
    }
}
