using Microsoft.AspNetCore.Mvc;

namespace friends.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendController : ControllerBase
    {
        private static readonly List<string> Friends = new(){"Betsy", "Ana", "Cesar", "Enzo", "Juan", "Alvaro"};
        [HttpGet]
        
        public ActionResult<IEnumerable<string>> GetFriend()
        {
            return Ok(Friends);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetFriend(int id)
        {
            if (id < 0 || id >= Friends.Count)
            {
                return NotFound("Friend not found");
            }
            return Ok(Friends[id]);
        }

        [HttpPost]
        public ActionResult AddFriend([FromBody] string friend)
        {
            Friends.Add(friend);
            return CreatedAtAction(nameof(GetFriend), new { id = Friends.Count - 1 }, friend);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateFriend(int id, [FromBody] string friend)
        {
            if (id < 0 || id >= Friends.Count)
            {
                return NotFound("Friend not found");
            }
            Friends[id] = friend;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFriend(int id)
        {
            if (id < 0 || id >= Friends.Count)
            {
                return NotFound("Friend not found");
            }
            Friends.RemoveAt(id);
            return NoContent();
        }
    }
}
