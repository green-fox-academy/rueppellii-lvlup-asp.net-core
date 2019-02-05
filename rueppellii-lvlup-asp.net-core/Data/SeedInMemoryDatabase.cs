using rueppellii_lvlup_asp.net_core.Models;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Data
{
    public static class SeedInMemoryDatabase
    {
        public static void AddSeededData(this LvlUpDbContext context)
        {

            context.Badges.Add(new Badges
            {
                Id = 1,
                Version = "v2.1",
                Name = "Process improve/initator",
                Tag = "general"
            });
            context.Badges.Add(new Badges
            {
                Id = 2,
                Version = "v1.1",
                Name = "English speaker",
                Tag = "mentor"
            });
            context.Badges.Add(new Badges
            {
                Id = 3,
                Version = "v1.1",
                Name = "Feedback receiver",
                Tag = "general"
            });
            context.Badges.Add(new Badges
            {
                Id = 4,
                Version = "v1.1",
                Name = "Feedback giver",
                Tag = "marketing",
            });

            context.Levels.Add(new Levels
            {
                Id = 1,
                Level = 1,
                Description = "I can see through processes and propose relevant and doable ideas for improvement. I can create improved definition / accountibility / documentation and communicate it to the team",
                BadgeId = 1
            });
            context.Levels.Add(new Levels
            {
                Id = 2,
                Level = 2,
                Description = "I can reliably improve processes across the organization, doing all that's needed for the change management",
                BadgeId = 1
            });
            context.Levels.Add(new Levels
            {
                Id = 3,
                Level = 3,
                Description = "I can introduce processes that are new to the company, and implement them",
                BadgeId = 1
            });
            context.Levels.Add(new Levels
            {
                Id = 4,
                Level = 4,
                Description = "I can come up with brand new processes that have high impact on the company (i.e. Húli)",
                BadgeId = 1
            });

            context.Levels.Add(new Levels
            {
                Level = 0,
                Description = "I can follow processes and internal English sessions and occasionally speak with preparation.",
                BadgeId = 2
            });
            context.Levels.Add(new Levels
            {
                Level = 1,
                Description = "I can present/facilitate sessions in English yet not always fluently.",
                BadgeId = 2
            });
            context.Levels.Add(new Levels
            {
                Level = 2,
                Description = "I can confidently present/facilitate sessions in English.",
                BadgeId = 2
            });
            context.Levels.Add(new Levels
            {
                Level = 3,
                Description = "I can express and understand nuanced opinions, needs and feelings (i.e. partner meeting, interviewing, profiling, coaching, event presentation)Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla quam velit, vulputate",
                BadgeId = 2
            });
            context.Levels.Add(new Levels
            {
                Level = 4,
                Description = "I can negotiate with clients and partners, using sophisticated, grammaticaly correct English",
                BadgeId = 2
            });

            context.Levels.Add(new Levels
            {
                Level = 1,
                Description = "I usually receive feedback even if I get triggered while receiving it.",
                BadgeId = 3
            });
            context.Levels.Add(new Levels
            {
                Level = 2,
                Description = "I usually receive feedback without interrupting, getting defensive, trying to find excuses, lashing out, and integrate it upon reflection.",
                BadgeId = 3
            });
            context.Levels.Add(new Levels
            {
                Level = 3,
                Description = "I proactively seek feedback on projects or my general work and choose how to integrate it.",
                BadgeId = 3
            });
            context.Levels.Add(new Levels
            {
                Level = 4,
                Description = "When you give me feedback, I help you get specific on: what I did, why that matters, what could we do about it",
                BadgeId = 3
            });
            context.Levels.Add(new Levels
            {
                Level = 5,
                Description = "I am a role-model for how to receive and process feedback.",
                BadgeId = 3
            });

            context.Levels.Add(new Levels
            {
                Level = 0,
                Description = "When I have a problem, I usually let you know by expressing it clearly instead of keeping to myself",
                BadgeId = 4
            });
            context.Levels.Add(new Levels
            {
                Level = 1,
                Description = "I proactively give specific, easy to understand observations, and make a request to you",
                BadgeId = 4
            });
            context.Levels.Add(new Levels
            {
                Level = 2,
                Description = "I describe my feelings and needs in conflict situations with most of my team mates (not only with whom I feel comfortable with)",
                BadgeId = 4
            });
            context.Levels.Add(new Levels
            {
                Level = 3,
                Description = "I am confident in describing my feelings and needs considering the feedback receivers feelings and suggest a constructive solution",
                BadgeId = 4
            });

        context.SaveChanges();
        }
}
}
