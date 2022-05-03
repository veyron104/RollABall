using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInteractive : MonoBehaviour
{
    [HideInInspector]
    public bool IsActive = true;
    public int ID;
    [HideInInspector]
    public float Speed;

    private void Awake()
    {
        Speed = Random.Range(0f, 2f);
    }

    public void GameLoaded(bool isActive)
    {
        IsActive = isActive;
    }

    public virtual void ChangeStatus()
    {
        gameObject.SetActive(IsActive);
    }

    public virtual void Vizualization()
    {

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player")) Interaction();
    //}

    public virtual (int id, bool goodBonus) Interaction()
    {
        IsActive = false;
        ChangeStatus();
        return (0, false);
    }
}