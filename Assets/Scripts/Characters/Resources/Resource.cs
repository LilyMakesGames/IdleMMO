using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource",menuName = "New Resource")]
public class Resource : ScriptableObject
{
    public float maxValue;
    public float currentValue;
    public float regenResource;


    public void AddResource(float value)
    {
        currentValue += value;
        if(currentValue > maxValue)
        {
            currentValue = maxValue;
        }
    }

    public void RemoveResource(float value)
    {
        currentValue -= value;
        if(currentValue < 0)
        {
            currentValue = 0;
        }
    }

}
