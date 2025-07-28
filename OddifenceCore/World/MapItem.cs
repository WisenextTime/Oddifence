namespace OddifenceCore.World;

public class MapItem
{
	public enum ItemType
	{
		Info,Spawner,Foundation,Effector,Teleport,Tower
	}
	public (int X, int Y) Position = (0, 0);
	public ItemType Type = ItemType.Info;
	public string Content = "None";
}