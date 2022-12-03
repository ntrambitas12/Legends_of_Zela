using System;

public interface IProjectile : IItem
{
    public int Direction();
    public void SetDirection(int direction);
    public FireProjectile FireCommand();
    public void SetFireCommand(FireProjectile fireProjectile);
    public int Distance();
    public void SetDistance(int distance);
    public bool ShouldCollide();
    public void SetShouldCollide(bool shouldCollide);
    public String GetDropName();
    public String GetDropDescription();
}


