using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Entity : MonoBehaviour, ITargetable
{
    public EntityStats entityStats;
    SpriteRenderer spriteRenderer;
    BoxCollider2D spriteCollider;
    #region
    //public float MaxHealth { get; set; }
    //public Resource Resource { get; set; }
    //public float Strength { get; set; }
    //public float Agility { get; set; }
    //public float Intelligence { get; set; }

    //public float AttackSpeed { get; set; } = 1;

    //float baseMaxHP;
    //float currentHP;
    //float baseStrength, baseAgility, baseIntelligence;
    //float regenHP;

    //public float attackStat;
    //float armorStat;
    //public float magicAttackStat;
    //float magicResistance;

    //protected int teamID;

    protected List<BaseSkill> skills = new List<BaseSkill>();
    #endregion

    public virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteCollider = GetComponent<BoxCollider2D>();
        if(entityStats.sprite != null)
        {
            spriteRenderer.sprite = entityStats.sprite;
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
    }

    public virtual void ReceiveHeal(float healValue)
    {
        entityStats.currentHP += healValue;
    }

    protected void UpdateSprite()
    {
        if (entityStats.sprite != null)
        {
            spriteRenderer.sprite = entityStats.sprite;
            spriteCollider.size = spriteRenderer.sprite.bounds.size;
        }
    }

    private void OnMouseDown()
    {
        CombatManager.instance.PlayerSelectTarget(this);
    }
}
