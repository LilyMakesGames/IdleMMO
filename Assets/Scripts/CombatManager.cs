using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatManager : MonoBehaviour
{
    UIManager uiManager;

    [SerializeField] Map currentMap;

    public static CombatManager instance;

    public GameObject combatEntityPrefab;
    public GameObject playerEntityPrefab;

    [SerializeField] GameObject[] enemyPositionsOnWorld;

    public List<CombatEntity> EnemiesOnScreen
    {
        get
        {
            return teams[1];
        }
    }

    public GameObject targetCircle;

    List<CombatEntity> entitiesInCombat = new List<CombatEntity>(16);

    List<CombatEntity>[] teams = new List<CombatEntity>[2] { new List<CombatEntity>(8), new List<CombatEntity>(8) };

    List<Controller> controllers = new List<Controller>(16);
    PlayerController playerController;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        uiManager = GetComponent<UIManager>();
    }

    private void Update()
    {
        for (int i = 0; i < controllers.Count; i++)
        {
            controllers[i].Tick(Time.deltaTime);
        }
    }

    public void StartCombat()
    {
        SpawnPlayer(GameManager.instance.playerCharacter);

        var enemyParty = currentMap.spawnPool[Random.Range(0, currentMap.spawnPool.Length)];

        for (int i = 0; i < enemyParty.enemies.Length; i++)
        {
            SpawnEntity(enemyParty.enemies[i], i);
        }

    }

    public void SpawnEntity(CharacterBaseStats baseStats, int position)
    {
        GameObject gObj = Instantiate(combatEntityPrefab,enemyPositionsOnWorld[position].transform.position,Quaternion.identity);
        CombatEntity entity = gObj.GetComponent<CombatEntity>();
        EntityData entityData = new EntityData(baseStats);
        entity.Initialize(entityData);
        teams[entity.TeamID].Add(entity);
        entitiesInCombat.Add(entity);
        controllers.Add(gObj.GetComponent<Controller>());
    }

    public void SpawnPlayer(PlayerCharacter playerChar)
    {
        GameObject gObj = Instantiate(playerEntityPrefab);
        CombatEntity entity = gObj.GetComponent<CombatEntity>();
        entity.Initialize(playerChar.entityStats);
        teams[entity.TeamID].Add(entity);
        entitiesInCombat.Add(entity);
        Controller controller = gObj.GetComponent<Controller>();
        if (controller is PlayerController pController)
        {
            playerController = pController;
            uiManager.currentMainCharacter = entity;
        }
        controllers.Add(controller);
    }

    public void DespawnEnemy(CombatEntity enemy)
    {
        teams[enemy.TeamID].Remove(enemy);
    }

    public void PlayerSelectTarget(CombatEntity target)
    {
        if (target.TeamID == 0)
        {
            playerController.currentTargetAlly = target;
        } else
        {
            playerController.currentTargetEnemy = target;
        }
        uiManager.playerSelectedTarget(target);
        uiManager.UpdateTargetInfo();
    }

    public void DeselectPlayerEnemyTarget()
    {
        playerController.currentTargetEnemy = null;

        uiManager.playerSelectedTarget(null);
        uiManager.UpdateTargetInfo();
    }

    void PlayerCharactersDistributeExp(float exp)
    {
    }

    public IEnumerator WaitToSpawnEnemy(int seconds, CharacterBaseStats baseStats)
    {
        yield return new WaitForSeconds(seconds);
        //SpawnEntity(baseStats);
    }
}