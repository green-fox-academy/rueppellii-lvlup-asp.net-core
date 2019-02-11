namespace rueppellii_lvlup_asp.net_core.Utility
{
    public class ErrorMessage
    {
        public string Error { get; }

        public ErrorMessage(string error)
        {
            this.Error = error;
        }
    }
}
