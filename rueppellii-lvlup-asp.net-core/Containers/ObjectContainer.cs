using rueppellii_lvlup_asp.net_core.Dtos;

namespace rueppellii_lvlup_asp.net_core.Containers
{
  public class ObjectContainer
  {
    public LevelDto[] Badges { get; set; }

    public ObjectContainer()
    {
      Badges = new LevelDto[3];
    }
  }
}
