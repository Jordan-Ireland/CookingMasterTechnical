using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    public Vegetables[] vegetables = new Vegetables[3];
    public bool beingUsed = false;

    public SpriteRenderer[] renderers = new SpriteRenderer[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (Input.GetKey(player.pm.interact) && !beingUsed)
        {
            beingUsed = true;
            if (player.vegetables[0].vegetable != Vegetables.None)
            {
                StartCoroutine(Chop(player));
            }else
            {
                Reset();
                player.hasSalad = true;
                player.saladRenderer.gameObject.SetActive(true);
            }
        }
    }

    public void Reset()
    {
        for (int i = 0; i < vegetables.Length; i++)
        {
            vegetables[i] = Vegetables.None;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        beingUsed = false;
    }

    IEnumerator Chop(Player _player)
    {
        _player.pm.canMove = false;
        bool added = AddVegetable(_player.vegetables[0].vegetable);
        if (added)
        {
            yield return new WaitForSeconds(1);
            _player.RemoveVegetable();
        }
        _player.pm.canMove = true;
        beingUsed = false;
        yield break;
    }

    bool AddVegetable(Vegetables _veg)
    {
        for (int i = 0; i < vegetables.Length; i++)
        {
            if(vegetables[i] == Vegetables.None)
            {
                vegetables[i] = _veg;
                renderers[i].sprite = GameManager.instance.GetSprite(_veg);
                return true;
            }
        }
        return false;
    }
}
