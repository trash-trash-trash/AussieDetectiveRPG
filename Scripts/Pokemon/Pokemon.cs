using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    PokemonStats _stats;
	int level;
	
	public Pokemon(PokemonStats pStats, int pLevel)
	{
		_stats = pStats;
		level = pLevel;
		
		
	}
	
	//"this is the formula pokemon games use"
	//ask mark?
	//will probably need tweaking
	//bulbapedia
	public int MaxHP{
		get { return Mathf.FloorToInt((_stats.Attack * level) / 100f) + 10; }
	}

	
	public int Attack{
		get { return Mathf.FloorToInt((_stats.Attack * level) / 100f) + 5; }
	}
	
	public int Defense{
		get { return Mathf.FloorToInt((_stats.Attack * level) / 100f) + 5; }
	}
	
	public int Speed{
		get { return Mathf.FloorToInt((_stats.Attack * level) / 100f) + 5; }
	}
	

	
}
