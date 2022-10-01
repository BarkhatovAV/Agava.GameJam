using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectsPool<TPoolObject> : MonoBehaviour
    where TPoolObject: PoolObject
{
    [SerializeField] private TPoolObject[] _templates;

    private IEnumerable<TPoolObject> _deactivatedObjects;
    private List<TPoolObject> _pool;
    private Transform _container;
    private TPoolObject _createdClone;
    private int _randomIndex;

    protected void Initialize(Transform container)
    {
        _pool = new List<TPoolObject>();
        _container = container;
        Fill();
    }

    protected bool TryGetRandomObject(out TPoolObject poolObject)
    {
        _deactivatedObjects = _pool.Where(desiredObject => desiredObject.Deactivated);
        _randomIndex = Random.Range(0, _deactivatedObjects.Count());
        poolObject = _deactivatedObjects.ElementAtOrDefault(_randomIndex);
        return poolObject != null;
    }

    private void Fill()
    {
        foreach (var template in _templates)
            for (var i = 0; i < template.ClonesCount; i++)
                CreateClone(template);
    }

    private void CreateClone(TPoolObject template)
    {
        _createdClone = Instantiate(template, _container);
        _createdClone.Deactivate();
        _pool.Add(_createdClone);
    }
}