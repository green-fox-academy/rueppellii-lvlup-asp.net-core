﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Structs
{
    public struct ResponseMessage
    {
        public string message;

        public ResponseMessage(string message)
        {
            this.message = message;
        }
    }
}