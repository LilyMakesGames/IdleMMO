using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    protected CombatEntity entity;
    protected List<BaseSkill> skills;

    public CombatEntity currentTargetEnemy, currentTargetAlly;

    private void Awake()
    {
        AwakeInit();
    }

    protected virtual void AwakeInit()
    {
        entity = GetComponent<CombatEntity>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartInit();
    }

    protected virtual void StartInit()
    {
        skills = entity.GetSkills();
    }

    // Update is called once per frame
    public virtual void Tick(float deltaTime)
    {
        if (entity != null)
        {
            entity.Tick(deltaTime);
        }
    }

    protected abstract void CastSkill(BaseSkill skill);
    protected abstract List<CombatEntity> FindTarget(BaseSkill skill);

    public abstract void SetTarget(CombatEntity target);

}
