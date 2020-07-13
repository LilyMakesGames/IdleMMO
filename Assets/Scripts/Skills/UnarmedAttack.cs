using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnarmedAttack : BaseSkill
{
    float baseDamage;

    protected override float GetBaseStatFromUser(Entity user)
    {
        return user.entityStats.attackStat;
    }

    protected override void OnCast()
    {
        WhileCasting();
    }
    protected override void WhileCasting()
    {
        EndCast();
    }


    protected override void EndCast()
    {
        DoSkill();
    }

    public override void Cast(Entity user, List<ITargetable> target)
    {
        this.user = user;
        this.target = target[0];
        OnCast();
    }



    protected override void DoSkill()
    {
        Debug.Log($"Hit");
        baseDamage = GetBaseStatFromUser(user);
        target.ReceiveDamage(baseDamage, DamageType.Physical);

    }
}
