using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public Card card;
    public TMP_Text tmp;
    private BoxCollider2D thisCard;
    public bool isMouseOver;
    private void Start()
    {
        thisCard = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnMouseOver()
    {
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        isMouseOver = false;
    }
    
}

public enum CardSprite
{
    MAN1,
    MAN2,
    MAN3,
    MAN4,
    MAN5,
    WOMAN1,
    WOMAN2,
    WOMAN3,
    WOMAN4,
    WOMAN5
}