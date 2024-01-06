using System;

namespace Codebase.Gameplay.Enums
{
    public enum CatAnimationType
    {
        none = 0,
        
        [CatAnimationTypeAttribute(2.667f)] action_digging,
        [CatAnimationTypeAttribute(0.633f)] action_coding_begin,
        [CatAnimationTypeAttribute(1.5f)] action_coding_loop,
        [CatAnimationTypeAttribute(0.467f)] action_coding_finish,
        [CatAnimationTypeAttribute(3.0f)] action_drink_down,
        [CatAnimationTypeAttribute(3.0f)] action_drink_up,
        [CatAnimationTypeAttribute(2.83f)] action_drop_l_sit,
        [CatAnimationTypeAttribute(2.83f)] action_drop_r_sit,
        [CatAnimationTypeAttribute(3.0f)] action_eat_dowm,
        [CatAnimationTypeAttribute(3.0f)] action_eat_up,
        [CatAnimationTypeAttribute(6.67f)] action_licking_sit,
        [CatAnimationTypeAttribute(2.67f)] action_pet,
        [CatAnimationTypeAttribute(2.67f)] action_pet_lie,
        [CatAnimationTypeAttribute(2.67f)] action_pet_sit,
        [CatAnimationTypeAttribute(2.33f)] action_shaking,
        [CatAnimationTypeAttribute(4.333f)] action_sharpness_claws,
        
        [CatAnimationTypeAttribute(2.0f)] add_aim_dowm,
        [CatAnimationTypeAttribute(2.0f)] add_aim_front,
        [CatAnimationTypeAttribute(2.0f)] add_aim_up,
        [CatAnimationTypeAttribute(1.0f)] add_angry,
        [CatAnimationTypeAttribute(0.33f)] add_blink,
        [CatAnimationTypeAttribute(0.33f)] add_breathe,
        [CatAnimationTypeAttribute(2.667f)] add_ears_heard,
        [CatAnimationTypeAttribute(0.6f)] add_ears_twitch_l,
        [CatAnimationTypeAttribute(0.6f)] add_ears_twitch_r,
        [CatAnimationTypeAttribute(2.0f)] add_incline,
        [CatAnimationTypeAttribute(2.0f)] add_incline_side,
        
        [CatAnimationTypeAttribute(1.3f)] combat_bite_l,
        [CatAnimationTypeAttribute(1.3f)] combat_bite_r,
        [CatAnimationTypeAttribute(1.33f)] combat_damage_bl,
        [CatAnimationTypeAttribute(1.33f)] combat_damage_br,
        [CatAnimationTypeAttribute(1.667f)] combat_damage_fl,
        [CatAnimationTypeAttribute(1.667f)] combat_damage_fr,
        [CatAnimationTypeAttribute(1.33f)] combat_damage_sl,
        [CatAnimationTypeAttribute(1.33f)] combat_damage_sr,
        [CatAnimationTypeAttribute(1.33f)] combat_death_l,
        [CatAnimationTypeAttribute(1.33f)] combat_death_r,
        [CatAnimationTypeAttribute(1.33f)] combat_paw_l,
        [CatAnimationTypeAttribute(1.33f)] combat_paw_r,
        
        [CatAnimationTypeAttribute(2.667f)] idle_base,
        [CatAnimationTypeAttribute(3.333f)] idle_look,
        [CatAnimationTypeAttribute(6f)] idle_look_down,
        [CatAnimationTypeAttribute(5.33f)] idle_look_site,
        [CatAnimationTypeAttribute(4.33f)] idle_stretching,
        [CatAnimationTypeAttribute(2.667f)] idle_yaw,
        
        [CatAnimationTypeAttribute(1.33f)] jump_fall_high,
        [CatAnimationTypeAttribute(1.33f)] jump_fall_low,
        [CatAnimationTypeAttribute(2.6f)] jump_in_place,
        [CatAnimationTypeAttribute(0.33f)] jump_land_run,
        [CatAnimationTypeAttribute(0.83f)] jump_land_stop,
        [CatAnimationTypeAttribute(1.667f)] jump_run,
        
        [CatAnimationTypeAttribute(1f)] move_crouch_f,
        [CatAnimationTypeAttribute(2.667f)] move_crouch_idle,
        [CatAnimationTypeAttribute(1f)] move_crouch_l,
        [CatAnimationTypeAttribute(1f)] move_crouch_r,
        [CatAnimationTypeAttribute(1f)] move_crouch_turn_l,
        [CatAnimationTypeAttribute(1f)] move_crouch_turn_r,
        [CatAnimationTypeAttribute(0.667f)] move_run_f,
        [CatAnimationTypeAttribute(0.667f)] move_run_l,
        [CatAnimationTypeAttribute(0.667f)] move_run_r,
        [CatAnimationTypeAttribute(2f)] move_swim_enter,
        [CatAnimationTypeAttribute(1.067f)] move_swim_f,
        [CatAnimationTypeAttribute(1.667f)] move_swim_idle,
        [CatAnimationTypeAttribute(1.067f)] move_swim_l,
        [CatAnimationTypeAttribute(1.067f)] move_swim_r,
        [CatAnimationTypeAttribute(1.067f)] move_swim_turn_l,
        [CatAnimationTypeAttribute(1.067f)] move_swim_turn_r,
        [CatAnimationTypeAttribute(0.8f)] move_trot_f,
        [CatAnimationTypeAttribute(0.8f)] move_trot_l,
        [CatAnimationTypeAttribute(0.8f)] move_trot_r,
        [CatAnimationTypeAttribute(1f)] move_turn_45_l,
        [CatAnimationTypeAttribute(1f)] move_turn_45_r,
        [CatAnimationTypeAttribute(1f)] move_turn_90_l,
        [CatAnimationTypeAttribute(1f)] move_turn_90_r,
        [CatAnimationTypeAttribute(1.667f)] move_walk_f,
        [CatAnimationTypeAttribute(1.667f)] move_walk_l,
        [CatAnimationTypeAttribute(1.667f)] move_walk_r,
        
        [CatAnimationTypeAttribute(1.167f)] rest_edge_from,
        [CatAnimationTypeAttribute(2.667f)] rest_edge_idle,
        [CatAnimationTypeAttribute(0.833f)] rest_edge_to,
        [CatAnimationTypeAttribute(1.33f)] rest_lie_from,
        [CatAnimationTypeAttribute(2.667f)] rest_lie_idle,
        [CatAnimationTypeAttribute(1.33f)] rest_lie_to,
        [CatAnimationTypeAttribute(1.33f)] rest_sit_from,
        [CatAnimationTypeAttribute(2.667f)] rest_sit_idle,
        [CatAnimationTypeAttribute(1.33f)] rest_sit_to,
        [CatAnimationTypeAttribute(1.33f)] rest_sleep_from,
        [CatAnimationTypeAttribute(2.667f)] rest_sleep_idle,
        [CatAnimationTypeAttribute(2.667f)] rest_sleep_to,
    }

    public class CatAnimationTypeAttribute : Attribute
    {
        public float AnimationLength;

        public CatAnimationTypeAttribute(float animationLength) => AnimationLength = animationLength;
    }
}