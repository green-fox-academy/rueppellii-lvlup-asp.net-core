namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class PitchDto
    {
        public string BadgeName { get; set; }
        public int? OldLVL { get; set; }
        public int? PitchedLVL { get; set; }
        public string PitchMessage { get; set; }
        public string[] Holders { get; set; }
    }
}
