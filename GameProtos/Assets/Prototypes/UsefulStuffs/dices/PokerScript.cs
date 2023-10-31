using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PockerFace
{
    Ace = 1,
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

public enum PokerSuit
{

    Heart,
    Diamonds,
    Clubs,
    Spaders
}

[System.Serializable]
public class Poker
{
    public string face;
    public string suit;

}


public class PokerScript : MonoBehaviour
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

    string[] suits = new string[] { "Heart","Diamonds", "Clubs", "Spaders" };

    [SerializeField]
    public List<Poker> decks = new List<Poker>();
    void Start()
    {
        initDecks();
    }

    void initDecks() {
        for (int i = 0; i < 52; i++)
        {
            Poker poker = new Poker();
            poker.face = faces[i % 13];
            poker.suit = suits[i / 13];
            decks.Add(poker);
        }
    }

    void shuffle() {
        int j = 0;
        Poker p;
        for (int i = 0; i < 52; i++)
        {
            j = Random.Range(0, 52);
            p = decks[i];
            decks[i] = decks[j];
            decks[j] = p;
        }
    }

    void deal() {
        for (int i = 0; i < 52; i++)
        {
            Debug.Log(decks[i].face+" of "+decks[i].suit);
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shuffle();
            deal();
        }
    }
}
