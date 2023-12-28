using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemsData", fileName = "ItemsDataSO", order = 0)]
public class AllItemsData : ScriptableObject
{
    [field: SerializeField] public ItemData[] ItemDatas { get; private set; }
}
