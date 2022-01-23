using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CharacterSelection : MonoBehaviour
{
    public PlayerChoice playerChoice;
    public CharacterData[] characters;
    private List<GameObject> instances = new List<GameObject>();
    public Transform modelParent;
    public GameObject inputPrefab;
    private PlayerInput input;

    void Start()
    {
        foreach (var character in characters)
        {
            Debug.Log(character.modelPrefab);
            var obj = Instantiate(character.modelPrefab);
            obj.GetComponent<Character>().ShowModelForHealth(1);
            obj.AddComponent<RotateY>();
            instances.Add(obj);
            obj.transform.SetParent(modelParent, false);
        }


    }

    void OnEnable()
    {
        input = PlayerInput.Instantiate(inputPrefab, controlScheme: playerChoice.controlScheme, pairWithDevice: playerChoice.inputDevice);
        input.GetComponent<CharacterSelector>().selection = this;
    }

    void OnDisable()
    {
        foreach (var instance in instances)
        {
            if (instance)
            {
                instance.SetActive(false);
            }
        }
        if (input)
        {
            Destroy(input.gameObject);
        }
    }

    void Update()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] == playerChoice.character)
            {
                instances[i].SetActive(true);
            }
            else
            {
                instances[i].SetActive(false);
            }
        }

    }

    private int GetSelectedIndex()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] == playerChoice.character)
            {
                return i;
            }
        }
        Debug.LogError($"Invalid character selected {playerChoice.character.name}");
        return -1;
    }

    public void SelectNext()
    {
        int index = GetSelectedIndex() + 1;
        if (index >= characters.Length)
        {
            index = 0;
        }
        playerChoice.character = characters[index];
    }
    public void SelectPrevious()
    {
        int index = GetSelectedIndex() - 1;
        if (index < 0)
        {
            index = characters.Length - 1;
        }
        playerChoice.character = characters[index];
    }
}
