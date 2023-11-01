using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    SolitaCard solitaCard;
    void Start()
    {
        solitaCard = FindObjectOfType<SolitaCard>();
    }

   
    void Update()
    {
        
    }

    private void OnMouseUpAsButton()
    {
        solitaCard.DrawCard();
    }
}
