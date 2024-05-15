using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class TurretTrigger : MonoBehaviour
{

    public Transform Target;

    public Vector3 dirToTarget;
    public Vector3 localPos;
    public float height = 1;
    public float radius = 1;
    [Range(0f, 1f)] 
    public float AngleTreshHolder = .5f;


    private void OnDrawGizmos()
    {

        

        Gizmos.color = Handles.color = Contanins(Target.position) ? Color.red : Color.white;
        Handles.DrawWireDisc(transform.position, transform.up, radius);
        Handles.DrawWireDisc(transform.position + transform.up * height, transform.up, radius);
        float p = AngleTreshHolder;
        float x = Mathf.Sqrt(1- p *p);

        Vector3 rAngleLine = (transform.forward * p + transform.right * x)*radius;
        Vector3 lAngleLine = (transform.forward * p - transform.right * x) * radius;


        Gizmos.DrawRay(transform.position, rAngleLine);
        Gizmos.DrawRay(transform.position, lAngleLine);
        Gizmos.DrawRay(transform.position + (transform.up * height), rAngleLine);
        Gizmos.DrawRay(transform.position + (transform.up * height), lAngleLine);


        Gizmos.DrawLine(transform.position + rAngleLine + transform.up * height, transform.position + rAngleLine);
        Gizmos.DrawLine(transform.position + lAngleLine + transform.up * height, transform.position + lAngleLine);
        Gizmos.DrawLine(transform.position, transform.position + transform.up * height);





    }

    public bool Contanins(Vector3 position)
    {
        Vector3 disToTarget = (position - transform.position);
        localPos = transform.InverseTransformVector(disToTarget);
        localPos.y = 0;
        dirToTarget = localPos.normalized;
        
        if (localPos.y < 0 || localPos.y > height)
        {
            return false;
        }
        else if(Vector3.Distance(transform.position,position) > radius)
        {
            return false;
        }
        else if(dirToTarget.z < AngleTreshHolder)
        {
            return false;
        }

        

           

        return true;

      

    }
}
