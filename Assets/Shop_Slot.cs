using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Slot : MonoBehaviour
{
    public int Item_Cost = 0;
    public string Item_Name = "";

    [SerializeField] private Text _item_cost_text;

    [SerializeField] private Hero_System _player;

    private void Update()
    {
        _item_cost_text.text = Item_Cost.ToString();
    }

    public void OnClickBuy()
    {
        if (_player.Coins >= Item_Cost)
        {
            _player.Coins -= Item_Cost;
            Debug.Log("Вы купили товар " + Item_Name);
        }
    }
}
