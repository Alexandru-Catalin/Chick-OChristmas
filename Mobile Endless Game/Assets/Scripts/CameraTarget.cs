using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        //Camera will follow the Target at Z position - 10 and freezes positions X and Y
        Vector3 newPos = new Vector3(0, target.transform.position.y + 6, target.transform.position.z - 8);
        transform.position = newPos;

        //Freez camera Rotations on X, Y, Z
        Quaternion newPos2 = Quaternion.Euler(transform.rotation.x + 16, transform.rotation.y, target.transform.rotation.z);
        transform.rotation = newPos2;
    }
}
