using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Speed;

    Transform[] Points;
    int currentPoint = 0;
    GameObject hp;
    GameController gameController;
    void Update()
    {
        if (currentPoint < Points.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[currentPoint].position, Time.deltaTime * Speed);
            transform.LookAt(Points[currentPoint].position);
            if (Vector3.Distance(transform.position, Points[currentPoint].position) < 0.5f)
            {
                currentPoint++;
            }
        }
        if (hp.GetComponent<HpBar>().CurrentHp <= 0)
        {
            gameController.RewardKillEnemy();
            Destroy(gameObject);
            Destroy(hp);
        }
    }

    public void SetPoints(Transform[] points)
    {
        Points = points;
    }

    public void SetObjectHp(GameObject hp)
    {
        this.hp = hp;
    }

    public GameObject GetObjectHp()
    {
        return hp;
    }

    public void SetGameController(GameController gameController)
    {
        this.gameController = gameController;
    }

    private void OnMouseDown()
    {
        FindObjectOfType<UITower>().SetTargetCurrentTower(gameObject.transform);
    }
}
