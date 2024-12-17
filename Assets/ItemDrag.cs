using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform m_RectTransform;
    public ItemSwapper swapper;
    public HorizontalLayoutGroup horizontalLayoutGroup;
    private void Start()
    {
        m_RectTransform = GetComponent<RectTransform>();
        swapper = GetComponentInParent<ItemSwapper>();
        horizontalLayoutGroup = GetComponentInParent<HorizontalLayoutGroup>();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        horizontalLayoutGroup.enabled = false;
        swapper.NullfyCurrentItemBeingDragged();
        horizontalLayoutGroup.enabled = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       
        swapper.SetCurrentItemBeinDragged(m_RectTransform);
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_RectTransform.anchoredPosition += eventData.delta;
    }
   
}
