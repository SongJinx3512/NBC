using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownCharacterController _controller;

    [SerializeField] private Transform projectileSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject testPrefab;


    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }


    void Start()
    {
        _controller.OnAttackEvent += OnFire;
        _controller.OnLookEvent += OnAim;
    }


    private void OnAim(Vector2 newAimDirection)
    {
        _aimDirection = newAimDirection;
    }


    private void OnFire()
    {
        CreateProjectile();
    }


    private void CreateProjectile()
    {
        //Debug.Log("Fire");
        Instantiate(testPrefab, projectileSpawnPosition.position,Quaternion.identity);
    }
}
