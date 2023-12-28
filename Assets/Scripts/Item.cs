using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public int _tier;
    [SerializeField]
    protected AllItemsData _allItemsData;
    private Transform _transform;
    private bool _hasCollided;

    protected virtual void Init()
    {
        _hasCollided = false;
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        Init();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //create a bool to mark if is collided
        if(_hasCollided)
            return;
        
        if (!other.gameObject.TryGetComponent(out Item item))
            return;
        
        if (IsMerging(_tier, other.gameObject.GetComponent<Item>()._tier))
        {
            item._hasCollided = true;
            Instantiate(_allItemsData.ItemDatas[_tier].ItemPrefab, _transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private bool IsMerging(int gameObjectTier, int otherGameObjectTier)
    {
        if (gameObjectTier >= _allItemsData.ItemDatas.Length)
            return false;
        return gameObjectTier == otherGameObjectTier;
    }
}
