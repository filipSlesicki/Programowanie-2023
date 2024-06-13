using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float startingMoveSpeed = 5;
    private float currentMoveSpeed;
    private Rigidbody rb;

    /// <summary>
    /// Dictionary od temporary modifiers by effect type (scriptable object)
    /// W s�owniku nie mo�e by� 2 takich samych kluczy (pierwsza warto��)
    /// U�ywamy s�ownika �eby sprawdzi� czy ju� na�o�yli�my dany efekt
    /// </summary>
    private Dictionary<SpeedChangeEffect, EffectTimer> temporarySpeedModifiers = new Dictionary<SpeedChangeEffect, EffectTimer>();

    /// <summary>
    /// Lista efekt�w do usuni�cia. Jest tworzona raz i czyszczona co klatk� w celach optymalizacyjnych
    /// Tworzenie nowej listy co klatk� jest wolne
    /// </summary>
    private List<SpeedChangeEffect> toRemove = new List<SpeedChangeEffect>();

    void Start()
    {
        currentMoveSpeed = startingMoveSpeed;
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 moveDirection)
    {
        //mno�ymy przez Time.deltaTime �eby zamieni� pr�dko�� na klatk�
        //na pr�dko�� na sekund�
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
        // Sprawdzamy czy ten efekt jest ju� na�o�ony (jest w s�owniku)
        if (temporarySpeedModifiers.ContainsKey(effect))
        {
            // Je�eli jest, to zwi�kszamy jego d�ugo��
            temporarySpeedModifiers[effect].RemainingDuration += duration;
        }
        else
        {
            // Je�eli nie, to dodajemy go i tworzymy TemporaryModifier, kt�ry b�dzie odlicza� czas
            temporarySpeedModifiers.Add(effect, new EffectTimer(duration));
            // Kiedy nak�adamy efekt, modyfikujemy pr�dko��
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
                // Przy zdejmowaniu efektu dzielimy pr�dko�� przez Multiplier,
                // �eby wr�ci� pr�dko�� do warto�� przed na�o�eniem efektu
                currentMoveSpeed /= modifier.Key.Multiplier;
                // Usuwamy efekty kt�ych pozosta�y czas doszed� do 0 
                // Nie mo�na modyfikowa� kolekcji (listy, s�ownika etc.) w foreach
                // Dodajemy do listy obiekt�w do usuni�cia i usuwamy poni�ej
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
