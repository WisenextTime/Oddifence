using System.Collections.Generic;

namespace OddifenceCore.World;

public class MapRule
{
	public bool LockedDefaultTower { get; set; } = false;
	public List<string> Towers = [];
	/// <summary>
	/// Disabled when zero.
	/// </summary>
	public int OverrideMaxHealth { get; set; } = 0;
	public Dictionary<string,float> GlobalEffects { get; set; } = new();
}