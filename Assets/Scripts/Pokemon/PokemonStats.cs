using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new pokemon")]

public class PokemonStats : ScriptableObject
{
    [SerializeField] string name;
	
	[TextArea]
	[SerializeField] string description;
	
	
	[SerializeField] Sprite frontSprite;
	[SerializeField] Sprite backSprite;
	
	[SerializeField] PokemonType type1;
	[SerializeField] PokemonType type2;
	
	//Stats
	[SerializeField] int maxHP;	
	[SerializeField] int attack;
	[SerializeField] int defense;
	[SerializeField] int speed;
	
	//Getters and setters
	
	public string Name {
		get { return name; } 
	}
	
	public string Description {
		get { return description; } 
	}
	
	public int MaxHP {
		get { return maxHP; } 
	}
	
	public int Attack {
		get { return attack; } 
	}
	
	public int Defense {
		get { return defense; } 
	}
	
	public int Speed {
		get { return speed; } 
	}
	
}

public enum PokemonType
{
	None,
	Normal,
	Fire,
	Water,
	Rock
}