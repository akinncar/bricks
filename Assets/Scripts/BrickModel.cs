using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickModel : MonoBehaviour
{
    [SerializeField] private float _health;

    public float Health { get => _health; set => _health = value; }
}