using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    public int hp;
    public int mp;
    public int attack;
    public int defense;
}

[System.Serializable]
public class Skill
{
    public string name;
    public int damage;
    public int mana_cost;
    public int cooldown;
    public string effect;
}

[System.Serializable]
public class Hero
{
    public int id;
    public string name;
    public string heroclass;
    public string element;
    public CharacterStats stats;
    public List<Skill> skills;
    public string sprite;
}

[System.Serializable]
public class HeroList
{
    public Hero[] heroes;
}
