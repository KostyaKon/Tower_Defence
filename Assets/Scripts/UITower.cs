using UnityEngine;
using UnityEngine.UI;

public class UITower : MonoBehaviour
{
    public Text levelTower;
    public int costUpLevel = 60;

    GameObject currentTowerOnScene;
    Money money;
    void Start()
    {
        money = GetComponent<Money>();
    }

    public void SetCurrentTower(GameObject tower)
    {
        currentTowerOnScene = tower;
        levelTower.text = "Tower Level: " + currentTowerOnScene.GetComponent<TowerController>().GetLevel().ToString();
    }

    public void DestroyTower()
    {
        if (currentTowerOnScene)
            Destroy(currentTowerOnScene);
    }

    public void UpLevelTower()
    {
        if (currentTowerOnScene)
        {
            if (money.IsMoney(costUpLevel))
            {
                TowerController tc = currentTowerOnScene.GetComponent<TowerController>();
                tc.UpLevel();
                levelTower.text = "Tower Level: " + tc.GetLevel().ToString();
                money.AddMoney(-costUpLevel);
            }
        }
    }

    /// <summary>
    /// set a new target for the selected tower
    /// </summary>
    /// <param name="target">new target</param>
    public void SetTargetCurrentTower(Transform target)
    {
        currentTowerOnScene.GetComponent<TowerController>().SetTarget(target);
    }
}
