namespace OddifenceCore.IO.World;

public class MapModel
{
	/// <summary>
	/// <para>The name of map.</para>
	/// <para>It can be empty but is not recommended.</para>
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// <para>The description of map.</para>
	/// <para>Support rich-text format. </para>
	/// </summary>
	public string Description { get; set; }

	/// <summary>
	/// <para>The width of map.</para>
	/// <para>Should NOT be zero.</para>
	/// </summary>
	public uint Width { get; set; }

	/// <summary>
	/// <para>The height of map.</para>
	/// <para>Should NOT be zero.</para>
	/// </summary>
	public uint Height { get; set; }

	/// <summary>
	/// <para>The map tiles data stored in text format.</para>
	/// </summary>
	public string Tiles { get; set; }
	
}