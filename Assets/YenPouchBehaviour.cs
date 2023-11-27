using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class YenPouchBehaviour : MonoBehaviour, IInteractable
{
   // public GameObject coinPrefab;
    public static Action OnYenPounchInteractionStart;
    //public static object onYenPounchInteractionStarted;

    public void StartInteraction()
    {
       //spawn coins
       OnYenPounchInteractionStart?.Invoke();
       gameObject.SetActive(false);
       //Instantiate(coinPrefab,gameObject.transform.position + new Vector3(5,1,0) , quaternion.identity);

    }

    public void StopInteraction()
    {
      
    }
}
