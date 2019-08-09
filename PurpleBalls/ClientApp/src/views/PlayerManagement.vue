<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-layout column>
        
        <v-layout>
            <div>
                <h1>Players</h1>
                <p>Playaaaaaaaaaaaaaaaaaaaaaa</p>
            </div>
            <v-layout align-end justify-end >
                <div class="action-buttons">
                    <v-btn color="secondary" @click="refreshPlayers">
                        <v-icon left dark>refresh</v-icon>
                        Refresh
                    </v-btn>
    
                    <AddPlayer />
                </div>
            </v-layout>
        </v-layout>

        <v-data-table
          :headers="headers"
          :items="players"
          hide-actions
          :loading="loading"
          class="elevation-1"
        >
          <v-progress-linear v-slot:progress color="blue" indeterminate></v-progress-linear>
          <template v-slot:items="props">
            <td><PlayerShirt v-if="!loading" class="player-shirt" :shirt-info="getPlayerShirt(props.item)"/></td>
            <td>{{ props.item.firstName }}</td>
            <td>{{ props.item.lastName }}</td>
            <td>{{ props.item.email }}</td>
            <td>{{ props.item.phoneNumber }}</td>
            <td>
              <DeletePlayer :player-id="props.item.playerId" />
              <v-btn fab dark small color="primary">
                <v-icon>edit</v-icon>
              </v-btn>
            </td>
          </template>
        </v-data-table>

      </v-layout>
    </v-slide-y-transition>    
  </v-container>
</template>

<style>
.player-shirt{
  width: 50px;
}
</style>


<script lang="ts">
import _ from 'lodash';
import { Component, Vue } from 'vue-property-decorator';
import { Player } from '../models/Player';
import { Getter, Action } from 'vuex-class';
import AddPlayer from '@/components/AddPlayer.vue';
import DeletePlayer from '@/components/DeletePlayer.vue';
import PlayerShirt from '@/components/PlayerShirt.vue';
import { PlayerShirtModel } from '../models/PlayerShirtModel';
const namespace: string = 'player';

@Component({
    components: { AddPlayer, DeletePlayer, PlayerShirt },
})
export default class PlayerManagementView extends Vue {
  private headers = [
    { text: 'Shirt' },
    { text: 'First Name', value: 'firstName' },
    { text: 'Last Name', value: 'lastName' },
    { text: 'Email', value: 'email' },
    { text: 'Phone', value: 'phoneNumber' },
    { text: 'Actions', value: 'actions' },
  ];

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

  private loading: boolean = false;

  @Getter('players', { namespace })
  private players!: Player[];

  @Action('getPlayers', { namespace })
  private getPlayers: any;

  @Getter('playerShirts', { namespace })
  private playerShirts!: PlayerShirtModel[];

  @Action('getPlayerShirts', { namespace })
  private getPlayerShirts: any;

  private created() {
    if (this.players.length === 0) {
        this.refreshPlayers();
    }
  }

  private getPlayerShirt(selectedPlayer: Player): PlayerShirtModel {
    const self = this;
    if (selectedPlayer != null) {
      const shirt = _.find(self.playerShirts, (s: PlayerShirtModel) => {
        return s.playerId === selectedPlayer.playerId;
      });
      if (shirt !== undefined) {
        return shirt;
      }
    }

    return this.defaultShirt;
  }

  private refreshPlayers() {
    this.loading = true;
    this.getPlayers().then(() => {
      this.getPlayerShirts().finally(() => {
        this.loading = false;
      });
    });
  }
}
</script>

<style>
    .action-buttons {
        margin-bottom: 0.5rem;
    }
</style>
