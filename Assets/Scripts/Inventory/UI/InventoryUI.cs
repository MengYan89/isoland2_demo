using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Button leftButton, rightButton;

    public SlotUI slotUI;

    public ToottipUI toottipUI;

    // ��Ʒ���
    public int currentIndex;

    private void OnEnable()
    {
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void OnDisable()
    {
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        if (itemDetails == null)
        {
            slotUI.SetEmpty();
            currentIndex = -1;
            leftButton.interactable = false;
            rightButton.interactable = false;
        } 
        else
        {
            leftButton.interactable = false;
            currentIndex = index;
            slotUI.SetItem(itemDetails);

            if (index > 0)
            {
                leftButton.interactable = true;
            } else if (index == -1)
            {
                rightButton.interactable = false;
            }
        }
    }

    /// <summary>
    /// ���Ұ�ťEvent�¼�
    /// </summary>
    /// <param name="amount"></param>
    public void SwitchItem(int amount)
    {
        var index = currentIndex + amount;

        if (index < currentIndex)
        {
            leftButton.interactable = false;
            rightButton.interactable = true;
        }
        else if (index > currentIndex)
        {
            leftButton.interactable = true;
            rightButton.interactable = false;
        }
        else // ����������������
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
        }

        EventHandler.CallChangeItemEvent(index);
    }
}
