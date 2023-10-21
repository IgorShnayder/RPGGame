using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    
    private float _detectionDistance = 2;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Approaching();
    }

    private void Open()
    {
        _animator.SetTrigger("open");
    }

    private void Approaching()
    {
        var distance = Vector3.Distance(_player.transform.position, gameObject.transform.position);

        if (distance < _detectionDistance)
        {
            Open();
        }
    }
}