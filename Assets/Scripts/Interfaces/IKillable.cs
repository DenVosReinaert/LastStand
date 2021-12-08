public interface IKillable
{

    public int health { get; set; }
    public void Die();
    public void Damage(int incomingDamage);

}
