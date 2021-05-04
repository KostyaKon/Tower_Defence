using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField]
    int initialСapital = 500;

    public int[] costTawers;
    public Text moneyText;

    void Update()
    {
        moneyText.text = "Money: " + initialСapital.ToString();
    }

    /// <summary>
    /// checking the availability of money for the selected tower
    /// </summary>
    /// <param name="numberTower">tower number listed</param>
    /// <returns></returns>
    public bool IsHaveMoneyOnTower(int numberTower)
    {
        if(numberTower >=0 && costTawers.Length > numberTower)
        {
            if (initialСapital >= costTawers[numberTower])
                return true;
        }
        return false;
    }

    /// <summary>
    /// checking the sufficiency of money
    /// </summary>
    /// <param name="countMoney">purchase value</param>
    /// <returns></returns>
    public bool IsMoney(int countMoney)
    {
        return (initialСapital >= countMoney) ? true : false;
    }

    public void BuyTower(int numberTower)
    {
        initialСapital -= costTawers[numberTower];
    }

    /// <summary>
    /// change the amount of player money
    /// </summary>
    /// <param name="money">sum</param>
    public void AddMoney(int money)
    {
        initialСapital += money;
    }
}
