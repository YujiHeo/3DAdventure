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
    public Image interactPage;
    public GameObject curInteractGameObject;

    public bool IsOpen = false;

    float wait = 3;


    public void InteractInvestigateItem()
    {
        interactIcon.gameObject.SetActive(true);

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

        //curInteractGameObject = hit.collider.gameObject;

        Color originalColor = interactPage.color; //originalColor변수에 interactPage 색상값을 저장.
        Color tempColor = originalColor; //tempColor에 originalColor를 저장.

        tempColor.a = 1f;
        yield return new WaitForSecondsRealtime(wait);

        tempColor.a = 0.8f;
        interactPage.color = tempColor;
        yield return null;
        tempColor.a = 0.6f;
        interactPage.color = tempColor;
        yield return null;
        tempColor.a = 0.3f;
        interactPage.color = tempColor;
        yield return null;

        //반복문 써보기

        interactPage.gameObject.SetActive(false);
        interactPage.color = originalColor; //원래 색상값을 interactPage에 재할당.

        IsOpen = false;

        yield break;
    }


    public void NotInteractInvestigateItem()
    {
        interactIcon.gameObject.SetActive(false);
    }
}