using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public Vegetables vegetableType;
    public Player player;

    private void Update()
    {
        if (player != null && Input.GetKeyUp(player.pm.interact) && !player.hasSalad)
        {
            for (int i = 0; i < player.vegetables.Length; i++)
            {
                if (player.vegetables[i].vegetable == Vegetables.None)
                {
                    player.vegetables[i].AddVegetable(vegetableType);
                    break;
                }
            }
        }
    }

    private void OnTriggerStay2D (Collider2D other)
    {
        player = other.GetComponent<Player>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player _player = other.GetComponent<Player>();
        if(player == _player)
        {
            player = null;
        }
    }
}
