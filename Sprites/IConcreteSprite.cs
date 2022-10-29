﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

public interface IConcreteSprite : ISprite
{
    public ISpriteState still { get; set; }
    public ISpriteState moving { get; set; }
    public ISpriteState damaged { get; set; }
    public ISpriteState dead { get; set; }
    public ISpriteState stillAnimated { get; set; }
    public ISpriteState attack { get; set; }
    public ISpriteState use { get; set; }
    public int health { get; set; }
    public bool isDead { get; set; }
    public IProjectile[] projectiles { get; set; }

    void SetSpriteState(SpriteAction action, ISpriteState spriteState);

    public void AddProjectile(IProjectile projectile, ArrayIndex i);
    public ArrayIndex ProjectileIndex();
    public void SetProjectileIndex(ArrayIndex i);
    public void ProjectileAttack();
    public void SwordAttack();
    public void TakeDamage();
}

