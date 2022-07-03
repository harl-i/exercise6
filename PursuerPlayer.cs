using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuerPlayer : MonoBehaviour
{
    private Player _player;
    private float _moveSpeed = 4f;
    private float _orientationSpeed = 4f;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Chase();
        OrientTowards();
    }

    private void Chase()
    {
        transform.position = Vector3.MoveTowards
            (transform.position, _player.transform.position, _moveSpeed * Time.deltaTime);
    }

    private void OrientTowards()
    {
        Vector3 lookDirection = Vector3.ProjectOnPlane(_player.transform.position - transform.position, Vector3.up).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _orientationSpeed);
    }
}
