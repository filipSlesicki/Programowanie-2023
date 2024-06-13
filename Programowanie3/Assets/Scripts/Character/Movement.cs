using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float startingMoveSpeed = 5;
    private float currentMoveSpeed;
    private Rigidbody rb;

    /// <summary>
    /// Dictionary od temporary modifiers by effect type (scriptable object)
    /// W s³owniku nie mo¿e byæ 2 takich samych kluczy (pierwsza wartoœæ)
    /// U¿ywamy s³ownika ¿eby sprawdziæ czy ju¿ na³o¿yliœmy dany efekt
    /// </summary>
    private Dictionary<SpeedChangeEffect, EffectTimer> temporarySpeedModifiers = new Dictionary<SpeedChangeEffect, EffectTimer>();

    /// <summary>
    /// Lista efektów do usuniêcia. Jest tworzona raz i czyszczona co klatkê w celach optymalizacyjnych
    /// Tworzenie nowej listy co klatkê jest wolne
    /// </summary>
    private List<SpeedChangeEffect> toRemove = new List<SpeedChangeEffect>();

    void Start()
    {
        currentMoveSpeed = startingMoveSpeed;
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 moveDirection)
    {
        //mno¿ymy przez Time.deltaTime ¿eby zamieniæ prêdkoœæ na klatkê
        //na prêdkoœæ na sekundê
        transform.Translate(moveDirection * currentMoveSpeed * Time.deltaTime);
    }

    public void MoveWithForce(Vector3 moveDirection)
    {
        rb.AddForce(moveDirection * currentMoveSpeed);
    }

    public void MoveWithVelocity(Vector3 moveDirection)
    {
        rb.velocity = moveDirection * currentMoveSpeed;
    }

    public void ApplySpeedModifier(SpeedChangeEffect effect, float duration)
    {
        // Sprawdzamy czy ten efekt jest ju¿ na³o¿ony (jest w s³owniku)
        if (temporarySpeedModifiers.ContainsKey(effect))
        {
            // Je¿eli jest, to zwiêkszamy jego d³ugoœæ
            temporarySpeedModifiers[effect].RemainingDuration += duration;
        }
        else
        {
            // Je¿eli nie, to dodajemy go i tworzymy TemporaryModifier, który bêdzie odlicza³ czas
            temporarySpeedModifiers.Add(effect, new EffectTimer(duration));
            // Kiedy nak³adamy efekt, modyfikujemy prêdkoœæ
            currentMoveSpeed *= effect.Multiplier;
        }
    }

    private void Update()
    {
        foreach (var modifier in temporarySpeedModifiers)
        {
            modifier.Value.RemainingDuration -= Time.deltaTime;
            if(modifier.Value.RemainingDuration <=0)
            {
                // Przy zdejmowaniu efektu dzielimy prêdkoœæ przez Multiplier,
                // ¿eby wróciæ prêdkoœæ do wartoœæ przed na³o¿eniem efektu
                currentMoveSpeed /= modifier.Key.Multiplier;
                // Usuwamy efekty któych pozosta³y czas doszed³ do 0 
                // Nie mo¿na modyfikowaæ kolekcji (listy, s³ownika etc.) w foreach
                // Dodajemy do listy obiektów do usuniêcia i usuwamy poni¿ej
                toRemove.Add(modifier.Key);
            }
        }

        foreach (var modifier in toRemove)
        {
            temporarySpeedModifiers.Remove(modifier);
        }
        toRemove.Clear();
    }
}
