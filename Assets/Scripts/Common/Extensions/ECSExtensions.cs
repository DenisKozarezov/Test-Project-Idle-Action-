namespace Core
{
    public static class ECSExtensions
    {
        public static GameContext Game() => Contexts.sharedInstance.game;
        public static GameEntity Empty() => Game().CreateEntity();
    }
}