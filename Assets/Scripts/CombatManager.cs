using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    public Map currentMap;

    public static CombatManager instance;
    public List<Enemy> enemiesOnScreen;
    public Controller playerController;
    public PlayerCharacter playerCharacter;


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

    public void SpawnEnemy(Enemy enemy)
    {
        enemy.SetEnemy(currentMap.enemiesOnMap[Random.Range(0, currentMap.enemiesOnMap.Count)]);
    }

    void FillEnemies()
    {
        foreach (var enemy in enemiesOnScreen)
        {
            SpawnEnemy(enemy);
        }
    }

    public void PlayerSelectTarget(Entity target)
    {
        playerController.SetTarget(target);
    }

    public void PlayerCharacterEarnEXP(float exp)
    {
        playerCharacter.EarnEXP(exp);
    }
}
