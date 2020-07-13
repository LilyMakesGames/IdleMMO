using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "New Entity", order = 0)]
public class EntityStats : ScriptableObject
{
    public float MaxHealth;

    public Resource resource;
    public float Strength { get; set; }
    public float Agility { get; set; }
    public float Intelligence { get; set; }


    public float baseMaxHP;
    public float currentHP;
    public float baseStrength, baseAgility, baseIntelligence;
    public float regenHP;

    public float attackStat;
    public float armorStat;
    public float magicAttackStat;
    public float magicResistance;
    public float attackSpeed;


    public int teamID;

    public Sprite sprite;

    public List<BaseSkill> skills;

    public void Initialize()
    {
        MaxHealth = baseMaxHP;
        currentHP = MaxHealth;
        Strength = baseStrength;
        Agility = baseAgility;
        Intelligence = baseIntelligence;
    }

}
