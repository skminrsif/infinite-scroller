using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Entity Data/Player Data")]
public class PlayerData : EntityData
{
    public int lives;
    public int filmCount;
    public float invulTime;
    public float deathTime;
    public float deathInvulTime;

}
