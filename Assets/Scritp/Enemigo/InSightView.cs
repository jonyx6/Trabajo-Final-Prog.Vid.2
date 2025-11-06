using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class InSightView : MonoBehaviour
{
    [SerializeField]
    private float visionRadius = 1;
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private float anguloMaximo;
    private Collider2D target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public bool Distancia()
    {
        target = Physics2D.OverlapCircle(transform.position, visionRadius, _layerMask);
        if (target)
        {
            return true;
        }
        return false;
    }
    public bool EstaEnAngulo(Transform target)
    {
        float angulo = Vector2.Angle(transform.right, DirectionToTarget(target));
        return angulo < anguloMaximo;
    }
    public bool NoHayAlgoEnElMedio(Transform target)
    {
        Vector2 direction = DirectionToTarget(target);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionRadius);
        return hit && hit.collider.gameObject == target.gameObject;
    }
    Vector2 DirectionToTarget(Transform target)
    {
        return target.position - transform.position;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (Distancia())
        {
            Gizmos.color = Color.blue;
        }
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.color = Color.red;
        if(target)
        {
            
            if (EstaEnAngulo(target.transform))
            {
                Gizmos.color = Color.blue;
                if (NoHayAlgoEnElMedio(target.transform))
                {
                    Gizmos.color = Color.green;
                }
            }
            Gizmos.DrawLine(target.transform.position, transform.position);
        }
    }
}
