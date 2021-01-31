using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableTrolley : IMovable
{
    public void Move(Transform transform)
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.Translate(input);
    }
}
