using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
	GameObject inventoryPanel;
	GameObject slotPanel;
	ItemDatabase database;
	public GameObject inventorySlot;
	public GameObject inventoryItem;

	private int slotAmount;
	public List<Item> items = new List<Item>();
	public List<GameObject> slots = new List<GameObject>();
	Dictionary<int, GameObject> invenItemSlot = new Dictionary<int, GameObject>();

	void Start()
	{
		database = GetComponent<ItemDatabase>();
		slotAmount = 8;
		inventoryPanel = GameObject.Find("InventoryPanel");
		slotPanel = inventoryPanel.transform.Find("SlotPanel").gameObject;
		for (int i = 0; i < slotAmount; i++)
		{
			items.Add(new Item());
			slots.Add(Instantiate(inventorySlot));
			slots[i].GetComponent<Slot>().id = i;
			slots[i].transform.SetParent(slotPanel.transform);
		}

	}

	void Update()
	{
		
	}

	public void AddItem(int id)
	{
		Item itemToAdd = database.FetchItemById(id);
		if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
		{
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].Id == id)
				{
					ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
					data.amount++;
					data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
					break;
				}
			}
		}
		else
		{
			for (int i = 0; i < items.Count; i++)
			{
				if (items[i].Id == -1)
				{
					items[i] = itemToAdd;
					GameObject itemObj = Instantiate(inventoryItem);
					itemObj.GetComponent<ItemData>().item = itemToAdd;
					itemObj.GetComponent<ItemData>().slotId = i;
					itemObj.transform.SetParent(slots[i].transform);
					itemObj.transform.position = slots[i].transform.position;	
					itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
					itemObj.name = "Item: " + itemToAdd.Title;
					slots[i].name = "Slot: " + itemToAdd.Title;
					invenItemSlot[id] = itemObj;
					break;
				}
			}
		}
	}

	public void PutBackItem(int id)
	{
		Item itemToPutBack = database.FetchItemById(id);
		if(CheckIfItemIsInInventory(itemToPutBack))
		{
			for(int i = 0 ; i < items.Count ; i++)
			{
				if(items[i].Id == id && invenItemSlot.ContainsKey(id))
				{
					Destroy(invenItemSlot[id]);
					items[i] = new Item();
				}
			}
		}
	}

	bool CheckIfItemIsInInventory(Item item)
	{
		for (int i = 0; i < items.Count; i++)
		{
			if (items[i].Id == item.Id)
			{
				return true;
			}
		}

		return false;
	}

}
