
using UnityEngine;

public class LightTheTorches : MonoBehaviour
{
    [SerializeField] private GameObject _firstTorch;
    [SerializeField] private GameObject _secondTorch;
    
    private float _detectionDistance = 3f;

    private void Update()
    {
        var distanceToTorches = Vector3.Distance(transform.position, _firstTorch.transform.position);

        if (distanceToTorches <= _detectionDistance)
        {
            _firstTorch.SetActive(true);
            _secondTorch.SetActive(true);
        }
    }
}
