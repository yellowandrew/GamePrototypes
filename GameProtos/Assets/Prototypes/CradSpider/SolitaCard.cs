using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum CardSuit
{
    Heart,
    Diamonds,
    Clubs,
    Spaders,
    Joker
}

public enum CardFace
{
    Ace,
    Deuce,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King

}


public class SolitaCard : MonoBehaviour
{
    string[] faces = new string[] {
        "Ace" ,
        "Deuce",
        "Three",
        "Four",
        "Five",
        "Six",
        "Seven",
       "Eight" ,
        "Nine",
        "Ten",
        "Jack",
        "Queen",
        "King"
    };

    string[] suits = new string[] { "Heart", "Diamonds", "Clubs", "Spaders" };
    public GameObject cardPrefab;
    public Sprite[] cardSprites;
    public List<Card> decks = new List<Card>();

    public List<Stack<Card>> slots = new List<Stack<Card>>();

    public Transform[] slotpositions;

    public Transform handPoint;


    public TextMeshPro numberText;
    public int cardCounter = 52;

    public Transform drawPoint;
    public AudioSource _audio;
   
    void Start()
    {
        cardCounter = 52;
        FullDecks();
         shuffle();

        for (int i = 0; i < slotpositions.Length; i++)
        {

            Stack<Card> stack = new Stack<Card>();
            for (int j = 0; j < 5; j++)
            {
                int r = Random.Range(0, 52);
                Card c = CreateCard(r);
               
                c.transform.parent = slotpositions[i];
                c.transform.localPosition = new Vector3(0, 1+0.1f*j, -0.08f*j);
                c.slotIndex = i;
                c.FaceDown();
                stack.Push(c);
            }
            stack.Peek().FaceUp();
            slots.Add(stack);
        }
    }
    void FullDecks()
    {
        for (int i = 0; i < 52; i++)
        {
            Card c = CreateCard(i);
            decks.Add(c);
        }

        foreach (var item in decks)
        {
            item.gameObject.SetActive(false);
        }
    }

     Card CreateCard(int i) {
        GameObject go = Instantiate(cardPrefab);
        Card c = go.GetComponent<Card>();
        c.FaceDown();
        c.face = faces[i % 13];
        c.suit = suits[i / 13];
        c.number = i % 13 + 1;
        c.SetSprite(cardSprites[i]);
        go.name = c.face + " of " + c.suit;
        go.transform.parent = transform;
        go.transform.position = new Vector3(i % 13, 0, i / 13);
        return c;
    }
    void shuffle()
    {
        int j = 0;
        Card c;
        for (int i = 0; i < 52; i++)
        {
            j = Random.Range(0, 52);
            c = decks[i];
            decks[i] = decks[j];
            decks[j] = c;
        }
    }


   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // shuffle();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           //int i = Random.Range(0, 52);
           // Card c = decks[i];
           //   last = c.transform.position;
           // c.FaceUp();
           // c.transform.position = new Vector3(6, 0, -2);

           // Debug.Log("draw -> "+c.ToString());
           // Debug.Log(c.Prev()+"<->"+c.Next());
        }
    }

    public Card lastCard = null;
    public void DrawCard() {
        _audio.PlayOneShot(_audio.clip);
        cardCounter--;
        numberText.text = cardCounter + "";
        GameObject go = Instantiate(cardPrefab);
        Card c = go.GetComponent<Card>();
        c.face = decks[cardCounter].face;
        c.suit = decks[cardCounter].suit;
        c.number = decks[cardCounter].number;

        c.SetSprite(decks[cardCounter].sp);
        go.name = decks[cardCounter].name;
        go.transform.parent = drawPoint;
        go.transform.localPosition = Vector3.zero;
        c.FaceUp();
        
        go.transform.DOMove(handPoint.position, 0.25f).SetDelay(0.25f).OnComplete(()=> {
            if (lastCard != null)
            {
                Destroy(lastCard.gameObject);
               
            }
            lastCard = c;
        });

       
    }


    public bool IsGameover() {
        foreach (var s in slots)
        {
            if (s.Count > 0) return false;
          
        }

        return true;
    }
    public void CheckLink(Card card) {
        _audio.PlayOneShot(_audio.clip);
        if (lastCard&& card.Next()==lastCard.number || card.Prev()== lastCard.number)
        {

            card.transform.DOMoveY(1, 0.25f).OnComplete(()=> {
                card.transform.DOMove(handPoint.position, 0.75f).OnComplete(() => {
                    Destroy(lastCard.gameObject);
                    lastCard = card;
                    slots[card.slotIndex].Pop();
                    slots[card.slotIndex].Peek().FaceUp();
                    card.slotIndex = -1;
                    card.transform.parent = drawPoint;
                    if (IsGameover())
                    {
                        showOverPanel();
                    }
                });

            });
        
        }
    }

    public GameObject overpanel;
    public void showOverPanel() {
        overpanel.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
}
