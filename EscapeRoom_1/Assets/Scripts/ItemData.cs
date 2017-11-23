using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public Item item;
	public int amount;
	public int slotId;

	private Inventory inv;
	private Tooltip tooltip;
	private Vector2 offset;
	private OnHand onHand;

	void Start()
	{
		onHand = GameObject.Find("/FPSController/FirstPersonCharacter").GetComponent<OnHand>();
		inv = GameObject.Find("Inventory").GetComponent<Inventory>();
		tooltip = inv.GetComponent<Tooltip>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (item != null)
		{
			this.transform.SetParent(this.transform.parent.parent);
			this.transform.position = eventData.position - offset;
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (item != null)
		{
			this.transform.position = eventData.position - offset;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		this.transform.SetParent(inv.slots[slotId].transform);
		this.transform.position = inv.slots[slotId].transform.position;
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.Activate(item);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.Deactivate();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if(!onHand.isOnHand)
		{
			if(item.Title == "Key1")
			{
				inv.PutBackItem(0);
				onHand.obj1.transform.parent = onHand.fps.transform;
				onHand.obj1.transform.position = onHand.fps.transform.position + onHand.fps.transform.forward * 3f;
				onHand.obj1.SetActive(true);
				onHand.isOnHand = true;
			}
			if(item.Title == "Key2")
			{
				inv.PutBackItem(1);
				onHand.obj2.transform.parent = onHand.fps.transform;
				onHand.obj2.transform.position = onHand.fps.transform.position + onHand.fps.transform.forward * 3f;
				onHand.obj2.SetActive(true);
				onHand.isOnHand = true;
			}
			if(item.Title == "Torc")
			{
				inv.PutBackItem(2);
				onHand.torc.transform.parent = onHand.fps.transform;
				onHand.torc.transform.position = onHand.fps.transform.position + onHand.fps.transform.forward * 1f;
				onHand.torc.SetActive(true);
				onHand.isOnHand = true;
			}
		}
		tooltip.Deactivate();
		
    }
}
