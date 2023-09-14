using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class GameManage : MonoBehaviour
{
    public Image pokemonImage;
    public TMP_Text pokemonNameText;
    public TMP_Text pokemonWegText;
    public TMP_Text pokemonhpText;
    public TMP_Text pokemonattackText;
    public TMP_Text pokemondefText;

    
    private const string apiURL = "https://pokeapi.co/api/v2/pokemon/";

    public Scrollbar loading;
    public TMP_Text download;
    public TMP_Text downLoading;

    public void OnButtonClick()
    {
        int pokemonID = UnityEngine.Random.Range(1, 899);

        string pokemonURL = apiURL + pokemonID;
        
        loading.size = 0.2f;
        StartCoroutine(FetchPokemonData(pokemonURL));
    }


    private IEnumerator FetchPokemonData(string url)
    {
        using (var webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            loading.size = 0.4f;
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error fetching Pokemon data: " + webRequest.error);
                yield break;
            }
            string response = webRequest.downloadHandler.text;
            //convert json data to pokemon data 
            PokemonData pokemonData = JsonUtility.FromJson<PokemonData>(response);

            // Update UI elements
            pokemonNameText.text = pokemonData.name;

            // Download and set the Pokemon image
            using (var imageRequest = UnityWebRequestTexture.GetTexture(pokemonData.sprites.front_default))
            {
                loading.size = 0.6f;
                yield return imageRequest.SendWebRequest();

                if (imageRequest.result == UnityWebRequest.Result.ConnectionError || imageRequest.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError("Error downloading Pokemon image: " + imageRequest.error);
                    yield break;
                }
                Texture2D texture = DownloadHandlerTexture.GetContent(imageRequest);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                pokemonImage.sprite = sprite;
                loading.size = 0.8f;
                
                // Fetch and display HP, Attack, and Defense stats
                foreach (var stat in pokemonData.stats)
                {
                    string statName = stat.stat.name;
                    int baseStat = stat.base_stat;

                    if (statName == "hp")
                        pokemonhpText.text = "Hit Points: " + baseStat;
                    else if (statName == "attack")
                        pokemonattackText.text = "Attack: " + baseStat;
                    else if (statName == "defense")
                        pokemondefText.text = "Defense: " + baseStat;
                }
                pokemonWegText.text = "Weighs: " + pokemonData.weight;
            }
        }
        StartCoroutine(CompleteDownload());   
    }

    private IEnumerator CompleteDownload()
    {
        yield return new WaitForSeconds(0.8f);
        loading.size = 1.0f;
        downLoading.gameObject.SetActive(false);
        download.gameObject.SetActive(true);

    }

    [Serializable]
    public class PokemonData
    {
        public string name;
        public SpriteData sprites;
        public StatData[] stats;
        public string weight;
    }
    [Serializable]
    public class StatData
    {
        public Stat stat;
        public int base_stat;
    }
    
    [Serializable]
    public class Stat
    {
        public string name;
    }
    
    [Serializable]
    public class SpriteData
    {
        public string front_default;
    }

    public class Test
    {
        public int value;
        public string name;
    }
    
}