using UnityEngine;
using System.Collections;

public class MouseController : Food
{

    private void FixedUpdate()
    {
        transform.position = new Vector3(fixedPosition.x +
            Mathf.Cos(Time.time * moveSpeed * Mathf.PI / 180) * 4,
           fixedPosition.y + Mathf.Sin(Time.time * moveSpeed * Mathf.PI / 180) * 4,
            fixedPosition.z);
    }

}
 