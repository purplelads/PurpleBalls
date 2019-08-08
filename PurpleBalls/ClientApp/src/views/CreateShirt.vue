<template>
  <v-container fluid>
    <v-slide-y-transition mode='out-in'>
      <v-layout column>
        <v-select
          :items="players"
          item-text="firstName"
          label="Select a Player"
          :return-object="true"
          v-model="selectedPlayer"
          solo
        >
        
        </v-select>
        <PlayerShirt v-if="selectedPlayerShirt != null" :shirtInfo='selectedPlayerShirt'></PlayerShirt>
      </v-layout>
    </v-slide-y-transition>    
  </v-container>
</template>

<script lang='ts'>
import { Component, Vue, Watch } from 'vue-property-decorator';
import PlayerShirt from '@/components/PlayerShirt.vue';
import { PlayerShirtModel } from '../models/PlayerShirtModel';
import { Getter, Action } from 'vuex-class';
import { Player } from '../models/Player';
import _ from 'lodash';
const namespace: string = 'player';

@Component({
  components: { PlayerShirt },
})
export default class CreateShirtView extends Vue {

  private selectedPlayer!: Player;

  @Getter('playerShirts', { namespace })
  private playerShirts!: PlayerShirt[];

  @Action('getPlayerShirts', { namespace })
  private getPlayerShirts: any;

  @Getter('players', { namespace })
  private players!: Player[];

  @Action('getPlayers', { namespace })
  private getPlayers: any;

  private created() {
    if (this.players.length === 0 || this.playerShirts.length === 0) {
        this.refreshPlayers();
    }
  }

  get selectedPlayerShirt() {
    const self = this;
    if (self.selectedPlayer != null) {
      return _.find(self.playerShirts, (s: Player) => {
        return s.playerId === self.selectedPlayer.playerId;
      });
    }
  }

  private refreshPlayers() {
    this.getPlayers();
    this.getPlayerShirts();
  }

}
</script>
