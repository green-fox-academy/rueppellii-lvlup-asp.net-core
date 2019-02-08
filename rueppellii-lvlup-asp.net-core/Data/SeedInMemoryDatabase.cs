using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Data
{
    public static class SeedInMemoryDatabase
    {
        public static void AddSeededData(this LvlUpDbContext context)
        {
            context.Users.Add(new User
            {
                Id = 1,
                Name = "test.admin",
                TokenAuth = "testadmin:token",
                Pic = "base64://dwabi24632gdkje8549632...",
                UserLevels = null
            });
            context.Users.Add(new User
            {
                Id = 2,
                Name = "balazs.barna",
                TokenAuth = "verysecuretokendjawuidguowa76795432",
                Pic = "base64://dwabi24632gdkje8549632...",
                UserLevels = null
            });
            context.Users.Add(new User
            {
                Id = 3,
                Name = "sandor.vass",
                TokenAuth = "sandor542ghd237tiguk3",
                Pic = "base64://dwabi24632gdkje8549632...",
                UserLevels = null
            });
            context.Users.Add(new User
            {
                Id = 4,
                Name = "alajos.katona",
                TokenAuth = "verysecuretokendnj32t7853t2iugkjds",
                Pic = "base64://dwabi24632gdkje8549632...",
                UserLevels = null
            });

            context.Badges.Add(new Badge
            {
                Id = 1,
                Version = "v2.1",
                Name = "Process improve/initator",
                Tag = "general",
                Levels = null
            });
            context.Badges.Add(new Badge
            {
                Id = 2,
                Version = "v1.1",
                Name = "English speaker",
                Tag = "mentor",
                Levels = null
            });
            context.Badges.Add(new Badge
            {
                Id = 3,
                Version = "v1.1",
                Name = "Feedback receiver",
                Tag = "general",
                Levels = null
            });
            context.Badges.Add(new Badge
            {
                Id = 4,
                Version = "v1.1",
                Name = "Feedback giver",
                Tag = "marketing",
                Levels = null
            });

            context.Levels.Add(new Level
            {
                Id = 1,
                BadgeLevel = 1,
                Description = "I can see through processes and propose relevant and doable ideas for improvement. I can create improved definition / accountibility / documentation and communicate it to the team",
                Badge = context.Badges.Find((long)1)
            });
            context.Levels.Add(new Level
            {
                Id = 2,
                BadgeLevel = 2,
                Description = "I can reliably improve processes across the organization, doing all that's needed for the change management",
                Badge = context.Badges.Find((long)1)
            });
            context.Levels.Add(new Level
            {
                Id = 3,
                BadgeLevel = 3,
                Description = "I can introduce processes that are new to the company, and implement them",
                Badge = context.Badges.Find((long)1)
            });
            context.Levels.Add(new Level
            {
                Id = 4,
                BadgeLevel = 4,
                Description = "I can come up with brand new processes that have high impact on the company (i.e. Húli)",
                Badge = context.Badges.Find((long)1)
            });

            context.Levels.Add(new Level
            {
                Id = 5,
                BadgeLevel = 0,
                Description = "I can follow processes and internal English sessions and occasionally speak with preparation.",
                Badge = context.Badges.Find((long)2)
            });
            context.Levels.Add(new Level
            {
                Id = 6,
                BadgeLevel = 1,
                Description = "I can present/facilitate sessions in English yet not always fluently.",
                Badge = context.Badges.Find((long)2)
            });
            context.Levels.Add(new Level
            {
                Id = 7,
                BadgeLevel = 2,
                Description = "I can confidently present/facilitate sessions in English.",
                Badge = context.Badges.Find((long)2)
            });
            context.Levels.Add(new Level
            {
                Id = 8,
                BadgeLevel = 3,
                Description = "I can express and understand nuanced opinions, needs and feelings (i.e. partner meeting, interviewing, profiling, coaching, event presentation)Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla quam velit, vulputate",
                Badge = context.Badges.Find((long)2)
            });
            context.Levels.Add(new Level
            {
                Id = 9,
                BadgeLevel = 4,
                Description = "I can negotiate with clients and partners, using sophisticated, grammaticaly correct English",
                Badge = context.Badges.Find((long)2)
            });

            context.Levels.Add(new Level
            {
                Id = 10,
                BadgeLevel = 1,
                Description = "I usually receive feedback even if I get triggered while receiving it.",
                Badge = context.Badges.Find((long)3)
            });
            context.Levels.Add(new Level
            {
                Id = 11,
                BadgeLevel = 2,
                Description = "I usually receive feedback without interrupting, getting defensive, trying to find excuses, lashing out, and integrate it upon reflection.",
                Badge = context.Badges.Find((long)3)
            });
            context.Levels.Add(new Level
            {
                Id = 12,
                BadgeLevel = 3,
                Description = "I proactively seek feedback on projects or my general work and choose how to integrate it.",
                Badge = context.Badges.Find((long)3)
            });
            context.Levels.Add(new Level
            {
                Id = 13,
                BadgeLevel = 4,
                Description = "When you give me feedback, I help you get specific on: what I did, why that matters, what could we do about it",
                Badge = context.Badges.Find((long)3)
            });
            context.Levels.Add(new Level
            {
                Id = 14,
                BadgeLevel = 5,
                Description = "I am a role-model for how to receive and process feedback.",
                Badge = context.Badges.Find((long)3)
            });

            context.Levels.Add(new Level
            {
                Id = 15,
                BadgeLevel = 0,
                Description = "When I have a problem, I usually let you know by expressing it clearly instead of keeping to myself",
                Badge = context.Badges.Find((long)4)
            });
            context.Levels.Add(new Level
            {
                Id = 16,
                BadgeLevel = 1,
                Description = "I proactively give specific, easy to understand observations, and make a request to you",
                Badge = context.Badges.Find((long)4)
            });
            context.Levels.Add(new Level
            {
                Id = 17,
                BadgeLevel = 2,
                Description = "I describe my feelings and needs in conflict situations with most of my team mates (not only with whom I feel comfortable with)",
                Badge = context.Badges.Find((long)4)
            });
            context.Levels.Add(new Level
            {
                Id = 18,
                BadgeLevel = 3,
                Description = "I am confident in describing my feelings and needs considering the feedback receivers feelings and suggest a constructive solution",
                Badge = context.Badges.Find((long)4)
            });

            context.Archetypes.Add(new Archetype
            {
                Id = 1,
                Name = "Junior Mentor",
                ArchetypeLevels = null
            });

            context.Archetypes.Add(new Archetype
            {
                Id = 2,
                Name = "Medior Mentor",
                ArchetypeLevels = new List<ArchetypeLevel>()
                {

                }
            });
            context.Archetypes.Add(new Archetype
            {
                Id = 3,
                Name = "Senior Mentor",
                ArchetypeLevels = new List<ArchetypeLevel>()
                {

                }
            });

            IList<ArchetypeLevel> archetypeLevels = new List<ArchetypeLevel>()
            {

                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)1),
                    Level = context.Levels.Find((long)1)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)1),
                    Level = context.Levels.Find((long)6)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)1),
                    Level = context.Levels.Find((long)10)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)1),
                    Level = context.Levels.Find((long)16)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)2),
                    Level = context.Levels.Find((long)2)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)2),
                    Level = context.Levels.Find((long)7)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)2),
                    Level = context.Levels.Find((long)11)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)2),
                    Level = context.Levels.Find((long)17)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)3),
                    Level = context.Levels.Find((long)3)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)3),
                    Level = context.Levels.Find((long)8)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long)3),
                    Level = context.Levels.Find((long)12)
                },
                new ArchetypeLevel
                {
                    Archetype = context.Archetypes.Find((long) 3),
                    Level = context.Levels.Find((long)18)
                }
            };
            context.ArchetypeLevels.AddRange(archetypeLevels);

            context.Pitches.Add(new Pitch
            {
                Id = 1,
                Timestamp = DateTime.UtcNow,
                OldLevel = 2,
                PitchedLevel = 3,
                PitchMessage = "I was working abroad for six years, so I can speak english very well. Pls improve my badge level to 3.",
                Reviews = null,
                User = context.Users.Find((long)4),
                Badge = context.Badges.Find((long)2),
                Level = context.Levels.Find((long)8)
            });
            context.Pitches.Add(new Pitch
            {
                Id = 2,
                Timestamp = DateTime.UtcNow.AddHours(-12),
                OldLevel = 1,
                PitchedLevel = 5,
                PitchMessage = "I can see through processes and propose relevant and doable ideas for improvement. I can create improved definition / accountibility / documentation and communicate it to the team",
                Reviews = null,
                User = context.Users.Find((long)4),
                Badge = context.Badges.Find((long)1),
                Level = context.Levels.Find((long)5)
            });
            context.Pitches.Add(new Pitch
            {
                Id = 3,
                Timestamp = DateTime.UtcNow.AddDays(-4),
                OldLevel = 1,
                PitchedLevel = 3,
                PitchMessage = "I proactively seek feedback on projects or my general work and choose how to integrate it.",
                Reviews = null,
                User = context.Users.Find((long)2),
                Badge = context.Badges.Find((long)3),
                Level = context.Levels.Find((long)12)
            });
            context.Pitches.Add(new Pitch
            {
                Id = 4,
                Timestamp = DateTime.UtcNow.AddMinutes(-52),
                OldLevel = 4,
                PitchedLevel = 5,
                PitchMessage = "When I have a problem, I usually let you know by expressing it clearly instead of keeping to myself",
                Reviews = null,
                User = context.Users.Find((long)3),
                Badge = context.Badges.Find((long)4),
                Level = context.Levels.Find((long)18)
            });
            context.Pitches.Add(new Pitch
            {
                Id = 5,
                Timestamp = DateTime.UtcNow.AddMonths(-3),
                OldLevel = 2,
                PitchedLevel = 3,
                PitchMessage = "I improved in React, Redux, basic JS, NodeJS, Express and in LowDB, pls give me more money",
                Reviews = null,
                User = context.Users.Find((long)3),
                Badge = context.Badges.Find((long)2),
                Level = context.Levels.Find((long)8)
            });
            context.Pitches.Add(new Pitch
            {
                Id = 6,
                Timestamp = DateTime.UtcNow,
                OldLevel = 3,
                PitchedLevel = 4,
                PitchMessage = "I am confident in describing my feelings and needs considering the feedback receivers feelings and suggest a constructive solution",
                Reviews = null,
                User = context.Users.Find((long)1),
                Badge = context.Badges.Find((long)2),
                Level = context.Levels.Find((long)9)
            });

            context.SaveChanges();
        }
    }
}
