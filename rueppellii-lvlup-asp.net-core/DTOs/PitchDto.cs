namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class PitchDto
    {
        public string BadgeName { get; set; }
        public int? OldLevel { get; set; }
        public int? PitchedLevel { get; set; }
        public string PitchMessage { get; set; }
        public string[] Holders { get; set; }
    }
}
