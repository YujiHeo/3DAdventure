using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemSlot : MonoBehaviour
{
    public GameObject itemSlot;

    public void OnPopUp(InputAction.CallbackContext context)
    {
        PlayerController playerController = FindObjectOfType<PlayerController>();

        if (playerController != null)
        {
            itemSlot.SetActive(!itemSlot.activeSelf);
            Time.timeScale = 0;
            playerController.canLook = false;
        }

        
        if (!itemSlot.activeSelf)
        {
            Time.timeScale = 1;
            playerController.canLook = true;
        }   
        
    }
}
