using System;

namespace InternalAssets.Codebase.Gameplay.Entities.Cats.Enums
{
    public enum CatAnimationType
    {
        none = 0,
        
        [CatAnimationType(2.667f)] action_digging,
        [CatAnimationType(0.633f)] action_coding_begin,
        [CatAnimationType(1.5f)] action_coding_loop,
        [CatAnimationType(0.467f)] action_coding_finish,
        [CatAnimationType(3.0f)] action_drink_down,
        [CatAnimationType(3.0f)] action_drink_up,
        [CatAnimationType(2.83f)] action_drop_l_sit,
        [CatAnimationType(2.83f)] action_drop_r_sit,
        [CatAnimationType(3.0f)] action_eat_dowm,
        [CatAnimationType(3.0f)] action_eat_up,
        [CatAnimationType(6.67f)] action_licking_sit,
        [CatAnimationType(2.67f)] action_pet,
        [CatAnimationType(2.67f)] action_pet_lie,
        [CatAnimationType(2.67f)] action_pet_sit,
        [CatAnimationType(2.33f)] action_shaking,
        [CatAnimationType(4.333f)] action_sharpness_claws,
        
        [CatAnimationType(2.0f)] add_aim_dowm,
        [CatAnimationType(2.0f)] add_aim_front,
        [CatAnimationType(2.0f)] add_aim_up,
        [CatAnimationType(1.0f)] add_angry,
        [CatAnimationType(0.33f)] add_blink,
        [CatAnimationType(0.33f)] add_breathe,
        [CatAnimationType(2.667f)] add_ears_heard,
        [CatAnimationType(0.6f)] add_ears_twitch_l,
        [CatAnimationType(0.6f)] add_ears_twitch_r,
        [CatAnimationType(2.0f)] add_incline,
        [CatAnimationType(2.0f)] add_incline_side,
        
        [CatAnimationType(1.3f)] combat_bite_l,
        [CatAnimationType(1.3f)] combat_bite_r,
        [CatAnimationType(1.33f)] combat_damage_bl,
        [CatAnimationType(1.33f)] combat_damage_br,
        [CatAnimationType(1.667f)] combat_damage_fl,
        [CatAnimationType(1.667f)] combat_damage_fr,
        [CatAnimationType(1.33f)] combat_damage_sl,
        [CatAnimationType(1.33f)] combat_damage_sr,
        [CatAnimationType(1.33f)] combat_death_l,
        [CatAnimationType(1.33f)] combat_death_r,
        [CatAnimationType(1.33f)] combat_paw_l,
        [CatAnimationType(1.33f)] combat_paw_r,
        
        [CatAnimationType(2.667f)] idle_base,
        [CatAnimationType(3.333f)] idle_look,
        [CatAnimationType(6f)] idle_look_down,
        [CatAnimationType(5.33f)] idle_look_site,
        [CatAnimationType(4.33f)] idle_stretching,
        [CatAnimationType(2.667f)] idle_yaw,
        
        [CatAnimationType(1.33f)] jump_fall_high,
        [CatAnimationType(1.33f)] jump_fall_low,
        [CatAnimationType(2.6f)] jump_in_place,
        [CatAnimationType(0.33f)] jump_land_run,
        [CatAnimationType(0.83f)] jump_land_stop,
        [CatAnimationType(1.667f)] jump_run,
        
        [CatAnimationType(1f)] move_crouch_f,
        [CatAnimationType(2.667f)] move_crouch_idle,
        [CatAnimationType(1f)] move_crouch_l,
        [CatAnimationType(1f)] move_crouch_r,
        [CatAnimationType(1f)] move_crouch_turn_l,
        [CatAnimationType(1f)] move_crouch_turn_r,
        [CatAnimationType(0.667f)] move_run_f,
        [CatAnimationType(0.667f)] move_run_l,
        [CatAnimationType(0.667f)] move_run_r,
        [CatAnimationType(2f)] move_swim_enter,
        [CatAnimationType(1.067f)] move_swim_f,
        [CatAnimationType(1.667f)] move_swim_idle,
        [CatAnimationType(1.067f)] move_swim_l,
        [CatAnimationType(1.067f)] move_swim_r,
        [CatAnimationType(1.067f)] move_swim_turn_l,
        [CatAnimationType(1.067f)] move_swim_turn_r,
        [CatAnimationType(0.8f)] move_trot_f,
        [CatAnimationType(0.8f)] move_trot_l,
        [CatAnimationType(0.8f)] move_trot_r,
        [CatAnimationType(1f)] move_turn_45_l,
        [CatAnimationType(1f)] move_turn_45_r,
        [CatAnimationType(1f)] move_turn_90_l,
        [CatAnimationType(1f)] move_turn_90_r,
        [CatAnimationType(1.667f)] move_walk_f,
        [CatAnimationType(1.667f)] move_walk_l,
        [CatAnimationType(1.667f)] move_walk_r,
        
        [CatAnimationType(1.167f)] rest_edge_from,
        [CatAnimationType(2.667f)] rest_edge_idle,
        [CatAnimationType(0.833f)] rest_edge_to,
        [CatAnimationType(1.33f)] rest_lie_from,
        [CatAnimationType(2.667f)] rest_lie_idle,
        [CatAnimationType(1.33f)] rest_lie_to,
        [CatAnimationType(1.33f)] rest_sit_from,
        [CatAnimationType(2.667f)] rest_sit_idle,
        [CatAnimationType(1.33f)] rest_sit_to,
        [CatAnimationType(1.33f)] rest_sleep_from,
        [CatAnimationType(2.667f)] rest_sleep_idle,
        [CatAnimationType(2.667f)] rest_sleep_to,
    }

    public class CatAnimationTypeAttribute : Attribute
    {
        public float AnimationLength { get; private set; } = 0f;

        public CatAnimationTypeAttribute(float animationLength) => AnimationLength = animationLength;
    }
}