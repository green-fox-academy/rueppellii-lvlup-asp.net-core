﻿using Microsoft.AspNetCore.Hosting;

namespace rueppellii_lvlup_asp.net_core.Environments
{
    public static class TestingEnvironment
    {
        public const string Testing = "Testing";

        public static bool IsTest(this IHostingEnvironment hosting)
        {
            return hosting.IsEnvironment(Testing);
        }
    }
}