using System;
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
    public event Action<Transform> OnEnemyVisible;
    public event Action OnEnemyNoVisible;

    private void Update() {
        if (EstaCerca() && EstaEnAngulo() && NoHayObstaculos())
        {
            OnEnemyVisible?.Invoke(target.transform);
        }
        else
        {
            //linea 26
            OnEnemyNoVisible?.Invoke();
        }
    }

    public bool EstaCerca()
    {
        target = Physics2D.OverlapCircle(transform.position, visionRadius, _layerMask);
        return target != null;
    }
    public bool EstaEnAngulo()
    {
        float angulo = Vector2.Angle(transform.right, DirectionToTarget(target.transform));
        return angulo < anguloMaximo;
    }
    public bool NoHayObstaculos()
    {
        Vector2 direction = DirectionToTarget(target.transform);
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
        if (EstaCerca())
        {
            Gizmos.color = Color.blue;
        }
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.color = Color.red;
        if(target)
        {
            
            if (EstaEnAngulo())
            {
                Gizmos.color = Color.blue;
                if (NoHayObstaculos())
                {
                    Gizmos.color = Color.green;
                }
            }
            Gizmos.DrawLine(target.transform.position, transform.position);
        }
    }
}
