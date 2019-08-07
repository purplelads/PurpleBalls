<template>
  <div class="shirt-template">
    <svg viewBox="0 0 190 190" xmlns="http://www.w3.org/2000/svg">        
        
        <rect width="100" height="140" x="45" y="30" rx="10" ry="10" :fill="playerShirt.shirtPrimary"/>
        <path id="collar" :fill="playerShirt.shirtPrimary" d="
                                            M45 40
                                            v-10
                                            l30 -10
                                            q20,20  40,0
                                            l30 10
                                            v10
                                            Z
        "/>
        <path id="l-arm" :fill="playerShirt.shirtSecondary" d="
                                            M45 30
                                            l-40 55
                                            q-1.5,2.5 0,5
                                            l25 25
                                            q2.5,2.5 5,0
                                            l10 -15
                                            Z
        "/>
        <path id="r-arm" :fill="playerShirt.shirtSecondary" d="
                                            M145 30
                                            l40 55
                                            q1.5,2.5 0,5
                                            l-25 25
                                            q-2.5,2.5 -5,0
                                            l-10 -15
                                            Z
        "/>
        <path id="text-path" fill="transparent" d="M50 65 q45,-25 90,0"/>
        <text class="player-name" text-anchor="middle" :fill="playerShirt.textColour">
            <textPath startOffset="50%" xlink:href="#text-path">
                {{playerShirt.shirtName}}
            </textPath>
        </text>
        <text class="player-number" text-anchor="middle" x="95" y="120" :fill="playerShirt.textColour" stroke="#a0a0a0" stroke-width="1">{{playerShirt.shirtNumber}}</text>
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
import { Component, Prop, Vue } from 'vue-property-decorator';
import { PlayerShirtModel } from '../models/PlayerShirtModel';

@Component({})
export default class CreateShirt extends Vue {
    @Prop({type: Object as () => PlayerShirtModel}) shirtInfo
    private playerShirt: PlayerShirtModel = this.shirtInfo;
}
</script>
