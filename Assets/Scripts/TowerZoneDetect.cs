using UnityEngine;

public class TowerZoneDetect : MonoBehaviour
{
    public TowerController tower;

    bool lockEnemy;
    GameObject currentTarget;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !lockEnemy)
        {
            tower.SetTarget(other.gameObject.transform);
            currentTarget = other.gameObject;
            lockEnemy = true;
        }
    }
    void Update()
    {
        if (!currentTarget)
        {
            lockEnemy = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && other.gameObject == currentTarget)
        {
            lockEnemy = false;
        }
    }
}
