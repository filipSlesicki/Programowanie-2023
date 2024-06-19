using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    private float currentSpeed;
    private Rigidbody rb;
    private Dictionary<SpeedChangeEffect, TemporaryModifier> temporarySpeedModifiers = new Dictionary<SpeedChangeEffect, TemporaryModifier>();

    void Start()
    {
        currentSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 moveDirection)
    {
        //mno¿ymy przez Time.deltaTime ¿eby zamieniæ prêdkoœæ na klatkê
        //na prêdkoœæ na sekundê
        transform.Translate(moveDirection * currentSpeed * Time.deltaTime);
    }

    public void MoveWithForce(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection * currentSpeed);
    }

    public void MoveWithVelocity(Vector3 moveDirection)
    {
        rb.velocity = moveDirection * currentSpeed;
    }

    public void ApplySpeedModifier(SpeedChangeEffect effect, float duration)
    {
        if (temporarySpeedModifiers.ContainsKey(effect))
        {
            temporarySpeedModifiers[effect].RemainingDuration += duration;
        }
        else
        {
            temporarySpeedModifiers.Add(effect, new TemporaryModifier(effect.Multiplier,duration));
            currentSpeed *= effect.Multiplier;
        }
    }

    private void Update()
    {
        List<SpeedChangeEffect> toRemove = new List<SpeedChangeEffect>();
        foreach (var modifier in temporarySpeedModifiers)
        {
            modifier.Value.RemainingDuration -= Time.deltaTime;
            if(modifier.Value.RemainingDuration <= 0)
            {
                currentSpeed /= modifier.Value.Multiplier;
                toRemove.Add(modifier.Key);
            }
        }

        foreach (var modifier in toRemove)
        {
            temporarySpeedModifiers.Remove(modifier);
        }
    }

    //IEnumerator ApplySpeedModifier(float multiplier, float duration)
    //{
    //    currentSpeed *= multiplier;
    //    yield return new WaitForSeconds(duration);
    //    currentSpeed /= multiplier;
    //}
}
