﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rueppellii_lvlup_asp.net_core.Models
{
  public class ErrorHandler
  {
    public string error;

    public ErrorHandler(string error)
    {
      this.error = error;
    }
  }
}