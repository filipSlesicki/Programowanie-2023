using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqTest : MonoBehaviour
{
    [SerializeField] private Transform[] cubes;
    
    void Start()
    {
        IEnumerable<string> belowGroundCubeNames = cubes
            .Where(cube => cube.position.y < 0) // Wszyskie poni¿ej 0 na Y
            .OrderBy(cube => Vector3.Distance(cube.position, transform.position)) // Posortowane po odleg³oœci od tego obiektu
            .Select(cube => cube.name); // Bierzemy same nazwy tych transformów (zminiamy listê transformów na listê stringów)
            // cube to jest ka¿dy element w tej kolekcji (tak jak w foreach)
            

        Debug.Log(string.Join(", ", belowGroundCubeNames));

        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, };

        //OrderBy((_) => Random.value) sortuje losowo
        //numbers.OrderBy((_) => Random.value).Take(5).ToList().ForEach(n => Debug.Log(n));
        Debug.Log(numbers.Where(number => number % 2 == 0).Sum());

    }

    bool BelowGround(Transform t)
    {
        return t.position.y < 0;
    }
}
