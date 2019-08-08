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
  private playerShirt: PlayerShirtModel = {
    shirtName: 'Causier',
    shirtNumber: 14,
    shirtStyle: 1,
    shirtPrimary: '#000000',
    shirtSecondary: '#555555',
    textColour: '#ffffff',
    playerId: 1,
  };

}
</script>
