public static class Storage
{
    static int lives = 3;

    public static int GetLives()
    {
        return lives;
    }

    public static void SetLives(int newLives)
    {
        lives = newLives;
    }
}