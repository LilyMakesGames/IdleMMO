using UnityEngine;

public class PlayerCharacter
{
    Equipment headSlot;
    Equipment bodySlot;
    Equipment leftHandSlot;
    Equipment rightHandSlot;
    Equipment legsSlot;
    Equipment footSlot;

    Inventory inventory;

    public EntityData entityStats;
    public float currentExp;

    public PlayerCharacter(CharacterBaseStats baseStats)
    {
        entityStats = new EntityData(baseStats);
    }

    public void EarnEXP(float exp)
    {
        currentExp += exp;
        Debug.Log($"Level: {entityStats.level} \n EXP Atual: {currentExp} \n EXP para upar: {currentExp}");
        /*if (currentExp > entityStats.xpToLevel)
        {
            float aux = currentExp - entityStats.xpToLevel;
            currentExp = aux;
            entityData.level++;
            entityStats.xpToLevel = entityStats.level * 2; 
        }*/
    }
}
