using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public static Inventory instance;

	#region Singleton
	void Awake () {
		if (instance != null) {
			Debug.LogWarning("More than one instance of Inventory found. What did you do!");
			return;
		}
		instance = this;
	}
	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 20;

	public List<Item> items = new List<Item>();

	public bool Add (Item item) {
		if (!item.isDefaultItem) {
			if (items.Count >= space) {
				Debug.Log("Out of space.");
				return false;
			}
			items.Add(item);

			if (onItemChangedCallback != null) {
				onItemChangedCallback.Invoke();
			}
		}
		return true;
	}

	public void Remove (Item item) {
		items.Remove(item);

		if (onItemChangedCallback != null) {
			onItemChangedCallback.Invoke();
		}
	}

}
