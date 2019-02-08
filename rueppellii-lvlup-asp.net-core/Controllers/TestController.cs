using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Controllers
{
    public class TestController : Controller
    {
        private readonly LvlUpDbContext ctx;

        public TestController(LvlUpDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet("")]
        public IActionResult List()
        {
            List<Object> returned = new List<Object>();
            returned.Add(ctx.Users.ToList());
            returned.Add("--------------");
            returned.Add(ctx.Badges.ToList());
            returned.Add("--------------");
            returned.Add(ctx.Levels.ToList());
            returned.Add("--------------");
            returned.Add(ctx.Archetypes.ToList());
            returned.Add("--------------");
            //returned.Add(ctx.Pitches.ToList());
            returned.Add("--------------");
            returned.Add(ctx.ArchetypeLevels.ToList());
            string json = JsonConvert.SerializeObject(returned, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return StatusCode(418, json);
        }
    }
}
