using System;
using System.IO;

// ReSharper disable UnusedMember.Global

namespace OddifenceCore;

/// <summary>
///     <para> The global variables of this game.</para>
///     <para>
///         These are usually used to handle the underlying related logic. Moddings should avoid using them as much as
///         possible.
///     </para>
/// </summary>
public static class Vars
{
	/// <summary>
	///     <para>The Game Version code.</para>
	///     <para>
	///         The first number is the major version.
	///         It will be different when the game has major modifications.
	///         It should be prohibited reading files or mods across this version.
	///     </para>
	///     <para>
	///         The second one is the sub version.
	///         Although it means a non-significant change,
	///         it may still be compatibility issues when reading files or mods across the different version.
	///     </para>
	///     <para>
	///         The last one is the minor version
	///         This updates usually only fix bugs.
	///         There should be no issues with reading files or mods across this version.
	///     </para>
	/// </summary>
	public static readonly int[] VERSION = [0, 1, 0];

	/// <summary>
	///     <para> Get game data directory safely.</para>
	/// </summary>
	public static readonly string DATA_DIRECTORY =
		Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Oddifence");
}