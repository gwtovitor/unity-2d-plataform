using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void Load(int i)
    {   
        Debug.Log("to no load");
        SceneManager.LoadScene(i);

    }

    public void Load(string s)
    {
        SceneManager.LoadScene(s);
    }

}
