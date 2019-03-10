using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehavior : MonoBehaviour {

    private void Update()
    {
        if (transform.position.y < -3f)
        {
            Destroy(gameObject);
        }
    }

}
