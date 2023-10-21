
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    
    private float _detectionDistance = 4;
    private Rigidbody[] _rigidbodies;
    private NavMeshObstacle _navMeshObstacle;
    
    private float _minForceValue = 150;
    private float _maxForceValue = 200;

    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    private void Update()
    {
        Approaching();
    }

    private void Break()
    {
        _navMeshObstacle.enabled = true;
        
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
            
            var forceValue = Random.Range(_minForceValue, _maxForceValue);
            
            var direction = Random.insideUnitSphere;
            
            rigidbody.AddForce(direction * forceValue);
        }
    }

    private void Approaching()
    {
        var highlighting = _player.GetComponent<Outline>().OutlineWidth;
        
        if (highlighting >= 2) return;
        
        var distance = Vector3.Distance(_player.transform.position, gameObject.transform.position);

        if (distance < _detectionDistance)
        {
            Break();
        }
    }
}