using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LudoText : MonoBehaviour
{
    public TMP_Text textComponent;

    private float yOffset = 15f; // Y-axis offset for each character
    private float speed = 10f; // Movement speed of characters

    private bool animationCompleted = false; // Flag to track if animation has completed for a character
    private int currentCharacterIndex = 0; // Index of the current character being animated

    private Vector3[] originalPositions; // Array to store the original positions of characters

    private bool isMovingUp = true; // Flag to indicate whether characters are moving up or down

    private bool isLastCharacter = false; // Flag to track the last character "O"

    void Start()
    {
        StoreOriginalPositions();
    }

    void StoreOriginalPositions()
    {
        textComponent.ForceMeshUpdate();
        var textInfo = textComponent.textInfo;
        originalPositions = new Vector3[textInfo.characterCount * 4]; // Adjust array size to accommodate all vertices

        for (int i = 0; i < textInfo.characterCount; ++i)
        {
            var charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)
            {
                originalPositions[i * 4 + j] = verts[charInfo.vertexIndex + j];
            }
        }
    }

    void Update()
    {
        if (!animationCompleted) // Only update positions if animation hasn't completed yet
        {
            textComponent.ForceMeshUpdate();
            var textInfo = textComponent.textInfo;

            for (int i = 0; i <= currentCharacterIndex; ++i)
            {
                var charInfo = textInfo.characterInfo[i];
                if (!charInfo.isVisible)
                {
                    continue;
                }

                var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

                for (int j = 0; j < 4; ++j)
                {
                    var orig = originalPositions[i * 4 + j];

                    // Calculate the Y-axis offset based on the character index
                    float offsetY = Mathf.Sin((Time.time * speed) + i) * yOffset;

                    if (i == currentCharacterIndex) // Apply movement only to the current character
                    {
                        verts[charInfo.vertexIndex + j] = orig + new Vector3(0f, offsetY, 0f);
                    }
                    else // Keep other characters at their original positions
                    {
                        verts[charInfo.vertexIndex + j] = orig;
                    }
                }
            }

            for (int i = 0; i < textInfo.meshInfo.Length; ++i)
            {
                var meshInfo = textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                textComponent.UpdateGeometry(meshInfo.mesh, i);
            }

            if (Time.time >= (currentCharacterIndex + 1) * 1f) // Check if animation for current character has completed
            {
                currentCharacterIndex++;
                if (currentCharacterIndex >= textInfo.characterCount)
                {
                    animationCompleted = true; // All characters have completed their animation
                }
                else if (currentCharacterIndex == 1) // Animation of "L" is completed
                {
                    isMovingUp = !isMovingUp; // Reverse the movement direction for "U"
                }
                else if (currentCharacterIndex == textInfo.characterCount - 1) // Animation of last character "O" is completed
                {
                    isLastCharacter = true; // Set the flag for last character
                }
            }
        }
        else if (isLastCharacter) // Animation completed, return last character "O" to its original position
        {
            textComponent.ForceMeshUpdate();
            var textInfo = textComponent.textInfo;
            var charInfo = textInfo.characterInfo[textInfo.characterCount - 1];
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)
            {
                var orig = originalPositions[(textInfo.characterCount - 1) * 4 + j];
                verts[charInfo.vertexIndex + j] = orig;
            }

            for (int i = 0; i < textInfo.meshInfo.Length; ++i)
            {
                var meshInfo = textInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                textComponent.UpdateGeometry(meshInfo.mesh, i);
            }
        }
    }
}
