using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetable : MonoBehaviour
{
    public Vegetables vegetableType;

    private void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Wroking");
        Player _player = other.GetComponent<Player>();

        for (int i = 0; i < _player.vegetables.Length; i++)
        {
            if (_player.vegetables[i].vegetable == Vegetables.None)
            {
                _player.vegetables[i].AddVegetable(vegetableType);
                break;
            }
        }
    }
}
