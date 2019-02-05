using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Data
{
    public static class SeedInMemoryDatabase
    {
        public static void AddSeededData(this LvlUpDbContext context)
        {

            context.Badges.Add(new Badge
            {
                Id = 1,
                Version = "v2.1",
                Name = "Process improve/initator",
                Tag = "general"
            });
            context.Badges.Add(new Badge
            {
                Id = 2,
                Version = "v1.1",
                Name = "English speaker",
                Tag = "mentor"
            });
            context.Badges.Add(new Badge
            {
                Id = 3,
                Version = "v1.1",
                Name = "Feedback receiver",
                Tag = "general"
            });
            context.Badges.Add(new Badge
            {
                Id = 4,
                Version = "v1.1",
                Name = "Feedback giver",
                Tag = "marketing",
            });

            context.Levels.Add(new Level
            {
                Id = 1,
                Level = 1,
                Description = "I can see through processes and propose relevant and doable ideas for improvement. I can create improved definition / accountibility / documentation and communicate it to the team",
                BadgeId = 1
            });
            context.Levels.Add(new Level
            {
                Id = 2,
                Level = 2,
                Description = "I can reliably improve processes across the organization, doing all that's needed for the change management",
                BadgeId = 1
            });
            context.Levels.Add(new Level
            {
                Id = 3,
                Level = 3,
                Description = "I can introduce processes that are new to the company, and implement them",
                BadgeId = 1
            });
            context.Levels.Add(new Level
            {
                Id = 4,
                Level = 4,
                Description = "I can come up with brand new processes that have high impact on the company (i.e. Húli)",
                BadgeId = 1
            });

            context.Levels.Add(new Level
            {
                Level = 0,
                Description = "I can follow processes and internal English sessions and occasionally speak with preparation.",
                BadgeId = 2
            });
            context.Levels.Add(new Level
            {
                Level = 1,
                Description = "I can present/facilitate sessions in English yet not always fluently.",
                BadgeId = 2
            });
            context.Levels.Add(new Level
            {
                Level = 2,
                Description = "I can confidently present/facilitate sessions in English.",
                BadgeId = 2
            });
            context.Levels.Add(new Level
            {
                Level = 3,
                Description = "I can express and understand nuanced opinions, needs and feelings (i.e. partner meeting, interviewing, profiling, coaching, event presentation)Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla quam velit, vulputate",
                BadgeId = 2
            });
            context.Levels.Add(new Level
            {
                Level = 4,
                Description = "I can negotiate with clients and partners, using sophisticated, grammaticaly correct English",
                BadgeId = 2
            });

            context.Levels.Add(new Level
            {
                Level = 1,
                Description = "I usually receive feedback even if I get triggered while receiving it.",
                BadgeId = 3
            });
            context.Levels.Add(new Level
            {
                Level = 2,
                Description = "I usually receive feedback without interrupting, getting defensive, trying to find excuses, lashing out, and integrate it upon reflection.",
                BadgeId = 3
            });
            context.Levels.Add(new Level
            {
                Level = 3,
                Description = "I proactively seek feedback on projects or my general work and choose how to integrate it.",
                BadgeId = 3
            });
            context.Levels.Add(new Level
            {
                Level = 4,
                Description = "When you give me feedback, I help you get specific on: what I did, why that matters, what could we do about it",
                BadgeId = 3
            });
            context.Levels.Add(new Level
            {
                Level = 5,
                Description = "I am a role-model for how to receive and process feedback.",
                BadgeId = 3
            });

            context.Levels.Add(new Level
            {
                Level = 0,
                Description = "When I have a problem, I usually let you know by expressing it clearly instead of keeping to myself",
                BadgeId = 4
            });
            context.Levels.Add(new Level
            {
                Level = 1,
                Description = "I proactively give specific, easy to understand observations, and make a request to you",
                BadgeId = 4
            });
            context.Levels.Add(new Level
            {
                Level = 2,
                Description = "I describe my feelings and needs in conflict situations with most of my team mates (not only with whom I feel comfortable with)",
                BadgeId = 4
            });
            context.Levels.Add(new Level
            {
                Level = 3,
                Description = "I am confident in describing my feelings and needs considering the feedback receivers feelings and suggest a constructive solution",
                BadgeId = 4
            });

            context.Users.Add(new User
            {
                Id = 1,
                Name = "test.admin",
                TokenAuth = "testadmin:token",
                Pic = "base64://dwabi24632gdkje8549632...",
                Badges = null
            });
            context.Users.Add(new User
            {
                Id = 2,
                Name = "balazs.barna",
                TokenAuth = "verysecuretokendjawuidguowa76795432",
                Pic = "base64://dwabi24632gdkje8549632...",
                Badges = null
            });
            context.Users.Add(new User
            {
                Id = 3,
                Name = "sandor.vass",
                TokenAuth = "sandor542ghd237tiguk3",
                Pic = "base64://dwabi24632gdkje8549632...",
                Badges = null
            });
            context.Users.Add(new User
            {
                Id = 4,
                Name = "alajos.katona",
                TokenAuth = "verysecuretokendnj32t7853t2iugkjds",
                Pic = "base64://dwabi24632gdkje8549632...",
                Badges = null
            });

            context.Archetypes.Add(new Archetype
            {
                Id = 1,
                Name = "Junior Mentor",
                Badges = null
            });
            context.Archetypes.Add(new Archetype
            {
                Id = 2,
                Name = "Medior Mentor",
                Badges = null
            });
            context.Archetypes.Add(new Archetype
            {
                Id = 3,
                Name = "Senior Mentor",
                Badges = null
            });

            context.Pitches.Add(new Pitch
            {
                Id = 1,
                Timestamp = DateTime.UtcNow,
                PitchedLevel = 3,
                PitchMessage = "I was working abroad for six years, so I can speak english very well.Pls improve my badge level to 3.",
                UserId = 4,
                BadgeId = 3,
                LevelId = 3
            });
            context.Pitches.Add(new Pitch
            {
                Id = 2,
                Timestamp = DateTime.UtcNow.AddHours(-12),
                PitchedLevel = 3,
                PitchMessage = "I was working abroad for six years, so I can speak english very well.Pls improve my badge level to 3.",
                UserId = 2,
                BadgeId = 2,
                LevelId = 3
            });
            context.Pitches.Add(new Pitch
            {
                Id = 3,
                Timestamp = DateTime.UtcNow.AddDays(-4),
                PitchedLevel = 3,
                PitchMessage = "I was working abroad for six years, so I can speak english very well.Pls improve my badge level to 3.",
                UserId = 3,
                BadgeId = 4,
                LevelId = 3
            });
            context.Pitches.Add(new Pitch
            {
                Id = 4,
                Timestamp = DateTime.UtcNow.AddMinutes(-52),
                PitchedLevel = 3,
                PitchMessage = "I was working abroad for six years, so I can speak english very well.Pls improve my badge level to 3.",
                UserId = 2,
                BadgeId = 4,
                LevelId = 3
            });
            context.Pitches.Add(new Pitch
            {
                Id = 5,
                Timestamp = DateTime.UtcNow.AddMonths(-3),
                PitchedLevel = 3,
                PitchMessage = "I was working abroad for six years, so I can speak english very well.Pls improve my badge level to 3.",
                UserId = 4,
                BadgeId = 1,
                LevelId = 3
            });
            context.Pitches.Add(new Pitch
            {
                Id = 6,
                Timestamp = DateTime.UtcNow,
                PitchedLevel = 3,
                PitchMessage = "I was working abroad for six years, so I can speak english very well.Pls improve my badge level to 3.",
                UserId = 1,
                BadgeId = 2,
                LevelId = 4
            });

            context.SaveChanges();
        }
}
}
