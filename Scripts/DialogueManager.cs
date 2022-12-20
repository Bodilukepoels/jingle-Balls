using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    // A list of all the dialogue lines in the game
    public List<string> dialogueLines = new List<string>();

    // The current line of dialogue
    public string currentLine;

    // A reference to the UI text component that displays the dialogue
    public Text dialogueText;

    // A reference to the UI image component that displays the character's portrait
    public Image portrait;

    // A list of all the character portraits in the game
    public List<Sprite> characterPortraits = new List<Sprite>();

    // The current character's portrait
    public Sprite currentPortrait;

    // A reference to the UI panel that holds the dialogue text and portrait
    public GameObject dialoguePanel;

    // A reference to the player character
    public GameObject player;

    // A reference to the NPC character
    public GameObject npc;

    // A flag to determine whether the dialogue is active
    public bool dialogueActive;

    // The index of the current line of dialogue in the dialogueLines list
    public int dialogueLineIndex;

    public void UpdateUI()
    {
        // Set the text of the dialogueText component to the current line of dialogue
        dialogueText.text = currentLine;

        // Set the sprite of the portrait component to the current character portrait
        portrait.sprite = currentPortrait;
    }


    void Awake()
    {
        // Set the instance variable to this object
        instance = this;
    }

    void Update()
    {
        // If the dialogue is active and the player presses the "submit" button
        if (dialogueActive && Input.GetButtonDown("Submit"))
        {
            // Increment the dialogue line index
            dialogueLineIndex++;

            // If we have reached the end of the dialogue lines
            if (dialogueLineIndex >= dialogueLines.Count)
            {
                // End the dialogue
                EndDialogue();
            }
            else
            {
                // Update the current line and portrait
                currentLine = dialogueLines[dialogueLineIndex];
                currentPortrait = characterPortraits[dialogueLineIndex];

                // Update the UI
                UpdateUI();
            }
        }
    }
    public void EndDialogue()
    {
        // Set the dialogue active flag to false
        dialogueActive = false;

        // Set the dialogue panel to inactive
        dialoguePanel.SetActive(false);

        // Set the NPC to inactive
        npc.SetActive(false);

        // Set the player to active
        player.SetActive(true);
    }

    public class Dialogue
    {
        public string name;
        public List<string> lines;
        public List<Sprite> portraits;
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        // Set the dialogue active flag to true
        dialogueActive = true;

        // Set the dialogue panel to active
        dialoguePanel.SetActive(true);

        // Set the NPC to active
        npc.SetActive(true);

        // Set the player to inactive
        player.SetActive(false);

        // Clear the dialogue lines and character portraits lists
        dialogueLines.Clear();
        characterPortraits.Clear();

        // Add the lines and portraits from the dialogue object
        foreach (string line in dialogue.lines)
        {
            dialogueLines.Add(line);
        }
        foreach (Sprite portrait in dialogue.portraits)
        {
            characterPortraits.Add(portrait);
        }
    }
} 