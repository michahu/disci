using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public Equipment item;

	// Pickup item and trigger inventory/equipment addition
	public void Pickup () {
        
        Debug.Log("Picking up item.");
        bool wasPickedUp = Inventory.instance.Add(item);

        if (wasPickedUp)
            EquipmentManager.instance.Equip(item);
            Destroy(gameObject);
	}
}
