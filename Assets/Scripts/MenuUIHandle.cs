using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandle : MonoBehaviour
{
    public InputField playerName;
    // Start is called before the first frame update
    void Start()
    {
        playerName.onEndEdit.AddListener(SubmitName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitName(string arg0)
    {
        SessionManager.instance.PlayerName = arg0;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
}
