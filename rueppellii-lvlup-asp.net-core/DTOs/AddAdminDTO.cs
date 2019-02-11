namespace rueppellii_lvlup_asp.net_core.Dtos
{
    public class AddAdminDto
    {
        public double Version { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public int[] Levels { get; set; }
    }
}
