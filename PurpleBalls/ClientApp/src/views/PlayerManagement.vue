<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-layout column>
        <h1>Players</h1>
        <p>Playaaaaaaaaaaaaaaaaaaaaaa</p>

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

@Component({})
export default class FetchDataView extends Vue {
  private loading: boolean = true;
  private players: Player[] = [];
  private headers = [
    { text: 'First Name', value: 'firstName' },
    { text: 'Last Name', value: 'lastName' },
    { text: 'Email', value: 'email' },
    { text: 'Phone', value: 'phoneNumber' },
  ];

  private created() {
    this.getPlayers();
  }

  private getPlayers() {
    axios
      .get<Player[]>('api/players')
      .then((response) => {
        this.players = response.data;
      })
      .catch((e) => {
          this.players = [];
      })
      .finally(() => (this.loading = false));
  }
}
</script>
