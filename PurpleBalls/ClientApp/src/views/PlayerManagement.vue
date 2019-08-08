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
            <td>{{ props.item.firstName }}</td>
            <td>{{ props.item.lastName }}</td>
            <td>{{ props.item.email }}</td>
            <td>{{ props.item.phoneNumber }}</td>
            <td>
              <v-btn fab dark small color="red">
                <v-icon>clear</v-icon>
              </v-btn>
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

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { Player } from '../models/Player';
import axios from 'axios';
import { Getter, Action } from 'vuex-class';
import AddPlayer from '@/components/AddPlayer.vue';
const namespace: string = 'player';

@Component({
    components: { AddPlayer },
})
export default class PlayerManagementView extends Vue {
  private headers = [
    { text: 'First Name', value: 'firstName' },
    { text: 'Last Name', value: 'lastName' },
    { text: 'Email', value: 'email' },
    { text: 'Phone', value: 'phoneNumber' },
    { text: 'Actions', value: 'actions' },
  ];

  private loading: boolean = false;

  @Getter('players', { namespace })
  private players!: Player[];

  @Action('getPlayers', { namespace })
  private getPlayers: any;

  private created() {
    if (this.players.length === 0) {
        this.refreshPlayers();
    }
  }

  private refreshPlayers() {
    this.loading = true;
    this.getPlayers().finally(() => {
      this.loading = false;
    });
  }
}
</script>

<style>
    .action-buttons {
        margin-bottom: 0.5rem;
    }
</style>
