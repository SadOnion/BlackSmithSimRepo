using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreSerializer {

    private const int maxLength = 5;
    private string path = "ScoreData.data";

    public void SerializeList(List<Score> list)
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(path)) File.Create(path);
        using (FileStream fs = new FileStream(path,FileMode.Open, FileAccess.Write))
        {
            bf.Serialize(fs,list);
        }
    }
    public bool CanWriteNewScore(int  taxPaid)
    {
        List<Score> scoreList = ReadScoreList();
        if (scoreList.Count < maxLength) return true;
        else
        {
            int min= scoreList[0].taxPaid;
            foreach(Score s in scoreList)
            {
                if (min > s.taxPaid) min = s.taxPaid;
            }
            if (taxPaid > min) return true;
            else return false;
        }
    }
    public List<Score> ReadScoreList()
    {
        List<Score> returnList = new List<Score>();
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(path))
        {
            File.Create(path);
            for (int i = 0; i < 5; i++)
            {
                returnList.Add(new Score(0, "none"));
            }
           
        }
        using (FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read))
        {
            returnList = (List<Score>)bf.Deserialize(fs);
        }
        return returnList;
    }
}
[System.Serializable]
public class Score : IComparable
{
    public int taxPaid;
    public string name;

    public Score(int tax,string name)
    {
        this.name = name;
        taxPaid = tax;
    }
    public int CompareTo(object obj)
    {
        if(obj is Score)
        {
            Score scoreToCompare = (Score)obj;
            return scoreToCompare.taxPaid.CompareTo(taxPaid);
        }
        return 0;


    }
}
