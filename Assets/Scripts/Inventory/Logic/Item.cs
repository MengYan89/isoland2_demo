using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName itemName;

    public void ItemClicked()
    {
        // 物品添加至背包
        InventoryManager.Instance.AddItem(itemName);
        // 添加到背包后隐藏物品
        this.gameObject.SetActive(false);
    }
}
