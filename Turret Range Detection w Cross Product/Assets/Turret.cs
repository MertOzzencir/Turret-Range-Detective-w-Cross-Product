using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    public Transform turretHead;
    public TurretTrigger trigger;

    private void OnDrawGizmos()
    {

        if (trigger.Contanins(target.position))
        {
            Vector3 direction = target.position - turretHead.position;

            turretHead.rotation = Quaternion.LookRotation(direction, transform.up);

        }

    }

}
