//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Core.ECS.Components.MoneyCounter moneyCounterComponent = new Core.ECS.Components.MoneyCounter();

    public bool isMoneyCounter {
        get { return HasComponent(GameComponentsLookup.MoneyCounter); }
        set {
            if (value != isMoneyCounter) {
                var index = GameComponentsLookup.MoneyCounter;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : moneyCounterComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMoneyCounter;

    public static Entitas.IMatcher<GameEntity> MoneyCounter {
        get {
            if (_matcherMoneyCounter == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MoneyCounter);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMoneyCounter = matcher;
            }

            return _matcherMoneyCounter;
        }
    }
}
