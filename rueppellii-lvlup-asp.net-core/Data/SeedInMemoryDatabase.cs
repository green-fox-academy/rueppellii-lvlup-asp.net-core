using rueppellii_lvlup_asp.net_core.Models;
using System;
using System.Collections.Generic;

namespace rueppellii_lvlup_asp.net_core.Data
{
    public static class SeedInMemoryDatabase
    {
        public static void AddSeededData(this LvlUpDbContext context)
        {
            IList<User> users = new List<User>()
            {
                new User
                {
                    Name = "test.admin",
                    Pic = "base64://dwabi24632gdkje8549632...",
                    UserLevels = null
                },
                new User
                {
                    Name = "balazs.barna",
                    Pic = "base64://dwabi24632gdkje8549632...",
                    UserLevels = null
                },
                new User
                {
                    Name = "sandor.vass",
                    Pic = "base64://dwabi24632gdkje8549632...",
                    UserLevels = null
                },
                new User
                {
                    Name = "alajos.katona",
                    Pic = "base64://dwabi24632gdkje8549632...",
                    UserLevels = null
                }
            };
            context.Users.AddRange(users);

            IList<Badge> badges = new List<Badge>()
            {
                new Badge
                {
                    Version = "v2.1",
                    Name = "Process improve/initator",
                    Tag = "general",
                    Levels = null
                },
                new Badge
                {
                    Version = "v1.1",
                    Name = "English speaker",
                    Tag = "mentor",
                    Levels = null
                },
                new Badge
                {
                    Version = "v1.1",
                    Name = "Feedback receiver",
                    Tag = "general",
                    Levels = null
                },
                new Badge
                {
                    Version = "v1.1",
                    Name = "Feedback giver",
                    Tag = "marketing",
                    Levels = null
                }
            };
            context.Badges.AddRange(badges);

            IList<Level> levels = new List<Level>()
            {
                new Level
                {
                    BadgeLevel = 1,
                    Description = "I can see through processes and propose relevant and doable ideas for improvement. I can create improved definition / accountibility / documentation and communicate it to the team",
                    Badge = context.Badges.Find((long)1)
                },
                new Level
                {
                    BadgeLevel = 2,
                    Description = "I can reliably improve processes across the organization, doing all that's needed for the change management",
                    Badge = context.Badges.Find((long)1)
                },
                new Level
                {
                    BadgeLevel = 3,
                    Description = "I can introduce processes that are new to the company, and implement them",
                    Badge = context.Badges.Find((long)1)
                },
                new Level
                {
                    BadgeLevel = 4,
                    Description = "I can come up with brand new processes that have high impact on the company (i.e. Húli)",
                    Badge = context.Badges.Find((long)1)
                },
                new Level
                {
                    BadgeLevel = 0,
                    Description = "I can follow processes and internal English sessions and occasionally speak with preparation.",
                    Badge = context.Badges.Find((long)2)
                },
                new Level
                {
                    BadgeLevel = 1,
                    Description = "I can present/facilitate sessions in English yet not always fluently.",
                    Badge = context.Badges.Find((long)2)
                },
                new Level
                {
                    BadgeLevel = 2,
                    Description = "I can confidently present/facilitate sessions in English.",
                    Badge = context.Badges.Find((long)2)
                },
                new Level
                {
                    BadgeLevel = 3,
                    Description = "I can express and understand nuanced opinions, needs and feelings (i.e. partner meeting, interviewing, profiling, coaching, event presentation)Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla quam velit, vulputate",
                    Badge = context.Badges.Find((long)2)
                },
                new Level
                {
                    BadgeLevel = 4,
                    Description = "I can negotiate with clients and partners, using sophisticated, grammaticaly correct English",
                    Badge = context.Badges.Find((long)2)
                },
                new Level
                {
                    BadgeLevel = 1,
                    Description = "I usually receive feedback even if I get triggered while receiving it.",
                    Badge = context.Badges.Find((long)3)
                },
                new Level
                {
                    BadgeLevel = 2,
                    Description = "I usually receive feedback without interrupting, getting defensive, trying to find excuses, lashing out, and integrate it upon reflection.",
                    Badge = context.Badges.Find((long)3)
                },
                new Level
                {
                    BadgeLevel = 3,
                    Description = "I proactively seek feedback on projects or my general work and choose how to integrate it.",
                    Badge = context.Badges.Find((long)3)
                },
                new Level
                {
                    BadgeLevel = 4,
                    Description = "When you give me feedback, I help you get specific on: what I did, why that matters, what could we do about it",
                    Badge = context.Badges.Find((long)3)
                },
                new Level
                {
                    BadgeLevel = 5,
                    Description = "I am a role-model for how to receive and process feedback.",
                    Badge = context.Badges.Find((long)3)
                },
                new Level
                {
                    BadgeLevel = 0,
                    Description = "When I have a problem, I usually let you know by expressing it clearly instead of keeping to myself",
                    Badge = context.Badges.Find((long)4)
                },
                new Level
                {
                    BadgeLevel = 1,
                    Description = "I proactively give specific, easy to understand observations, and make a request to you",
                    Badge = context.Badges.Find((long)4)
                },
                new Level
                {
                    BadgeLevel = 2,
                    Description = "I describe my feelings and needs in conflict situations with most of my team mates (not only with whom I feel comfortable with)",
                    Badge = context.Badges.Find((long)4)
                },
                new Level
                {
                    BadgeLevel = 3,
                    Description = "I am confident in describing my feelings and needs considering the feedback receivers feelings and suggest a constructive solution",
                    Badge = context.Badges.Find((long)4)
                }
            };
            context.Levels.AddRange(levels);

            IList<Archetype> archetypes = new List<Archetype>()
            {
                new Archetype
                {
                    Name = "Junior Mentor",
                    ArchetypeLevels = null
                },
                new Archetype
                {
                    Name = "Medior Mentor",
                    ArchetypeLevels = null
                },
                new Archetype
                {
                    Name = "Senior Mentor",
                    ArchetypeLevels = null
                }
            };
            context.Archetypes.AddRange(archetypes);

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

            IList<Pitch> pitches = new List<Pitch>()
            {
                new Pitch
                {
                    Timestamp = DateTime.UtcNow,
                    OldLevel = 2,
                    PitchedLevel = 3,
                    PitchMessage = "I was working abroad for six years, so I can speak english very well. Pls improve my badge level to 3.",
                    Reviews = null,
                    User = context.Users.Find((long)4),
                    Badge = context.Badges.Find((long)2),
                    Level = context.Levels.Find((long)8)
                },
                new Pitch
                {
                    Timestamp = DateTime.UtcNow.AddHours(-12),
                    OldLevel = 1,
                    PitchedLevel = 5,
                    PitchMessage = "I can see through processes and propose relevant and doable ideas for improvement. I can create improved definition / accountibility / documentation and communicate it to the team",
                    Reviews = null,
                    User = context.Users.Find((long)4),
                    Badge = context.Badges.Find((long)1),
                    Level = context.Levels.Find((long)5)
                },
                new Pitch
                {
                    Timestamp = DateTime.UtcNow.AddDays(-4),
                    OldLevel = 1,
                    PitchedLevel = 3,
                    PitchMessage = "I proactively seek feedback on projects or my general work and choose how to integrate it.",
                    Reviews = null,
                    User = context.Users.Find((long)2),
                    Badge = context.Badges.Find((long)3),
                    Level = context.Levels.Find((long)12)
                },
                new Pitch
                {
                    Timestamp = DateTime.UtcNow.AddMinutes(-52),
                    OldLevel = 4,
                    PitchedLevel = 5,
                    PitchMessage = "When I have a problem, I usually let you know by expressing it clearly instead of keeping to myself",
                    Reviews = null,
                    User = context.Users.Find((long)3),
                    Badge = context.Badges.Find((long)4),
                    Level = context.Levels.Find((long)18)
                },
                new Pitch
                {
                    Timestamp = DateTime.UtcNow.AddMonths(-3),
                    OldLevel = 2,
                    PitchedLevel = 3,
                    PitchMessage = "I improved in React, Redux, basic JS, NodeJS, Express and in LowDB, pls give me more money",
                    Reviews = null,
                    User = context.Users.Find((long)3),
                    Badge = context.Badges.Find((long)2),
                    Level = context.Levels.Find((long)8)
                },
                new Pitch
                {
                    Timestamp = DateTime.UtcNow,
                    OldLevel = 3,
                    PitchedLevel = 4,
                    PitchMessage = "I am confident in describing my feelings and needs considering the feedback receivers feelings and suggest a constructive solution",
                    Reviews = null,
                    User = context.Users.Find((long)1),
                    Badge = context.Badges.Find((long)2),
                    Level = context.Levels.Find((long)9)
                }
            };
            context.Pitches.AddRange(pitches);

            IList<UserLevel> userLevels = new List<UserLevel>()
            {
                new UserLevel
                {
                    User = context.Users.Find((long)1),
                    Level = context.Levels.Find((long)5)
                },
                new UserLevel
                {
                    User = context.Users.Find((long)1),
                    Level = context.Levels.Find((long)8)
                },
                new UserLevel
                {
                    User = context.Users.Find((long)1),
                    Level = context.Levels.Find((long)15)
                },
                new UserLevel
                {
                    User = context.Users.Find((long)1),
                    Level = context.Levels.Find((long)18)
                },
                new UserLevel
                {
                    User = context.Users.Find((long)2),
                    Level = context.Levels.Find((long)1)
                },
                new UserLevel
                {
                    User = context.Users.Find((long)2),
                    Level = context.Levels.Find((long)7)
                },
                new UserLevel
                {
                    User = context.Users.Find((long)3),
                    Level = context.Levels.Find((long)2)
                },
                new UserLevel
                {
                    User = context.Users.Find((long)4),
                    Level = context.Levels.Find((long)7)
                },
                new UserLevel
                {
                    User = context.Users.Find((long)4),
                    Level = context.Levels.Find((long)10)
                }
            };
            context.UserLevels.AddRange(userLevels);

            IList<Review> reviews = new List<Review>()
            {
                new Review
                {
                    Message = "Yes you improved a lot.",
                    PitchStatus = true,
                    User = context.Users.Find((long) 1),
                    Pitch = context.Pitches.Find((long) 1)
                },
                new Review
                {
                    Message = "Agreed",
                    PitchStatus = true,
                    User = context.Users.Find((long) 3),
                    Pitch = context.Pitches.Find((long) 1)
                },
                new Review
                {
                    Message = "Nah, this change is not justified.",
                    PitchStatus = false,
                    User = context.Users.Find((long) 2),
                    Pitch = context.Pitches.Find((long) 2)
                },
                new Review
                {
                    Message = "Agreed",
                    PitchStatus = true,
                    User = context.Users.Find((long) 3),
                    Pitch = context.Pitches.Find((long) 2)
                },
                new Review
                {
                    Message = null,
                    PitchStatus = true,
                    User = context.Users.Find((long) 1),
                    Pitch = context.Pitches.Find((long) 3)
                },
                new Review
                {
                    Message = "Oh, I don't think so...",
                    PitchStatus = false,
                    User = context.Users.Find((long) 2),
                    Pitch = context.Pitches.Find((long) 4)
                },
                new Review
                {
                    Message = "General Kenobi!",
                    PitchStatus = false,
                    User = context.Users.Find((long) 1),
                    Pitch = context.Pitches.Find((long) 4)
                },
                new Review
                {
                    Message = "Yes, I agree with this pitch",
                    PitchStatus = true,
                    User = context.Users.Find((long) 1),
                    Pitch = context.Pitches.Find((long) 5)
                }
            };
            context.Reviews.AddRange(reviews);

            context.SaveChanges();
        }
    }
}
