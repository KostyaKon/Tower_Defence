using UnityEngine;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// the number of enemies in the wave
    /// </summary>
    public int waveSize;
    public GameObject enemyPrefab;
    /// <summary>
    /// time between the appearance of enemies in the wave
    /// </summary>
    public float enemyInterval;
    public Transform spawnPoint;
    /// <summary>
    /// time between waves of enemies
    /// </summary>
    public float startTime;
    /// <summary>
    /// an array of points along which enemies are moving
    /// </summary>
    public Transform[] wayPoints;
    /// <summary>
    /// object displaying the number of lives of the enemy
    /// </summary>
    public GameObject hpPrefab;
    /// <summary>
    /// reward for a killed enemy
    /// </summary>
    public int rewardForTheEnemy = 20;
    public GameObject canvas;

    public GameObject[] TowersPrefab;

    int chosenTower;

    Money money;

    int enemyCount = 0;
    bool startWave = false;
    int HpEnemy;

    void Start()
    {
        chosenTower = 0;
        money = GetComponent<Money>();
        HpEnemy = hpPrefab.GetComponent<HpBar>().CurrentHp;
    }
    void Update()
    {
        SpawnWavesOfEnemies();
    }
    void SpawnEnemy()
    {
        enemyCount++;
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        enemy.GetComponent<EnemyController>().SetPoints(wayPoints);
        enemy.GetComponent<EnemyController>().SetGameController(this);
        GameObject hp = Instantiate(hpPrefab, enemy.transform.position, Quaternion.identity) as GameObject;
        hp.transform.SetParent(canvas.transform);
        hp.GetComponent<HpBar>().CurrentHp = HpEnemy;
        hp.GetComponent<HpBar>().SetEnemy(enemy);
        enemy.GetComponent<EnemyController>().SetObjectHp(hp);
    }

    void SpawnWavesOfEnemies()
    {
        if (enemyCount < waveSize && !startWave)
        {
            startWave = true;
            InvokeRepeating("SpawnEnemy", startTime, enemyInterval);
        }
        else if (enemyCount == waveSize)
        {
            CancelInvoke("SpawnEnemy");
            waveSize += 3;
            HpEnemy += 5;
            startWave = false;
            enemyCount = 0;
        }
    }

    /// <summary>
    /// remembers the number of the selected tower
    /// </summary>
    /// <param name="chosenTower">number of the selected tower in the list</param>
    public void SetChosenTower(int chosenTower)
    {
        this.chosenTower = chosenTower;
    }

    /// <summary>
    /// get the ordinal number of the tower in the list
    /// </summary>
    /// <returns>number of the tower in the list</returns>
    public int GetChosenTower()
    {
        return chosenTower;
    }

    /// <summary>
    /// get tower prefab from the list
    /// </summary>
    /// <returns>Prefab Tower</returns>
    public GameObject GetTower()
    {
        return TowersPrefab[chosenTower];
    }

    /// <summary>
    /// checking if there is enough money for the construction of the tower
    /// </summary>
    /// <returns></returns>
    public bool IsCanBuild()
    {
        return money.IsHaveMoneyOnTower(chosenTower);
    }

    /// <summary>
    /// deduct money for the installed tower
    /// </summary>
    public void BuyTower()
    {
        money.BuyTower(chosenTower);
    }

    /// <summary>
    /// get a reward for a caught enemy
    /// </summary>
    public void RewardKillEnemy()
    {
        money.AddMoney(rewardForTheEnemy);
    }
}
