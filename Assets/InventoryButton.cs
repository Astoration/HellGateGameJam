using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour {
    private void OnMouseUpAsButton()
    {
        if (GameObject.Find("PopupSchedule") != null || GameObject.Find("EventPopup") != null) return;
        PopupInventory.Instantiate().Init();
    }
}
