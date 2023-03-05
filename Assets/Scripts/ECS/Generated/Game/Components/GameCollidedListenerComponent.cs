//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CollidedListenerComponent collidedListener { get { return (CollidedListenerComponent)GetComponent(GameComponentsLookup.CollidedListener); } }
    public bool hasCollidedListener { get { return HasComponent(GameComponentsLookup.CollidedListener); } }

    public void AddCollidedListener(System.Collections.Generic.List<ICollidedListener> newValue) {
        var index = GameComponentsLookup.CollidedListener;
        var component = (CollidedListenerComponent)CreateComponent(index, typeof(CollidedListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCollidedListener(System.Collections.Generic.List<ICollidedListener> newValue) {
        var index = GameComponentsLookup.CollidedListener;
        var component = (CollidedListenerComponent)CreateComponent(index, typeof(CollidedListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCollidedListener() {
        RemoveComponent(GameComponentsLookup.CollidedListener);
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

    static Entitas.IMatcher<GameEntity> _matcherCollidedListener;

    public static Entitas.IMatcher<GameEntity> CollidedListener {
        get {
            if (_matcherCollidedListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CollidedListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCollidedListener = matcher;
            }

            return _matcherCollidedListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddCollidedListener(ICollidedListener value) {
        var listeners = hasCollidedListener
            ? collidedListener.value
            : new System.Collections.Generic.List<ICollidedListener>();
        listeners.Add(value);
        ReplaceCollidedListener(listeners);
    }

    public void RemoveCollidedListener(ICollidedListener value, bool removeComponentWhenEmpty = true) {
        var listeners = collidedListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveCollidedListener();
        } else {
            ReplaceCollidedListener(listeners);
        }
    }
}
