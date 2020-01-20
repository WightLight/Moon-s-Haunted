using UnityEngine;
using TMPro;

public abstract class FieldWatcher : MonoBehaviour
{
    private TMP_Text field;

    public abstract string Value();

    void Awake()
    {
        Debugging.Use(() => {
            field = GetComponent<TMP_Text>();
            Debugging.Log(field);
        });
    }

    // Update is called once per frame
    void Update()
    {
        field.text = Value();
    }
}
