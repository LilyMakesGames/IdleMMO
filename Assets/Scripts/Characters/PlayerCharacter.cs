using System.Collections;
using System.Collections.Generic;
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
        entityStats.teamID = 0;
        entityStats.Initialize();
    }

    void Update()
    {

    }

    public override void CastSkill(BaseSkill skill, List<ITargetable> target)
    {
        skill.Cast(this, target);
    }
}
