using System;

namespace Codebase.Gameplay.Enums
{
    public enum CatAnimationType
    {
        none = 0,
        
        [CatAnimationTypeAttribute(2.667f)] action_digging,
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
        
        [CatAnimationTypeAttribute(0f)] add_aim_dowm,
        [CatAnimationTypeAttribute(0f)] add_aim_front,
        [CatAnimationTypeAttribute(0f)] add_aim_up,
        [CatAnimationTypeAttribute(0f)] add_angry,
        [CatAnimationTypeAttribute(0f)] add_blink,
        [CatAnimationTypeAttribute(0f)] add_breathe,
        [CatAnimationTypeAttribute(0f)] add_ears_heard,
        [CatAnimationTypeAttribute(0f)] add_ears_twitch_l,
        [CatAnimationTypeAttribute(0f)] add_ears_twitch_r,
        [CatAnimationTypeAttribute(0f)] add_incline,
        [CatAnimationTypeAttribute(0f)] add_incline_side,
        
        [CatAnimationTypeAttribute(0f)] combat_bite_l,
        [CatAnimationTypeAttribute(0f)] combat_bite_r,
        [CatAnimationTypeAttribute(0f)] combat_damage_bl,
        [CatAnimationTypeAttribute(0f)] combat_damage_br,
        [CatAnimationTypeAttribute(0f)] combat_damage_fl,
        [CatAnimationTypeAttribute(0f)] combat_damage_fr,
        [CatAnimationTypeAttribute(0f)] combat_damage_sl,
        [CatAnimationTypeAttribute(0f)] combat_damage_sr,
        [CatAnimationTypeAttribute(0f)] combat_death_l,
        [CatAnimationTypeAttribute(0f)] combat_death_r,
        [CatAnimationTypeAttribute(0f)] combat_paw_l,
        [CatAnimationTypeAttribute(0f)] combat_paw_r,
        
        [CatAnimationTypeAttribute(0f)] idle_base,
        [CatAnimationTypeAttribute(0f)] idle_look,
        [CatAnimationTypeAttribute(0f)] idle_look_down,
        [CatAnimationTypeAttribute(0f)] idle_loog_site,
        [CatAnimationTypeAttribute(0f)] idle_stretching,
        [CatAnimationTypeAttribute(0f)] idle_yaw,
        
        [CatAnimationTypeAttribute(0f)] jump_fall_high,
        [CatAnimationTypeAttribute(0f)] jump_fall_low,
        [CatAnimationTypeAttribute(0f)] jump_in_place,
        [CatAnimationTypeAttribute(0f)] jump_land_run,
        [CatAnimationTypeAttribute(0f)] jump_land_stop,
        [CatAnimationTypeAttribute(0f)] jump_run,
        
        [CatAnimationTypeAttribute(0f)] move_crouch_f,
        [CatAnimationTypeAttribute(0f)] move_crouch_idle,
        [CatAnimationTypeAttribute(0f)] move_crouch_l,
        [CatAnimationTypeAttribute(0f)] move_crouch_r,
        [CatAnimationTypeAttribute(0f)] move_crouch_turn_l,
        [CatAnimationTypeAttribute(0f)] move_crouch_turn_r,
        [CatAnimationTypeAttribute(0f)] move_run_f,
        [CatAnimationTypeAttribute(0f)] move_run_l,
        [CatAnimationTypeAttribute(0f)] move_run_r,
        [CatAnimationTypeAttribute(0f)] move_swim_enter,
        [CatAnimationTypeAttribute(0f)] move_swim_f,
        [CatAnimationTypeAttribute(0f)] move_swim_idle,
        [CatAnimationTypeAttribute(0f)] move_swim_l,
        [CatAnimationTypeAttribute(0f)] move_swim_r,
        [CatAnimationTypeAttribute(0f)] move_swim_turn_l,
        [CatAnimationTypeAttribute(0f)] move_swim_turn_r,
        [CatAnimationTypeAttribute(0f)] move_trot_f,
        [CatAnimationTypeAttribute(0f)] move_trot_l,
        [CatAnimationTypeAttribute(0f)] move_trot_r,
        [CatAnimationTypeAttribute(0f)] move_turn_45_l,
        [CatAnimationTypeAttribute(0f)] move_turn_45_r,
        [CatAnimationTypeAttribute(0f)] move_turn_90_l,
        [CatAnimationTypeAttribute(0f)] move_turn_90_r,
        [CatAnimationTypeAttribute(0f)] move_walk_f,
        [CatAnimationTypeAttribute(0f)] move_walk_l,
        [CatAnimationTypeAttribute(0f)] move_walk_r,
        
        [CatAnimationTypeAttribute(0f)] rest_edge_from,
        [CatAnimationTypeAttribute(0f)] rest_edge_idle,
        [CatAnimationTypeAttribute(0f)] rest_edge_to,
        [CatAnimationTypeAttribute(0f)] rest_lie_from,
        [CatAnimationTypeAttribute(0f)] rest_lie_idle,
        [CatAnimationTypeAttribute(0f)] rest_lie_to,
        [CatAnimationTypeAttribute(0f)] rest_sit_from,
        [CatAnimationTypeAttribute(0f)] rest_sit_idle,
        [CatAnimationTypeAttribute(0f)] rest_sit_to,
        [CatAnimationTypeAttribute(0f)] rest_sleep_from,
        [CatAnimationTypeAttribute(0f)] rest_sleep_idle,
        [CatAnimationTypeAttribute(0f)] rest_sleep_to,
    }

    public class CatAnimationTypeAttribute : Attribute
    {
        public float AnimationLength;

        public CatAnimationTypeAttribute(float animationLength) => AnimationLength = animationLength;
    }
}