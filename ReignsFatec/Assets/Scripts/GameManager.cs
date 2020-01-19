using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool mobileBuild;
    //CITY 
    public static int cityFlorest;
    public static int cityPeople;
    public static int cityHealth;
    public static int cityMoney;
    public static int maxValue = 100;
    public int minValue = 0;
    //GameObjects
    public GameObject cardGameObject;
    public CardController mainCardController;
    public SpriteRenderer cardSpriteRenderer;
    public ResourceManager resourceManager;
    public Vector2 defaultPositionCard;
    public GameObject lostGame;
    //variables
    public float fMovingSpeed;
    public float fRotationSpeed;
    public float fSideMargin;
    public float fSideTrigger;
    public float divideValue;
    public float backgroundDivideValue;
    float alphaTest;
    public Color textColor;
    public Color actionBackgroundColor;
    public float fTransparency = .7f;
    public float fRotationCoefficient;
    Vector3 pos;
    //UI
    public TMP_Text display;
    public TMP_Text characterDialogue;
    public TMP_Text characterName;
    public TMP_Text actionQuoteLeft;
    public TMP_Text actionQuoteRight;
    public SpriteRenderer actionBackground;
    //Card variables
    public string direction;
    private string leftQuote;
    private string rightQuote;
    public Card currentCard;
    public Card testCard;
    //Substitution
    public bool isSubstituting = false;
    public Vector3 cardRotation; //default one
    public Vector3 currentRotation; //the current rotation
    public Vector3 initialRotation; //initial rotation of the card


    void Start()
    {
        NewCard();
        cityFlorest = 50;
        cityPeople = 50;
        cityHealth = 50;
        cityMoney = 50;
    }

    void UpdateDialogue()
    {
        Color emptyAlpha = textColor;
        emptyAlpha.a = 0;
        actionBackground.color = actionBackgroundColor;
        if (cardGameObject.transform.position.x < 0)
        {
            actionQuoteRight.color = emptyAlpha;
            actionQuoteLeft.color = textColor;
            actionQuoteLeft.text = leftQuote;
        }
        else
        {
            actionQuoteLeft.color = emptyAlpha;
            actionQuoteRight.color = textColor;
            actionQuoteRight.text = rightQuote;
        }
    }

    void Update()
    {
        if (mobileBuild)
        {
            if (Input.touchCount == 0)
            {
                mainCardController.isMouseOver = false;
            }
            else
            {
                mainCardController.isMouseOver = true;
            }

        }
        //Dialogue text handing
        textColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / divideValue, 1);
        actionBackgroundColor.a = Mathf.Min((Mathf.Abs(cardGameObject.transform.position.x) - fSideMargin) / backgroundDivideValue, fTransparency);
        if (cardGameObject.transform.position.x > fSideTrigger)
        {
            direction = "right";
            if (Input.GetMouseButtonUp(0) || (mobileBuild && Input.touchCount == 0))
            {
                currentCard.Right();
                NewCard();
            }
        }
        else if (cardGameObject.transform.position.x > fSideMargin)
        {
            direction = "right";
        }
        else if (cardGameObject.transform.position.x > -fSideMargin)
        {
            direction = "none";
            textColor.a = 0;
        }
        else if (cardGameObject.transform.position.x > -fSideTrigger)
        {
            direction = "left";
        }
        else
        {
            direction = "left";
            UpdateDialogue();
            if (Input.GetMouseButtonUp(0) || (mobileBuild && Input.touchCount == 0))
            {
                currentCard.Left();
                NewCard();
            }
        }
        UpdateDialogue();
        //Movement
        if (mobileBuild)
        {
            if (Input.touchCount > 0 && mainCardController.isMouseOver)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);
                cardGameObject.transform.position = pos;
                cardGameObject.transform.eulerAngles = new Vector3(0, 0, cardGameObject.transform.position.x * fRotationCoefficient);
            }
            else if (!isSubstituting)
            {
                cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, defaultPositionCard, fMovingSpeed);
                cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (isSubstituting)
            {
                cardGameObject.transform.eulerAngles = Vector3.MoveTowards(cardGameObject.transform.eulerAngles, cardRotation, fRotationSpeed);

            }
        }
        else
        {
            if (Input.GetMouseButton(0) && mainCardController.isMouseOver)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                cardGameObject.transform.position = pos;
                cardGameObject.transform.eulerAngles = new Vector3(0, 0, cardGameObject.transform.position.x * fRotationCoefficient);
            }
            else if (!isSubstituting)
            {
                cardGameObject.transform.position = Vector2.MoveTowards(cardGameObject.transform.position, defaultPositionCard, fMovingSpeed);
                cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (isSubstituting)
            {
                cardGameObject.transform.eulerAngles = Vector3.MoveTowards(cardGameObject.transform.eulerAngles, cardRotation, fRotationSpeed);

            }
        }
        
        //UI

        display.text = "" + alphaTest;

        characterDialogue.text = currentCard.dialogue;

        //rotating the card
        if (cardGameObject.transform.eulerAngles == cardRotation)
        {
            isSubstituting = false;
        }
    }

    public void LoadCard(Card card)
    {
        cardSpriteRenderer.sprite = resourceManager.sprites[(int)card.sprite];
        leftQuote = card.leftQuote;
        rightQuote = card.rightQuote;
        currentCard = card;
        characterDialogue.text = card.dialogue;
        characterName.text = card.cardName;
        //reset position of card
        cardGameObject.transform.position = defaultPositionCard;
        cardGameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        //initialize the rotation of card
        isSubstituting = true;
        cardGameObject.transform.eulerAngles = initialRotation;
    }

    public void NewCard()
    {
        if (cityFlorest < 0 || cityHealth < 0 || cityMoney < 0 || cityPeople < 0)
        {
            lostGame.SetActive(true);
            StartCoroutine(LostCount());
        }
        int rollDice = Random.Range(0, resourceManager.cards.Length);
        LoadCard(resourceManager.cards[rollDice]);
    }

    private IEnumerator LostCount()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
