using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{

    public RectTransform hand;
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private bool canClick;

    private ItemName currentItem;

    private bool holdItem;
    private void Update()
    {
        canClick = ObjectAtMousePosition();

        if (hand.gameObject.activeInHierarchy)
        {
            hand.position = Input.mousePosition;
        }

        if (InteractWithUI()) return;

        if (canClick && Input.GetMouseButtonDown(0))
        {
            //�����껥�����
            ClickAction(ObjectAtMousePosition().gameObject);
            
        }

    }

    private void OnEnable()
    {
        EventHandler.ItemSelectedEvent += OnItemSelectedEvent;
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemSelectedEvent -= OnItemSelectedEvent;
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
    }

    private void OnItemUsedEvent(ItemName obj)
    {
        currentItem = ItemName.None;
        holdItem = false;
        hand.gameObject.SetActive(false);
    }

    private void OnItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
    {
        holdItem = isSelected;
        if (isSelected)
        {
            currentItem = itemDetails.itemName;
        }
        hand.gameObject.SetActive(holdItem);
    }

    private void ClickAction(GameObject clickObject)
    {
        switch (clickObject.tag)
        {
            case "Teleport":
                var teleport = clickObject.GetComponent<Teleport>();
                teleport?.TeleportToScene();
                break;
            case "Item":
                var item = clickObject.GetComponent<Item>();
                item?.ItemClicked();
                break;
            case "Interactive":
                var interactive = clickObject.GetComponent<Interactive>();
                if (holdItem)
                {
                    interactive?.CheckItem(currentItem);
                }
                else
                {
                    interactive?.EmptyClicked();
                }
               
                break;
        }
    }

    // ����������Χ����ײ��
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);
    }

    private bool InteractWithUI()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }

        return false;
    }

}
