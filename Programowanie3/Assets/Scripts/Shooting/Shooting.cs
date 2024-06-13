using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons = new List<Weapon>();
    private int currentWeaponIndex;

    private void Start()
    {
        ChangeWeapon(0);
    }

    public void AddWeapon(Weapon weapon)
    {
        weapons.Add(weapon);
    }

    public void ChangeWeapon(int index)
    {
        if(index >= weapons.Count)
        {
            return;
        }

        CurrentWeapon().gameObject.SetActive(false);
        currentWeaponIndex = index;
        CurrentWeapon().gameObject.SetActive(true);
    }

    public void ChangeToNextWeapon()
    {
        int nextWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;
        ChangeWeapon(nextWeaponIndex);
    }

    public void ChangeToPreviousWeapon()
    {
        int previousWeaponIndex = (currentWeaponIndex - 1);
        if(previousWeaponIndex <0)
        {
            previousWeaponIndex = weapons.Count - 1;
        }
        ChangeWeapon(previousWeaponIndex);
    }

    public void StartShooting()
    {
        CurrentWeapon().StartShooting();
    }

    public void StopShooting()
    {
        CurrentWeapon().StopShooting();
    }

    private Weapon CurrentWeapon()
    {
        return weapons[currentWeaponIndex];
    }
}
