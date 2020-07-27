using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map",menuName = "New Map", order = 3)]
public class Map : ScriptableObject
{
    enum MapType
    {
        Overworld,
        Town,
        Dungeon
    }

    public EnemyParty[] spawnPool;
}
