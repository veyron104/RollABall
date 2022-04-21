using System.Runtime.Serialization;

[DataContract]
public class BonusData
{
    [DataMember]
    public bool IsActive = true;
}