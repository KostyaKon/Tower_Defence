using UnityEngine;
using UnityEngine.UI;

public class FinishController : MonoBehaviour
{
    public int HP = 100;
    public Text HPtext;

    public Text gameOver;
    public GameObject restart;

    void Start()
    {
        gameOver.enabled = false;
        restart.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        HPtext.text = "Base life: " + HP.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            HP -= 10;
            Destroy(other.GetComponent<EnemyController>().GetObjectHp());
            Destroy(other.gameObject);
            if(HP <= 0)
            {
                StopGame();
            }
        }
    }

    void StopGame()
    {
        Time.timeScale = 0;
        gameOver.enabled = true;
        restart.SetActive(true);
    }
}
