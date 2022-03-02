using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerView : MonoBehaviour
{
  PlayerController _playerController;

  // Start is called before the first frame update
  void Start()
  {
    _playerController = GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.R))
    {
      GlobalVariables.numberOfBricks = 11;
      SceneManager.LoadScene("Menu");
      return;
    }

    float h = Input.GetAxis("Horizontal");
    _playerController.Move(h);
  }
}
