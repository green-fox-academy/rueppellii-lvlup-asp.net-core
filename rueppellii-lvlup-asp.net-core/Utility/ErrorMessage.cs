﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Utility
{
    public class ErrorMessage
    {
        public readonly string error;

        public ErrorMessage(string error)
        {
            this.error = error;
        }
    }
}