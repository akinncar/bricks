using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickModel : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health { get => _health; set => _health = value; }
}