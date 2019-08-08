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
        <div>
        <v-form id="create-player-form">
          <v-card-title>
            <span class="headline">Customize Your Shirt</span>
          </v-card-title>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12 sm6 md6>
                  <v-text-field label="Shirt Name*" v-model="selectedPlayerShirt.shirtName"></v-text-field>
                </v-flex>
                <v-flex xs12 sm6 md6>
                  <v-text-field label="Shirt Number*" v-model="selectedPlayerShirt.shirtNumber"></v-text-field>
                </v-flex>
              </v-layout>
            </v-container>
            <small>*indicates required field</small>
          </v-card-text>
        </v-form>

        <PlayerShirt id="player-shirt" v-if="selectedPlayerShirt != null" :shirtInfo='selectedPlayerShirt'></PlayerShirt>
      </div>
      </v-layout>
    </v-slide-y-transition>    
  </v-container>
</template>

<style>
#player-shirt{
  width: 50%;
  float:left;
  padding: 0px 20px;
}
#create-player-form{
  width: 50%;
  float: left;
  background-color: #eaeaea;
}
</style>


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

  private selectedPlayer: Player = null;

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
    else{
      return new PlayerShirtModel(null, "Example", 0, 1, "#000000", "#000000", "#FFFFFF", null)
    }
  }

  private refreshPlayers() {
    this.getPlayers();
    this.getPlayerShirts();
  }

}
</script>
