using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string face;
    public string suit;
    public int number;
    public SpriteRenderer spriteRenderer;
    public BoxCollider boxCollider;
    public Sprite sp;
    public int slotIndex = -1;

    SolitaCard solitaCard;
    void Start()
    {
        solitaCard = FindObjectOfType<SolitaCard>();
        
    }

    public int Prev() {
        int n = number-1;
        if (n <= 0) n = 13;
      
        return n;
    }

    public int Next() {
        int n = number+1;
        if (n >13) n = 1;
        return n;
    }

    public void Popup() {
        boxCollider.enabled = true;
    }

    public void SetSprite(Sprite sprite) {
        spriteRenderer.sprite = sprite;
        sp = sprite;
    }

    public void FaceUp() {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        Popup();
    }
    public void FaceDown()
    {
        transform.localEulerAngles = new Vector3(0,0,180);
        boxCollider.enabled = false;
    }

    private void OnMouseUpAsButton()
    {
        solitaCard.CheckLink(this);
    }

    public override string ToString()
    {
        return $"{face} of {suit}";
    }
}