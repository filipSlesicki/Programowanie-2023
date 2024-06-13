using UnityEngine;
using UnityEngine.Events;

public class TriggerEnterEventCaller : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> triggerEnterEvent;
    [SerializeField] private string targetTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            triggerEnterEvent?.Invoke(other.gameObject);
        }
    }
}
