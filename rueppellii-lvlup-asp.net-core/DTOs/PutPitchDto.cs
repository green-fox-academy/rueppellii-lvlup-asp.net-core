namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class PutPitchDto : BasePitchDto
    {
        public string PitcherName { get; set; }
        public string BadgeName { get; set; }
        public int? NewStatus { get; set; }
        public string NewMessage { get; set; }
    }
}
