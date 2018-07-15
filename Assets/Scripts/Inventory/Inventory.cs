using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public static Inventory instance;
	
	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}
		
		instance = this;
	}
	
	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 6;
	
	public List<GameObject> items = new List<GameObject>();
	
	public bool Add (GameObject item)
	{
		if (items.Count >= space)
		{
			Debug.Log("Not enough room.");
			return false;
		}
			
		items.Add(item);
			
		if (onItemChangedCallback != null)
		onItemChangedCallback.Invoke();
	    return true;
	}
	
	public void Remove (GameObject item)
	{
		items.Remove(item);
		
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}
}
