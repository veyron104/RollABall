using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[DataContract]
public class PlayerData
{
    [DataMember]
    public string NickName = "";
    [DataMember]
    public List<BonusData> GoodBonuses = new List<BonusData>();
    [DataMember]
    public List<BonusData> BadBonuses = new List<BonusData>();

    public PlayerData(string nickName)
    {
        NickName = nickName;
        ListChecker();
    }

    public void RestartGame()
    {
        ListChecker();
        SaveList(GoodBonuses);
        SaveList(BadBonuses);
    }

    public void SaveList(List<BonusData> chekingList)
    {
        for (int i = 0; i < chekingList.Count; i++)
        {
            chekingList[i].IsActive = true;
        }
    }

    public void SaveData()
    {
        ListChecker();
        SaveList(GoodBonuses, GameManager.s_GameManager.GoodBonuses);
        SaveList(BadBonuses, GameManager.s_GameManager.BadBonuses);
    }

    public void SaveList(List<BonusData> chekingList, List<IInteractive> baseList)
    {
        for (int i = 0; i < chekingList.Count; i++)
        {
            chekingList[i].IsActive = baseList[i].IsActive;
        }
    }

    public void ListChecker()
    {
        CountChecker(GoodBonuses, GameManager.s_GameManager.GoodBonuses);
        CountChecker(BadBonuses, GameManager.s_GameManager.BadBonuses);
    }

    void CountChecker(List<BonusData> chekingList, List<IInteractive> baseList)
    {
        while (chekingList.Count < baseList.Count)
        {
            chekingList.Add(new BonusData());
        }
    }
}