using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : Interactable
{
    public SpriteRenderer[] sprites = new SpriteRenderer[3];
    public int saladWanted = -1;
    public bool isAngry = false;

    private void Start()
    {
        PickSalad();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && player.hasSalad && Input.GetKeyDown(player.pm.interact))
        {
            player.RemoveSalad();
            DeliverSalad();
            //add points
        }
    }

    void PickSalad()
    {
        for (int x = 0; x < sprites.Length; x++)
        {
            sprites[x].sprite = null;
        }
        saladWanted = Random.Range(0, SaladCombo.combos.Keys.Count);
        int i = 0;
        foreach (Vegetables ingredient in SaladCombo.combos[saladWanted])
        {
            sprites[i].sprite = GameManager.instance.GetSprite(ingredient);
            i++;
        }
    }

    void DeliverSalad()
    {
        if(player.currentSalad == saladWanted)
        {
            //plus points
            GameManager.AddScore(player.isPlayer1, 5);
            isAngry = false;
        }else
        {
            GameManager.AddScore(player.isPlayer1, -5);
            isAngry = true;
        }

        PickSalad();
    }
}
