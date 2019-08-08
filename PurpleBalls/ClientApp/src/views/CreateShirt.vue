<template>
  <v-container fluid>
    <v-slide-y-transition mode='out-in'>
      <v-layout column>
        <PlayerShirt :shirtInfo='playerShirt'></PlayerShirt>
      </v-layout>
    </v-slide-y-transition>    
  </v-container>
</template>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator';
import PlayerShirt from '@/components/PlayerShirt.vue';
import { PlayerShirtModel } from '../models/PlayerShirtModel';

@Component({
  components: { PlayerShirt },
})
export default class CreateShirtView extends Vue {
  
  @Getter('playerShirts', { namespace })
  private playerShirts!: PlayerShirt[];

  @Action('getPlayerShirts', { namespace })
  private getPlayerShirts: any;

  @Getter('players', { namespace })
  private players!: Player[];

  @Action('getPlayers', { namespace })
  private getPlayers: any;

  private created() {
    if (this.players.length === 0) {
        this.refreshPlayers();
    }
    if (this.playerShirts.length ===0){
        this.refreshPlayers();
    }
  }

  private refreshPlayers() {
    this.getPlayers();
    this.getPlayerShirts();
  }

}
</script>
