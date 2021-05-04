using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed;

    Transform target;
    int damage = 0;

    void Update()
    {
        if (target)
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);
        if (!target)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().GetObjectHp().GetComponent<HpBar>().Dmg(damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
