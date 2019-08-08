<template>
  <v-dialog v-model="dialog" persistent max-width="290">
    <template v-slot:activator="{ on }">
      <v-btn fab dark small color="red" v-on="on">
        <v-icon>clear</v-icon>
      </v-btn>
    </template>
    <v-card>
      <v-card-title class="headline">Delete Player</v-card-title>
      <v-card-text>Are you sure you wish to delete this player?</v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="green darken-1" flat @click="dialog = false" :disabled="loading">Cancel</v-btn>
        <v-btn
          color="green darken-1"
          flat
          @click="deletePlaya"
          :disabled="loading"
          :loading="loading"
        >Confirm</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { State, Action, Getter } from 'vuex-class';
import { Component, Prop, Vue } from 'vue-property-decorator';
const namespace: string = 'player';

@Component
export default class DeletePlayer extends Vue {
  @Prop({ default: 0 })
  private playerId!: number;

  @Action('deletePlayer', { namespace })
  private deletePlayer: any;

  private loading: boolean = false;
  private dialog: boolean = false;

  private deletePlaya() {
    if (this.playerId === 0) {
      this.dialog = false;
      return;
    }

    this.loading = true;
    this.deletePlayer(this.playerId).finally(() => {
      this.loading = false;
      this.dialog = false;
    });
  }
}
</script>
