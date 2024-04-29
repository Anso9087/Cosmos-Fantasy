using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private void Awake(){
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);


        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        for(int i = 0; i < highscores.highscoreEntryList.Count; i++){ //swap
            for(int j = i; j < highscores.highscoreEntryList.Count; j++){
                if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score){
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        if (highscores.highscoreEntryList.Count > 10){
            for (int h = highscores.highscoreEntryList.Count; h>10; h--){
                highscores.highscoreEntryList.RemoveAt(10);
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach(HighscoreEntry highscoreEntry in highscores.highscoreEntryList){
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

    }
    private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, 
        Transform container, List<Transform> transformList)
        {
            float templateHeight = 40f;
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight*transformList.Count);
            entryTransform.gameObject.SetActive(true);

            int rank = transformList.Count + 1;
            string rankString;
            switch(rank){
            default: rankString = rank + "TH";break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
            }
            entryTransform.Find("Rank").GetComponent<TMP_Text>().text = rankString;
            int score = highscoreEntry.score;
            entryTransform.Find("Score").GetComponent<TMP_Text>().text = score.ToString();
            int kill = highscoreEntry.kill;
            entryTransform.Find("Kill").GetComponent<TMP_Text>().text = kill.ToString(); 
            DateTime currentDate = DateTime.Today;
            entryTransform.Find("Date").GetComponent<TMP_Text>().text = currentDate.ToString("dd/MM/yyyy");

            transformList.Add(entryTransform);       

    }
    public static void AddHighscoreEntry(int score, int kill){
        //create entry
        HighscoreEntry highscoreEntry = new HighscoreEntry{score = score, kill =kill};
        //load entry
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //add new entry
        highscores.highscoreEntryList.Add(highscoreEntry);
        for(int i = 0; i < highscores.highscoreEntryList.Count; i++){ //swap
            for(int j = i; j < highscores.highscoreEntryList.Count; j++){
                if(highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score){
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        //save update
        if (highscores.highscoreEntryList.Count > 10){
            for (int h = highscores.highscoreEntryList.Count; h>10; h--){
                highscores.highscoreEntryList.RemoveAt(10);
            }
        }
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    private class Highscores{
        public List<HighscoreEntry> highscoreEntryList;
    } 

    [System.Serializable]
    private class HighscoreEntry {
        public int score;
        public int kill;
    }
}
