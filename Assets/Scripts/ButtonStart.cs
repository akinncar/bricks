using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
  public Button btn;

  void Start()
  {
    Button btn = GetComponent<Button>();
    btn.onClick.AddListener(TaskOnClick);
  }

  void TaskOnClick()
  {
    SceneManager.LoadScene("Fase1");

  }
}
