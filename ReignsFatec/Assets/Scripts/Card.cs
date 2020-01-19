using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Card : ScriptableObject
{
    //Basic card values
    public int cardID;
    public string cardName;
    public CardSprite sprite;
    public string dialogue;
    public string leftQuote;
    public string rightQuote;
    //Impact values
    //left
    public int kFlorestLeft;
    public int kPeopleLeft;
    public int kHealthLeft;
    public int kMoneyLeft;
    //right
    public int kFlorestRight;
    public int kPeopleRight;
    public int kHealthRight;
    public int kMoneyRight;
    public void Left()
    {
        GameManager.cityFlorest += kFlorestLeft;
        GameManager.cityPeople += kPeopleLeft;
        GameManager.cityHealth += kHealthLeft;
        GameManager.cityMoney += kMoneyLeft;
    }
    public void Right()
    {
        GameManager.cityFlorest += kFlorestRight;
        GameManager.cityPeople += kPeopleRight;
        GameManager.cityHealth += kHealthRight;
        GameManager.cityMoney += kMoneyRight;
    }
}
