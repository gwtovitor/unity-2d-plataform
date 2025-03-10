using TMPro;
using UnityEngine;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TMP_Text uiTextValue;


    void Start()
    {
        uiTextValue.text = soInt.value.ToString();
    }

    void Update()
    {
        uiTextValue.text = soInt.value.ToString();
        
    }


}
