using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveGame()
    {
        Save save = CreateSave();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }

    private Save CreateSave()
    {
        Save save = new Save();

        if (GameData.Instance)
        {
            save.coins = GameData.Instance.coinCount;
            save.frags = GameData.Instance.FragCount;
            save.Intro = GameData.Instance.Intro;
        }
        return save;
    }

    public void LoadGame()
    {
        if(File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            GameData.Instance.coinCount = save.coins;
            GameData.Instance.FragCount = save.frags;
            GameData.Instance.Intro = save.Intro;
        }
    }
}
