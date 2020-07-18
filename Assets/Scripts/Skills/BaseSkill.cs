using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : ScriptableObject
{
    public enum Target
    {
        Self,
        Enemy,
        All_Enemies,
        Ally,
        All_Allies,
        Global
    }

    public int ID;
    public float resourceCost;
    public float cooldown;
    public float castTime;
    public Target targetType;
    public ITargetable target;
    public Entity user;
    public DamageType damageType;

    protected abstract float GetBaseStatFromUser(Entity user);

    public abstract void Cast(Entity user, List<ITargetable> target);

    protected abstract void OnCast();

    protected abstract void WhileCasting();

    protected abstract void EndCast();

    protected abstract void DoSkill();

}
