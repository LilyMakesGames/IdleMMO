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
        entityBaseStats.teamID = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnDeath()
    {
        CombatManager.instance.PlayerCharacterEarnEXP(entityStats.xpOnDeath);
        CombatManager.instance.SpawnEnemy(this);
    }

    public void SetEnemy(EntityBaseStats enemyBaseStats)
    {
        entityBaseStats = enemyBaseStats;
        entityStats.Initialize(enemyBaseStats);
        UpdateSprite();
    }
}
