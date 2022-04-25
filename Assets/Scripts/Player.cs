using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Vegetables { None, Lettuce, Tomato, Onion }
public class Player : MonoBehaviour
{
    public VegetableWorldObj[] vegetables = new VegetableWorldObj[2];
    public PlayerMovement pm;
    public bool hasSalad = false;
    public SpriteRenderer saladRenderer;

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveVegetable()
    {
        vegetables[0].RemoveVegetable();
        vegetables[0].AddVegetable(vegetables[1].vegetable);
        vegetables[1].RemoveVegetable();
    }
}

[System.Serializable]
public struct VegetableWorldObj
{
    public SpriteRenderer spriteRend;
    public Vegetables vegetable;

    public void AddVegetable(Vegetables _veg)
    {
        Sprite _sprite = GameManager.instance.GetSprite(_veg);
        spriteRend.sprite = _sprite;
        vegetable = _veg;
    }

    public void RemoveVegetable()
    {
        spriteRend.sprite = null;
        vegetable = Vegetables.None;
    }
}
