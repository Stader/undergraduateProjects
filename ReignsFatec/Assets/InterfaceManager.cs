using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    //Card
    public GameManager gameManager;
    public GameObject card;
    //UI Icons
    public Image cityFlorest;
    public Image cityPeople;
    public Image cityHealth;
    public Image cityMoney;

    //UI Impact
    public Image cityFlorestImpact;
    public Image cityPeopleImpact;
    public Image cityHealthImpact;
    public Image cityMoneyImpact;
    void Update()
    {
        //UI Icons
        cityFlorest.fillAmount = (float) GameManager.cityFlorest / GameManager.maxValue;
        cityPeople.fillAmount = (float)GameManager.cityPeople / GameManager.maxValue;
        cityHealth.fillAmount = (float)GameManager.cityHealth / GameManager.maxValue;
        cityMoney.fillAmount = (float) GameManager.cityMoney / GameManager.maxValue;
        //UI impact icon
        //Right
        if (gameManager.direction == "right")
        {
            if (gameManager.currentCard.kFlorestRight != 0)
                cityFlorestImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kPeopleRight != 0)
                cityPeopleImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kHealthRight != 0)
                cityHealthImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kMoneyRight != 0)
                cityMoneyImpact.transform.localScale = new Vector3(1, 1, 0);
        }
        //Left
        else if (gameManager.direction == "left")
        {
            if(gameManager.currentCard.kFlorestLeft!=0)
                cityFlorestImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kPeopleLeft != 0)
                cityPeopleImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kHealthLeft != 0)
                cityHealthImpact.transform.localScale = new Vector3(1, 1, 0);
            if (gameManager.currentCard.kMoneyLeft != 0)
                cityMoneyImpact.transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            cityFlorestImpact.transform.localScale = new Vector3(0, 0, 0);
            cityPeopleImpact.transform.localScale = new Vector3(0, 0, 0);
            cityHealthImpact.transform.localScale = new Vector3(0, 0, 0);
            cityMoneyImpact.transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
