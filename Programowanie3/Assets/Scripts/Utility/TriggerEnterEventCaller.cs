using UnityEngine;
using UnityEngine.Events;

public class TriggerEnterEventCaller : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> triggerEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent?.Invoke(other.gameObject);
    }
}
