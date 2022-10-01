public class BulletsArmory
{
    public int Value { get; private set; }
    
    public BulletsArmory()
    {
        Value = 0;
    }

    public void AddBullets(int value)
    {
        Value += value;
    }

    public void ShotBullet()
    {
        if(Value > 0)
            Value--;
    }
}
