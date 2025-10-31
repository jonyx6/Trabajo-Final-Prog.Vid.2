using UnityEngine;

public class ShooterSystem : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    void Shoot()
    {
        Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
    }
}