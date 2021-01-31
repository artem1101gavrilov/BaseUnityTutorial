using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableMain : IMovable
{
    public void Move(Transform transform)
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(input);
    }
}
