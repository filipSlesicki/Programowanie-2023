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

    public void NextWeapon()
    {
        //int nextWeaponIndex = currentWeaponIndex + 1;
        //if(nextWeaponIndex >= weapons.Length)
        //{
        //    nextWeaponIndex = 0;
        //}
        int nextWeaponIndex = (currentWeaponIndex + 1) % weapons.Count;

        ChangeWeapon(nextWeaponIndex);
    }


    public void Shoot()
    {
        //Shoot current weapon
       CurrentWeapon().Shoot();
    }

    private Weapon CurrentWeapon()
    {
        return weapons[currentWeaponIndex];
    }
}
