using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToottipUI : MonoBehaviour
{
    public Text itemNameText;

    public void SetItem(ItemName itemName)
    {
        itemNameText.text = itemName switch
        {
            ItemName.Key => "一个钥匙",
            ItemName.Ticket => "一张船票",
            _ => ""
        };
    }

}
