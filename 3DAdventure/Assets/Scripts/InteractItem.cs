using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class InteractItem : MonoBehaviour
{

    public Image interactIcon;
    public CanvasGroup interactPage;
    public GameObject curInteractGameObject;

    public bool IsOpen = false;

    float wait = 3;


    public void InteractInvestigateItem()
    {
        interactIcon.gameObject.SetActive(true);
        ToggleCursor();
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
    }


    public void OnInteractItemInput(InputAction.CallbackContext context)
    {
        if (interactIcon.gameObject.activeSelf)
        {
            if (IsOpen == false)
            {
                StopAllCoroutines();
                StartCoroutine(InteractPageOpen());
            }
        }

        else
        {
            Debug.Log("조사할 대상이 없습니다.");
        }
    }


    public IEnumerator InteractPageOpen()
    {
        //Canvas Group으로 수정

        IsOpen = true;

        interactPage.gameObject.SetActive(true);

        float i = 1f;
        interactPage.alpha = 1f;

        yield return new WaitForSecondsRealtime(wait);

        for (i = 1f; i >= 0f; i -= 0.1f)
        {
            interactPage.alpha = i;

            yield return null;
        }

        interactPage.gameObject.SetActive(false);
        interactPage.alpha = 1f;

        IsOpen = false;

        yield break;
    }


    public void NotInteractInvestigateItem()
    {
        interactIcon.gameObject.SetActive(false);
    }
}