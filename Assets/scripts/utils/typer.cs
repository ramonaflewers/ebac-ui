using System.Collections;
using UnityEngine;
using TMPro;

public class typer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float WriteTime = .1f;
    public string sentence;

    [NaughtyAttributes.Button]
    public void StartType()
    {
        StartCoroutine(Type(sentence));
    }

    IEnumerator Type(string s)
    {
        textMesh.text = "";
        foreach (char l in s)
        {
            textMesh.text += l;
            yield return new WaitForSeconds(WriteTime);
        }
    }

    public void Clear()
    {
        StopAllCoroutines();
        textMesh.text = "";
    }
}
