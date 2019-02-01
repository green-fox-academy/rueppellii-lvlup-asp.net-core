using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public static class DummyJsonResponseDTO
    {
        public static string json = "{\"myPitches\":" +
            "[{\"timeStamp\": \"2018-11-29 17:10:47\"," +
            "\"userName\": \"balazs.barna\"," +
            "\"badgeName\": \"Programming\"," +
            "\"oldLvl\": 2," +
            "\"pitchedLvl\": 3," +
            "\"pitchMessage\": \"I improved in React, Redux, basic JS," +
            " NodeJS, Express and in LowDB, pls give me more money\"," +
            "\"holders\": " +
            "[{\"name\": \"sandor.vass\"," +
            "\"message\": null," +
            "\"pitchStatus\": false}]}]," +
            "\"pitchesToReview\": " +
            "[{\"timeStamp\": \"2018-11-29 17:10:47\"," +
            "\"userName\": \"berei.daniel\"," +
            "\"badgeName\": \"English speaker\"," +
            "\"oldLvl\": 2," +
            "\"pitchedLvl\": 3," +
            "\"pitchMessage\": \"I was working abroad for " +
            "six years, so I can speak english very well. Pls " +
            "improve my badge level to 3.\"," +
            "\"holders\": [{" +
            "\"name\": \"balazs.jozsef\"," +
            "\"message\": \"Yes, you are able to speak english\"," +
            "\"pitchStatus\": true}]}]}";
    }
}
