namespace InternalAssets.Codebase.Gameplay.Generators
{
    public interface IGenerator<out T>
    {
        public T Generate();
    }
}