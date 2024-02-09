using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(new Vector3(0, 1000 * Time.deltaTime, 0));
    }

    public virtual void Picked()
    {
        print("Bazowa: Picked");
        Destroy(gameObject);
    }
}
