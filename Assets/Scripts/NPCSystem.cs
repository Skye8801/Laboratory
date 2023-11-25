using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCSystem : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canva;

    bool player_detection = false;

    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.E) && !PlayerMove.dialogue)
        {
            canva.SetActive(false);
            PlayerMove.dialogue = true;
            NewDialogue("Hi");
            NewDialogue("It's nice to meet you!");
            canva.transform.GetChild(1).gameObject.SetActive(true);
        }

    }

    void NewDialogue(string text)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canva.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PlayerBody")
        {
            player_detection = true;
        }
        else
        {
            Debug.Log("NPC no dialogue");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
    }
}
