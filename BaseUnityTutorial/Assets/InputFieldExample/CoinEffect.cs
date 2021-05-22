using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEffect : MonoBehaviour
{
    [SerializeField] private InputFieldExample input;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        input.AddCoin += ChangeAnimation;
    }

    private void OnDisable()
    {
        input.AddCoin -= ChangeAnimation;
    }

    private void ChangeAnimation()
    {
        animator.Play("NewCoin", -1, 0);
    }
}
