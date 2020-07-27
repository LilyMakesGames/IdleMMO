using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{

    public List<BaseSkill> skillsOnHotbar;

    protected override void StartInit()
    {
        base.StartInit();

        skillsOnHotbar = new List<BaseSkill>(16);
        foreach (BaseSkill skill in entity.entityStats.skills)
        {
            skillsOnHotbar.Add(Instantiate(skill));
        }
    }

    // Update is called once per frame
    public override void Tick(float deltaTime)
    {
        base.Tick(deltaTime);

        switch (entity.currentState)
        {
            case CombatEntity.CurrentState.Idle:
                if (Input.GetButtonDown("Skill 1"))
                {
                    CastSkill(entity.GetSkills()[0]);
                }
                break;
            case CombatEntity.CurrentState.Casting:
                break;
            case CombatEntity.CurrentState.Stunned:
                break;
            default:
                break;
        }
    }

    public override void SetTarget(CombatEntity target)
    {
        if (target.TeamID == entity.TeamID)
        {
            currentTargetAlly = target;
        }
        else
        {
            currentTargetEnemy = target;
            CombatManager.instance.targetCircle.transform.position = target.gameObject.transform.position;
        }   
    }

    protected override List<CombatEntity> FindTarget(BaseSkill skill)
    {
        List<CombatEntity> targets = new List<CombatEntity>();
        switch (skill.targetType)
        {
            case BaseSkill.Target.Self:
                targets.Add(entity);
                break;
            case BaseSkill.Target.Enemy:
                if (currentTargetEnemy == null)
                {
                    SetTarget(CombatManager.instance.EnemiesOnScreen[Random.Range(0, CombatManager.instance.EnemiesOnScreen.Count)]);
                }
                targets.Add(currentTargetEnemy);
                break;
            case BaseSkill.Target.Ally:
                if (currentTargetAlly == null)
                {
                    targets.Add(entity);
                }
                else
                {
                    targets.Add(currentTargetAlly);
                }
                break;
            default:
                return null;
        }

        return targets;
    }

    public void DeselectEnemyTarget()
    {
        currentTargetEnemy = null;
    }

    protected override void CastSkill(BaseSkill skill)
    {
        entity.CastSkill(skill, FindTarget(skill));
    }
}
