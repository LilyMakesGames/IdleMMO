using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class PlayerCharacter : Entity
{
    Equipment headSlot;
    Equipment bodySlot;
    Equipment leftHandSlot;
    Equipment rightHandSlot;
    Equipment legsSlot;
    Equipment footSlot;
    List<BaseItem> inventory;

    UnarmedAttack unarmedAttack;



    public override void Start()
    {
        base.Start();
        entityStats.teamID = 0;
        entityStats.Initialize(entityBaseStats);
    }

    void Update()
    {

    }

    public void EarnEXP(float exp)
    {
        entityStats.xpCurrent += exp;
        Debug.Log($"Level: {entityStats.level} \n EXP Atual: {entityStats.xpCurrent} \n EXP para upar: {entityStats.xpToLevel}");
        if(entityStats.xpCurrent > entityStats.xpToLevel)
        {
            float aux = entityStats.xpCurrent - entityStats.xpToLevel;
            entityStats.xpCurrent = aux;
            entityStats.level++;
            entityStats.xpToLevel = entityStats.level * 2; 
        }
    }

    public override void CastSkill(BaseSkill skill, List<ITargetable> target)
    {
        skill.Cast(this, target);
    }
}
