using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class WeaponRaycastSettings
{
    public UnityEvent<Vector3> RayEndPoisitionEvent;
    public UnityEvent<GameObject> HitObjectEvent;
}
