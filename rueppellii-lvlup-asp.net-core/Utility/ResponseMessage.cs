﻿namespace rueppellii_lvlup_asp.net_core.Utility
{
    public class ResponseMessage
    {
        public string Message { get; }

        public ResponseMessage(string message)
        {
            this.Message = message;
        }
    }
}
