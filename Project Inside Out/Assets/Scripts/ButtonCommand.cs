using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCommand : MonoBehaviour
{
    public void OnButtonPress()
    {
        SceneManager.LoadScene(1);
    }
}
