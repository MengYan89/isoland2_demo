using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName itemName;

    public void ItemClicked()
    {
        // ��Ʒ���������
        InventoryManager.Instance.AddItem(itemName);
        // ��ӵ�������������Ʒ
        this.gameObject.SetActive(false);
    }
}
