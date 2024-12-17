
using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwapper : MonoBehaviour
{

    public List<ItemDrag> items;
    public RectTransform currentItemBeingDragged;
    public RectTransform itemToSwapWith;
    private void Start()
    {
        PopulateTheItem();

    }

    private void Update()
    {
        if (currentItemBeingDragged != null)
        {
            SwapCurrentItemBeinDragged();
        }
    }
    public void PopulateTheItem()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            items.Add(transform.GetChild(i).GetComponent<ItemDrag>());
        }
    }
    public void SetCurrentItemBeinDragged(RectTransform currentItem)
    {
        currentItemBeingDragged = currentItem;
    }
    public void NullfyCurrentItemBeingDragged()
    {
        currentItemBeingDragged = null;
    }
    public void SwapCurrentItemBeinDragged()
    {
        foreach (var item in items)
        {
            if (item == currentItemBeingDragged)
            {
                continue;

            }
            RectTransformUtility.ScreenPointToLocalPointInRectangle(item.GetComponent<RectTransform>(), Input.mousePosition, Camera.main, out Vector2 localPoint);
            if (currentItemBeingDragged.rect.Contains(localPoint))
            {
                itemToSwapWith = item.GetComponent<RectTransform>();
                if (itemToSwapWith == null)
                {
                    return;
                }
                currentItemBeingDragged.transform.SetSiblingIndex(item.transform.GetSiblingIndex());
                itemToSwapWith = null;

            }
        }
    }
}
