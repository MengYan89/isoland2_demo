using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public ItemName requireItem;
    
    public bool isDone;

    public void CheckItem(ItemName itemName)
    {
        if (itemName == requireItem && !isDone)
        {
            isDone = true;
            // ʹ�������Ʒ,���Ƴ���Ʒ
            OnClickedAction();
            EventHandler.CallItemUsedEvent(itemName);
        }
    }

    /// <summary>
    /// Ĭ������ȷ����Ʒ�����ִ��
    /// </summary>
    protected virtual void OnClickedAction()
    {

    }

    public virtual void EmptyClicked()
    {
        Debug.Log("�յ�");
    }
}
