using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Save_Serial_Data
{
    const string path_ending = "/Leveling/Save.dat";

    public static void Save_Data()
    {
        BinaryFormatter bform = new BinaryFormatter();

        string save_path = Application.persistentDataPath + path_ending;
        FileStream stream = new FileStream(save_path, FileMode.Create); // Creates new file or overwrites existing

        Serial_Data sdata = new Serial_Data();

        bform.Serialize(stream, sdata);
        stream.Close();
    }

    public static Serial_Data Load_Data()
    {
        string save_path = Application.persistentDataPath + path_ending;

        if (File.Exists(save_path))
        {
            BinaryFormatter bform = new BinaryFormatter();
            FileStream stream = new FileStream(save_path, FileMode.Open);

            Serial_Data sdata = bform.Deserialize(stream) as Serial_Data;
            stream.Close();

            return sdata;
        }
        else
        {
            return new Serial_Data();
        }
    }
}
