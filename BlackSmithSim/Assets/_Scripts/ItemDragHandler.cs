using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragHandler : MonoBehaviour , IDragHandler,IEndDragHandler{


    private ItemSlot itemSlot;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        foreach (GameObject o in eventData.hovered)
        {
            IPlacable placable = o.GetComponent<IPlacable>();
            if (placable != null)
            {
                itemSlot.AddItem(placable.Replace(itemSlot.item));
                return;
            }
        }
        
    }


    // Use this for initialization
    void Start () {
        itemSlot = GetComponentInParent<ItemSlot>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
