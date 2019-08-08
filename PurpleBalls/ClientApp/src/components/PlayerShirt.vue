<template>
  <div class="shirt-template">
    <svg viewBox="0 0 190 190" xmlns="http://www.w3.org/2000/svg">        
        
        <!-- Style 1 And 2 (2 change arm colour) -->
        <rect width="100" height="140" x="45" y="30" rx="10" ry="10" :fill="shirtInfo.shirtPrimary"/>
        <path id="collar" :fill="shirtInfo.shirtPrimary" d="
                                            M45 40
                                            v-10
                                            l30 -10
                                            q20,20  40,0
                                            l30 10
                                            v10
                                            Z
        "/>
        <path id="l-arm" :fill="
        (shirtInfo.shirtStyle == 2 
        || shirtInfo.shirtStyle == 3 
        || shirtInfo.shirtStyle == 4) ? shirtInfo.shirtSecondary : shirtInfo.shirtPrimary" d="
                                            M45 30
                                            l-40 55
                                            q-1.5,2.5 0,5
                                            l25 25
                                            q2.5,2.5 5,0
                                            l10 -15
                                            Z
        "/>
        <path id="r-arm" :fill="(shirtInfo.shirtStyle == 2 
        || shirtInfo.shirtStyle == 3 
        || shirtInfo.shirtStyle == 4) ? shirtInfo.shirtSecondary : shirtInfo.shirtPrimary" d="
                                            M145 30
                                            l40 55
                                            q1.5,2.5 0,5
                                            l-25 25
                                            q-2.5,2.5 -5,0
                                            l-10 -15
                                            Z
        "/>

        <!-- Style 3 Stripe Vertical -->
        <path id="stripe" v-if="shirtInfo.shirtStyle == 3" :fill="shirtInfo.shirtSecondary" d="
                                            M75 20
                                            v150
                                            h40
                                            v-150
                                            q-20,20 -40,0
                                            Z
        "/>

        <!-- Style 4 Stripe Horizontal -->
        <rect class="horiz-stripe" width="100" height="40" x="45" y="40" v-if="shirtInfo.shirtStyle == 4" :fill="shirtInfo.shirtSecondary"/>
        <rect class="horiz-stripe" width="100" height="40" x="45" y="110" v-if="shirtInfo.shirtStyle == 4" :fill="shirtInfo.shirtSecondary"/>

        <!-- Style 5 Coloured Tips -->
        <path v-if="shirtInfo.shirtStyle == 5" id="l-arm-tip" :fill="shirtInfo.shirtSecondary" d="
                                            M5 85
                                            q-1.5,2.5 0,5
                                            l25 25
                                            q2.5,2.5 5,0
                                            Z
        "/>
        <path v-if="shirtInfo.shirtStyle == 5" id="r-arm-tip" :fill="shirtInfo.shirtSecondary" d="
                                            M185 85
                                            q1.5,2.5 0,5
                                            l-25 25
                                            q-2.5,2.5 -5,0
                                            Z
        "/>
        <path v-if="shirtInfo.shirtStyle == 5" id="collar-tip" :fill="shirtInfo.shirtSecondary" d="
                                            M75 20
                                            q20,20  40,0
                                            l4 1.4
                                            q-24,24 -48,0
                                            Z
        "/>

        <path id="text-path" fill="transparent" d="M50 65 q45,-25 90,0"/>
        <text class="player-name" text-anchor="middle" :fill="shirtInfo.textColour">
            <textPath startOffset="50%" xlink:href="#text-path">
                {{shirtInfo.shirtName}}
            </textPath>
        </text>
        <text class="player-number" text-anchor="middle" x="95" y="120" :fill="shirtInfo.textColour" stroke="#a0a0a0" stroke-width="1">{{shirtInfo.shirtNumber}}</text>
    </svg>
  </div>
</template>

<style>
@font-face{
    font-family: OpenSans;
    src: url("../assets/fonts/OpenSans-Bold.ttf"); 
}
@font-face{
    font-family: OpenSansExtraBold;
    src: url("../assets/fonts/OpenSans-ExtraBold.ttf"); 
}
.shirt-template{
    width:190px;
}
.player-name{
    font-family: OpenSans;
    text-transform: uppercase;
}
.player-number{
    font-family:OpenSansExtraBold;
    font-size: 60px;
}
</style>


<script lang="ts">
import { State, Action, Getter } from 'vuex-class';
import { Component, Prop, Vue, Watch } from 'vue-property-decorator';
import { PlayerShirtModel } from '../models/PlayerShirtModel';

@Component({})
export default class CreateShirt extends Vue {
    @Prop({type: Object as () => PlayerShirtModel}) private shirtInfo!: PlayerShirtModel;
}
</script>
