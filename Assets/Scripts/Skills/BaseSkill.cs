using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : ScriptableObject
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

    public enum Effect
    {
        Damage,
        Heal,
        Status_Effect,

    }

    public int ID;
    public string skillName;
    public Sprite sprite;
    public float resourceCost;
    public float resourceGain;
    public float cooldown;
    float timeToNextCast;
    public float timerCast;
    public float castTime;
    public float effectMultiplier;
    public Target targetType;
    public List<CombatEntity> target;
    public CombatEntity user;
    public DamageType damageType;

    protected virtual float GetBaseStatFromUser(CombatEntity user)
    {
        return -1;
    }

    public virtual void OnCast(CombatEntity user, List<CombatEntity> target)
    {
        if(Time.time > timeToNextCast)
        {
            timerCast = castTime;
            this.user = user;
            this.target = target;
            user.StartCastSkill(this);
            Debug.Log($"{user} is casting {this.skillName}");
        }
        else
        {
            Debug.Log($"{this.skillName} is on cooldown");
        }
    }

    protected virtual void WhileCasting()
    {

    }

    protected virtual void EndCast()
    {
        timeToNextCast = Time.time + cooldown;
        DoSkill();
        user.EndCastSkill();
    }

    protected virtual void DoSkill()
    {

    }

    public virtual void Tick(float deltaTime)
    {
        timerCast -= deltaTime;
        if (timerCast <= 0)
        {
            EndCast();
        }
    }
}
