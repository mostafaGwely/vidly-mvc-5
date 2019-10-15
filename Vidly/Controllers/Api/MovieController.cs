using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IHttpActionResult getMovies()
        {
            var moviesInDb = _context.Movies.Include(m=>m.Genre).ToList();
            if (moviesInDb == null)
                return NotFound();
            return Ok(moviesInDb.Select(Mapper.Map<Movie, MovieDto>));
        }

        //GET /api/movies/1
        public IHttpActionResult getMovies(int id)
        {
            return Ok(Mapper.Map<Movie, MovieDto>(_context.Movies.SingleOrDefault(m => m.Id == id)));
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult createMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(m => m.Errors);
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok(movieDto);
        }

        //PUT /api/movies
        [HttpPut]
        public IHttpActionResult updateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(e => e.Errors);
                return BadRequest();

            }
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok(movieDto);

        }

        //Delete /api/movies/1
        [HttpDelete]
        public IHttpActionResult deleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }

}