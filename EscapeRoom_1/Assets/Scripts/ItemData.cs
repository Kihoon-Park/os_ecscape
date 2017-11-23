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
	private OnHandTest onHandTest;

	void Start()
	{
		onHandTest = GameObject.Find("/FPSController/FirstPersonCharacter").GetComponent<OnHandTest>();
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
		if(!onHandTest.onHand)
		{
			if(item.Title == "Key1")
			{
				inv.PutBackItem(0);
				onHandTest.obj1.transform.parent = onHandTest.fps.transform;
				onHandTest.obj1.transform.position = onHandTest.fps.transform.position + onHandTest.fps.transform.forward * 3f;
				onHandTest.obj1.SetActive(true);
				onHandTest.onHand = true;
			}
			if(item.Title == "Key2")
			{
				inv.PutBackItem(1);
				onHandTest.obj2.transform.parent = onHandTest.fps.transform;
				onHandTest.obj2.transform.position = onHandTest.fps.transform.position + onHandTest.fps.transform.forward * 3f;
				onHandTest.obj2.SetActive(true);
				onHandTest.onHand = true;
			}
			if(item.Title == "Torc")
			{
				inv.PutBackItem(2);
				onHandTest.torc.transform.parent = onHandTest.fps.transform;
				onHandTest.torc.transform.position = onHandTest.fps.transform.position + onHandTest.fps.transform.forward * 1f;
				onHandTest.torc.SetActive(true);
				onHandTest.onHand = true;
			}
		}
		tooltip.Deactivate();
		
    }
}
