using System.Collections;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnBullet;
    public int dmg = 10;
    public float shootDelay;

    public Transform rotatingPartTower;

    Transform target;
    bool isShoot;
    UITower UITowerController;
    int levelTower;

    void Start()
    {
        UITowerController = FindObjectOfType<UITower>();
        levelTower = 1;
    }

    void Update()
    {
        if (target)
        {
            rotatingPartTower.transform.LookAt(target);
            if (!isShoot)
            {
                StartCoroutine(shoot());
            }
        }
    }

    IEnumerator shoot()
    {
        isShoot = true;
        yield return new WaitForSeconds(shootDelay);
        GameObject b = Instantiate(bullet, spawnBullet.position, Quaternion.identity) as GameObject;
        b.GetComponent<BulletController>().SetTarget(target);
        b.GetComponent<BulletController>().SetDamage(dmg);
        isShoot = false;
    }

    /// <summary>
    /// set a target for the tower
    /// </summary>
    /// <param name="target">new target</param>
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public int GetLevel()
    {
        return levelTower;
    }

    public void UpLevel()
    {
        levelTower++;
        dmg += (dmg / 5);
    }
    private void OnMouseDown()
    {
        UITowerController.SetCurrentTower(gameObject);
    }
}
