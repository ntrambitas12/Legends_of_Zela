public enum SpriteAction
{
    //for sprites that don't need to change direction it's pointing
    still = 0,
    attack = 1,
    damage = 2,
    
    //for sprites that can change how they're pointing in all 4 directions
    stillLeft = 0,
    stillRight = 1,
    stillUp = 2,
    stillDown = 3,
    moveLeft = 4,
    moveRight = 5,
    moveUp = 6,
    moveDown = 7,
    attackLeft = 8,
    attackRight = 9,
    attackUp = 10,
    attackDown = 11,
    damageLeft = 12,
    damageRight = 13,
    damageUp = 14,
    damageDown = 15,
}