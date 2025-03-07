using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakePhysicalDamage(int damage);
}
public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UICondition uiCondition;

    Condition health{ get { return uiCondition.health; } }

    public event Action onTakeDamage;

    void Update()
    {
        if(health.curValue == 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("���� ����");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }
}
