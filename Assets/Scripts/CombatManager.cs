using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    public Map currentMap;

    public static CombatManager instance;
    public List<Enemy> enemiesOnScreen;
    public PlayerController playerController;

    List<List<Entity>> teams;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        FillEnemies();
    }

    void Update()
    {

    }

    void FillEnemies()
    {
        foreach (var enemy in enemiesOnScreen)
        {
            enemy.SetEnemy(currentMap.enemiesOnMap[Random.Range(0, currentMap.enemiesOnMap.Count)]);
        }
    }

    public void PlayerSelectTarget(Entity target)
    {
        playerController.SetTarget(target);
    }
}
