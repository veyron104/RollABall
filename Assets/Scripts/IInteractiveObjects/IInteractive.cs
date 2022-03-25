using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInteractive : MonoBehaviour
{
    public virtual void GameStarted()
    {
        gameObject.SetActive(true);
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
        gameObject.SetActive(false);
    }
}