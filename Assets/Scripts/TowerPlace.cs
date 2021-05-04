using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public GameController gameController;
    public Vector3 offset;

    GameObject currentTower;
    bool empty;

    private void Start()
    {
        empty = true;
    }

    private void Update()
    {
        if (!empty && currentTower == null)
            empty = true;
    }
    void OnMouseDown()
    {
        if (empty && gameController.IsCanBuild())
        {
            currentTower = Instantiate(gameController.GetTower(), transform.position + offset, Quaternion.identity) as GameObject;
            gameController.BuyTower();
            empty = false;
        }
    }
}
