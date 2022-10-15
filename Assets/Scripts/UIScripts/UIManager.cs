using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update\
    public GameObject textField;
    void Awake()
    {
    }
    void Start()
    {
        HideTextField();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    private void HideTextField()
    {
        if (textField != null)
        {
            textField.gameObject.SetActive(false);
        }
    }

    public void ReturnToStart()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
