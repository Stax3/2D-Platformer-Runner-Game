using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class ItemManager : MonoBehaviour
{
    bool _isactive = false;
    public List<GameObject> purchasableItemsList;
    [FormerlySerializedAs("ObjToMoveInsSinWave")] [FormerlySerializedAs("nonpurchasableItemsList")] public List<GameObject> objToMoveInSinWave;
    [SerializeField] public GameObject yenPouch;
    [SerializeField] public GameObject scroll;
    [SerializeField] public float moveSpeed = 0.01f;
    
    public GameObject coinPrefab;
    public GameObject spawnPoint;
    private GameObject _coinTrail;

    public GameObject bronzeCoinPrefab;
    private GameObject _bronzeCoinTrail;

    

    public GameObject bonusCoinPrefab;
    private GameObject _bonusCoinTrail;
    
    public float amplitude = 0.01f;  
    public float frequency = 3f; 
    public float speed = 2.0f;     
    //private Vector2 _dropPos = new Vector2(5, .5f);
    private Vector2 _dropPosScroll = new Vector2(10, .5f);
    private float _time;

    public float speedMultiplier;

    [SerializeField] private AnimationCurve _animationcurve;
    private bool _hasSpawned = false;

    public List<GameObject> coins;
    private List<GameObject> objToMoveInStraightLine;
    
    float timer = 0f;
    const float destroyTime = 40f; // Time after which coins will be spawned(wait for secs) and destroyed

    void Start()
    {
        
        StartCoroutine(nameof(MoveItemsInSinWave));
        InvokeRepeating(nameof(Yenpouch), 10f, 120f);

        InvokeRepeating(nameof(scrollItem), 160f, 250f);
        
        //StartCoroutine(nameof(MoveItemsInSinWave));
        
        //InvokeRepeating(nameof(SpawnBronzeCoinTrail), 2f, 5f);
        
        StartCoroutine(Test());
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        YenPouchBehaviour.OnYenPounchInteractionStart += SpawnCoinTrail;
        ScrollBehaviour.OnScrollInteractionStart += SpawnBonusCoinTrail;
    }

    private void OnDisable()
    {
        YenPouchBehaviour.OnYenPounchInteractionStart -= SpawnCoinTrail;
        ScrollBehaviour.OnScrollInteractionStart -= SpawnBonusCoinTrail;

    }


    private void SpawnCoin(GameObject coin)
    {
        var coinReference = Instantiate(coin, spawnPoint.transform.position , quaternion.identity);
        objToMoveInSinWave.Add(coinReference);
        
    }

    [ContextMenu("Spawn")]
    IEnumerator Test()
    {
        for (int trail = 0; trail < 100; trail++)
        {
            
            yield return GenerateCoinTrail(coins[0], coins[1]);
            
            Debug.Log("Coins generated and moved");
            yield return new WaitForSeconds(destroyTime); // Wait for seconds for next cointrail
        }
    }

    IEnumerator GenerateCoinTrail(GameObject coinType1, GameObject coinType2, int row = 3, int col= 10)
    {
        for (var r = 0; r < row ; r ++)
        { 
            for (var c = 0; c < col ; c++)
            {
                var coinItem = Instantiate(r % 2 == 0 ? coinType2 : coinType1, spawnPoint.transform.position + new Vector3(0.2f * c, 0.2f * r , 0)  , quaternion.identity);
                objToMoveInSinWave.Add(coinItem);
            }
            
        }

        yield return null;
    }

    IEnumerator MoveItemsInSinWave()
{
    float timer = 0f;
    //const float destroyTime = 5f; // Time after which coins will be destroyed

    while (true)
    {
        // Move existing coins in a sine wave
        foreach (var obj in objToMoveInSinWave)
        {
            var pos = obj.transform.position;
            float x = (pos.x - speed) * speedMultiplier;
            float y = (pos.y + amplitude * Mathf.Sin(frequency * x)) * speedMultiplier;
            obj.transform.position = new Vector2(x, y);
        }

        // Increment the timer
        timer += Time.deltaTime;

        // Check if it's time to destroy coins
        if (timer >= destroyTime)
        {
            DestroyCoins();
            timer = 0f; // Reset the timer after destroying coins
        }

        yield return null;
    }
}

void DestroyCoins()
{
    foreach (var coin in objToMoveInSinWave)
    {
        Destroy(coin);
    }
    objToMoveInSinWave.Clear(); // Clear the list after destroying coins
}

    
    
    
    private void SpawnBronzeCoinTrail()
    {
        if (_bronzeCoinTrail != null)
        {
            Destroy(_bronzeCoinTrail, 3f); 
        }
        _hasSpawned = true;
        _bronzeCoinTrail = Instantiate(bronzeCoinPrefab, spawnPoint.transform.position , quaternion.identity);
        StartCoroutine(nameof(MoveItemInStraightLine));
    }

    private IEnumerator MoveItemInStraightLine()
    {
        while (true)
        {
                if (objToMoveInStraightLine.Count > 0)
                {
                    foreach (var obj in objToMoveInStraightLine)
                    {
                        obj.transform.Translate(Vector3.left * moveSpeed);
                       
                    }
                }
            
                Debug.Log("Item Dropped");
                
                yield return null;
        }
        
    }

    
    private void SpawnBonusCoinTrail()
    {
        _bonusCoinTrail = Instantiate(bonusCoinPrefab, new Vector3(0.8f,-0.1f,0) , quaternion.identity);
        StartCoroutine((MoveAndDestroyCoinTrail(_bonusCoinTrail)));
        
    }

    /*private IEnumerator MoveBonusCoinTrail()
    {
        while (true)
        {
            _bonusCoinTrail.transform.Translate(Vector3.left * moveSpeed);
            
            yield return null;
        }
    }
    */
    private void SpawnCoinTrail()
    {
        GameObject coinTrail = Instantiate(coinPrefab, new Vector3(0.8f,0.1f,0) , quaternion.identity);
        //objToMoveInStraightLine.Add(coinTrail);
        StartCoroutine(MoveAndDestroyCoinTrail(coinTrail));
    }

    private IEnumerator MoveAndDestroyCoinTrail(GameObject coinTrail)
    {
        Debug.Log("MoveAndDestroyCoinTrail started");
        float timer = 0f;
        const float duration = 25f; // Duration before destroying the coin trail

        while (timer < duration)
        {
            coinTrail.transform.Translate(Vector3.left * moveSpeed);
            timer += Time.deltaTime;
            Debug.Log("Moving coin trail...");

            yield return null;
        }

        // If the timer exceeds the duration, destroy the coin trail
        DestroyImmediate(coinTrail);
        Debug.Log("Coin trail destroyed");
    }
    
    void Yenpouch()
    {
        GameObject yenpouch = Instantiate(yenPouch, spawnPoint.transform.position, Quaternion.identity);
        objToMoveInSinWave.Add(yenpouch);
        Debug.Log(objToMoveInSinWave);
        //StartCoroutine(ItemDrop());
        //StopCoroutine(ItemDrop(yenpouch));
    }
    
    void scrollItem()
    {
        GameObject scrollGameObject = Instantiate(scroll, spawnPoint.transform.position, Quaternion.identity);
        
        objToMoveInSinWave.Add(scrollGameObject);
        Debug.Log(objToMoveInSinWave);
        //StartCoroutine(ItemDrop());
        //StopCoroutine(ItemDrop(scrollGameObject));
    }
 
    
}
