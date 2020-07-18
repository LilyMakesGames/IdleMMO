using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map",menuName = "New Map")]
public class Map : ScriptableObject
{
    enum MapType
    {
        Overworld,
        Town,
        Dungeon
    }

    public List<EntityBaseStats> enemiesOnMap;
}
