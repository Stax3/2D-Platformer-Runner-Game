using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollBehaviour : MonoBehaviour, IInteractable
{
    public GameObject coinPrefab;
    public static Action OnScrollInteractionStart;
    //public static object onYenPounchInteractionStarted;

    public void StartInteraction()
    {
        //spawn coins
        OnScrollInteractionStart?.Invoke();
        gameObject.SetActive(false);
        
        //Instantiate(coinPrefab,gameObject.transform.position + new Vector3(5,1,0) , quaternion.identity);

    }

    public void StopInteraction()
    {
      
    }
}
