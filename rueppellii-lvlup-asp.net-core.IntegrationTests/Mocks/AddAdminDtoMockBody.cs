﻿using Newtonsoft.Json;
using rueppellii_lvlup_asp.net_core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace rueppellii_lvlup_asp.net_core.IntegrationTests.Mocks
{
    public class AddAdminDtoMockBody : AddAdminDto
    {
        public string GetCorrectBody()
        {
            this.Version = 2.3;
            this.Name = "Badge inserter";
            this.Tag = "general";
            this.Levels = "[]";
            return JsonConvert.SerializeObject(this);
        }
        public string GetMissingBody()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string GetEmptyStringsBody()
        {
            this.Version = 2.3;
            this.Name = "";
            this.Tag = "";
            this.Levels = "[]";
            return JsonConvert.SerializeObject(this);
        }
    }
}
