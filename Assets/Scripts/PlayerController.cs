using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{

    // Start is called before the first frame update
    void Start()
    {
        owner = GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoSkill(owner.entityStats.skills[0]);
        }
    }

    public void SetTarget(Entity target)
    {
        if(target.entityStats.teamID == owner.entityStats.teamID)
        {
            currentTargetAlly = target;
        }
        else
        {
            currentTargetEnemy = target;
        }
        Debug.Log(target);
    }

    protected override List<ITargetable> FindTarget(BaseSkill skill)
    {
        List<ITargetable> targets = new List<ITargetable>();
        switch (skill.targetType)
        {
            case BaseSkill.Target.Self:
                targets.Add(owner);
                break;
            case BaseSkill.Target.Enemy:
                targets.Add(currentTargetEnemy);
                break;
            case BaseSkill.Target.Ally:
                targets.Add(currentTargetAlly);
                break;
            default:
                return null;
        }

        return targets;
    }

    protected override void DoSkill(BaseSkill skill)
    {
        owner.CastSkill(skill, FindTarget(skill));
    }
}
