using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInteractive : MonoBehaviour
{
    [HideInInspector]
    public bool IsActive = true;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) Interaction();
    }

    public virtual void Interaction()
    {
        IsActive = false;
        ChangeStatus();
    }
}