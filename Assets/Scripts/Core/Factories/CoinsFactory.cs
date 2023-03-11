using UnityEngine;
using Zenject;

namespace Core
{
    public interface ICoinsFactory : IFactory<RectTransform>
    {

    }

    public sealed class CoinsFactory : PlaceholderFactory<RectTransform>
    {

    }
}
