using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public interface ILinkActionState
{
    public void Move(Vector2 movement);
    public void SwordAttack();
    public void BowAttack();
}

public interface IDamageState
{
    public void TakeDamage(int damage);
}
