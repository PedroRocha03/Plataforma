using UnityEngine;
using TMPro;
using System.Collections;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public float timeToDisappear = 3f; // Tempo em segundos antes de desaparecer (configurável no Inspector)
    private int index;
    private Coroutine disappearanceCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialog();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(textComponent.text == lines[index]){
                NextLine();
            }else{
                StopAllCoroutines();
                textComponent.text = lines[index];
                if (disappearanceCoroutine != null) StopCoroutine(disappearanceCoroutine);
                disappearanceCoroutine = StartCoroutine(DisappearAfterTime());
            }
        }
    }
    
    void StartDialog(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine(){
        foreach(char c in lines [index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        disappearanceCoroutine = StartCoroutine(DisappearAfterTime());
    }

    IEnumerator DisappearAfterTime()
    {
        yield return new WaitForSeconds(timeToDisappear);
        NextLine();
    }

    void NextLine(){
        if (disappearanceCoroutine != null) 
        {
            StopCoroutine(disappearanceCoroutine);
            disappearanceCoroutine = null;
        }
        if (index < lines.Length -1 ){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }else{
            gameObject.SetActive(false);
        }
    }

}
