using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        CombatManager.instance.enemiesOnScreen.Add(this);
        entityStats.teamID = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnemy(EntityStats enemyStats)
    {
        entityStats = enemyStats;
        enemyStats.Initialize();
        UpdateSprite();
    }
}
