using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{

    protected Entity owner;
    protected List<BaseSkill> skills;

    public ITargetable currentTargetEnemy, currentTargetAlly;



    // Start is called before the first frame update
    void Start()
    {
        skills = owner.GetSkills();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected abstract void DoSkill(BaseSkill skill);
    protected abstract List<ITargetable> FindTarget(BaseSkill skill);

    public abstract void SetTarget(Entity target);
}
