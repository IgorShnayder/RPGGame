
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
        // Вырезаем отверстие в навмеш (чтобы игрок там больше не смог пройти)
        _navMeshObstacle.enabled = true;
        
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;

            // Генерируем случайную силу.
            var forceValue = Random.Range(_minForceValue, _maxForceValue);

            // Генерируем случайное направление.
            var direction = Random.insideUnitSphere;
            
            // Придаем силу каждому rigidbody.
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