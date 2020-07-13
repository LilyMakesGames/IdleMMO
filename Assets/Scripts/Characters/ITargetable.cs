using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetable 
{

    void ReceiveDamage(float damageValue, DamageType damageType);
    void ReceiveHeal(float healValue);

}
