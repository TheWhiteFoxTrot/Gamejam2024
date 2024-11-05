using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeSword : MonoBehaviour
{
    public float RotateSpeed;
    public Transform holder;

    void Start()
    {
        
    }

    void Update()
    {
        holder.rotation = Quaternion.Euler(0f, 0f, holder.rotation.eulerAngles.z + (RotateSpeed * Time.deltaTime));
    }
}
