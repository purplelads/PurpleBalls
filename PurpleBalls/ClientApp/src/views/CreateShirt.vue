<template>
  <v-container fluid>
    <v-slide-y-transition mode='out-in'>
      <v-layout column>
        <v-select
          :items='players'
          item-text='firstName'
          label='Select a Player'
          :return-object='true'
          v-model='selectedPlayer'
          :change="selectPlayerShirt()"
          solo
        >        
        </v-select>
        <div>
        <v-form id='create-player-form'>
          <v-card-title>
            <span class='headline'>Customize Your Shirt</span>
          </v-card-title>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12 sm6 md6>
                  <v-text-field label='Shirt Name*' v-model='selectedPlayerShirt.shirtName'></v-text-field>
                </v-flex>
                <v-flex xs12 sm6 md6>
                  <v-text-field label='Shirt Number*' v-model='selectedPlayerShirt.shirtNumber'></v-text-field>
                </v-flex>
                <v-flex xs12 sm6 md6>
                  Shirt Style
                  <v-select
                    :items='shirtStyles'
                    item-text='styleName'
                    label='Select a Shirt Style'
                    item-value='styleId'
                    v-model='selectedPlayerShirt.shirtStyle'
                    solo
                  >        
                  </v-select>
                </v-flex>
                <v-flex xs12>
                  Shirt Colour
                  <Chrome :value='selectedPlayerShirt.shirtPrimary' @input='updatePrimaryColour'></Chrome>
                </v-flex>
                <v-flex v-show='selectedPlayerShirt.shirtStyle != 1' xs12>
                  Secondary Shirt Colour
                  <Chrome :value='selectedPlayerShirt.shirtSecondary' @input='updateSecondaryColour'></Chrome>
                </v-flex>
                <v-flex xs12>
                  Text Colour
                  <Chrome :value='selectedPlayerShirt.textColour' @input='updateTextColour'></Chrome>
                </v-flex>

                <v-btn v-if='selectedPlayer != null && selectedPlayer.playerId > 0' @click='savePlayer()' color='primary'>Save</v-btn>
              </v-layout>
            </v-container>
            <small>*indicates required field</small>
          </v-card-text>
        </v-form>

        <PlayerShirt id='player-shirt' :shirtInfo='selectedPlayerShirt'></PlayerShirt>
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
import { PlayerShirtStyles } from '../models/PlayerShirtStyles';
import _ from 'lodash';
import { Chrome } from 'vue-color';
const namespace: string = 'player';

@Component({
  components: { PlayerShirt, Chrome },
})
export default class CreateShirtView extends Vue {

  private colors = '#000000';
  private selectedPlayer: Player = null;
  private defaultShirt: PlayerShirtModel = {
    playerShirtId: 0,
    shirtName: 'Example',
    shirtNumber: 0,
    shirtStyle: 1,
    shirtPrimary: '#000000',
    shirtSecondary: '#000000',
    textColour: '#FFFFFF',
    playerId: 0,
  };

  private selectedPlayerShirt: PlayerShirtModel = this.defaultShirt;

  private shirtStyles: PlayerShirtStyles[] = [
    {
      styleId: 1,
      styleName: 'Solid',
    },
    {
      styleId: 2,
      styleName: 'Coloured Arms',
    },
    {
      styleId: 3,
      styleName: 'Vertical Stripes',
    },
    {
      styleId: 4,
      styleName: 'Horizontal Stripes',
    },
    {
      styleId: 5,
      styleName: 'Coloured Tips',
    },
  ];

  @Getter('playerShirts', { namespace })
  private playerShirts!: PlayerShirtModel[];

  @Action('getPlayerShirts', { namespace })
  private getPlayerShirts: any;

  @Getter('players', { namespace })
  private players!: Player[];

  @Action('getPlayers', { namespace })
  private getPlayers: any;

  @Action('savePlayerShirt', { namespace })
  private savePlayerShirt!: any;

  private created() {
    if (this.players.length === 0 || this.playerShirts.length === 0) {
        this.refreshPlayers();
    }
  }

  private updatePrimaryColour(value) {
    const self = this;
    self.selectedPlayerShirt.shirtPrimary = value.hex;
  }

  private updateSecondaryColour(value) {
    const self = this;
    self.selectedPlayerShirt.shirtSecondary = value.hex;
  }

  private updateTextColour(value) {
    const self = this;
    self.selectedPlayerShirt.textColour = value.hex;
  }

  private selectPlayerShirt() {
    const self = this;
    if (self.selectedPlayer != null) {
      const shirt = _.find(self.playerShirts, (s: PlayerShirtModel) => {
        return s.playerId === self.selectedPlayer.playerId;
      });
      if (shirt !== undefined) {
        self.selectedPlayerShirt = shirt;
      }
    } else {
      self.selectedPlayerShirt =  self.defaultShirt;
    }
  }

  private savePlayer() {
    this.savePlayerShirt(this.selectedPlayerShirt).finally(() => {
      alert('success');
    });
  }

  private refreshPlayers() {
    this.getPlayers();
    this.getPlayerShirts();
  }

}
</script>
