using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Entity : MonoBehaviour, ITargetable
{
    public EntityBaseStats entityBaseStats;
    public EntityData entityStats;
    SpriteRenderer spriteRenderer;
    BoxCollider2D spriteCollider;
    
    protected List<BaseSkill> skills = new List<BaseSkill>();

    List<Object> onReceiveDamage;
    List<Object> onReceiveHeal;
    List<Object> onHeal;

    List<Object> onUseSkill;
    List<Object> onReceiveStatusEffect;


    public virtual void Start()
    {
        entityStats = new EntityData();
        entityStats.Initialize(entityBaseStats);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteCollider = GetComponent<BoxCollider2D>();
        if(entityBaseStats.sprite != null)
        {
            spriteRenderer.sprite = entityBaseStats.sprite;
            spriteCollider.size = spriteRenderer.sprite.bounds.size;
        }
        
    }

    public virtual void CastSkill(BaseSkill skill, List<ITargetable> target)
    {
        skill.Cast(this, target);
    }

    public List<BaseSkill> GetSkills()
    {
        return skills;
    }

    public virtual void ReceiveDamage(float damage, DamageType damageType)
    {
        Debug.Log($"{gameObject.name} received {damage} damage");
        switch (damageType)
        {
            case DamageType.Physical:
                entityStats.currentHP -= (damage * (100/(100 + entityStats.armorStat)));
                break;
            case DamageType.Magical:
                entityStats.currentHP -= (damage * (100 / (100 + entityStats.magicResistance)));
                break;
        }
        if(entityStats.currentHP <= 0)
        {
            OnDeath();
        }
    }

    public virtual void ReceiveHeal(float healValue)
    {
        entityStats.currentHP += healValue;
    }

    

    protected void UpdateSprite()
    {
        if (entityBaseStats.sprite != null)
        {
            spriteRenderer.sprite = entityBaseStats.sprite;
            spriteCollider.size = spriteRenderer.sprite.bounds.size;
        }
    }

    private void OnMouseDown()
    {
        CombatManager.instance.PlayerSelectTarget(this);
    }

    public virtual void OnDeath()
    {
    }
}
