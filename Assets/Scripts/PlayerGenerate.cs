using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class PlayerGenerate : MonoBehaviour
{
  public TMP_InputField nameField;
  public TMP_InputField ageField;
  public TMP_InputField colorField;
  public List<PlayerDetails> playerList = new List<PlayerDetails>();


  public void GeneratePlayer()
  {
    string name = nameField.text;
    int age = int.Parse(ageField.text);
    Color color = GetColorFromInput(colorField.text);

    PlayerDetails newPlayer = new PlayerDetails
    {
      name = name,
      age = age,
      color = color
    };
    playerList.Add(newPlayer);
  }

  private Color GetColorFromInput(string colorText)
  {
    Color color;
    if(ColorUtility.TryParseHtmlString(colorText, out color))
    {
      return color;
    }
    else
    {
      Debug.LogWarning("Invalid Color Format.");
      return Color.white;
    }
  }
}


