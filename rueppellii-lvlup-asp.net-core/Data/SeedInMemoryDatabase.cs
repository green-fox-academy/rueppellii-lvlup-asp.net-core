using rueppellii_lvlup_asp.net_core.Models;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Data
{
    public static class SeedInMemoryDatabase
    {
        public static void AddSeededData (this LvlUpDbContext context)
        {

            context.Badges.Add(new Badges
            {
                Version = "v2.1",
                Name = "Process improve/initator",
                Tag = "general",
                Levels = new List<Levels>
                {
                    new Levels
                    {
                        Level = 1,
                        Description = "I can see through processes and propose relevant and doable ideas for improvement. I can create improved definition / accountibility / documentation and communicate it to the team",
                        Holders = null
                    },
                    new Levels
                    {
                        Level = 2,
                        Description = "I usually receive feedback without interrupting, getting defensive, trying to find excuses, lashing out, and integrate it upon reflection.",
                        Holders = null
                    },
                    new Levels
                    {
                        Level = 3,
                        Description = "I proactively seek feedback on projects or my general work and choose how to integrate it.",
                        Holders = null
                    },
                    new Levels
                    {
                        Level = 4,
                        Description = "When you give me feedback, I help you get specific on: what I did, why that matters, what could we do about it",
                        Holders = null
                    },
                    new Levels
                    {
                        Level = 5,
                        Description = "I am a role-model for how to receive and process feedback.",
                        Holders = null
                    }
                }
            });
            context.Badges.Add(new Badges
            {
                Version = "v1.1",
                Name = "Feedback giver",
                Tag = "marketing",
                Levels = new List<Levels>
                {
                    new Levels
                    {
                        Level = 0,
                        Description = "When I have a problem, I usually let you know by expressing it clearly instead of keeping to myself",
                        Holders = null
                    },
                    new Levels
                    {
                        Level = 1,
                        Description = "I proactively give specific, easy to understand observations, and make a request to you",
                        Holders = null
                    },
                    new Levels
                    {
                        Level = 2,
                        Description = "I describe my feelings and needs in conflict situations with most of my team mates (not only with whom I feel comfortable with)",
                        Holders = null
                    },
                    new Levels
                    {
                        Level = 3,
                        Description = "I am confident in describing my feelings and needs considering the feedback receivers feelings and suggest a constructive solution",
                        Holders = null
                    }
                }
            });
            context.SaveChanges();
        }
    }
}
