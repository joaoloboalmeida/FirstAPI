using Game.Data;
using Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Game.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get([FromServices] GameDbContext context) 
            => Ok(context.Games.AsNoTracking().ToList());

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] GameDbContext context)
        {
            var game = context.Games.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (game == null)
                return NotFound();
           
            return Ok(game.Name);
        }

        [HttpPost("/")]
        public IActionResult Post([FromBody] GameModel game, [FromServices] GameDbContext context)
        {
            context.Games.Add(game);
            context.SaveChanges();
            return Created($"/{game.Id}",$"Name: {game.Name} and Price: $ {game.Price}");
        }

        [HttpPut("/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] GameModel game, 
            [FromServices] GameDbContext context)
        {
            var model = context.Games.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            model.Name = game.Name;
            model.Price = game.Price;

            context.Games.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/{id:int}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] GameDbContext context)
        {
            var model = context.Games.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();

            context.Games.Remove(model);
            context.SaveChanges();

            return Ok("Successful delete!");
        }
    }
}