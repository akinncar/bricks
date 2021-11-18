using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Br : MonoBehaviour
{
    private BrickController _brickController;

    public BrickController BrickController { get => _brickController; set => _brickController = value; }

    // Start is called before the first frame update
    void Start()
    {
        _brickController = GetComponent<BrickController>();
    }

    // Update is called once per frame
    public void PerformTakeDamage(float damage)
    {
        _brickController.TakeDamage(damage)
    }
}
