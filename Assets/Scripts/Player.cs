using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Vegetables { None, Lettuce, Tomato, Onion }
public class Player : MonoBehaviour
{
    public VegetableWorldObj[] vegetables = new VegetableWorldObj[2]; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public struct VegetableWorldObj
{
    public SpriteRenderer spriteRend;
    public Vegetables vegetable;

    public void AddVegetable(Vegetables _veg)
    {
        Sprite _sprite = null;
        switch (_veg)
        {
            case Vegetables.None:
                break;
            case Vegetables.Lettuce:
                _sprite = GameManager.instance.lettuceSprite;
                break;
            case Vegetables.Tomato:
                _sprite = GameManager.instance.tomatoSprite;
                break;
            case Vegetables.Onion:
                _sprite = GameManager.instance.onionSprite;
                break;
        }
        spriteRend.sprite = _sprite;
        vegetable = _veg;
    }

    public void RemoveVegetable()
    {
        spriteRend.sprite = null;
        vegetable = Vegetables.None;
    }
}
