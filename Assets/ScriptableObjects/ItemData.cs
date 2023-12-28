using System;
using UnityEngine;

[Serializable]
public class ItemData
{
    [field: SerializeField] public int Tier { get; private set; }
    [field: SerializeField] public int Score { get; private set; }
    [field: SerializeField] public GameObject ItemPrefab { get; private set; }
}
