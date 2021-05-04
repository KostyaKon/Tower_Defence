using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour {

	public int CurrentHp = 30; 

	GameObject enemy;

	public void Dmg (int DMGcount) 
	{
        CurrentHp -= DMGcount;
	}

    public void SetEnemy(GameObject enemy)
    {
        this.enemy = enemy;
    }
	void Update () {
		GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(enemy.transform.position);
		GetComponent<Text>().text = CurrentHp.ToString();
	}
}
