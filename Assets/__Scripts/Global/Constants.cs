public static class Constants {
    public static class AnimatorParameters {
        //Movements
        public const string VELOCITY_FLOAT = "VelocityFloat";
        public const string ROTATION_FLOAT = "RotationFloat";
        public const string JUMP_TRIGGER = "JumpTrigger";

        public const string DEATH_TRIGGER = "DeathTrigger";
        public const string DEATH_INT = "DeathInt";
        public const string REVIVE_TRIGGER = "ReviveTrigger";
        public const string GET_LIGHT_HIT_TRIGGER = "GetLightHitTrigger";
        public const string ALIVE_BOOL = "AliveBool";
        public const string WALKING_BOOL = "WalkingBool";

        //Attacks
        public const string NORMAL_ATTACK_TRIGGER = "NormalAttackTrigger";
        public const string NORMAL_ATTACK_BOOL = "NormalAttackBool";
    };

    public static class KeyInputs
    {
        public const string LEFT_MOUSE_CLICK = "Fire1";
        public const string VERTICAL = "Vertical";
        public const string HORIZONTAL = "Horizontal";
    }

    public static class ObjectTags
    {
        public const string WEAPON = "Weapon";
    }

    public static class Layers
    {
        public const string HITABLE = "Hitable";
        public const string DAMAGEABLE = "Damageable";
        public const string CHARACTER = "Character";
        public const string ITEM = "Item";
    }

    public static class StatsMultiplier
    {
        public const int STRENGTH = 5;
        public const int VITALITY = 5;
        public const int INTELLIGENT = 5;
    }

    public const string SCENE_CONTROLLER_TAG = "SceneController";
        
}
