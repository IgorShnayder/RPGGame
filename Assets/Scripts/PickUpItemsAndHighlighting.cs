using System;
using UnityEngine;

public class PickUpItemsAndHighlighting : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Potion"))
        {
            Destroy(other.gameObject);

            var highlighting = GetComponent<Outline>();
            highlighting.enabled = true;
            highlighting.OutlineWidth = 2;
        }
    }
} 
