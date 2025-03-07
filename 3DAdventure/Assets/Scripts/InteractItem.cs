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
            Debug.Log("������ ����� �����ϴ�.");
        }
    }


    public IEnumerator InteractPageOpen()
    {
        //Canvas Group���� ����

        IsOpen = true;

        interactPage.gameObject.SetActive(true);

        //curInteractGameObject = hit.collider.gameObject;

        Color originalColor = interactPage.color; //originalColor������ interactPage ������ ����.
        Color tempColor = originalColor; //tempColor�� originalColor�� ����.

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

        //�ݺ��� �Ẹ��

        interactPage.gameObject.SetActive(false);
        interactPage.color = originalColor; //���� ������ interactPage�� ���Ҵ�.

        IsOpen = false;

        yield break;
    }


    public void NotInteractInvestigateItem()
    {
        interactIcon.gameObject.SetActive(false);
    }
}