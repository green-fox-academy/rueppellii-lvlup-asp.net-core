using rueppellii_lvlup_asp.net_core.DTOs;

namespace rueppellii_lvlup_asp.net_core.Containers
{
  public class ObjectContainer
  {
    public BadgeDto[] Badges { get; set; }

    public ObjectContainer()
    {
      Badges = new BadgeDto[3];
    }
  }
}
