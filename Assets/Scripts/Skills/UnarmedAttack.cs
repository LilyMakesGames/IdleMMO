using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "aaa", menuName = "Unarmed Attack")]
public class UnarmedAttack : BaseSkill
{
    float baseDamage;

    protected override float GetBaseStatFromUser(CombatEntity user)
    {
        return user.entityStats.attackStat;
    }

    protected override void EndCast()
    {
        base.EndCast();
    }

    protected override void DoSkill()
    {
        baseDamage = GetBaseStatFromUser(user);
        target[0].ReceiveDamage(baseDamage, DamageType.Physical);
    }
}
