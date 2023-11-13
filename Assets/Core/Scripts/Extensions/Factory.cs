using Lean.Pool;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _parent;

    public T Create<T>(Vector3 position)
    {
        return LeanPool
            .Spawn(_prefab, position, Quaternion.identity, _parent).GetComponent<T>();
    }
}