using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Transform))]
public class EnemyManager : MonoBehaviour
{
    [SerializeField] public GameObject TypeBEnemy;
    [SerializeField] public GameObject TypeAEnemy;
    [SerializeField] public GameObject SnowTypeBEnemy;
    [SerializeField] public GameObject SnowTypeAEnemy;
    [SerializeField] public float moveSpeed = 10;
    private bool movingRight = true;
    private bool hasSpawned = false;


    public Vector2 posA = new Vector2(44f, 0f);

    public List<GameObject> enemiesList;

    void Start()
    {
        StartCoroutine(nameof(Move));
        InvokeRepeating(nameof(SpawnTypeBAfterDelay),3f, 10f);
        InvokeRepeating(nameof(SpawnTypeAAfterDelay), 15f, 30f);
        InvokeRepeating(nameof(SpawnSnowTypeBAfterDelay), 25f, 50f);
        InvokeRepeating(nameof(SpawnSnowTypeAAfterDelay), 35f, 60f);
        Debug.Log("2nd Invoke Called");
    }
    IEnumerator Move()
    {
        while (true)
        {
            if (enemiesList.Count > 0)
            {
                foreach (var obj in enemiesList)
                {
                    obj.transform.Translate(Vector3.left * moveSpeed);
                }
                Debug.Log("MoveAkush");
            }
            
            
            yield return null;
        }
    }
    
    //TODO: bad approach, there should be a single spawn function that handles the spawning of all your enemy types
    void SpawnTypeBAfterDelay()
    {
        if (!hasSpawned)
        {
            GameObject typeBenemy = Instantiate(TypeBEnemy, transform.position, Quaternion.identity);
            enemiesList.Add(typeBenemy);
            //StartCoroutine(Move());
        }
    }
    void SpawnTypeAAfterDelay()
    {
        
        if (!hasSpawned)
        {
            GameObject typeAenemy = Instantiate(TypeAEnemy, posA, Quaternion.identity);
            enemiesList.Add(typeAenemy);
            Debug.Log(enemiesList);
           // StartCoroutine(Move());
           
        }
    }
    
    
    void SpawnSnowTypeBAfterDelay()
    {
        if (!hasSpawned)
        {
            GameObject SnowtypeBenemy = Instantiate(SnowTypeBEnemy, transform.position, Quaternion.identity);
            enemiesList.Add(SnowtypeBenemy);
            //StartCoroutine(Move());
        }
    }
    void SpawnSnowTypeAAfterDelay()
    {
        if (!hasSpawned)
        {
            GameObject SnowtypeAenemy = Instantiate(SnowTypeAEnemy, posA, Quaternion.identity);
            enemiesList.Add(SnowtypeAenemy);
            Debug.Log(enemiesList);
            //StartCoroutine(Move());
           
        }
    }
}