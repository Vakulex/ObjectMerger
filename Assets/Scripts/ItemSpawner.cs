using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cursorItemHolder;
    [SerializeField] private GameObject _cursorYLevel; 
    [SerializeField] private AllItemsData _allItemsData;
    private readonly int _minRandomItem = 0;
    [SerializeField]
    private int _maxRandomItem;

    private bool _isAbleToSpawn = true;

    [SerializeField] private ScoreCounter _scoreCounter;

    private void Start()
    {
        _scoreCounter = gameObject.AddComponent<ScoreCounter>();
    }
    
    private void Update()
    {
        if (Camera.main != null)
            _cursorItemHolder.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            InstantiateNewItem(_cursorItemHolder.transform);
            StartCoroutine(ClickCooldown());
        }
    }
    
    private void InstantiateNewItem(Transform pos)
    {
        if(_isAbleToSpawn)
        {
            _isAbleToSpawn = false;
            int randomItem = CalculateRandomItem(_minRandomItem, _maxRandomItem);
            if (Camera.main != null)
            {
                Instantiate(_allItemsData.ItemDatas[randomItem].ItemPrefab,
                    new Vector3(pos.position.x,
                        Camera.main.ScreenToWorldPoint(_cursorYLevel.transform.position).y, 0f),
                    quaternion.identity);
                _scoreCounter.SetScore(_scoreCounter.GetScore() + _allItemsData.ItemDatas[randomItem].Score);
            }
            
        }    
    }

    private int CalculateRandomItem(int minRandomItem, int maxRandomItem)
    {
        return Random.Range(minRandomItem, maxRandomItem - 1);
    }

    IEnumerator ClickCooldown()
    {
        yield return new WaitForSeconds(1f);
        _isAbleToSpawn = true;
    }
}
