public enum SpriteAction
{
    //for sprites that don't need to change direction it's pointing
    still = 0,
    attack = 1,
    damage = 2,
    
    //for sprites that can change how they're pointing in all 4 directions
    moveLeft = 0,
    moveRight = 1,
    moveUp = 2,
    moveDown = 3,
    attackLeft = 4,
    attackRight = 5,
    attackUp = 6,
    attackDown = 7,
    damageLeft = 8,
    damageRight = 9,
    damageUp = 10,
    damageDown = 11,
}